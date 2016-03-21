using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace ClientsIdentification
{
    class DBManager
    {
        public static int LAST_ERROR = 0;
        public static string[] AUTH_DATA = new string[2] {"", ""}; 

        public enum ERRORS
        {
            NO_ERROR, CONNECTION_DISABLED , TABLE_ERROR, CONTROL_SUM, SETTING, DB_READ, BARCODE_NOT_FOUND, EVENT_TIME_PASSED, EVENT_TIME_NOT_COME
        }

        private static ArrayList GetTicketList(string actionName, string status)
        {
            ArrayList ticketList = null;

            if (ConnectToDB())
            {
                actionName = actionName.Replace("\"", "\\\"");

                string whereBlock = "WHERE ( `actions`.`name` LIKE  \"" + actionName + "\")";

                if (status.Length > 0)
                {
                    whereBlock += " and (`tickets`.`status` LIKE  \"" + status + "\")";
                }

                ticketList = prepareDataList(SendQuery(SELECTING_COLUMNS, COMMAND_FROM_BLOCK, COMMAND_JOIN_BLOCK,
                    whereBlock));
            }

            return ticketList;
        }

        public static ArrayList GetAllTicketsList(string actionName)
        {
            return GetTicketList(actionName, "");
        }

        public static ArrayList GetConductedList(string actionName)
        {
            return GetTicketList(actionName, "1");
        }

        public static ArrayList GetUnconductedList(string actionName)
        {
            return GetTicketList(actionName, "0");
        }

        public static bool CheckControlSum(string code)
        {
            int third = Convert.ToInt32(code[2].ToString());
            int eight = Convert.ToInt32(code[7].ToString());
            int six = Convert.ToInt32(code[5].ToString());

            if((third + eight) != six)
            {
                LAST_ERROR = (int)ERRORS.CONTROL_SUM;
                return false;
            }

            return true;
        }

        public static ArrayList GetEvents()
        {
            ArrayList events = null;

            if (ConnectToDB())
            {
                ArrayList temp = SendQuery(new string[] { "`name`" }, "`actions`", "", "");

                events = new ArrayList();

                foreach(string[] row in temp)
                {
                    events.Add(row[0]);
                }
            }

            return events;
        }

        public static ArrayList GetTodayEvents()
        {
            ArrayList events = null;

            if (ConnectToDB())
            {
                DateTime date = DateTime.Now;

                string todayDate = date.Year.ToString() + "-" + date.Month.ToString("D2") + "-" + date.Day.ToString("D2");

                ArrayList temp = SendQuery(new string[] { "`name`" }, "`actions`", "", "WHERE `datasa` = \"" + todayDate + "\"");

                events = new ArrayList();

                foreach (string[] row in temp)
                {
                    events.Add(row[0]);
                }
            }

            return events;
        }
        
        private static ArrayList SendQuery(string[] columns, string tableName, string joinBlock, string whereBlock)
        {
            ArrayList list = null;

            string selectBlock = "";

            foreach (string str in columns)
            {
                selectBlock += str + ", ";
            }

            selectBlock = selectBlock.Remove(selectBlock.Length - 2, 1);

            MySqlCommand command = new MySqlCommand("SELECT " + selectBlock + " FROM " + tableName + " " + joinBlock + " " + whereBlock, connection);

            using (MySqlDataReader dr = command.ExecuteReader())
            {
                list = new ArrayList();

                while (dr.Read())
                {
                    string[] col = new string[columns.Length];

                    for(int i = 0; i < columns.Length; i++)
                    {
                        string str = columns[i].Replace("`", "");

                        if(str.IndexOf(".") != -1)
                        {
                            str = str.Remove(0, str.IndexOf(".") + 1);
                        }

                        col[i] = dr[str].ToString();
                    }

                    list.Add(col);
                }
            }

            connection.Close();

            if(list==null)
            {
                LAST_ERROR = (int) ERRORS.DB_READ;
            }

            return list;
        }

        private static bool ConnectToDB()
        {
            try
            {               
                connection = new MySqlConnection(connectionString);
                connection.Open();

                LAST_ERROR = (int)ERRORS.NO_ERROR;
                return true;
            }
            catch(Exception e)
            {
                LAST_ERROR = (int)ERRORS.CONNECTION_DISABLED;
                return false;
            }            
        }

/*
SELECT  `orders`.`data_barcodes` ,  `orders`.`id` ,  `users`.`fio` ,  `users`.`tel` ,  `orders`.`data_param` ,  `actions`.`name` 
FROM  `orders` 
JOIN  `users` ON  `orders`.`userid` =  `users`.`id` 
JOIN  `zakaz` ON  `orders`.`zakazs` =  `zakaz`.`id` 
JOIN  `actions` ON  `zakaz`.`idmer` =  `actions`.`id` 
WHERE  `data_barcodes` LIKE  "%0022091700-20621%"
*/

        private static ArrayList prepareDataList(ArrayList requestedList, string code = "", bool conductMode = false)
        {
            ArrayList temp = null;
            int columnsCount = 0;

            if(requestedList != null && requestedList.Count > 0)
            {
                columnsCount = ((string[])requestedList[0]).Length;

                temp = new ArrayList();

                for (int i = 0; i < requestedList.Count; i++)
                {
                    string[] requestedRow = (string[])requestedList[i];
                    string[,] seats = ParseSeat(requestedRow[4]);

                    if(seats == null)
                    {
                        seats = new string[,] { {"", "", ""} };
                    }

                    string[] barcodes = ParseBarcode(requestedRow[0], seats.GetLength(0));
                    
                    string date = "";

                    if (conductMode)
                    {
                        date = requestedRow[8].Replace(" 0:00:00", "") + " " + requestedRow[9];
                    }

                    if (code.Equals(""))
                    {
                        for (int k = 0; k < seats.GetLength(0) && i + k < requestedList.Count; k++)
                        {
                            temp.Add(CreateRow((string[])requestedList[i + k], seats[k, 1], seats[k, 2], seats[k, 0], barcodes[k], date));                                
                        }                            
                    }
                    else
                    {
                        int index = TicketIndex(code, requestedRow[0]);

                        if(index >= 0)
                        {
                            temp.Add(CreateRow((string[])requestedList[i + index], seats[index, 1], seats[index, 2], seats[index, 0], barcodes[index], date));
                        }
                    }

                    i += seats.GetLength(0) - 1;
                                                      
                }                                
            }

            return temp;
        }

        private static DateTime ParseEventDateTime(string date, string time)
        {
            try
            {
                int year = Convert.ToInt32(date.Substring(6, 4));
                int month = Convert.ToInt32(date.Substring(3, 2));
                int day = Convert.ToInt32(date.Substring(0, 2));

                int hours = Convert.ToInt32(time.Substring(0, 2));
                int minutes = Convert.ToInt32(time.Substring(3, 2));
                int seconds = Convert.ToInt32(time.Substring(6, 2));

                if(hours == 23)
                {
                    day++;
                }
                else
                {
                    hours++;
                }

                DateTime dateTime = new DateTime(year, month, day, hours, minutes, seconds);

                return dateTime;
            }
            catch(Exception e)
            {
                LAST_ERROR = (int)ERRORS.TABLE_ERROR;

                return new DateTime();
            }            
        }

        private static string[] ParseBarcode(string text, int ticketsNumber)
        {
            string[] barcodes = new string[ticketsNumber];

            for(int i = 0; i < barcodes.Length; i++)
            {
                barcodes[i] = "";
            }

            try
            {
                if (text.Length > 0)
                {
                    int start = text.IndexOf(":");
                    int end = text.IndexOf(":", start + 1);

                    /*int ticketsNumber = 0;

                    if (end > start)
                    {
                        ticketsNumber = Convert.ToInt32(text.Substring(start + 1, end - start - 1));
                    }*/

                    if (ticketsNumber > 0)
                    {
                        for (int i = 0; i < ticketsNumber; i++)
                        {
                            start = text.IndexOf(";");
                            text = text.Remove(0, start + 1);

                            start = text.IndexOf("\"");

                            text = text.Remove(0, start + 1);

                            end = text.IndexOf("\"");

                            barcodes[i] = text.Substring(0, end);

                            text = text.Remove(0, end + 2);                         
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return barcodes;
        }

        private static string[] CreateRow(string[] requestedRow, string row, string seat, string location, string barcode, string date = "")
        {
            if(requestedRow.Length >= 8)
            {
                seatCode = requestedRow[7];
                
                Console.WriteLine(seatCode);
            }
            
            string status = requestedRow[6].Equals("1") ? "+" : "-";
            
            if(date.Length > 0)
            {
               return new string[9] { barcode, requestedRow[5], requestedRow[2], requestedRow[3], location, row, seat, status, date};
            }

            return new string[] { barcode, requestedRow[5], requestedRow[2], requestedRow[3], location, row, seat, status};
        }

        private static int TicketIndex(string code, string data_barcodes)
        {
            if (data_barcodes.Length > 0)
            {
                int start = data_barcodes.IndexOf(":");
                int end = data_barcodes.IndexOf(":", start + 1);

                int ticketsNumber = 0;

                if (end > start)
                {
                    ticketsNumber = Convert.ToInt32(data_barcodes.Substring(start + 1, end - start - 1));
                }

                if (ticketsNumber > 0)
                {
                    for(int i = 0; i < ticketsNumber; i++)
                    {
                        start = data_barcodes.IndexOf(";");
                        data_barcodes = data_barcodes.Remove(0, start + 1);

                        start = data_barcodes.IndexOf(":\"");
                        end = data_barcodes.IndexOf("\";");

                        string foundCode = data_barcodes.Substring(start + 2, end - start - 2);

                        data_barcodes = data_barcodes.Remove(0, end + 2);

                        if (foundCode.Contains(code)) return i;
                    }
                }
            }

            return -1;
        }

        private static string[,] ParseSeat(string text)
        {
            try {
                if (text.Length > 0)
                {
                    int start = text.IndexOf(":");
                    int end = text.IndexOf(":", start + 1);

                    int ticketsNumber = 0;

                    if (end > start)
                    {
                        ticketsNumber = Convert.ToInt32(text.Substring(start + 1, end - start - 1));
                    }

                    if(ticketsNumber > 0)
                    {
                        string[,] ticketSeats = new string[ticketsNumber,3];

                        for(int i = 0; i < ticketsNumber; i++)
                        {
                            start = text.IndexOf(";");
                            text = text.Remove(0, start + 1);

                            start = text.IndexOf("\"");
                            
                            text = text.Remove(0, start + 1);

                            end = text.IndexOf(":");

                            if(end > 2)
                            {
                                ticketSeats[i, 0] = text.Substring(0, 1);

                                if(ticketSeats[i, 0].Equals("1"))
                                {
                                    ticketSeats[i, 0] = "Партер";
                                }
                                else if (ticketSeats[i, 0].Equals("2"))
                                {
                                    ticketSeats[i, 0] = "Амфитеатр";
                                }
                                else if (ticketSeats[i, 0].Equals("3"))
                                {
                                    ticketSeats[i, 0] = "Балкон";
                                }

                                text = text.Remove(0, 1);
                            }
                            else
                            {
                                ticketSeats[i, 0] = "";
                            }

                            ticketSeats[i, 1] = text.Substring(0, end);

                            start = end;
                            end = text.IndexOf("\";");

                            ticketSeats[i, 2] = text.Substring(start + 1, end - start - 1);

                            text = text.Remove(0, end + 2);
                        }

                        for(int i = 0; i < ticketSeats.GetLength(0); i++)
                        {
                            for (int k = 0; k < ticketSeats.GetLength(1); k++)
                            {
                                ticketSeats[i, k] = ticketSeats[i, k].Replace(":", "");
                            }
                        }

                        return ticketSeats;
                    }
                }
            } catch (Exception e)
            {

            }
            
            return null;
        }

        public static ArrayList ReturnTicket(string code)
        {
            ArrayList ticketList = null;
            
            if (ConnectToDB())
            {
                ArrayList temp = SendQuery(SELECTING_COLUMNS_WITH_SEAT, COMMAND_FROM_BLOCK, COMMAND_JOIN_BLOCK,
                    "WHERE  `data_barcodes` LIKE  \"%" + code + "%\"");

                ticketList = prepareDataList(temp, code, true);

                if (ticketList == null || ticketList.Count == 0)
                {
                    LAST_ERROR = (int)ERRORS.BARCODE_NOT_FOUND;
                }
                else
                {
                    if (ConnectToDB())
                    {
                        string Query = COMMAND_UPDATE_0 + seatCode + "\"";
                        MySqlCommand command = new MySqlCommand(Query, connection);
                        command.ExecuteReader();
                        connection.Close();

                        ((string[])ticketList[0])[7] = "+";
                    }
                }
            }

            return ticketList;
        }

        public static ArrayList ConductTicket(string code)
        {
            ArrayList ticketList = null;

            if (ConnectToDB())
            {
                ArrayList temp = SendQuery(SELECTING_COLUMNS_WITH_SEAT, COMMAND_FROM_BLOCK, COMMAND_JOIN_BLOCK,
                    "WHERE  `data_barcodes` LIKE  \"%" + code + "%\"");

                ticketList = prepareDataList(temp, code, true);

                if (ticketList == null || ticketList.Count == 0)
                {
                    LAST_ERROR = (int)ERRORS.BARCODE_NOT_FOUND;
                } else
                {
                    DateTime ticketDate = ParseEventDateTime(((string[])temp[0])[8], ((string[])temp[0])[9]);

                    DateTime now = DateTime.Now;

                    if(ticketDate.Hour == 1 && ticketDate.Minute == 0 && ticketDate.Second == 0)
                    {
                        now = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    }

                    int comparing = DateTime.Compare(ticketDate, now);

                    if (comparing > 0)
                    {
                        if(DateTime.Compare(new DateTime(ticketDate.Year, ticketDate.Month, ticketDate.Day, 0, 0, 0), 
                                            new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)) == 0)
                        {
                            if (((string[])ticketList[0])[7].Equals("+"))
                            {
                                ((string[])ticketList[0])[7] = "-";//"По даному билету прошел(а): " + ((string[])ticketList[0])[1] + ", " + ((string[])ticketList[0])[2];
                            }
                            else
                            {
                                if (ConnectToDB())
                                {
                                    string Query = COMMAND_UPDATE_1 + seatCode + "\"";
                                    MySqlCommand command = new MySqlCommand(Query, connection);
                                    command.ExecuteReader();
                                    connection.Close();

                                    ((string[])ticketList[0])[7] = "+";
                                }
                            }
                        }
                        else
                        {
                            LAST_ERROR = (int)ERRORS.EVENT_TIME_NOT_COME;

                            ticketList = null;
                        }
                    }
                    else
                    {
                        LAST_ERROR = (int)ERRORS.EVENT_TIME_PASSED;

                        ticketList = null;
                    }                    
                }                                
            }

            return ticketList;
        }

        public static int GetConductedAmount(string actionName)
        {
            ArrayList list = GetConductedList(actionName);

            return list == null ? 0 : list.Count;
        }

        public static int GetUnConductedAmount(string actionName)
        {
            ArrayList list = GetUnconductedList(actionName);

            return list == null ? 0 : list.Count;
        }
        public static int GetFreeAmount(string actionName)
        {
            return 0;
        }

        private static bool ReadAuthData()
        {
            string serverName = "";
            string userName = "";
            string password = "";
            string databaseName = "nekrasof_ticket";

            try
            {
                string text = Cryptor.Decrypt(File.ReadAllText(@"ClientsIdentification.stg"), true);

                int indexStart = text.IndexOf(":");
                int indexFinish = text.IndexOf(";");

                serverName = text.Substring(indexStart + 1, indexFinish - indexStart - 1);
                text = text.Remove(0, indexFinish + 1);

                indexStart = text.IndexOf(":");
                indexFinish = text.IndexOf(";");

                userName = text.Substring(indexStart + 1, indexFinish - indexStart - 1);
                text = text.Remove(0, indexFinish + 1);

                indexStart = text.IndexOf(":");
                indexFinish = text.IndexOf(";");

                password = text.Substring(indexStart + 1, indexFinish - indexStart - 1);

                if (userName.Equals("") || password.Equals("") || serverName.Equals(""))
                {
                    LAST_ERROR = (int)ERRORS.SETTING;

                    return false;
                }

                indexStart = serverName.IndexOf("://");
                indexFinish = serverName.IndexOf("/", 9);

                if (indexStart >= 0 && indexFinish >= 0 && indexFinish != indexStart)
                {
                    serverName = serverName.Substring(indexStart + 3, indexFinish - indexStart - 3);
                }

                AUTH_DATA[0] = serverName;
                AUTH_DATA[1] = userName;

                MySqlConnectionStringBuilder mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = serverName;
                mysqlCSB.Database = databaseName;
                mysqlCSB.UserID = userName;
                mysqlCSB.Password = password;
                mysqlCSB.ConnectionProtocol = MySqlConnectionProtocol.UnixSocket;

                connectionString = mysqlCSB.ConnectionString;

            }
            catch(Exception e) 
            {
                LAST_ERROR = (int)ERRORS.SETTING;

                return false;
            }

            return true;
        }

        public static bool ReloadUsersAuthData()
        {
            return ReadAuthData();
        }

        private static MySqlConnection connection;

        private static string[] SELECTING_COLUMNS = new string[] { "`orders`.`data_barcodes`", "`orders`.`id`", "`users`.`fio`", "`users`.`tel`", "`orders`.`data_param`", "`actions`.`name`", "`tickets`.`status`"};
        private static string[] SELECTING_COLUMNS_WITH_SEAT = new string[] { "`orders`.`data_barcodes`", "`orders`.`id`", "`users`.`fio`", "`users`.`tel`", "`orders`.`data_param`", "`actions`.`name`", "`tickets`.`status`", "`tickets`.`mesto`", "`actions`.`datasa`", "`actions`.`vrem`"};
        private static string COMMAND_JOIN_BLOCK = "JOIN  `users` ON  `orders`.`userid` = `users`.`id` JOIN `zakaz` ON `orders`.`zakazs` = `zakaz`.`id` JOIN `actions` ON  `zakaz`.`idmer` =  `actions`.`id` JOIN  `tickets` ON  `zakaz`.`id` =  `tickets`.`zakazid`";
        private static string COMMAND_UPDATE_0 = "UPDATE `nekrasof_ticket`.`tickets` SET `status`='0' WHERE `mesto` LIKE \"";
        private static string COMMAND_UPDATE_1 = "UPDATE `nekrasof_ticket`.`tickets` SET `status`='1' WHERE `mesto` LIKE \"";
        private static string COMMAND_FROM_BLOCK = "`orders`";

        private static string seatCode = "";
        private static string connectionString = "";

    }
}

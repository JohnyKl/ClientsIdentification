using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace ClientsIdentification
{    
    public partial class Form1 : Form
    {
        public enum FILTER
        {
            ALL_TICKET, CONDUCTED, UNCONDUCTED, RETURNING
        };

        public void SetFocusOnCodeTextBox()
        {
            tbTicketCode.Focus();
        }

        public Form1()
        {
            InitializeComponent();

            cmbSearchFilter.SelectedIndex = 0;

            DBManager.ReloadUsersAuthData();

            LoadEventsList();

            SetColumnsWidth();

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            toolStripMenuItemReload.PerformClick();

            toolTipSearch.SetToolTip(tbSearchValue, "Гарячая клавиша для поиска - F");

            ticketInfo = null;
            /*pnlTable.Visible = false;
            pnlTicketCode.Visible = false;*/
        }

        private void SetColumnsWidth()
        {
            dataGridView1.Columns[(int)ColumnsIndexes.ROW].Width = 75;
            dataGridView1.Columns[(int)ColumnsIndexes.SEAT].Width = 75;
            dataGridView1.Columns[(int)ColumnsIndexes.STATUS].Width = 75;
        }

        private void LoadEventsList()
        {
            if (CONNECTION_ERRORS_COUNTER < 3)
            {
                cmbEvent.Items.Clear();

                ArrayList cmbItems = null;
                
                if(toolStripMenuItemAllEvents.Checked) 
                    cmbItems = DBManager.GetEvents();
                else if(toolStripMenuItemTodayEvents.Checked)
                    cmbItems = DBManager.GetTodayEvents();

                if (cmbItems != null)
                {
                    cmbEvent.Items.AddRange(cmbItems.ToArray());

                    if(cmbEvent.Items.Count > 0)
                    {
                        cmbEvent.SelectedIndex = 0;

                        ReloadActionInfo();
                    }    
                    else
                    {
                        MessageBoxEx.Show(this, "Сегодня нету мероприятий.", MESSAGE_TITLE_DATABASE_ERROR);
                    }                
                }
                else
                {
                    ShowErrorMessage();
                }
            }
            else
            {
                CONNECTION_ERRORS_COUNTER = 0;
            }            
        }

        private void ShowMainPage()
        {
            pnlTable.Visible = false;
            pnlTicketCode.Visible = false;
            pnlEvent.Visible = true;
            cmbEvent.Focus();

            lblSearch.Enabled = false;
            btnSearch.Enabled = false;
            cmbSearchFilter.Enabled = false;
            tbSearchValue.Enabled = false;
        }

        public void ShowTicketPage()
        {
            bool result = true;

            if (toolStripMenuItemTicketsAll.Checked)
            {
                result = FillTable(DBManager.GetAllTicketsList((string)cmbEvent.SelectedItem));
            }
            else if (toolStripMenuItemTicketsConducted.Checked)
            {
                result = FillTable(DBManager.GetConductedList((string)cmbEvent.SelectedItem));
            }
            else if (toolStripMenuItemUnConducted.Checked)
            {
                result = FillTable(DBManager.GetUnconductedList((string)cmbEvent.SelectedItem));
            }
            
            if (!result)
            {
                ShowErrorMessage();
            }
            else
            {
                pnlTable.Visible = true;
                pnlTicketCode.Visible = true;
                //pnlEvent.Visible = false;
                tbTicketCode.Focus();

                lblSearch.Enabled = true;
                btnSearch.Enabled = true;
                cmbSearchFilter.Enabled = true;
                tbSearchValue.Enabled = true;
                //ReloadActionInfo();
            }            
        }

        private void ShowSettingsWindow()
        {
            Settings stg = new Settings();

            stg.ShowDialog();

            LoadEventsList();
            //MessageBoxEx.Show(this, "form shown");
        }

        private void ShowErrorMessage()
        {  switch (DBManager.LAST_ERROR)
            {
                case (int)DBManager.ERRORS.CONNECTION_DISABLED:
                    CONNECTION_ERRORS_COUNTER++;

                    MessageBoxEx.Show(this, "Ошибка при попытке подключиться к базе данных. \n Проверьте соединение.", MESSAGE_TITLE_DATABASE_ERROR);

                    ShowSettingsWindow();                      
                  
                    break;
                case (int)DBManager.ERRORS.TABLE_ERROR:
                    MessageBoxEx.Show(this, "Ошибка при заполнении таблицы. Возможно, неправильные данные.", MESSAGE_TITLE_PROGRAM_ERROR);
                    break;
                case (int)DBManager.ERRORS.CONTROL_SUM:
                    MessageBoxEx.Show(this, "Ошибка при идентификации билета.", MESSAGE_TITLE_IDENTIFICATION_ERROR);
                    break;
                case (int)DBManager.ERRORS.SETTING:
                    MessageBoxEx.Show(this, "Ошибка настроек программы. Пожалуста, заполните необходимые данные еще раз.", MESSAGE_TITLE_PROGRAM_ERROR);

                    ShowSettingsWindow();
                    break;
                case (int)DBManager.ERRORS.BARCODE_NOT_FOUND:
                    MessageBoxEx.Show(this, "Билет не найден в базе даных.", MESSAGE_TITLE_IDENTIFICATION_ERROR);
                    break;
                case (int)DBManager.ERRORS.EVENT_TIME_PASSED:
                    MessageBoxEx.Show(this, "Мероприятие уже состоялось!", MESSAGE_TITLE_IDENTIFICATION_ERROR);
                    break;
                case (int)DBManager.ERRORS.EVENT_TIME_NOT_COME:
                    MessageBoxEx.Show(this, "Мероприятие запланировано на другой день!", MESSAGE_TITLE_IDENTIFICATION_ERROR);
                    break;
                case (int)DBManager.ERRORS.NO_ERROR:
                    break;
            }
        }

        private void toolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            (new Settings()).Show();
        }

        private void toolStripMenuItemTicketsAll_Click(object sender, EventArgs e)
        {
            ShowTicketPage();

            toolStripMenuItemUnConducted.Checked = false;
            toolStripMenuItemTicketsConducted.Checked = false;
            toolStripMenuItemTicketsAll.Checked = true;
        }

        private void toolStripMenuItemTicketsConducted_Click(object sender, EventArgs e)
        {
            ShowTicketPage();

            toolStripMenuItemUnConducted.Checked = false;
            toolStripMenuItemTicketsConducted.Checked = true;
            toolStripMenuItemTicketsAll.Checked = false;
        }

        private void toolStripMenuItemUnConducted_Click(object sender, EventArgs e)
        {
            ShowTicketPage();

            toolStripMenuItemUnConducted.Checked = true;
            toolStripMenuItemTicketsConducted.Checked = false;
            toolStripMenuItemTicketsAll.Checked = false;
        }

        private void toolStripMenuItemMain_Click(object sender, EventArgs e)
        {
            ShowMainPage();
        }

        private void tbTicketCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbTicketCode_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbTicketCode.Text, "  ^ [0-9]"))
            {
                tbTicketCode.Text = "";
            }
        }

        private void tbTicketCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbTicketCode.Text.Length == 0)
                {
                    CloseTicketInfo();
                }

                if (tbTicketCode.Text.Length == 15)
                {
                    btnTicketCodeCheck.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;

                int index = dataGridView1.CurrentCell.RowIndex;

                if (index > 0)
                {
                    for (int i = index - 1; i > 0; i--)
                    {
                        if (dataGridView1.Rows[i].Visible)
                        {
                            dataGridView1.Rows[i].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                            break;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;

                int index = dataGridView1.CurrentCell.RowIndex;

                if (index < dataGridView1.Rows.Count - 1)
                {
                    for (int i = index + 1; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Visible)
                        {
                            dataGridView1.Rows[i].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                            break;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.F)
            {  
                if(tbSearchValue.Enabled && !tbSearchValue.Focused)
                {
                    e.Handled = true;

                    tbSearchValue.Focus();
                }
            }
        }

        private void btnTicketCodeCheck_Click(object sender, EventArgs e)
        {
            if (tbTicketCode.Text.Length >= 10)
            {
                if (DBManager.CheckControlSum(tbTicketCode.Text.Trim()))
                {
                    ShowTicketInfo();
                }

                ShowErrorMessage();

                tbTicketCode.Text = "";
            }
            else
            {
                MessageBoxEx.Show(this, "Введенный штрих-код состоит меньше чем из 15 символов.", MESSAGE_TITLE_IDENTIFICATION_ERROR );
            }

            toolStripMenuItemReload.PerformClick();
        }
        
        private void ShowTicketInfo()
        {            
            ArrayList infoList;

            if (chbReturningTicket.Checked)
            {
                infoList = DBManager.ReturnTicket(tbTicketCode.Text.Trim().Substring(0, 10));
                
                if( infoList != null)
                {
                    CloseTicketInfo();

                    ticketInfo = new TicketInfo(this, infoList, true);
                }                
            }
            else
            {
                infoList = DBManager.ConductTicket(tbTicketCode.Text.Trim().Substring(0, 10));

                if (infoList != null)
                {
                    CloseTicketInfo();

                    ticketInfo = new TicketInfo(this, infoList);
                }
            }

            ShowErrorMessage();

            ShowTicketPage();

            if(ticketInfo != null) ticketInfo.Show();            
        }

        private void cmbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTicketPage();

            pnlTable.Visible = true;
            pnlTicketCode.Visible = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            tbTicketCode.Focus();
            tbTicketCode.Select(tbTicketCode.Text.Length, 0);
        }

        public bool FillTable(ArrayList data)
        {
            dataGridView1.Rows.Clear();

            int i = 0;

            if (data != null)
            {
                foreach (string[] rowData in data)
                {
                    dataGridView1.Rows.Add(rowData);

                    Color color = Color.White;
                    Color selectionColor = Color.Silver;

                    if (rowData[(int)ColumnsIndexes.STATUS].Equals("+") )
                    {
                        color = Color.FromName("palegreen");
                        selectionColor = Color.FromName("darkseagreen");
                    }
                    else if (rowData[(int)ColumnsIndexes.STATUS].StartsWith("-"))
                    {
                        color = Color.FromName("lightcoral");
                        selectionColor = Color.FromName("rosybrown");
                    }

                    dataGridView1.Rows[i].Cells[(int)ColumnsIndexes.STATUS].Style.SelectionBackColor = selectionColor;
                    dataGridView1.Rows[i].Cells[(int)ColumnsIndexes.STATUS].Style.BackColor = color;

                    i++;
                }

                return true;
            }
            else ShowErrorMessage();

            return false;
        }


        private void cmbEvent_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void toolStripMenuItemAllEvents_Click(object sender, EventArgs e)
        {
            toolStripMenuItemAllEvents.Checked = true;
            toolStripMenuItemTodayEvents.Checked = false;

            LoadEventsList();
        }

        private void toolStripMenuItemTodayEvents_Click(object sender, EventArgs e)
        {
            toolStripMenuItemAllEvents.Checked = false;
            toolStripMenuItemTodayEvents.Checked = true;

            LoadEventsList();
        }

        private void toolStripMenuItemReload_Click(object sender, EventArgs e)
        {
            ReloadActionInfo();       
        }
                
        private void ReloadActionInfo()
        {
            if (cmbEvent.SelectedIndex > -1)
            {
                lblGoIn.Text = LABEL_GO_IN_TEXT + DBManager.GetConductedAmount((string)cmbEvent.SelectedItem).ToString();
                lblLeft.Text = LABEL_LEFT_TEXT + DBManager.GetUnConductedAmount((string)cmbEvent.SelectedItem).ToString();
                lblFree.Text = LABEL_FREE_TEXT + DBManager.GetFreeAmount((string)cmbEvent.SelectedItem).ToString();

                ShowTicketPage();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chbReturningTicket.Checked)
            {
                chbReturningTicket.BackColor = Color.FromName("goldenrod");
            }
            else
            {
                chbReturningTicket.BackColor = Color.LightGray;
            }
        }

        public void CloseTicketInfo()
        {
            if(ticketInfo != null)
            {
                ticketInfo.Close();
                ticketInfo = null;
            }            
        }

        private TicketInfo ticketInfo;

        private enum ColumnsIndexes { BAR_CODE, EVENT_NAME, USER_NAME, USER_PHONE, LOCATION, ROW, SEAT, STATUS };

        private const string RETURN_BTN_LBL = "Возврат";
        private const string CONDUCT_BTN_LBL = "Идентифицировать";

        private const string MESSAGE_TITLE_PROGRAM_ERROR = "Ошибка программы";
        private const string MESSAGE_TITLE_DATABASE_ERROR = "Ошибка подключения";
        private const string MESSAGE_TITLE_IDENTIFICATION_ERROR = "Ошибка идентификации";

        private static int CONNECTION_ERRORS_COUNTER = 0;

        private static string LABEL_GO_IN_TEXT = "Зашло: ";
        private static string LABEL_LEFT_TEXT = "Осталось: ";
        private static string LABEL_FREE_TEXT = "Свободно: ";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearchValue.Text.Trim().Length == 0)
            {
                ClearTableFilter();
            }
            else
            {
                FilterTable();
            }
        }

        private void tbSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(tbSearchValue.Text.Trim().Length == 0)
                {
                    ClearTableFilter();
                }
                else
                {
                    FilterTable();
                }

                tbTicketCode.Focus();                
            }            
        }

        private void FilterTable()
        {
            int columnIndex = (int)ColumnsIndexes.USER_NAME; //filtering by Name

            switch (cmbSearchFilter.SelectedIndex)
            {
                case 1: columnIndex = (int)ColumnsIndexes.USER_PHONE; break;//filtering by phone number
                case 2: columnIndex = (int)ColumnsIndexes.BAR_CODE; break;//filtering by barcode
            }

            dataGridView1.CurrentCell = null;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {          
                dataGridView1.Rows[i].Visible = false;

                if (dataGridView1[columnIndex, i].Value.ToString().Contains(tbSearchValue.Text.Trim()))
                {
                    dataGridView1.Rows[i].Visible = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                    Console.WriteLine("current row index - {0}", i);                    
                }
            }            
        }

        private void ClearTableFilter()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Visible = true;
            }
        }
    }
}

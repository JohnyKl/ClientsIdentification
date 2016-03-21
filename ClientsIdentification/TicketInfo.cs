using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace ClientsIdentification
{
    public partial class TicketInfo : Form
    {
        private Form1 mainForm;

        public TicketInfo(Form1 mainForm, ArrayList values, bool returningMode = false)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            SetValues(values);

            this.returningMode = returningMode;

            mainForm.SetFocusOnCodeTextBox();

            TopMost = true;
        }

        private void SetValues(ArrayList values)
        {
            if(values != null)
            {
                string[] text = (string[]) values[0];

                tbTicketCode.Text = text[0];
                tbEventName.Text = text[1];
                tbUserName.Text = text[2];
                tbPhone.Text = text[3];
                tbLocation.Text = text[4];
                tbRow.Text = text[5];
                tbSeat.Text = text[6];
                tbStatus.Text = text[7];
                tdData.Text = text[8];

                if (tbStatus.Text.Equals("+"))
                {
                    tbStatus.BackColor = Color.FromName("palegreen");
                }
                else if (tbStatus.Text.Equals("-"))
                {
                    tbStatus.BackColor = Color.FromName("lightcoral");
                }
            }
            else
            {
                mainForm.CloseTicketInfo();
            }            
        }

        private void btnTicketCodeCheck_Click(object sender, EventArgs e)
        {
            /*if (tbHidden.Text.Length >= 10)
            {
                if (DBManager.CheckControlSum(tbHidden.Text.Trim()))
                {
                    if (returningMode)
                    {
                        SetValues(DBManager.ReturnTicket(tbHidden.Text.Trim().Substring(0, 10)));
                    }
                    else
                    {
                        SetValues(DBManager.ConductTicket(tbHidden.Text.Trim().Substring(0, 10)));
                    }

                    mainForm.ShowTicketPage();
                }                
                tbHidden.Text = "";

                mainForm.SetFocusOnCodeTextBox();
            }
            else if (tbHidden.Text.Length > 0)
            {
                MessageBoxEx.Show(this, "Введенный штрих-код состоит меньше чем из 15 символов.", "Ошибка идентификации");

                Close();
            }
            else
            {*/
                mainForm.CloseTicketInfo();
            //}
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbHidden.Text, "  ^ [0-9]"))
            {
                tbHidden.Text = "";
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTicketCodeCheck.PerformClick();
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool returningMode;

        private void tbTicketCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

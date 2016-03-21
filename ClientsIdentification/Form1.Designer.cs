namespace ClientsIdentification
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAllEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTodayEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTickets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTicketsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTicketsConducted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUnConducted = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReload = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTicketCodeCheck = new System.Windows.Forms.Button();
            this.tbTicketCode = new System.Windows.Forms.TextBox();
            this.lblTicketCode = new System.Windows.Forms.Label();
            this.pnlTicketCode = new System.Windows.Forms.Panel();
            this.chbReturningTicket = new System.Windows.Forms.CheckBox();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearchValue = new System.Windows.Forms.TextBox();
            this.cmbSearchFilter = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFree = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblGoIn = new System.Windows.Forms.Label();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.toolTipSearch = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTicketCode.SuspendLayout();
            this.pnlEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMain,
            this.toolStripMenuItemTickets,
            this.toolStripMenuItemSettings,
            this.toolStripMenuItemReload});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemMain
            // 
            this.toolStripMenuItemMain.BackColor = System.Drawing.Color.LightGray;
            this.toolStripMenuItemMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAllEvents,
            this.toolStripMenuItemTodayEvents});
            this.toolStripMenuItemMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItemMain.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripMenuItemMain.Name = "toolStripMenuItemMain";
            this.toolStripMenuItemMain.Size = new System.Drawing.Size(74, 20);
            this.toolStripMenuItemMain.Text = "Главная";
            this.toolStripMenuItemMain.Click += new System.EventHandler(this.toolStripMenuItemMain_Click);
            // 
            // toolStripMenuItemAllEvents
            // 
            this.toolStripMenuItemAllEvents.CheckOnClick = true;
            this.toolStripMenuItemAllEvents.Name = "toolStripMenuItemAllEvents";
            this.toolStripMenuItemAllEvents.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemAllEvents.Text = "Все мероприятия";
            this.toolStripMenuItemAllEvents.Click += new System.EventHandler(this.toolStripMenuItemAllEvents_Click);
            // 
            // toolStripMenuItemTodayEvents
            // 
            this.toolStripMenuItemTodayEvents.Checked = true;
            this.toolStripMenuItemTodayEvents.CheckOnClick = true;
            this.toolStripMenuItemTodayEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTodayEvents.Name = "toolStripMenuItemTodayEvents";
            this.toolStripMenuItemTodayEvents.Size = new System.Drawing.Size(189, 22);
            this.toolStripMenuItemTodayEvents.Text = "На сегодня";
            this.toolStripMenuItemTodayEvents.Click += new System.EventHandler(this.toolStripMenuItemTodayEvents_Click);
            // 
            // toolStripMenuItemTickets
            // 
            this.toolStripMenuItemTickets.BackColor = System.Drawing.Color.LightGray;
            this.toolStripMenuItemTickets.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTicketsAll,
            this.toolStripMenuItemTicketsConducted,
            this.toolStripMenuItemUnConducted});
            this.toolStripMenuItemTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItemTickets.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripMenuItemTickets.Name = "toolStripMenuItemTickets";
            this.toolStripMenuItemTickets.Size = new System.Drawing.Size(69, 20);
            this.toolStripMenuItemTickets.Text = "Билеты";
            // 
            // toolStripMenuItemTicketsAll
            // 
            this.toolStripMenuItemTicketsAll.Checked = true;
            this.toolStripMenuItemTicketsAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTicketsAll.Name = "toolStripMenuItemTicketsAll";
            this.toolStripMenuItemTicketsAll.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemTicketsAll.Text = "Все";
            this.toolStripMenuItemTicketsAll.Click += new System.EventHandler(this.toolStripMenuItemTicketsAll_Click);
            // 
            // toolStripMenuItemTicketsConducted
            // 
            this.toolStripMenuItemTicketsConducted.Name = "toolStripMenuItemTicketsConducted";
            this.toolStripMenuItemTicketsConducted.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemTicketsConducted.Text = "Проведенные";
            this.toolStripMenuItemTicketsConducted.Click += new System.EventHandler(this.toolStripMenuItemTicketsConducted_Click);
            // 
            // toolStripMenuItemUnConducted
            // 
            this.toolStripMenuItemUnConducted.Name = "toolStripMenuItemUnConducted";
            this.toolStripMenuItemUnConducted.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItemUnConducted.Text = "Не проведенные";
            this.toolStripMenuItemUnConducted.Click += new System.EventHandler(this.toolStripMenuItemUnConducted_Click);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(91, 22);
            this.toolStripMenuItemSettings.Text = "Настройки";
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.toolStripMenuItemSettings_Click);
            // 
            // toolStripMenuItemReload
            // 
            this.toolStripMenuItemReload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.toolStripMenuItemReload.Name = "toolStripMenuItemReload";
            this.toolStripMenuItemReload.Size = new System.Drawing.Size(84, 22);
            this.toolStripMenuItemReload.Text = "Обновить";
            this.toolStripMenuItemReload.Click += new System.EventHandler(this.toolStripMenuItemReload_Click);
            // 
            // pnlTable
            // 
            this.pnlTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlTable.Controls.Add(this.dataGridView1);
            this.pnlTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pnlTable.Location = new System.Drawing.Point(0, 117);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlTable.Size = new System.Drawing.Size(987, 241);
            this.pnlTable.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col7,
            this.col1,
            this.col2,
            this.col3,
            this.col8,
            this.col4,
            this.col5,
            this.col6});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(987, 241);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // col7
            // 
            this.col7.HeaderText = "Штрих-код";
            this.col7.Name = "col7";
            this.col7.ReadOnly = true;
            // 
            // col1
            // 
            this.col1.HeaderText = "Название мероприятия";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            // 
            // col2
            // 
            this.col2.HeaderText = "ФИО";
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            // 
            // col3
            // 
            this.col3.HeaderText = "Телефон";
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            // 
            // col8
            // 
            this.col8.HeaderText = "Расположение";
            this.col8.Name = "col8";
            this.col8.ReadOnly = true;
            // 
            // col4
            // 
            this.col4.HeaderText = "Ряд";
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            // 
            // col5
            // 
            this.col5.HeaderText = "Место";
            this.col5.Name = "col5";
            this.col5.ReadOnly = true;
            // 
            // col6
            // 
            this.col6.HeaderText = "Статус";
            this.col6.Name = "col6";
            this.col6.ReadOnly = true;
            // 
            // btnTicketCodeCheck
            // 
            this.btnTicketCodeCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTicketCodeCheck.BackColor = System.Drawing.Color.LightGray;
            this.btnTicketCodeCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTicketCodeCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTicketCodeCheck.Location = new System.Drawing.Point(606, 3);
            this.btnTicketCodeCheck.Name = "btnTicketCodeCheck";
            this.btnTicketCodeCheck.Size = new System.Drawing.Size(198, 34);
            this.btnTicketCodeCheck.TabIndex = 0;
            this.btnTicketCodeCheck.Text = "Идентифицировать";
            this.btnTicketCodeCheck.UseVisualStyleBackColor = false;
            this.btnTicketCodeCheck.Click += new System.EventHandler(this.btnTicketCodeCheck_Click);
            // 
            // tbTicketCode
            // 
            this.tbTicketCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTicketCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketCode.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTicketCode.Location = new System.Drawing.Point(207, 6);
            this.tbTicketCode.MaxLength = 15;
            this.tbTicketCode.Name = "tbTicketCode";
            this.tbTicketCode.Size = new System.Drawing.Size(393, 30);
            this.tbTicketCode.TabIndex = 1;
            this.tbTicketCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTicketCode.TextChanged += new System.EventHandler(this.tbTicketCode_TextChanged);
            this.tbTicketCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTicketCode_KeyDown);
            this.tbTicketCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTicketCode_KeyPress);
            // 
            // lblTicketCode
            // 
            this.lblTicketCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTicketCode.BackColor = System.Drawing.Color.LightGray;
            this.lblTicketCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTicketCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTicketCode.Location = new System.Drawing.Point(3, 3);
            this.lblTicketCode.Name = "lblTicketCode";
            this.lblTicketCode.Size = new System.Drawing.Size(198, 34);
            this.lblTicketCode.TabIndex = 2;
            this.lblTicketCode.Text = "Штрих-код билета: ";
            this.lblTicketCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTicketCode
            // 
            this.pnlTicketCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTicketCode.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTicketCode.Controls.Add(this.chbReturningTicket);
            this.pnlTicketCode.Controls.Add(this.tbTicketCode);
            this.pnlTicketCode.Controls.Add(this.lblTicketCode);
            this.pnlTicketCode.Controls.Add(this.btnTicketCodeCheck);
            this.pnlTicketCode.Location = new System.Drawing.Point(0, 358);
            this.pnlTicketCode.Name = "pnlTicketCode";
            this.pnlTicketCode.Size = new System.Drawing.Size(987, 42);
            this.pnlTicketCode.TabIndex = 2;
            // 
            // chbReturningTicket
            // 
            this.chbReturningTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbReturningTicket.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbReturningTicket.BackColor = System.Drawing.Color.LightGray;
            this.chbReturningTicket.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.chbReturningTicket.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.chbReturningTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chbReturningTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.chbReturningTicket.Location = new System.Drawing.Point(810, 3);
            this.chbReturningTicket.Name = "chbReturningTicket";
            this.chbReturningTicket.Size = new System.Drawing.Size(174, 34);
            this.chbReturningTicket.TabIndex = 4;
            this.chbReturningTicket.Text = "Возврат билета";
            this.chbReturningTicket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbReturningTicket.UseVisualStyleBackColor = false;
            this.chbReturningTicket.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pnlEvent
            // 
            this.pnlEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEvent.BackColor = System.Drawing.SystemColors.Control;
            this.pnlEvent.Controls.Add(this.btnSearch);
            this.pnlEvent.Controls.Add(this.tbSearchValue);
            this.pnlEvent.Controls.Add(this.cmbSearchFilter);
            this.pnlEvent.Controls.Add(this.lblSearch);
            this.pnlEvent.Controls.Add(this.lblFree);
            this.pnlEvent.Controls.Add(this.lblLeft);
            this.pnlEvent.Controls.Add(this.lblGoIn);
            this.pnlEvent.Controls.Add(this.cmbEvent);
            this.pnlEvent.Controls.Add(this.lblEvent);
            this.pnlEvent.Location = new System.Drawing.Point(0, 28);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Size = new System.Drawing.Size(987, 83);
            this.pnlEvent.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(810, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(165, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Искать";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearchValue
            // 
            this.tbSearchValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearchValue.Enabled = false;
            this.tbSearchValue.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearchValue.Location = new System.Drawing.Point(255, 46);
            this.tbSearchValue.MaxLength = 15;
            this.tbSearchValue.Name = "tbSearchValue";
            this.tbSearchValue.Size = new System.Drawing.Size(549, 30);
            this.tbSearchValue.TabIndex = 7;
            this.tbSearchValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchValue_KeyDown);
            // 
            // cmbSearchFilter
            // 
            this.cmbSearchFilter.BackColor = System.Drawing.Color.White;
            this.cmbSearchFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchFilter.Enabled = false;
            this.cmbSearchFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbSearchFilter.Items.AddRange(new object[] {
            "Имя, фамилия",
            "Телефон",
            "Штрих-код"});
            this.cmbSearchFilter.Location = new System.Drawing.Point(88, 45);
            this.cmbSearchFilter.Name = "cmbSearchFilter";
            this.cmbSearchFilter.Size = new System.Drawing.Size(161, 32);
            this.cmbSearchFilter.Sorted = true;
            this.cmbSearchFilter.TabIndex = 6;
            // 
            // lblSearch
            // 
            this.lblSearch.BackColor = System.Drawing.Color.LightGray;
            this.lblSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSearch.Enabled = false;
            this.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearch.Location = new System.Drawing.Point(11, 44);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 32);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Поиск: ";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFree
            // 
            this.lblFree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFree.BackColor = System.Drawing.Color.LightGray;
            this.lblFree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFree.Location = new System.Drawing.Point(810, 6);
            this.lblFree.Name = "lblFree";
            this.lblFree.Size = new System.Drawing.Size(165, 32);
            this.lblFree.TabIndex = 4;
            this.lblFree.Text = "Свободно: 0";
            this.lblFree.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLeft
            // 
            this.lblLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeft.BackColor = System.Drawing.Color.LightGray;
            this.lblLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLeft.Location = new System.Drawing.Point(647, 6);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(157, 32);
            this.lblLeft.TabIndex = 3;
            this.lblLeft.Text = "Осталось: 0";
            this.lblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGoIn
            // 
            this.lblGoIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGoIn.BackColor = System.Drawing.Color.LightGray;
            this.lblGoIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGoIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGoIn.Location = new System.Drawing.Point(516, 6);
            this.lblGoIn.Name = "lblGoIn";
            this.lblGoIn.Size = new System.Drawing.Size(125, 32);
            this.lblGoIn.TabIndex = 2;
            this.lblGoIn.Text = "Зашло: 0";
            this.lblGoIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEvent
            // 
            this.cmbEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEvent.BackColor = System.Drawing.Color.White;
            this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbEvent.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbEvent.Location = new System.Drawing.Point(221, 7);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(289, 32);
            this.cmbEvent.Sorted = true;
            this.cmbEvent.TabIndex = 1;
            this.cmbEvent.SelectedIndexChanged += new System.EventHandler(this.cmbEvent_SelectedIndexChanged);
            this.cmbEvent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEvent_KeyDown);
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.Color.LightGray;
            this.lblEvent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEvent.Location = new System.Drawing.Point(10, 7);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(205, 32);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Выбор мероприятия: ";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(987, 400);
            this.Controls.Add(this.pnlEvent);
            this.Controls.Add(this.pnlTicketCode);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Идентификация клиентов";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlTicketCode.ResumeLayout(false);
            this.pnlTicketCode.PerformLayout();
            this.pnlEvent.ResumeLayout(false);
            this.pnlEvent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTickets;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTicketsAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTicketsConducted;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUnConducted;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Label lblTicketCode;
        private System.Windows.Forms.TextBox tbTicketCode;
        private System.Windows.Forms.Button btnTicketCodeCheck;
        private System.Windows.Forms.Panel pnlTicketCode;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAllEvents;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTodayEvents;
        private System.Windows.Forms.Label lblFree;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblGoIn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn col7;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col8;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.CheckBox chbReturningTicket;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearchValue;
        private System.Windows.Forms.ComboBox cmbSearchFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ToolTip toolTipSearch;
    }
}


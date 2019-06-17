namespace Re_start
{
    partial class Connect
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusConect = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btConect = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServers = new System.Windows.Forms.Label();
            this.cbDataSource = new System.Windows.Forms.ComboBox();
            this.cbInitialCatalog = new System.Windows.Forms.ComboBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbUserID = new System.Windows.Forms.TextBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.statusConect.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 30);
            this.panel2.TabIndex = 3;
            // 
            // statusConect
            // 
            this.statusConect.BackColor = System.Drawing.Color.Transparent;
            this.statusConect.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusConect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusConect.Location = new System.Drawing.Point(0, 368);
            this.statusConect.Name = "statusConect";
            this.statusConect.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusConect.Size = new System.Drawing.Size(601, 32);
            this.statusConect.TabIndex = 4;
            this.statusConect.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(19, 25);
            this.tsslStatus.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(33, 338);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(564, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(37, 338);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btConect);
            this.panel4.Controls.Add(this.btCancel);
            this.panel4.Controls.Add(this.btCheck);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(33, 323);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(531, 45);
            this.panel4.TabIndex = 7;
            // 
            // btConect
            // 
            this.btConect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btConect.Enabled = false;
            this.btConect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btConect.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btConect.Location = new System.Drawing.Point(151, 0);
            this.btConect.Margin = new System.Windows.Forms.Padding(4);
            this.btConect.Name = "btConect";
            this.btConect.Size = new System.Drawing.Size(228, 45);
            this.btConect.TabIndex = 16;
            this.btConect.Text = "Подключить";
            this.btConect.UseVisualStyleBackColor = true;
            this.btConect.Click += new System.EventHandler(this.BtConect_Click);
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.Location = new System.Drawing.Point(379, 0);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(152, 45);
            this.btCancel.TabIndex = 15;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // btCheck
            // 
            this.btCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCheck.Enabled = false;
            this.btCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheck.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCheck.Location = new System.Drawing.Point(0, 0);
            this.btCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btCheck.Name = "btCheck";
            this.btCheck.Size = new System.Drawing.Size(151, 45);
            this.btCheck.TabIndex = 14;
            this.btCheck.Text = "Проверка";
            this.btCheck.UseVisualStyleBackColor = true;
            this.btCheck.Click += new System.EventHandler(this.BtCheck_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "Настройка подключения к базе данных";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblServers
            // 
            this.lblServers.AutoSize = true;
            this.lblServers.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblServers.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblServers.Location = new System.Drawing.Point(33, 76);
            this.lblServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(209, 29);
            this.lblServers.TabIndex = 14;
            this.lblServers.Text = "Список серверов:";
            // 
            // cbDataSource
            // 
            this.cbDataSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbDataSource.Enabled = false;
            this.cbDataSource.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbDataSource.FormattingEnabled = true;
            this.cbDataSource.Location = new System.Drawing.Point(33, 105);
            this.cbDataSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.Size = new System.Drawing.Size(531, 37);
            this.cbDataSource.TabIndex = 15;
            // 
            // cbInitialCatalog
            // 
            this.cbInitialCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbInitialCatalog.Enabled = false;
            this.cbInitialCatalog.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbInitialCatalog.FormattingEnabled = true;
            this.cbInitialCatalog.Location = new System.Drawing.Point(33, 313);
            this.cbInitialCatalog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbInitialCatalog.Name = "cbInitialCatalog";
            this.cbInitialCatalog.Size = new System.Drawing.Size(531, 37);
            this.cbInitialCatalog.TabIndex = 26;
            // 
            // lblDataSource
            // 
            this.lblDataSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataSource.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblDataSource.Location = new System.Drawing.Point(33, 281);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(531, 32);
            this.lblDataSource.TabIndex = 25;
            this.lblDataSource.Text = "Список источников данных:";
            this.lblDataSource.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPassword.Enabled = false;
            this.tbPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbPassword.Location = new System.Drawing.Point(33, 245);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.Size = new System.Drawing.Size(531, 36);
            this.tbPassword.TabIndex = 24;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblPassword.Location = new System.Drawing.Point(33, 213);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(531, 32);
            this.lblPassword.TabIndex = 23;
            this.lblPassword.Text = "Пароль пользователя:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbUserID
            // 
            this.tbUserID.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbUserID.Enabled = false;
            this.tbUserID.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbUserID.Location = new System.Drawing.Point(33, 177);
            this.tbUserID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserID.Name = "tbUserID";
            this.tbUserID.Size = new System.Drawing.Size(531, 36);
            this.tbUserID.TabIndex = 22;
            // 
            // lblUsers
            // 
            this.lblUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUsers.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblUsers.Location = new System.Drawing.Point(33, 142);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(531, 35);
            this.lblUsers.TabIndex = 21;
            this.lblUsers.Text = "Пользователь сервера:";
            this.lblUsers.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(601, 400);
            this.Controls.Add(this.cbInitialCatalog);
            this.Controls.Add(this.lblDataSource);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbUserID);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.cbDataSource);
            this.Controls.Add(this.lblServers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusConect);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конфигурация подключения к БД";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connect_FormClosing);
            this.Load += new System.EventHandler(this.Connect_Load);
            this.statusConect.ResumeLayout(false);
            this.statusConect.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusConect;
        public System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btConect;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.ComboBox cbDataSource;
        private System.Windows.Forms.ComboBox cbInitialCatalog;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUserID;
        private System.Windows.Forms.Label lblUsers;
    }
}


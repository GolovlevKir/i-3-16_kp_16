namespace Re_start
{
    partial class Document
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcConfig = new System.Windows.Forms.TabControl();
            this.tpMajorConfig = new System.Windows.Forms.TabPage();
            this.rtbOrganizationName = new System.Windows.Forms.RichTextBox();
            this.lbOrgName = new System.Windows.Forms.Label();
            this.tpDocument = new System.Windows.Forms.TabPage();
            this.gbDocumentMerge = new System.Windows.Forms.GroupBox();
            this.pnPage = new System.Windows.Forms.Panel();
            this.pnText = new System.Windows.Forms.Panel();
            this.gbRightMerj = new System.Windows.Forms.GroupBox();
            this.nudRightMerg = new System.Windows.Forms.NumericUpDown();
            this.gbLeftMerg = new System.Windows.Forms.GroupBox();
            this.nudLeftMerg = new System.Windows.Forms.NumericUpDown();
            this.gbBottomMerg = new System.Windows.Forms.GroupBox();
            this.nudBottomMerg = new System.Windows.Forms.NumericUpDown();
            this.gbTopMerg = new System.Windows.Forms.GroupBox();
            this.nudTopMerg = new System.Windows.Forms.NumericUpDown();
            this.pnPath = new System.Windows.Forms.Panel();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.pnCancel = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.btApplye = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tcConfig.SuspendLayout();
            this.tpMajorConfig.SuspendLayout();
            this.tpDocument.SuspendLayout();
            this.gbDocumentMerge.SuspendLayout();
            this.pnPage.SuspendLayout();
            this.gbRightMerj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRightMerg)).BeginInit();
            this.gbLeftMerg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftMerg)).BeginInit();
            this.gbBottomMerg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottomMerg)).BeginInit();
            this.gbTopMerg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopMerg)).BeginInit();
            this.pnPath.SuspendLayout();
            this.pnCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcConfig
            // 
            this.tcConfig.Controls.Add(this.tpMajorConfig);
            this.tcConfig.Controls.Add(this.tpDocument);
            this.tcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcConfig.Location = new System.Drawing.Point(0, 0);
            this.tcConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcConfig.Name = "tcConfig";
            this.tcConfig.SelectedIndex = 0;
            this.tcConfig.Size = new System.Drawing.Size(634, 637);
            this.tcConfig.TabIndex = 7;
            // 
            // tpMajorConfig
            // 
            this.tpMajorConfig.BackColor = System.Drawing.Color.Black;
            this.tpMajorConfig.Controls.Add(this.rtbOrganizationName);
            this.tpMajorConfig.Controls.Add(this.lbOrgName);
            this.tpMajorConfig.Location = new System.Drawing.Point(4, 29);
            this.tpMajorConfig.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMajorConfig.Name = "tpMajorConfig";
            this.tpMajorConfig.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpMajorConfig.Size = new System.Drawing.Size(551, 515);
            this.tpMajorConfig.TabIndex = 0;
            this.tpMajorConfig.Text = "Глобальные";
            // 
            // rtbOrganizationName
            // 
            this.rtbOrganizationName.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rtbOrganizationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOrganizationName.Location = new System.Drawing.Point(4, 54);
            this.rtbOrganizationName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbOrganizationName.Name = "rtbOrganizationName";
            this.rtbOrganizationName.Size = new System.Drawing.Size(543, 456);
            this.rtbOrganizationName.TabIndex = 1;
            this.rtbOrganizationName.Text = "";
            // 
            // lbOrgName
            // 
            this.lbOrgName.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lbOrgName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbOrgName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbOrgName.Location = new System.Drawing.Point(4, 5);
            this.lbOrgName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrgName.Name = "lbOrgName";
            this.lbOrgName.Size = new System.Drawing.Size(543, 49);
            this.lbOrgName.TabIndex = 0;
            this.lbOrgName.Text = "ШАПКА ЭКСПОРТИРУЕМЫХ ДОКУМЕНТОВ";
            this.lbOrgName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpDocument
            // 
            this.tpDocument.BackColor = System.Drawing.Color.MidnightBlue;
            this.tpDocument.Controls.Add(this.gbDocumentMerge);
            this.tpDocument.Controls.Add(this.pnPath);
            this.tpDocument.Controls.Add(this.lbPath);
            this.tpDocument.Location = new System.Drawing.Point(4, 29);
            this.tpDocument.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpDocument.Name = "tpDocument";
            this.tpDocument.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpDocument.Size = new System.Drawing.Size(626, 604);
            this.tpDocument.TabIndex = 1;
            this.tpDocument.Text = "Документы";
            // 
            // gbDocumentMerge
            // 
            this.gbDocumentMerge.Controls.Add(this.pnPage);
            this.gbDocumentMerge.Controls.Add(this.gbRightMerj);
            this.gbDocumentMerge.Controls.Add(this.gbLeftMerg);
            this.gbDocumentMerge.Controls.Add(this.gbBottomMerg);
            this.gbDocumentMerge.Controls.Add(this.gbTopMerg);
            this.gbDocumentMerge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocumentMerge.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbDocumentMerge.Location = new System.Drawing.Point(4, 56);
            this.gbDocumentMerge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDocumentMerge.Name = "gbDocumentMerge";
            this.gbDocumentMerge.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbDocumentMerge.Size = new System.Drawing.Size(618, 543);
            this.gbDocumentMerge.TabIndex = 3;
            this.gbDocumentMerge.TabStop = false;
            this.gbDocumentMerge.Text = "Отступы в документе";
            // 
            // pnPage
            // 
            this.pnPage.BackColor = System.Drawing.Color.DimGray;
            this.pnPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPage.Controls.Add(this.pnText);
            this.pnPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPage.Location = new System.Drawing.Point(154, 86);
            this.pnPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnPage.Name = "pnPage";
            this.pnPage.Size = new System.Drawing.Size(310, 398);
            this.pnPage.TabIndex = 4;
            // 
            // pnText
            // 
            this.pnText.BackColor = System.Drawing.Color.White;
            this.pnText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnText.Location = new System.Drawing.Point(-2, -2);
            this.pnText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnText.Name = "pnText";
            this.pnText.Size = new System.Drawing.Size(311, 399);
            this.pnText.TabIndex = 0;
            // 
            // gbRightMerj
            // 
            this.gbRightMerj.Controls.Add(this.nudRightMerg);
            this.gbRightMerj.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbRightMerj.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbRightMerj.Location = new System.Drawing.Point(464, 86);
            this.gbRightMerj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRightMerj.Name = "gbRightMerj";
            this.gbRightMerj.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRightMerj.Size = new System.Drawing.Size(150, 398);
            this.gbRightMerj.TabIndex = 3;
            this.gbRightMerj.TabStop = false;
            this.gbRightMerj.Text = "Правый отступ";
            // 
            // nudRightMerg
            // 
            this.nudRightMerg.DecimalPlaces = 1;
            this.nudRightMerg.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudRightMerg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRightMerg.Location = new System.Drawing.Point(4, 24);
            this.nudRightMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudRightMerg.Name = "nudRightMerg";
            this.nudRightMerg.Size = new System.Drawing.Size(142, 26);
            this.nudRightMerg.TabIndex = 0;
            this.nudRightMerg.ValueChanged += new System.EventHandler(this.NudRightMerg_ValueChanged);
            // 
            // gbLeftMerg
            // 
            this.gbLeftMerg.Controls.Add(this.nudLeftMerg);
            this.gbLeftMerg.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbLeftMerg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbLeftMerg.Location = new System.Drawing.Point(4, 86);
            this.gbLeftMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbLeftMerg.Name = "gbLeftMerg";
            this.gbLeftMerg.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbLeftMerg.Size = new System.Drawing.Size(150, 398);
            this.gbLeftMerg.TabIndex = 2;
            this.gbLeftMerg.TabStop = false;
            this.gbLeftMerg.Text = "Левый отступ";
            // 
            // nudLeftMerg
            // 
            this.nudLeftMerg.DecimalPlaces = 1;
            this.nudLeftMerg.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudLeftMerg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLeftMerg.Location = new System.Drawing.Point(4, 24);
            this.nudLeftMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudLeftMerg.Name = "nudLeftMerg";
            this.nudLeftMerg.Size = new System.Drawing.Size(142, 26);
            this.nudLeftMerg.TabIndex = 0;
            this.nudLeftMerg.ValueChanged += new System.EventHandler(this.NudLeftMerg_ValueChanged);
            // 
            // gbBottomMerg
            // 
            this.gbBottomMerg.Controls.Add(this.nudBottomMerg);
            this.gbBottomMerg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbBottomMerg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbBottomMerg.Location = new System.Drawing.Point(4, 484);
            this.gbBottomMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbBottomMerg.Name = "gbBottomMerg";
            this.gbBottomMerg.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbBottomMerg.Size = new System.Drawing.Size(610, 54);
            this.gbBottomMerg.TabIndex = 1;
            this.gbBottomMerg.TabStop = false;
            this.gbBottomMerg.Text = "Нижний отступ";
            // 
            // nudBottomMerg
            // 
            this.nudBottomMerg.DecimalPlaces = 1;
            this.nudBottomMerg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nudBottomMerg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBottomMerg.Location = new System.Drawing.Point(4, 23);
            this.nudBottomMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudBottomMerg.Name = "nudBottomMerg";
            this.nudBottomMerg.Size = new System.Drawing.Size(602, 26);
            this.nudBottomMerg.TabIndex = 0;
            this.nudBottomMerg.ValueChanged += new System.EventHandler(this.NudBottomMerg_ValueChanged);
            // 
            // gbTopMerg
            // 
            this.gbTopMerg.Controls.Add(this.nudTopMerg);
            this.gbTopMerg.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTopMerg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbTopMerg.Location = new System.Drawing.Point(4, 24);
            this.gbTopMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbTopMerg.Name = "gbTopMerg";
            this.gbTopMerg.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbTopMerg.Size = new System.Drawing.Size(610, 62);
            this.gbTopMerg.TabIndex = 0;
            this.gbTopMerg.TabStop = false;
            this.gbTopMerg.Text = "Верхний отступ";
            // 
            // nudTopMerg
            // 
            this.nudTopMerg.DecimalPlaces = 1;
            this.nudTopMerg.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudTopMerg.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTopMerg.Location = new System.Drawing.Point(4, 24);
            this.nudTopMerg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudTopMerg.Name = "nudTopMerg";
            this.nudTopMerg.Size = new System.Drawing.Size(602, 26);
            this.nudTopMerg.TabIndex = 0;
            this.nudTopMerg.ValueChanged += new System.EventHandler(this.NudTopMerg_ValueChanged);
            // 
            // pnPath
            // 
            this.pnPath.Controls.Add(this.btBrowse);
            this.pnPath.Controls.Add(this.tbPath);
            this.pnPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnPath.Location = new System.Drawing.Point(4, 24);
            this.pnPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnPath.Name = "pnPath";
            this.pnPath.Size = new System.Drawing.Size(618, 32);
            this.pnPath.TabIndex = 1;
            // 
            // tbPath
            // 
            this.tbPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPath.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tbPath.Location = new System.Drawing.Point(0, 0);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(618, 27);
            this.tbPath.TabIndex = 1;
            this.tbPath.Text = "C:\\Users\\kirvi\\Documents";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbPath.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPath.Location = new System.Drawing.Point(4, 5);
            this.lbPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(344, 19);
            this.lbPath.TabIndex = 0;
            this.lbPath.Text = "Выберите папку для сохранения документов:";
            // 
            // pnCancel
            // 
            this.pnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnCancel.Controls.Add(this.btSave);
            this.pnCancel.Controls.Add(this.btApplye);
            this.pnCancel.Controls.Add(this.btCancel);
            this.pnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCancel.Location = new System.Drawing.Point(0, 637);
            this.pnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnCancel.Name = "pnCancel";
            this.pnCancel.Size = new System.Drawing.Size(634, 55);
            this.pnCancel.TabIndex = 6;
            // 
            // btSave
            // 
            this.btSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btSave.FlatAppearance.BorderSize = 3;
            this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btSave.Location = new System.Drawing.Point(298, 0);
            this.btSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(112, 55);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // btApplye
            // 
            this.btApplye.Dock = System.Windows.Forms.DockStyle.Right;
            this.btApplye.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btApplye.FlatAppearance.BorderSize = 3;
            this.btApplye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btApplye.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btApplye.Location = new System.Drawing.Point(410, 0);
            this.btApplye.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btApplye.Name = "btApplye";
            this.btApplye.Size = new System.Drawing.Size(112, 55);
            this.btApplye.TabIndex = 1;
            this.btApplye.Text = "Применить";
            this.btApplye.UseVisualStyleBackColor = true;
            this.btApplye.Click += new System.EventHandler(this.BtApplye_Click);
            // 
            // btCancel
            // 
            this.btCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btCancel.FlatAppearance.BorderSize = 3;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btCancel.Location = new System.Drawing.Point(522, 0);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(112, 55);
            this.btCancel.TabIndex = 0;
            this.btCancel.Text = "Закрыть";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // btBrowse
            // 
            this.btBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btBrowse.FlatAppearance.BorderSize = 3;
            this.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBrowse.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btBrowse.Location = new System.Drawing.Point(582, 0);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(36, 32);
            this.btBrowse.TabIndex = 3;
            this.btBrowse.Text = "...";
            this.btBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.BtBrowse_Click);
            // 
            // Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(634, 692);
            this.Controls.Add(this.tcConfig);
            this.Controls.Add(this.pnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Document";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document";
            this.Load += new System.EventHandler(this.Document_Load);
            this.tcConfig.ResumeLayout(false);
            this.tpMajorConfig.ResumeLayout(false);
            this.tpDocument.ResumeLayout(false);
            this.tpDocument.PerformLayout();
            this.gbDocumentMerge.ResumeLayout(false);
            this.pnPage.ResumeLayout(false);
            this.gbRightMerj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRightMerg)).EndInit();
            this.gbLeftMerg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLeftMerg)).EndInit();
            this.gbBottomMerg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudBottomMerg)).EndInit();
            this.gbTopMerg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTopMerg)).EndInit();
            this.pnPath.ResumeLayout(false);
            this.pnPath.PerformLayout();
            this.pnCancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcConfig;
        private System.Windows.Forms.TabPage tpMajorConfig;
        private System.Windows.Forms.RichTextBox rtbOrganizationName;
        private System.Windows.Forms.Label lbOrgName;
        private System.Windows.Forms.TabPage tpDocument;
        private System.Windows.Forms.GroupBox gbDocumentMerge;
        private System.Windows.Forms.Panel pnPage;
        private System.Windows.Forms.Panel pnText;
        private System.Windows.Forms.GroupBox gbRightMerj;
        private System.Windows.Forms.NumericUpDown nudRightMerg;
        private System.Windows.Forms.GroupBox gbLeftMerg;
        private System.Windows.Forms.NumericUpDown nudLeftMerg;
        private System.Windows.Forms.GroupBox gbBottomMerg;
        private System.Windows.Forms.NumericUpDown nudBottomMerg;
        private System.Windows.Forms.GroupBox gbTopMerg;
        private System.Windows.Forms.NumericUpDown nudTopMerg;
        private System.Windows.Forms.Panel pnPath;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Panel pnCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btApplye;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
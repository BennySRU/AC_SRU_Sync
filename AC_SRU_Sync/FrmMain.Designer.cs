namespace AC_SRU_Sync
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblExe = new System.Windows.Forms.Label();
            this.lblSRU = new System.Windows.Forms.Label();
            this.txtACEXE = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pgbar = new System.Windows.Forms.ProgressBar();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFtpUser = new System.Windows.Forms.TextBox();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.tooly = new System.Windows.Forms.ToolTip(this.components);
            this.txtFTP = new System.Windows.Forms.TextBox();
            this.cmbDeep = new System.Windows.Forms.NumericUpDown();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFTP = new System.Windows.Forms.Panel();
            this.lblFTPHeader = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFTP = new System.Windows.Forms.Label();
            this.btnShowSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeep)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblExe
            // 
            this.lblExe.AutoSize = true;
            this.lblExe.Location = new System.Drawing.Point(5, 35);
            this.lblExe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExe.Name = "lblExe";
            this.lblExe.Size = new System.Drawing.Size(67, 20);
            this.lblExe.TabIndex = 0;
            this.lblExe.Text = "AC.exe:";
            // 
            // lblSRU
            // 
            this.lblSRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSRU.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSRU.Image = global::AC_SRU_Sync.Properties.Resources.SRU;
            this.lblSRU.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSRU.Location = new System.Drawing.Point(184, 5);
            this.lblSRU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSRU.Name = "lblSRU";
            this.lblSRU.Size = new System.Drawing.Size(482, 90);
            this.lblSRU.TabIndex = 2;
            this.lblSRU.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtACEXE
            // 
            this.txtACEXE.Location = new System.Drawing.Point(74, 31);
            this.txtACEXE.Name = "txtACEXE";
            this.txtACEXE.Size = new System.Drawing.Size(273, 26);
            this.txtACEXE.TabIndex = 4;
            // 
            // btnCheck
            // 
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.Location = new System.Drawing.Point(149, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(188, 42);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSync
            // 
            this.btnSync.ForeColor = System.Drawing.Color.Black;
            this.btnSync.Location = new System.Drawing.Point(414, 3);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(188, 42);
            this.btnSync.TabIndex = 8;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(663, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(188, 42);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(918, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbar
            // 
            this.pgbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbar.Location = new System.Drawing.Point(0, 0);
            this.pgbar.Name = "pgbar";
            this.pgbar.Size = new System.Drawing.Size(918, 30);
            this.pgbar.TabIndex = 11;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Location = new System.Drawing.Point(0, 0);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(918, 153);
            this.txtStatus.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(877, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFtpUser
            // 
            this.txtFtpUser.Location = new System.Drawing.Point(93, 66);
            this.txtFtpUser.Name = "txtFtpUser";
            this.txtFtpUser.Size = new System.Drawing.Size(244, 26);
            this.txtFtpUser.TabIndex = 14;
            this.tooly.SetToolTip(this.txtFtpUser, "User to connect (if empty will take anonymous)");
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Location = new System.Drawing.Point(93, 97);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.Size = new System.Drawing.Size(244, 26);
            this.txtFtpPassword.TabIndex = 15;
            this.tooly.SetToolTip(this.txtFtpPassword, "password for the user");
            this.txtFtpPassword.UseSystemPasswordChar = true;
            // 
            // txtFTP
            // 
            this.txtFTP.Location = new System.Drawing.Point(93, 35);
            this.txtFTP.Name = "txtFTP";
            this.txtFTP.Size = new System.Drawing.Size(244, 26);
            this.txtFTP.TabIndex = 5;
            this.tooly.SetToolTip(this.txtFTP, "Path to ftp server without ftp://");
            // 
            // cmbDeep
            // 
            this.cmbDeep.Location = new System.Drawing.Point(195, 94);
            this.cmbDeep.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbDeep.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.cmbDeep.Name = "cmbDeep";
            this.cmbDeep.Size = new System.Drawing.Size(39, 26);
            this.cmbDeep.TabIndex = 16;
            this.cmbDeep.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnShowSettings);
            this.pnlTop.Controls.Add(this.lblSRU);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(918, 175);
            this.pnlTop.TabIndex = 18;
            this.tooly.SetToolTip(this.pnlTop, "Show Settings");
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(4, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(910, 59);
            this.label2.TabIndex = 18;
            this.label2.Text = "ASSETTO CORSA SYNC CENTER ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.txtStatus);
            this.pnlStatus.Controls.Add(this.pnlProgress);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 424);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(918, 214);
            this.pnlStatus.TabIndex = 19;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.pgbar);
            this.pnlProgress.Controls.Add(this.lblStatus);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgress.Location = new System.Drawing.Point(0, 153);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(918, 61);
            this.pnlProgress.TabIndex = 13;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCheck);
            this.pnlButtons.Controls.Add(this.btnStart);
            this.pnlButtons.Controls.Add(this.btnSync);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 324);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(918, 100);
            this.pnlButtons.TabIndex = 20;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.panel1);
            this.pnlSettings.Controls.Add(this.pnlFTP);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(0, 175);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(918, 249);
            this.pnlSettings.TabIndex = 20;
            this.pnlSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSettings_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbDeep);
            this.panel1.Controls.Add(this.txtACEXE);
            this.panel1.Controls.Add(this.lblExe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(530, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 249);
            this.panel1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Local-Settings:";
            // 
            // pnlFTP
            // 
            this.pnlFTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFTP.Controls.Add(this.lblFTPHeader);
            this.pnlFTP.Controls.Add(this.label3);
            this.pnlFTP.Controls.Add(this.label1);
            this.pnlFTP.Controls.Add(this.txtFtpPassword);
            this.pnlFTP.Controls.Add(this.txtFtpUser);
            this.pnlFTP.Controls.Add(this.lblFTP);
            this.pnlFTP.Controls.Add(this.txtFTP);
            this.pnlFTP.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFTP.Location = new System.Drawing.Point(0, 0);
            this.pnlFTP.Name = "pnlFTP";
            this.pnlFTP.Size = new System.Drawing.Size(350, 249);
            this.pnlFTP.TabIndex = 6;
            // 
            // lblFTPHeader
            // 
            this.lblFTPHeader.AutoSize = true;
            this.lblFTPHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFTPHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFTPHeader.Location = new System.Drawing.Point(6, 6);
            this.lblFTPHeader.Name = "lblFTPHeader";
            this.lblFTPHeader.Size = new System.Drawing.Size(127, 22);
            this.lblFTPHeader.TabIndex = 18;
            this.lblFTPHeader.Text = "FTP-Settings:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "User:";
            // 
            // lblFTP
            // 
            this.lblFTP.AutoSize = true;
            this.lblFTP.Location = new System.Drawing.Point(4, 38);
            this.lblFTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFTP.Name = "lblFTP";
            this.lblFTP.Size = new System.Drawing.Size(63, 20);
            this.lblFTP.TabIndex = 4;
            this.lblFTP.Text = "Server:";
            // 
            // btnShowSettings
            // 
            this.btnShowSettings.ForeColor = System.Drawing.Color.Black;
            this.btnShowSettings.Location = new System.Drawing.Point(6, 146);
            this.btnShowSettings.Name = "btnShowSettings";
            this.btnShowSettings.Size = new System.Drawing.Size(26, 23);
            this.btnShowSettings.TabIndex = 19;
            this.btnShowSettings.Text = "+";
            this.btnShowSettings.UseVisualStyleBackColor = true;
            this.btnShowSettings.Click += new System.EventHandler(this.btnShowSettings_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(918, 638);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "Asetto Corsa Simracing United Sync Center";
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeep)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFTP.ResumeLayout(false);
            this.pnlFTP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblExe;
        private System.Windows.Forms.Label lblSRU;
        private System.Windows.Forms.TextBox txtACEXE;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pgbar;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip tooly;
        private System.Windows.Forms.TextBox txtFtpUser;
        private System.Windows.Forms.TextBox txtFtpPassword;
        private System.Windows.Forms.NumericUpDown cmbDeep;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.TextBox txtFTP;
        private System.Windows.Forms.Label lblFTP;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Panel pnlFTP;
        private System.Windows.Forms.Label lblFTPHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnShowSettings;
    }
}


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
            this.lblFTP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFTP = new System.Windows.Forms.TextBox();
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
            this.cmbDeep = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeep)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExe
            // 
            this.lblExe.AutoSize = true;
            this.lblExe.Location = new System.Drawing.Point(7, 176);
            this.lblExe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExe.Name = "lblExe";
            this.lblExe.Size = new System.Drawing.Size(105, 17);
            this.lblExe.TabIndex = 0;
            this.lblExe.Text = "Path to AC.exe:";
            // 
            // lblFTP
            // 
            this.lblFTP.AutoSize = true;
            this.lblFTP.Location = new System.Drawing.Point(37, 148);
            this.lblFTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFTP.Name = "lblFTP";
            this.lblFTP.Size = new System.Drawing.Size(71, 17);
            this.lblFTP.TabIndex = 1;
            this.lblFTP.Text = "FTP Path:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::AC_SRU_Sync.Properties.Resources.SRU;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(762, 133);
            this.label1.TabIndex = 2;
            this.label1.Text = "ASSETTO CORSA SYNC CENTER ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtFTP
            // 
            this.txtFTP.Location = new System.Drawing.Point(115, 145);
            this.txtFTP.Name = "txtFTP";
            this.txtFTP.Size = new System.Drawing.Size(187, 23);
            this.txtFTP.TabIndex = 3;
            this.tooly.SetToolTip(this.txtFTP, "Path to ftp server without ftp://");
            // 
            // txtACEXE
            // 
            this.txtACEXE.Location = new System.Drawing.Point(115, 173);
            this.txtACEXE.Name = "txtACEXE";
            this.txtACEXE.Size = new System.Drawing.Size(568, 23);
            this.txtACEXE.TabIndex = 4;
            // 
            // btnCheck
            // 
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.Location = new System.Drawing.Point(115, 202);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(188, 35);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSync
            // 
            this.btnSync.ForeColor = System.Drawing.Color.Black;
            this.btnSync.Location = new System.Drawing.Point(306, 202);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(188, 35);
            this.btnSync.TabIndex = 8;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(497, 202);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(188, 35);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(115, 270);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(568, 23);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbar
            // 
            this.pgbar.Location = new System.Drawing.Point(115, 244);
            this.pgbar.Name = "pgbar";
            this.pgbar.Size = new System.Drawing.Size(568, 23);
            this.pgbar.TabIndex = 11;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(114, 293);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(568, 219);
            this.txtStatus.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(742, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFtpUser
            // 
            this.txtFtpUser.Location = new System.Drawing.Point(306, 145);
            this.txtFtpUser.Name = "txtFtpUser";
            this.txtFtpUser.Size = new System.Drawing.Size(187, 23);
            this.txtFtpUser.TabIndex = 14;
            this.tooly.SetToolTip(this.txtFtpUser, "User to connect (if empty will take anonymous)");
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Location = new System.Drawing.Point(496, 145);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.Size = new System.Drawing.Size(187, 23);
            this.txtFtpPassword.TabIndex = 15;
            this.tooly.SetToolTip(this.txtFtpPassword, "password for the user");
            this.txtFtpPassword.UseSystemPasswordChar = true;
            // 
            // cmbDeep
            // 
            this.cmbDeep.Location = new System.Drawing.Point(690, 145);
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
            this.cmbDeep.Size = new System.Drawing.Size(39, 23);
            this.cmbDeep.TabIndex = 16;
            this.cmbDeep.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(780, 524);
            this.Controls.Add(this.cmbDeep);
            this.Controls.Add(this.txtFtpPassword);
            this.Controls.Add(this.txtFtpUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.pgbar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtACEXE);
            this.Controls.Add(this.txtFTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFTP);
            this.Controls.Add(this.lblExe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "Asetto Corsa Simracing United Sync Center";
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExe;
        private System.Windows.Forms.Label lblFTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFTP;
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
    }
}


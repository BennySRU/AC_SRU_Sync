namespace AC_SRU_Skins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblACS = new System.Windows.Forms.Label();
            this.lblSRU = new System.Windows.Forms.Label();
            this.txtACEXE = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.pgbar = new System.Windows.Forms.ProgressBar();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFtpUser = new System.Windows.Forms.TextBox();
            this.txtFtpPassword = new System.Windows.Forms.TextBox();
            this.tooly = new System.Windows.Forms.ToolTip(this.components);
            this.txtFTP = new System.Windows.Forms.TextBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnShowSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDirAC = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblStatus2 = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAllTogether = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlLocal = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblToSync = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFTP = new System.Windows.Forms.Panel();
            this.lblFTPHeader = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFTP = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.pnlLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlFTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblACS
            // 
            this.lblACS.AutoSize = true;
            this.lblACS.Location = new System.Drawing.Point(3, 70);
            this.lblACS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblACS.Name = "lblACS";
            this.lblACS.Size = new System.Drawing.Size(79, 17);
            this.lblACS.TabIndex = 0;
            this.lblACS.Text = "Local Path:";
            // 
            // lblSRU
            // 
            this.lblSRU.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSRU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSRU.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSRU.Image = global::AC_SRU_Skins.Properties.Resources.SRU;
            this.lblSRU.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSRU.Location = new System.Drawing.Point(316, 0);
            this.lblSRU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSRU.Name = "lblSRU";
            this.lblSRU.Size = new System.Drawing.Size(462, 90);
            this.lblSRU.TabIndex = 2;
            this.lblSRU.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSRU.Click += new System.EventHandler(this.lblSRU_Click);
            // 
            // txtACEXE
            // 
            this.txtACEXE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtACEXE.Location = new System.Drawing.Point(93, 67);
            this.txtACEXE.Name = "txtACEXE";
            this.txtACEXE.Size = new System.Drawing.Size(307, 23);
            this.txtACEXE.TabIndex = 4;
            // 
            // btnCheck
            // 
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCheck.FlatAppearance.BorderSize = 2;
            this.btnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Location = new System.Drawing.Point(0, 6);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(216, 42);
            this.btnCheck.TabIndex = 7;
            this.btnCheck.Text = "Check ";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnSync
            // 
            this.btnSync.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSync.FlatAppearance.BorderSize = 2;
            this.btnSync.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnSync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSync.Location = new System.Drawing.Point(223, 6);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(216, 42);
            this.btnSync.TabIndex = 8;
            this.btnSync.Text = "Sync with Server";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStart.FlatAppearance.BorderSize = 2;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(446, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(216, 42);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start Assetto Corsa";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStatus1
            // 
            this.lblStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus1.Location = new System.Drawing.Point(0, 23);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(995, 20);
            this.lblStatus1.TabIndex = 10;
            this.lblStatus1.Text = "...";
            this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbar
            // 
            this.pgbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbar.Location = new System.Drawing.Point(0, 5);
            this.pgbar.Name = "pgbar";
            this.pgbar.Size = new System.Drawing.Size(1095, 18);
            this.pgbar.TabIndex = 11;
            // 
            // txtStatus
            // 
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.Location = new System.Drawing.Point(0, 0);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatus.Size = new System.Drawing.Size(1095, 310);
            this.txtStatus.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1065, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFtpUser
            // 
            this.txtFtpUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpUser.Location = new System.Drawing.Point(93, 117);
            this.txtFtpUser.Name = "txtFtpUser";
            this.txtFtpUser.Size = new System.Drawing.Size(333, 23);
            this.txtFtpUser.TabIndex = 14;
            this.tooly.SetToolTip(this.txtFtpUser, "User to connect (if empty will take anonymous)");
            this.txtFtpUser.Visible = false;
            // 
            // txtFtpPassword
            // 
            this.txtFtpPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFtpPassword.Location = new System.Drawing.Point(93, 148);
            this.txtFtpPassword.Name = "txtFtpPassword";
            this.txtFtpPassword.Size = new System.Drawing.Size(333, 23);
            this.txtFtpPassword.TabIndex = 15;
            this.tooly.SetToolTip(this.txtFtpPassword, "password for the user");
            this.txtFtpPassword.UseSystemPasswordChar = true;
            this.txtFtpPassword.Visible = false;
            // 
            // txtFTP
            // 
            this.txtFTP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFTP.Location = new System.Drawing.Point(93, 35);
            this.txtFTP.Name = "txtFTP";
            this.txtFTP.Size = new System.Drawing.Size(343, 23);
            this.txtFTP.TabIndex = 5;
            this.tooly.SetToolTip(this.txtFTP, "Path to ftp server without ftp://");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnInfo);
            this.pnlTop.Controls.Add(this.btnShowSettings);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblSRU);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1095, 165);
            this.pnlTop.TabIndex = 18;
            this.tooly.SetToolTip(this.pnlTop, "Show Settings");
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMinimize.FlatAppearance.BorderSize = 2;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(1029, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 21;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInfo.FlatAppearance.BorderSize = 2;
            this.btnInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Location = new System.Drawing.Point(3, 0);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(30, 30);
            this.btnInfo.TabIndex = 20;
            this.btnInfo.Text = "i";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnShowSettings
            // 
            this.btnShowSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnShowSettings.FlatAppearance.BorderSize = 2;
            this.btnShowSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnShowSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnShowSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowSettings.Location = new System.Drawing.Point(0, 130);
            this.btnShowSettings.Name = "btnShowSettings";
            this.btnShowSettings.Size = new System.Drawing.Size(30, 30);
            this.btnShowSettings.TabIndex = 19;
            this.btnShowSettings.Text = "-";
            this.btnShowSettings.UseVisualStyleBackColor = true;
            this.btnShowSettings.Click += new System.EventHandler(this.btnShowSettings_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Location = new System.Drawing.Point(0, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1091, 49);
            this.label2.TabIndex = 18;
            this.label2.Text = "ASSETTO CORSA SKIN CENTER ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnDirAC
            // 
            this.btnDirAC.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDirAC.FlatAppearance.BorderSize = 2;
            this.btnDirAC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnDirAC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDirAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirAC.Location = new System.Drawing.Point(406, 67);
            this.btnDirAC.Name = "btnDirAC";
            this.btnDirAC.Size = new System.Drawing.Size(30, 23);
            this.btnDirAC.TabIndex = 25;
            this.btnDirAC.Text = "...";
            this.tooly.SetToolTip(this.btnDirAC, "Path to AssettoCorsa.exe if the textfile is empty the path will be getten by stea" +
        "m-Configuration");
            this.btnDirAC.UseVisualStyleBackColor = true;
            this.btnDirAC.Click += new System.EventHandler(this.btnDirAC_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.txtStatus);
            this.pnlStatus.Controls.Add(this.pnlProgress);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(15, 441);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1095, 353);
            this.pnlStatus.TabIndex = 19;
            this.pnlStatus.Visible = false;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.lblStatus1);
            this.pnlProgress.Controls.Add(this.lblStatus2);
            this.pnlProgress.Controls.Add(this.pgbar);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgress.Location = new System.Drawing.Point(0, 310);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlProgress.Size = new System.Drawing.Size(1095, 43);
            this.pnlProgress.TabIndex = 13;
            this.pnlProgress.Visible = false;
            // 
            // lblStatus2
            // 
            this.lblStatus2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStatus2.Location = new System.Drawing.Point(995, 23);
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(100, 20);
            this.lblStatus2.TabIndex = 12;
            this.lblStatus2.Text = "...";
            this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAllTogether);
            this.pnlButtons.Controls.Add(this.btnCheck);
            this.pnlButtons.Controls.Add(this.btnStart);
            this.pnlButtons.Controls.Add(this.btnSync);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(15, 387);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1095, 54);
            this.pnlButtons.TabIndex = 20;
            // 
            // btnAllTogether
            // 
            this.btnAllTogether.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllTogether.FlatAppearance.BorderSize = 2;
            this.btnAllTogether.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.btnAllTogether.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllTogether.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllTogether.Location = new System.Drawing.Point(669, 6);
            this.btnAllTogether.Name = "btnAllTogether";
            this.btnAllTogether.Size = new System.Drawing.Size(216, 42);
            this.btnAllTogether.TabIndex = 10;
            this.btnAllTogether.Text = "Check + Sync + Start";
            this.btnAllTogether.UseVisualStyleBackColor = true;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.pnlLocal);
            this.pnlSettings.Controls.Add(this.pnlFTP);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(15, 180);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1095, 207);
            this.pnlSettings.TabIndex = 20;
            this.pnlSettings.Visible = false;
            this.pnlSettings.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSettings_Paint);
            // 
            // pnlLocal
            // 
            this.pnlLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlLocal.Controls.Add(this.dataGridView1);
            this.pnlLocal.Controls.Add(this.lblToSync);
            this.pnlLocal.Controls.Add(this.label4);
            this.pnlLocal.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLocal.Location = new System.Drawing.Point(446, 0);
            this.pnlLocal.Name = "pnlLocal";
            this.pnlLocal.Size = new System.Drawing.Size(649, 207);
            this.pnlLocal.TabIndex = 19;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(72, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(315, 170);
            this.dataGridView1.TabIndex = 21;
            // 
            // lblToSync
            // 
            this.lblToSync.AutoSize = true;
            this.lblToSync.Location = new System.Drawing.Point(7, 38);
            this.lblToSync.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToSync.Name = "lblToSync";
            this.lblToSync.Size = new System.Drawing.Size(60, 17);
            this.lblToSync.TabIndex = 20;
            this.lblToSync.Text = "ToSync:";
            this.lblToSync.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cars:";
            // 
            // pnlFTP
            // 
            this.pnlFTP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlFTP.Controls.Add(this.lblFTPHeader);
            this.pnlFTP.Controls.Add(this.label3);
            this.pnlFTP.Controls.Add(this.label1);
            this.pnlFTP.Controls.Add(this.txtFtpPassword);
            this.pnlFTP.Controls.Add(this.btnDirAC);
            this.pnlFTP.Controls.Add(this.txtFtpUser);
            this.pnlFTP.Controls.Add(this.lblFTP);
            this.pnlFTP.Controls.Add(this.txtFTP);
            this.pnlFTP.Controls.Add(this.lblACS);
            this.pnlFTP.Controls.Add(this.txtACEXE);
            this.pnlFTP.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFTP.Location = new System.Drawing.Point(0, 0);
            this.pnlFTP.Name = "pnlFTP";
            this.pnlFTP.Size = new System.Drawing.Size(439, 207);
            this.pnlFTP.TabIndex = 6;
            // 
            // lblFTPHeader
            // 
            this.lblFTPHeader.AutoSize = true;
            this.lblFTPHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFTPHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFTPHeader.Location = new System.Drawing.Point(6, 6);
            this.lblFTPHeader.Name = "lblFTPHeader";
            this.lblFTPHeader.Size = new System.Drawing.Size(74, 19);
            this.lblFTPHeader.TabIndex = 18;
            this.lblFTPHeader.Text = "Settings:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password:";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "User:";
            this.label1.Visible = false;
            // 
            // lblFTP
            // 
            this.lblFTP.AutoSize = true;
            this.lblFTP.Location = new System.Drawing.Point(4, 38);
            this.lblFTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFTP.Name = "lblFTP";
            this.lblFTP.Size = new System.Drawing.Size(85, 17);
            this.lblFTP.TabIndex = 4;
            this.lblFTP.Text = "FTP-Server:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1125, 809);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Text = "Asetto Corsa Simracing United Sync Center";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.pnlTop.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlLocal.ResumeLayout(false);
            this.pnlLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlFTP.ResumeLayout(false);
            this.pnlFTP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblACS;
        private System.Windows.Forms.Label lblSRU;
        private System.Windows.Forms.TextBox txtACEXE;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.ProgressBar pgbar;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip tooly;
        private System.Windows.Forms.TextBox txtFtpUser;
        private System.Windows.Forms.TextBox txtFtpPassword;
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
        private System.Windows.Forms.Button btnShowSettings;
        private System.Windows.Forms.Button btnAllTogether;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnDirAC;
        private System.Windows.Forms.Label lblStatus2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlLocal;
        private System.Windows.Forms.Label lblToSync;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.FtpClient;
using System.Runtime.InteropServices;

namespace AC_SRU_Sync
{
    public partial class FrmMain : Form
    {
        //Variblen
        private FTPHelper ftpHelper;
        private SimpleAES simpleAES = new SimpleAES();
        private int deepToCheck = 7;
        private Dictionary<int, CheckBox> checkBoxes;
        private bool isLoading=true;

        //Attribute um das verschieben des Forms zu ermöglichen
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #region Formereignisse
        public FrmMain()
        {
            InitializeComponent();
            txtFTP.Text = AC_SRU_Sync.Properties.Settings.Default.ftpPath;
            txtACEXE.Text = AC_SRU_Sync.Properties.Settings.Default.localPath;
            txtFtpUser.Text = AC_SRU_Sync.Properties.Settings.Default.ftpUser;
            pnlSettings.Visible = AC_SRU_Sync.Properties.Settings.Default.SettingsVisible;
            btnShowSettings.Text = pnlSettings.Visible?"-":"+";
           
            if (!AC_SRU_Sync.Properties.Settings.Default.ftpPassword.Equals(""))
            {
                txtFtpPassword.Text = simpleAES.DecryptString(AC_SRU_Sync.Properties.Settings.Default.ftpPassword);
            }
            else
            {
                txtFtpPassword.Text = "";
            }
            if (AC_SRU_Sync.Properties.Settings.Default.deep > 3)
            {
                deepToCheck = AC_SRU_Sync.Properties.Settings.Default.deep;
            }
            cmbDeep.Value = deepToCheck;
            btnSync.Enabled = false;

            checkBoxes = new Dictionary<int, CheckBox>();
            checkBoxes.Add(0, checkBox1);
            checkBoxes.Add(1, checkBox2);
            checkBoxes.Add(2, checkBox3);
            checkBoxes.Add(3, checkBox4);
            LoadMainDirs();
            isLoading = false;

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (AC_SRU_Sync.Properties.Settings.Default.DesktopLocationX>=0&&
                AC_SRU_Sync.Properties.Settings.Default.DesktopLocationY >= 0 )
            this.SetDesktopLocation(AC_SRU_Sync.Properties.Settings.Default.DesktopLocationX, AC_SRU_Sync.Properties.Settings.Default.DesktopLocationY);// = AC_SRU_Sync.Properties.Settings.Default.WindowPosition;
            
        }
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

        }
        #endregion  

        public FTPHelper GetFTPHelper()
        {
            //Hier noch User und PW abfangen
            if (ftpHelper == null)
            {
                ftpHelper = new FTPHelper(txtFTP.Text);
            }
            return ftpHelper;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }
        #region Settings
        private void CloseApplication()
        {
            //Standardattribute speichern
            AC_SRU_Sync.Properties.Settings.Default.DesktopLocationX = this.DesktopLocation.X;
            AC_SRU_Sync.Properties.Settings.Default.DesktopLocationY = this.DesktopLocation.Y;
            AC_SRU_Sync.Properties.Settings.Default.SettingsVisible=pnlSettings.Visible;
            AC_SRU_Sync.Properties.Settings.Default.Save();

            if (HasSettingsChanged())
            {
                DialogResult result = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveSettings();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
                this.Close();
        }
        private void SaveSettings()
        {
            AC_SRU_Sync.Properties.Settings.Default.ftpPath = txtFTP.Text;
            AC_SRU_Sync.Properties.Settings.Default.localPath = txtACEXE.Text;
            AC_SRU_Sync.Properties.Settings.Default.ftpUser = txtFtpUser.Text;
            if (!txtFtpPassword.Text.Equals(""))
            {
                AC_SRU_Sync.Properties.Settings.Default.ftpPassword = simpleAES.EncryptToString(txtFtpPassword.Text);
            }
            else
            {
                AC_SRU_Sync.Properties.Settings.Default.ftpPassword = "";
            }
            AC_SRU_Sync.Properties.Settings.Default.deep = (int)cmbDeep.Value;
            AC_SRU_Sync.Properties.Settings.Default.Save();
    }
        private bool HasSettingsChanged() {
            if (txtFTP.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.ftpPath) &&
            txtACEXE.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.localPath) &&
            cmbDeep.Value == AC_SRU_Sync.Properties.Settings.Default.deep &&
            txtFtpUser.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.ftpUser )&&
            (txtFtpPassword.Text.Equals("")&&AC_SRU_Sync.Properties.Settings.Default.ftpPassword.Equals(""))||
            simpleAES.EncryptToString( txtFtpPassword.Text).Equals(AC_SRU_Sync.Properties.Settings.Default.ftpPassword))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void LoadMainDirs()
        {
            string mainDir = AC_SRU_Sync.Properties.Settings.Default.MainDirectories;
            string toSync = AC_SRU_Sync.Properties.Settings.Default.ToSync;
            foreach (KeyValuePair<int, CheckBox> pairly in checkBoxes)
            {
                pairly.Value.Visible = false;
            }
            if (mainDir.Equals(""))
            {
                this.lblToSync.Visible = false;
            }
            string[] folders = mainDir.Split(';');
            int i = 0;
            foreach (string folder in folders)
            {
                checkBoxes[i].Visible = true;
                checkBoxes[i].Text = folder;
                checkBoxes[i].Checked = (toSync.Contains(folder));
                i++;
            }
            if (i > 0) lblToSync.Visible = true;
        }
        private void LoadMainDirs(List<MainDirectory> mainDirs)
        {
            string mainDir = AC_SRU_Sync.Properties.Settings.Default.MainDirectories;
            string newDir = string.Join(";", mainDirs.Select(x => x.ftpDir._name));

            //nur neu laden, wenn sich was verändert hat
            if (!newDir.Equals(mainDir)){
                AC_SRU_Sync.Properties.Settings.Default.MainDirectories = newDir;
                AC_SRU_Sync.Properties.Settings.Default.ToSync = "";
                AC_SRU_Sync.Properties.Settings.Default.Save();
                LoadMainDirs();
                if (pnlSettings.Visible == false)
                {
                    pnlSettings.Visible = true;
                    btnShowSettings.Text = pnlSettings.Visible ? "-" : "+";
                }

            }
        }
        private void SaveMainDirs()
        {
            AC_SRU_Sync.Properties.Settings.Default.MainDirectories = string.Join(";", checkBoxes.Where(y => y.Value.Visible).Select(x => x.Value.Text));
            AC_SRU_Sync.Properties.Settings.Default.ToSync = string.Join(";", checkBoxes.Where(y => y.Value.Checked == true && y.Value.Visible).Select(x => x.Value.Text));
            AC_SRU_Sync.Properties.Settings.Default.Save();

        }
        #endregion
        #region CheckBeforeSync
        FTPDirectory rootDir;
        List<MainDirectory> mainDirectories;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.pnlStatus.Visible = true;
            this.pnlProgress.Visible = true;
            try {
                CheckFTPANDLocalFolders();
                if (mainDirectories.Count > 0)
                {
                    LoadMainDirs(mainDirectories);
                }
            }
            catch { }
            this.pnlProgress.Visible = false;
            this.Cursor = Cursors.Default;

        }

        private void CheckFTPANDLocalFolders()
        {
            DateTime start = DateTime.Now;
            pgbar.Maximum = 5;
            pgbar.Step = 1;
            pgbar.Value = 1;
            WriteLog("Check started at " + start.ToLongTimeString() + Environment.NewLine, false) ;
            if (CheckFTPServerNeu(txtFTP.Text) == false)
            {
                return;
            }
            pgbar.Value = 2;
            WriteLog("Successfull FTP Connection! Tree loaded with maxdeep of " + cmbDeep.Value.ToString("0") + " levels.");
            WriteLog("Elapsed: " + (DateTime.Now - start).TotalSeconds.ToString("0.00") + " s" + Environment.NewLine);
            start = DateTime.Now;
            if (CheckForContentFolders() == false)
            {
                return;
            }

            pgbar.Value = 3;
            int maxDeep = mainDirectories[1].ftpDir.Descendants().OrderByDescending(x => x._deep).First()._deep;
            WriteLog("Found Contentfolders: " + mainDirectories.Count + " with maxDeep of " + maxDeep );
            WriteLog("Elapsed:" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine);
            start = DateTime.Now;
            //Check AC Exe
            if (ACHelper.CheckLocalExeAndContentFolder(txtACEXE.Text) == false)
            {
                txtStatus.Text += "AC.exe or content folder not found! Check Path to Exe.";
                return;
            }
            pgbar.Value = 4;
            WriteLog("Compare folders in FileSystem" );
            bool canbeSyncd = false;
            foreach (MainDirectory mainDir in mainDirectories)
            {
                mainDir.ftpDirsToSync = ACHelper.CheckLocalFolder(txtACEXE.Text, mainDir);
                WriteLog("Subfolder " + mainDir.InfoString());
                if (mainDir.ftpDirsToSync.Count > 0)
                {
                    canbeSyncd = true;
                }
                btnSync.Enabled = canbeSyncd;
            }
            pgbar.Value = 5;
            WriteLog("Finished!!!" + Environment.NewLine + " Elapsed:" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine );
        }

        private Boolean CheckFTPServerNeu(string ftpServer)
        {
            try
            {
                if (GetFTPHelper().CheckConnection()==false)
                {
                    return false;
                }
                //Hier eventuell ohne user / Passwort
                rootDir = GetFTPHelper().GetFTPHoleTree(txtFTP.Text, "","", (int)cmbDeep.Value);
                return true;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                return false;
            }
        }
        private Boolean CheckForContentFolders()
        {
            try
            {
                mainDirectories = ACHelper.checkFolderForMainFolders(rootDir);
                return (mainDirectories.Count > 0);
            }
            catch
            {
                return false;
            }
        }


        private void WriteLog(string text, bool nlAtEnd=true)
        {
            lblStatus.Text = text.Replace(Environment.NewLine,"");
            if (nlAtEnd)
            {

                this.txtStatus.Text += System.Environment.NewLine + text;
            }
            else
            {
                this.txtStatus.Text = text;
            }
        }

        #endregion
        #region Sync
        private void btnSync_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.pnlStatus.Visible = true;
            this.pnlProgress.Visible = true;
            try
            {
                SyncAllSelectedMainDirs();

            }
            catch { }
            this.pnlProgress.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void SyncAllSelectedMainDirs()
        {
            DateTime start = DateTime.Now;
            txtStatus.Text = "Sync started at " + start.ToLongTimeString() + Environment.NewLine + Environment.NewLine;

            foreach (MainDirectory mainDir in mainDirectories)
            {
                if (AC_SRU_Sync.Properties.Settings.Default.ToSync.Contains(mainDir.ftpDir._name))
                {
                    WriteLog("Sync Folder " + mainDir.ftpDir._name);
                    int i = 1;
                    foreach (FTPDirectory ftpDir in mainDir.ftpDirsToSync)
                    {
                        WriteLog("Sync ObjectType " + ftpDir._parentDir._name + " Name: " + ftpDir._name + " " + (ftpDir.toAdd ? "add" : "sync"));
                        GetFTPHelper().DownloadFolder(ftpDir, this,i, mainDir.ftpDirsToSync.Count);
                        WriteLog("Elapsed :" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine);
                        start = DateTime.Now;
                        i++;
                    }
                }
            }
            WriteLog(Environment.NewLine + "Sync finished!");
        }

        public void SetProgress(int val, int max, string text="")
        {
            if (val > max) val = val % max;
            pgbar.Maximum = max;
            pgbar.Value = val;
            if (!text.Equals("")){
                lblStatus.Text = text;
            }
        }
        #endregion
        #region Start Assetto Corsa
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (ACHelper.CheckLocalExeAndContentFolder(txtACEXE.Text) == true)
            {
                System.Diagnostics.Process.Start(txtACEXE.Text);
            }

        }
        #endregion

        private void pnlSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = !pnlSettings.Visible ;
            btnShowSettings.Text = pnlSettings.Visible?"-":"+";
            
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            SaveMainDirs();
        }
    }
}

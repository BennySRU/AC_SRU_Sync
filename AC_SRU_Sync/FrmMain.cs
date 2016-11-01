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

namespace AC_SRU_Sync
{
    public partial class FrmMain : Form
    {
        //Variblen
        private FTPHelper ftpHelper;
        private SimpleAES simpleAES = new SimpleAES();
        private int deepToCheck = 7;
        public FrmMain()
        {
            InitializeComponent();
            txtFTP.Text = AC_SRU_Sync.Properties.Settings.Default.ftpPath;
            txtACEXE.Text = AC_SRU_Sync.Properties.Settings.Default.localPath;
            txtFtpUser.Text = AC_SRU_Sync.Properties.Settings.Default.ftpUser;
            if (!AC_SRU_Sync.Properties.Settings.Default.ftpPassword.Equals(""))
            {
                txtFtpPassword.Text = simpleAES.DecryptString(AC_SRU_Sync.Properties.Settings.Default.ftpPassword);
            }
            if (AC_SRU_Sync.Properties.Settings.Default.deep > 3)
            {
                deepToCheck = AC_SRU_Sync.Properties.Settings.Default.deep;
            }
            cmbDeep.Value = deepToCheck;
            btnSync.Enabled = false;

        }

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
            simpleAES.EncryptToString( txtFtpPassword.Text).Equals(AC_SRU_Sync.Properties.Settings.Default.ftpPassword))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region CheckBeforeSync
        FTPDirectory rootDir;
        List<MainDirectory> mainDirectories;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            txtStatus.Text = "Check started at " + start.ToLongTimeString() + Environment.NewLine + Environment.NewLine;
            if (CheckFTPServerNeu(txtFTP.Text) == false)
            {
                return;
            }
            txtStatus.Text += "Successfull FTP Connection! Tree loaded with maxdeep of " + cmbDeep.Value.ToString("0") + " levels.";
            WriteLog("Elapsed: " + (DateTime.Now - start).TotalSeconds.ToString("0.00") + " s" + Environment.NewLine);
            start = DateTime.Now;
            if (CheckForContentFolders() == false)
            {
                return;
            }
            int maxDeep = mainDirectories[1].ftpDir.Descendants().OrderByDescending(x => x._deep).First()._deep;
            txtStatus.Text += "Found Contentfolders: " + mainDirectories.Count + " with maxDeep of " + maxDeep + Environment.NewLine;
            txtStatus.Text += "Elapsed:" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine + Environment.NewLine;
            start = DateTime.Now;
            //Check AC Exe
            if (ACHelper.CheckLocalExeAndContentFolder(txtACEXE.Text) == false)
            {
                txtStatus.Text += "AC.exe or content folder not found! Check Path to Exe.";
                return;
            }
            txtStatus.Text += "Compare folders in FileSystem" + Environment.NewLine;
            bool canbeSyncd = false;
            foreach (MainDirectory mainDir in mainDirectories) {
                mainDir.ftpDirsToSync = ACHelper.CheckLocalFolder(txtACEXE.Text, mainDir); 
                txtStatus.Text += "Subfolder " + mainDir.InfoString() + Environment.NewLine;
                if (mainDir.ftpDirsToSync.Count > 0)
                {
                    canbeSyncd = true;
                }
                btnSync.Enabled = canbeSyncd;
            }
            txtStatus.Text += "Finished!!!" + Environment.NewLine + " Elapsed:" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine + Environment.NewLine;


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
            if (nlAtEnd)
            {
                this.txtStatus.Text += System.Environment.NewLine + text;
            }
        }

        #endregion
        #region Sync
        private void btnSync_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            txtStatus.Text = "Check started at " + start.ToLongTimeString() + Environment.NewLine + Environment.NewLine;
            
            foreach (MainDirectory mainDir in mainDirectories)
            {
                WriteLog("Sync Folder " + mainDir.ftpDir._name);
                foreach(FTPDirectory ftpDir in mainDir.ftpDirsToSync)
                {
                    WriteLog("Sync ObjectType " + ftpDir._parentDir._name + " Name: " + ftpDir._name);
                    GetFTPHelper().DownloadFolder(ftpDir);
                    WriteLog("Elapsed :" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine);
                    start = DateTime.Now;
                }
            }
            WriteLog(Environment.NewLine + "Sync finished!");
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

    }
}

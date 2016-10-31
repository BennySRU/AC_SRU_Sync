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

        public FrmMain()
        {
            InitializeComponent();
            txtFTP.Text = AC_SRU_Sync.Properties.Settings.Default.ftpPath;
            txtACEXE.Text = AC_SRU_Sync.Properties.Settings.Default.localPath;
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
            AC_SRU_Sync.Properties.Settings.Default.Save();
    }
        private bool HasSettingsChanged() {
            if (txtFTP.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.ftpPath) &&
            txtACEXE.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.localPath))
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
            txtStatus.Text += "Time:" + start.ToLongTimeString() + "\n\n";
            if (CheckFTPServerNeu(txtFTP.Text)==false)
            {
                return;
            }
            txtStatus.Text += "Elapsed:" + (DateTime.Now-start).Milliseconds + "ms\n\n";

            if (CheckForContentFolders())
            {
                return;
            }
            txtStatus.Text += "Found Contentfolders: " + mainDirectories.Count + "\n"; 
            txtStatus.Text += "Elapsed:" + (DateTime.Now - start).Milliseconds + "ms\n\n";
                

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
                rootDir = GetFTPHelper().GetFTPHoleTree(txtFTP.Text);
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
    }
}

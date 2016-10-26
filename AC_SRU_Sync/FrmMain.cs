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
        public FrmMain()
        {
            InitializeComponent();
            txtFTP.Text = AC_SRU_Sync.Properties.Settings.Default.ftpPath;
            txtACEXE.Text = AC_SRU_Sync.Properties.Settings.Default.localPath;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

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
        #region CheckBeforeSync
        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckFTPServerNeu(txtFTP.Text);
        }

        private Boolean CheckFTPServer(string ftpServer)
        {
            try
            {
                List<ftpinfo> directories = ftpHelper.getFTPTree(ftpServer, "", "");
                WriteLog("Files gefunden: " + directories.Count);
                foreach (var mainDirectory in directories.Where(x => x.fileType == directoryEntryTypes.directory).ToList())
                {
                    List<ftpinfo> subList = mainDirectory.getSubdirectories();
                    WriteLog(mainDirectory.filename + ": " + subList.Where(x => x.fileType == directoryEntryTypes.directory).Count() + " Ordner " + +subList.Where(x => x.fileType == directoryEntryTypes.file).Count() + " Files ");

                    foreach (var subDirectory in subList.Where(x => x.fileType == directoryEntryTypes.directory).ToList())
                    {
                        List<ftpinfo> subSubList = subDirectory.getSubdirectories();
                        WriteLog(subDirectory.filename + ": " + subSubList.Where(x => x.fileType == directoryEntryTypes.directory).Count() + " Ordner " + +subSubList.Where(x => x.fileType == directoryEntryTypes.file).Count() + " Files ");

                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
                return false;
            }
        }
        private Boolean CheckFTPServerNeu(string ftpServer)
        {
            try
            {
                List<FtpListItem> directories = ftpHelper.GetListItems(ftpServer,"");
                foreach (var mainDirectory in directories.Where(x => x.Type==FtpFileSystemObjectType.Directory ).ToList())
                {
                    List<FtpListItem> subList = ftpHelper.GetListItems(ftpServer,mainDirectory.FullName);
                    WriteLog(mainDirectory.FullName + ": " + subList.Where(x => x.Type == FtpFileSystemObjectType.Directory).Count() + " Ordner " + +subList.Where(x => x.Type == FtpFileSystemObjectType.File).Count() + " Files ");

                    foreach (var subDirectory in subList.Where(x => x.Type == FtpFileSystemObjectType.Directory).ToList())
                    {
                        List<FtpListItem> subSubList = ftpHelper.GetListItems(ftpServer,subDirectory.FullName);
                        WriteLog(subDirectory.FullName +": " + subSubList.Where(x => x.Type == FtpFileSystemObjectType.Directory).Count() + " Ordner " + +subSubList.Where(x => x.Type == FtpFileSystemObjectType.File).Count() + " Files ");

                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
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

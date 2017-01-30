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
using Microsoft.Win32;
using System.Threading;

namespace AC_SRU_Sync
{
    public partial class FrmMain : Form
    {
        //Variblen
        private FTPHelper ftpHelper;
        private SimpleAES simpleAES = new SimpleAES();
        private int deepToCheck = 7;
        private Dictionary<int, CheckBox> checkBoxes;
        private bool isLoading = true;
        private bool isSyncing = false;
        private bool isAborting = false;

        private Thread thread;

        //Attribute um das verschieben des Forms zu ermöglichen
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #region Laden und Form-Ereignisse
        public FrmMain()
        {
            InitializeComponent();

            LoadSettings();
            
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (AC_SRU_Sync.Properties.Settings.Default.DesktopLocationX >= 0 &&
                AC_SRU_Sync.Properties.Settings.Default.DesktopLocationY >= 0)
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseApplication();
            isAborting = true;
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
        #region Settings

        /// <summary>
        /// Lädt die Einstelungen aus den Usersettings
        /// </summary>
        private void LoadSettings()
        {
            txtFTP.Text = AC_SRU_Sync.Properties.Settings.Default.ftpPath;
            txtACEXE.Text = AC_SRU_Sync.Properties.Settings.Default.localPath;
            if (txtACEXE.Text.Equals(""))txtACEXE.Text = ACHelper.getACSFolder() + @"\AssettoCorsa.exe";
            txtFtpUser.Text = AC_SRU_Sync.Properties.Settings.Default.ftpUser;
            pnlSettings.Visible = AC_SRU_Sync.Properties.Settings.Default.SettingsVisible;
            btnShowSettings.Text = pnlSettings.Visible ? "-" : "+";

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
            btnStart.Enabled = false;

            checkBoxes = new Dictionary<int, CheckBox>();
            checkBoxes.Add(0, checkBox1);
            checkBoxes.Add(1, checkBox2);
            checkBoxes.Add(2, checkBox3);
            checkBoxes.Add(3, checkBox4);
            checkBoxes.Add(4, checkBox5);
            checkBoxes.Add(5, checkBox6);
            checkBoxes.Add(6, checkBox7);
            checkBoxes.Add(7, checkBox8);
            LoadMainDirsFromSettings();
            isLoading = false;
        }

        /// <summary>
        /// Close and Save Setting
        /// </summary>
        private void CloseApplication()
        {
            //Standardattribute speichern
            AC_SRU_Sync.Properties.Settings.Default.DesktopLocationX = this.DesktopLocation.X;
            AC_SRU_Sync.Properties.Settings.Default.DesktopLocationY = this.DesktopLocation.Y;
            AC_SRU_Sync.Properties.Settings.Default.SettingsVisible = pnlSettings.Visible;
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
        private bool HasSettingsChanged()
        {
            if (txtFTP.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.ftpPath) &&
            txtACEXE.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.localPath) &&
            cmbDeep.Value == AC_SRU_Sync.Properties.Settings.Default.deep &&
            txtFtpUser.Text.Equals(AC_SRU_Sync.Properties.Settings.Default.ftpUser) &&
            (txtFtpPassword.Text.Equals("") && AC_SRU_Sync.Properties.Settings.Default.ftpPassword.Equals("")) ||
            simpleAES.EncryptToString(txtFtpPassword.Text).Equals(AC_SRU_Sync.Properties.Settings.Default.ftpPassword))
            {
                return false;
            }
            else
            {
                return true;
            }
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

        private void LoadMainDirsFromSettings()
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
                return;
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
        private void LoadMainDirsFromFoundDirs(List<MainDirectory> mainDirs)
        {
            string mainDir = AC_SRU_Sync.Properties.Settings.Default.MainDirectories;
            string newDir = string.Join(";", mainDirs.Select(x => x.ftpDir.GetSeriesName()));

            //nur neu laden, wenn sich was verändert hat
            if (!newDir.Equals(mainDir))
            {
                AC_SRU_Sync.Properties.Settings.Default.MainDirectories = newDir;
                AC_SRU_Sync.Properties.Settings.Default.ToSync = "";
                AC_SRU_Sync.Properties.Settings.Default.Save();
                LoadMainDirsFromSettings();
                if (pnlSettings.Visible == false)
                {
                    pnlSettings.Visible = true;
                    btnShowSettings.Text = pnlSettings.Visible ? "-" : "+";
                }

            }
        }
        private void SaveMainDirsAndReload()
        {
            AC_SRU_Sync.Properties.Settings.Default.MainDirectories = string.Join(";", checkBoxes.Where(y => y.Value.Visible).Select(x => x.Value.Text));
            AC_SRU_Sync.Properties.Settings.Default.ToSync = string.Join(";", checkBoxes.Where(y => y.Value.Checked == true && y.Value.Visible).Select(x => x.Value.Text));
            AC_SRU_Sync.Properties.Settings.Default.Save();
            CheckSyncState();
        }
        #endregion
        #region CheckBeforeSync
        //FTPDirectoryDirect rootDirDirect;
        FTPDirectory rootDir;
        List<MainDirectory> mainDirectories;
        private void btnCheck_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            this.pnlStatus.Visible = true;
            this.pnlProgress.Visible = true;
            try
            {
                //RSyncHelper.CreateSignatur(@"sruadmin@race.hoferr.ch:/srv/ftp/acsync/legends", @"C:\temp\test.txt");  
                CheckFTPANDLocalFolders();

            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
            this.pnlProgress.Visible = false;
            this.Cursor = Cursors.Default;

        }

        private void CheckFTPANDLocalFolders()
        {
            DateTime start = DateTime.Now;
            pgbar.Maximum = 5;
            pgbar.Step = 1;
            pgbar.Value = 1;
            WriteLog("Check started at " + start.ToLongTimeString() + Environment.NewLine, false);
            if (checkFTPServer(txtFTP.Text) == false)
            {
                WriteLog("Sorry, could not conect to FTP Server!");
                WriteLog("Please check network connection and FTP-Settings");
                return;
            }
            pgbar.Value = 2;
            long size = rootDir.lstFiles.Select(x => x.SizeByte).Sum();
            WriteLog("Successfull FTP Connection! Content.txt loaded with " + rootDir.lstFiles.Count() + " Files with Total Size of " + ACHelper.FormatBytes(size));
            //WriteLog("Elapsed: " + (DateTime.Now - start).TotalSeconds.ToString("0.00") + " s" + Environment.NewLine);
            start = DateTime.Now;
            if (CheckForContentFolders() == false)
            {

                WriteLog("Sorry, no content Folder found on Server!");
                return;
            }

            pgbar.Value = 3;

            WriteLog("Found Contentfolders: " + mainDirectories.Count + " ");
            //WriteLog("Elapsed:" + (DateTime.Now - start).TotalSeconds.ToString("0.00") + "s" + Environment.NewLine);
            start = DateTime.Now;
            //Check AC Exe
            if (ACHelper.CheckLocalExeAndContentFolder(txtACEXE.Text) == false)
            {
                txtStatus.Text += "AC.exe or content folder not found! Check Path to Exe.";
                return;
            }
            pgbar.Value = 4;
            WriteLog("Compare folders in FileSystem");
            if (mainDirectories.Count > 0)
            {
                LoadMainDirsFromFoundDirs(mainDirectories);
            }
            foreach (MainDirectory mainDir in mainDirectories)
            {
                mainDir.ftpFilesToSync = ACHelper.CheckLocalFolder(txtACEXE.Text, rootDir, mainDir);
                WriteLog("Subfolder " + mainDir.InfoString());
            }
            CheckSyncState();
            pgbar.Value = 5;
            WriteLog(Environment.NewLine + "Check Finished!!! " + (btnStart.Enabled ? "You are ready to Start Assetto Corsa!" : "Please Sync your Folders!"));
        }

        private void CheckSyncState()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(CheckSyncState), new object[] {});
                return;
            }
            btnSync.Enabled = false;
            if (mainDirectories != null)
            {
                foreach (MainDirectory mainDir in mainDirectories)
                {
                    //WriteLog("Subfolder " + mainDir.InfoString());
                    if (mainDir.ftpFilesToSync != null)
                    {
                        if (AC_SRU_Sync.Properties.Settings.Default.ToSync.Contains(mainDir.ftpDir.GetSeriesName()) && mainDir.ftpFilesToSync.Count > 0)
                        {
                            btnSync.Enabled = true;
                        }
                    }
                }
                btnStart.Enabled = !btnSync.Enabled;
            }
            return;
        }

        private Boolean checkFTPServer(string ftpServer)
        {
            try
            {
                if (GetFTPHelper().CheckConnection() == false)
                {
                    return false;
                }
                //Hier eventuell ohne user / Passwort
                rootDir = GetFTPHelper().GetFTPHoleTreeByContentTXT(txtFTP.Text, "", "", this);
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


        private void WriteLog(string text, bool nlAtEnd = true)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string, bool>(WriteLog), new object[] { text, nlAtEnd });
                return;
            }
            lblStatus1.Text = text.Replace(Environment.NewLine, "");
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
            if (isSyncing == false)
            {
                this.Cursor = Cursors.WaitCursor;
                this.pnlStatus.Visible = true;
                this.pnlProgress.Visible = true;
                try
                {
                    isSyncing = true;
                    isAborting = false;
                    this.btnSync.Text = "Abort Sync";
                    this.btnSync.Cursor = Cursors.Default;
                    thread = new Thread(SyncAllSelectedMainDirs) { Name = "Father thread" };
                    thread.Start();

                }
                catch { }
                
            }
            else {
                isAborting = true;
                isSyncing = false;
                this.btnSync.Text = "Sync aborting...";
            }
        }
        private void StopProgress()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(StopProgress), new object[] {  });
                return;
            }
            btnSync.Text = "Sync with Server";
            this.pnlProgress.Visible = false;
            this.Cursor = Cursors.Default;
        }
        private void SyncAllSelectedMainDirs()
        {
            DateTime start = DateTime.Now;
            WriteLog(Environment.NewLine + "Sync started at " + start.ToLongTimeString() + Environment.NewLine);
            List<MainDirectory> toSync = mainDirectories.Where(x => AC_SRU_Sync.Properties.Settings.Default.ToSync.Contains(x.ftpDir.GetSeriesName())).ToList();
            long totalSizeLong = toSync.Select(x => x.ftpFilesToSync.Select(y => y.SizeByte).Sum()).Sum();

            double factor = totalSizeLong > Int32.MaxValue ? totalSizeLong / (double)Int32.MaxValue : 1;
            int totalSize = Convert.ToInt32(totalSizeLong / factor);
            int actSize = 0;
            
            SetProgress(actSize, totalSize);
            foreach (MainDirectory mainDir in toSync)
            {
                WriteLog("Sync Folder " + mainDir.ftpDir.GetSeriesName());
                string curObject = "";
                string curObjectType = "";
                
                foreach (FTPFile ftpFile in mainDir.ftpFilesToSync)
                {
                    if (!curObject.Equals(ftpFile.getSubFolder(2)))
                    {
                        if (!curObject.Equals(""))
                        {
                            WriteLog("Sync ObjectType " + curObjectType + " Name: " + curObject) ;
                        }
                        //start = DateTime.Now;
                        curObjectType = ftpFile.getSubFolder(1);
                        curObject = ftpFile.getSubFolder(2);

                    }
                    double seconds = actSize == 0 ? 0 : (totalSize /actSize * (DateTime.Now - start).TotalSeconds);

                    string time = actSize==0?" ?" : string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60); 
                    SetProgress(actSize, totalSize, ftpFile.FullPath + " Size " + ACHelper.FormatBytes(ftpFile.SizeByte) + "        (" + ACHelper.FormatBytes(Convert.ToInt64(actSize * factor)) + " / " + ACHelper.FormatBytes(totalSizeLong) + ")"," " + time);
                    GetFTPHelper().DownloadFile(ftpFile);
                    actSize += Convert.ToInt32(ftpFile.SizeByte / factor);

                    //Entfernen fürs weitermachen
                    mainDir.ftpFilesAlreadyDone.Add(ftpFile);
                    if (isAborting)
                    {
                        foreach (FTPFile file in mainDir.ftpFilesAlreadyDone)
                        {
                            mainDir.ftpFilesToSync.Remove(file);
                        }
                        WriteLog(Environment.NewLine + "Sync abborted!");
                        //this.Cursor = Cursors.Default;
                        btnStart.Enabled = false;
                        btnSync.Enabled = true;
                        isSyncing = false;
                        
                        StopProgress();
                        return; 
                    }
                }
                mainDir.ftpFilesToSync.Clear();
            }
            WriteLog(Environment.NewLine + "Sync finished!");
           
            StopProgress();
            CheckSyncState();
        }

        public void SetProgress(int val, int max, string text = "", string additionalText = "")
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<int,int,string,string>(SetProgress), new object[] {val,max,text,additionalText });
                return;
            }
            if (val > max) val = val % max;
            pgbar.Maximum = max;
            pgbar.Value = val;
            if (!text.Equals(""))
            {
                lblStatus1.Text = text;
            }
            lblStatus2.Text = additionalText;
        }
        #endregion
        #region Start Assetto Corsa
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartAC();

        }

        private void StartAC()
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
            pnlSettings.Visible = !pnlSettings.Visible;
            btnShowSettings.Text = pnlSettings.Visible ? "-" : "+";

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            SaveMainDirsAndReload();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            FrmInfo frmInfo = new FrmInfo();
            frmInfo.ShowDialog();
        }

        private void btnDirAC_Click(object sender, EventArgs e)
        {
            string path = "";
            if (txtACEXE.Text.Equals(""))
            {
                path = ACHelper.getACSFolder();
            }
            else
            {
                path = Path.GetFullPath(txtACEXE.Text);
            }

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.CheckFileExists = true;
            openfile.FileName = "AssettoCorsa.exe";
            openfile.InitialDirectory = path;
            DialogResult dlgRes = openfile.ShowDialog();

            if (dlgRes == DialogResult.OK)
            {
                if (File.Exists(openfile.FileName) && openfile.FileName.Contains("AssettoCorsa.exe"))
                {
                    this.txtACEXE.Text = openfile.FileName;
                    SaveSettings();

                }
            }
        }

        private void btnAllTogether_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            this.pnlStatus.Visible = true;
            this.pnlProgress.Visible = true;
            try
            {
                CheckFTPANDLocalFolders();
                if (btnSync.Enabled)
                {
                    SyncAllSelectedMainDirs();
                }
                if (btnStart.Enabled)
                {
                    this.Cursor = Cursors.Default;
                    this.pnlStatus.Visible = false;
                    this.pnlProgress.Visible = false;
                    StartAC();
                }
            }
            catch(Exception ex)
            {
                WriteLog(ex.Message);
            }
            this.Cursor = Cursors.Default;
            this.pnlStatus.Visible = false;
            this.pnlProgress.Visible = false;

        }

        private void lblSRU_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://simracing-united.net/");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

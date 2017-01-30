using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC_SRU_Skins
{
    public static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
        public static void StartWithSettings(int pDesktopLocationX,
                                            int pDesktopLocationY,
                                            string pftpPassword,
                                             string pftpPath,
                                             string pftpUser,
                                             string plocalPath,
                                             bool pSettingsVisible
                                             )
        {
            AC_SRU_Skins.Properties.Settings.Default.DesktopLocationX = pDesktopLocationX;
            AC_SRU_Skins.Properties.Settings.Default.DesktopLocationY = pDesktopLocationY;
            AC_SRU_Skins.Properties.Settings.Default.ftpPassword = pftpPassword;
            AC_SRU_Skins.Properties.Settings.Default.ftpPath = pftpPath;
            AC_SRU_Skins.Properties.Settings.Default.ftpUser = pftpUser;
            AC_SRU_Skins.Properties.Settings.Default.localPath = plocalPath;
            AC_SRU_Skins.Properties.Settings.Default.SettingsVisible = pSettingsVisible;

            FrmMain frmMain = new FrmMain();
            frmMain.Show();
        }
    }
}

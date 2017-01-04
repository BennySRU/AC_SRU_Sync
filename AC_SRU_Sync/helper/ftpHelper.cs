using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.FtpClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC_SRU_Sync
{
    public class FTPHelper
    {
        private string rootPath = "";
        private string _username = "";
        private string _password = "";
        private FtpClient _ftpClient;
        public FTPHelper(string pathToFTP, string username = "", string password = "")
        {
            rootPath = pathToFTP;
            _username = username;
            _password = password;
            if (_username.Equals("")) _username = "anonymous";
        }
        private String getFTPUri(String ftp)
        {
            if (!ftp.StartsWith("ftp://"))
            {
                ftp = "ftp://" + ftp;
            }
            return ftp;
        }
        private FtpClient getFTPClient()
        {
            try
            {
                if (_ftpClient == null || _ftpClient.IsConnected == false)
                {

                    _ftpClient = new FtpClient();
                    _ftpClient.Host = rootPath;
                    _ftpClient.Credentials = new NetworkCredential(_username, _password);
                    _ftpClient.Connect();
                }
            }
            catch { }
            return _ftpClient;
        }
        public Boolean CheckConnection() {
            try
            {
                return getFTPClient().IsConnected;
            }
            catch
            {
                return false;
            }
        }
        public FTPDirectoryDirect GetFTPHoleTree(string path, string username = "", string password = "", int maxDeep = 100, FrmMain frmMain = null)
        {
            FTPDirectoryDirect root = new FTPDirectoryDirect();
            root._name = path;
            root._fullpath = path;
            root._deep = 0;
            if (!path.Equals(rootPath) || getFTPClient().IsConnected == false)
            {
                rootPath = path;
                _username = username;
                _password = password;
                if (_username.Equals("")) _username = "anonymous";

            }
            if (getFTPClient().IsConnected == false)
            {
                return null;
            }
            //Root Elemente befüllen
            FillListItems(root, "", root._deep + 1, maxDeep, frmMain,1,10000);
            return root;
        }
        public FTPDirectory GetFTPHoleTreeByContentTXT(string path, string username = "", string password = "", FrmMain frmMain = null)
        {
            FTPDirectory root = new FTPDirectory(path);
            if (!path.Equals(rootPath) || getFTPClient().IsConnected == false)
            {
                rootPath = path;
                _username = username;
                _password = password;
                if (_username.Equals("")) _username = "anonymous";

            }
            if (getFTPClient().IsConnected == false)
            {
                return null;
            }
            List<string> content = ReadFile(root,"content.txt");

            ConvertContentToFTPFiles(root,content);


            return root;
        }

        private void ConvertContentToFTPFiles(FTPDirectory root, List<string> content)
        {
            long size = 0;
            string path = "";
            foreach (string line in content)
            {
                string[] splitty = line.Split('\t');
                if (splitty.Length > 1)
                {
                    if ( long.TryParse(splitty[0].Replace("B",""),out size))
                    {
                        path = splitty[1];

                        if ((path.Contains("content") || path.Contains("apps"))
                            && !path.Contains("content.txt")
                            )
                        {
                            //Create File
                            root.lstFiles.Add(new FTPFile(path, size));
                        }
                    }
                }

            }
        }

        private List<string>ReadFile(FTPDirectory ftpLy,string fileName)
        {
            List<string> inhalt = new List<string>();
            Stream ftpStream = getFTPClient().OpenRead(fileName);
            if ((int)ftpStream.Length == 0)
            {
                return inhalt;
            }
            var memoryStream = new MemoryStream();
            int bytesRead;
            byte[] buffer = new byte[16 * 1024];
            while ((bytesRead = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, bytesRead);
            }

            memoryStream.Flush();
            memoryStream.Position = 0;
            
            StreamReader reader = new StreamReader(memoryStream);
            while (reader.Peek() >= 0)
            {
                inhalt.Add(reader.ReadLine());
            }
            ftpStream.Close();
            reader.Close();
            return inhalt;

        }
        public void FillListItems( FTPDirectoryDirect dirToAdd,string subfolder = "",int deep=0,int maxDeep=100,FrmMain frmMain=null,int progressVal=0,int progressMax=1000)
        {
            List<FtpListItem> lstItems = getFTPClient().GetListing(subfolder).ToList();
            
            foreach (FtpListItem ftpli in lstItems)
            {
                progressVal += 1;
                if (frmMain != null) frmMain.SetProgress(progressVal, progressMax, "Found Folder " + ftpli.FullName + " (" + progressVal + ")");
                if (ftpli.Type == FtpFileSystemObjectType.Directory)
                {
                    FTPDirectoryDirect newDir = new FTPDirectoryDirect(ftpli.Name, ftpli.FullName,dirToAdd,dirToAdd._deep+1);
                    if (newDir._deep <= maxDeep)
                    {
                        FillListItems(newDir, newDir._fullpath, newDir._deep, maxDeep);

                    }
                    dirToAdd.subDirectories.Add(newDir);
                }
                else
                {
                    dirToAdd.lstFiles.Add(new FTPFileDirect(ftpli,dirToAdd));
                }
            }
            
        }
        public void DownloadFolder(FTPDirectoryDirect toSync, FrmMain frmMain,int curFolder,int maxFolder)
        {
            int curVal = curFolder * 3 + 1;
            int maxVal = maxFolder * 3;
            frmMain.SetProgress(curVal, maxVal,"Der Baum des Ordners(" + curFolder + "," + maxFolder +") wird noch einmal ganz durchsucht!");
            FillListItems(toSync, toSync._fullpath, toSync._deep + 1);
            //Verzeichnis erstellen
            if (!Directory.Exists(toSync._localPath))
            {
                Directory.CreateDirectory(toSync._localPath);
            }
            int anzObjekte = toSync.Descendants().Count();
            anzObjekte += toSync.Descendants().Select(x => x.lstFiles.Count).Sum();

            curVal = curVal + 1;
            frmMain.SetProgress(curVal, maxVal, "Ordner und Files werden angelegt! Anzahl Objekte:" + anzObjekte);
            curVal = anzObjekte * curVal;
            maxVal = anzObjekte *maxVal;
            CreateAllFilesAndFolders(toSync,  frmMain,curVal,maxVal);
        }
        private void CreateAllFilesAndFolders(FTPDirectoryDirect ftpDir, FrmMain frmMain, int curVal, int maxVal)
        {
            foreach (FTPDirectoryDirect dir in ftpDir.subDirectories)
            {
                dir._localPath = Path.Combine(ftpDir._localPath, dir._name);

                curVal++;
                frmMain.SetProgress(curVal, maxVal, "Ordner " + dir._localPath + " wird überprüft!");
                if (!Directory.Exists(dir._localPath))
                {

                    Directory.CreateDirectory(dir._localPath);
                }
                CreateAllFilesAndFolders(dir, frmMain,curVal,maxVal);
            }
            foreach(FTPFileDirect file in ftpDir.lstFiles)
            {
                try {
                    string destPath = Path.Combine(ftpDir._localPath, file.ftpListItem.Name);
                    using (var ftpStream = getFTPClient().OpenRead(file.ftpListItem.FullName))
                        if ((int)ftpStream.Length == 0)
                        {
                            if (!File.Exists(destPath))
                            {
                                System.IO.File.WriteAllLines(destPath, new string[0]);
                            }
                        }
                        else {
                            bool doOverwrite = true;
                            if (File.Exists(destPath))
                            {
                                byte[] file1 = File.ReadAllBytes(destPath);
                                if (file1.Length == file.ftpListItem.Size)
                                {
                                    doOverwrite = false;
                                }
                            }
                            if (doOverwrite)
                            {
                                using (var fileStream = File.Create(destPath, (int)ftpStream.Length))
                                {
                                    var buffer = new byte[8 * 1024];
                                    int count;
                                    while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        fileStream.Write(buffer, 0, count);
                                    }
                                }
                                frmMain.SetProgress(curVal, maxVal, "File " + destPath + " wird angelegt!");
                            }
                        }
                }
                catch
                {

                }
                curVal++;
            }
        }
        public bool DownloadFile(FTPFile fily)
        {

            try
            {
                string destPath = fily.LocalFullPath;
                if (!Directory.Exists(fily.getLocalFolder())){
                    //Create Folder
                    Directory.CreateDirectory(fily.getLocalFolder());

                }
                using (var ftpStream = getFTPClient().OpenRead(fily.FullPath))
                    if ((int)ftpStream.Length == 0)
                    {
                        if (!File.Exists(destPath))
                        {
                            File.Create(destPath).Dispose();
                        }
                        else
                        {
                            File.Create(destPath).Dispose();
                        }
                    }
                    else {
                        //bool doOverwrite = true;
                        //if (File.Exists(destPath))
                        //{
                        //    byte[] file1 = File.ReadAllBytes(destPath);
                        //    if (file1.Length == file.ftpListItem.Size)
                        //    {
                        //        doOverwrite = false;
                        //    }
                        //}
                        //if (doOverwrite)
                        //{
                            using (var fileStream = File.Create(destPath, (int)ftpStream.Length))
                            {
                                var buffer = new byte[8 * 1024];
                                int count;
                                while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, count);
                                }
                            }
                        //}
                    }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public class FTPFileDirect
    {
        public FTPFileDirect(FtpListItem file, FTPDirectoryDirect dir)
        {
            ftpListItem = file;
            ftpDirectory = dir;
        }

        public FtpListItem ftpListItem { get; set; }
        public FTPDirectoryDirect ftpDirectory { get; set; }

    }

}

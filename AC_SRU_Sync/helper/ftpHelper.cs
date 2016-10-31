using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.FtpClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        public void FillListItems( FTPDirectory dirToAdd,string subfolder = "",int deep=100)
        {
            List<FtpListItem> lstItems = getFTPClient().GetListing(subfolder).ToList();
            foreach (FtpListItem ftpli in lstItems)
            {
                if (ftpli.Type == FtpFileSystemObjectType.Directory)
                {
                    FTPDirectory newDir = new FTPDirectory(ftpli.Name, ftpli.FullName,dirToAdd);
                    if (deep > 0)
                    {
                        deep--;
                        FillListItems(newDir, newDir._fullpath,deep);

                    }
                    dirToAdd.subDirectories.Add(newDir);
                }
                else
                {
                    dirToAdd.lstFiles.Add(new FTPFile(ftpli,dirToAdd));
                }
            }
            
        }
        public FTPDirectory GetFTPHoleTree(string path, string username = "", string password = "", int deep=100)
        {
            FTPDirectory root = new FTPDirectory();
            root._name = path;
            root._fullpath = path;
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
            FillListItems(root, "",deep);
            return root;
        }
        public void DownloadFolder(FTPDirectory toSync)
        {
            FillListItems(toSync, toSync._fullpath);
            //Verzeichnis erstellen
            if (!Directory.Exists(toSync._localPath))
            {
                Directory.CreateDirectory(toSync._localPath);
                CreateAllFilesAndFolders(toSync);
            }
        }
        private void CreateAllFilesAndFolders(FTPDirectory ftpDir)
        {
            foreach (FTPDirectory dir in ftpDir.subDirectories)
            {
                dir._localPath = Path.Combine(ftpDir._localPath, dir._name);

                if (!Directory.Exists(dir._localPath))
                {
                    Directory.CreateDirectory(dir._localPath);
                    CreateAllFilesAndFolders(dir);
                }
            }
            foreach(FTPFile file in ftpDir.lstFiles)
            {
                try {
                    string destPath = Path.Combine(ftpDir._localPath, file.ftpListItem.Name);
                    using (var ftpStream = getFTPClient().OpenRead(file.ftpListItem.FullName))
                        if ((int)ftpStream.Length == 0)
                        {
                            System.IO.File.WriteAllLines(destPath, new string[0]);
                        }
                        else {
                            using (var fileStream = File.Create(destPath, (int)ftpStream.Length))
                            {
                                var buffer = new byte[8 * 1024];
                                int count;
                                while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, count);
                                }
                            }
                        }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
    public class FTPFile
    {
        public FTPFile(FtpListItem file, FTPDirectory dir)
        {
            ftpListItem = file;
            ftpDirectory = dir;
        }

        public FtpListItem ftpListItem { get; set; }
        public FTPDirectory ftpDirectory { get; set; }

    }

}

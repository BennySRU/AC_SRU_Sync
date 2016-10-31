using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public static class ACHelper
    {
        public  enum ContentTypes { cars, tracks}
        public static List<MainDirectory> checkFolderForMainFolders(FTPDirectory rootDir)
        {
            List<MainDirectory> mainDirs = new List<MainDirectory>();
            List<FTPDirectory> foundDir = rootDir.Descendants().Where(x => x._name.Equals("content")).ToList();
            if (foundDir.Count > 0)
            {
                foreach (FTPDirectory ftpDir in foundDir)
                {
                    if (ftpDir.Descendants().Where(x => getContentTypes().Contains( x._name)).Count()>0){
                        mainDirs.Add(new MainDirectory(ftpDir._parentDir));
                    }
                }
            }
            return mainDirs;
        }
        public static List<string> getContentTypes()
        {
            return Enum.GetNames(typeof(ContentTypes)).ToList();
        }

        public static List<FTPDirectory> CheckLocalFolder(string pathToExe, MainDirectory dirToCheck)
        {
            List<FTPDirectory> directoriesToSync = new List<FTPDirectory>();
           string acPath = Path.GetDirectoryName(pathToExe);
            //Erste Stufe Content / App
            foreach (FTPDirectory dirDeep1 in dirToCheck.ftpDir.subDirectories)
            {
                //Zweite Stufe Tracks / Cars
                foreach(FTPDirectory dirDeep2 in dirDeep1.subDirectories)
                {
                    //Dritte Stufe Inhalt
                    foreach (FTPDirectory dirDeep3 in dirDeep2.subDirectories)
                    {
                        string path = Path.Combine(new string[] { acPath, dirDeep1._name, dirDeep2._name, dirDeep3._name });
                        if (Directory.Exists(path)==false)
                        {
                            dirDeep3.toAdd = true;
                            directoriesToSync.Add(dirDeep3);
                        }
                        else
                        {
                            if (hasDiff(path, dirDeep3))
                            {
                                dirDeep3.toAdd = false;
                                directoriesToSync.Add(dirDeep3);
                            }
                        }

                    }
                }
            }
            return directoriesToSync;
        }
        /// <summary>
        /// Recursive scan of files an folders
        /// If something not exists or a Filesize not the same it will retunr true for the hole subfolder
        /// </summary>
        /// <param name="path"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static Boolean hasDiff(string path, FTPDirectory toCheck)
        {
            foreach (FTPFile ftpFile in toCheck.lstFiles)
            {
                if (File.Exists(Path.Combine(path, ftpFile.ftpListItem.Name)))
                {
                    byte[] file1 = File.ReadAllBytes(Path.Combine(path, ftpFile.ftpListItem.Name));
                    if (file1.Length != ftpFile.ftpListItem.Size)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            foreach (FTPDirectory ftpDir in toCheck.subDirectories)
            {
                if (hasDiff(Path.Combine(path, ftpDir._name), ftpDir))
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean CheckLocalExeAndContentFolder(string pathToExe)
        {
            if (!File.Exists(pathToExe))
            {
                return false;
            }
            else
            {
                string acPathContent = Path.GetDirectoryName(pathToExe);
                acPathContent = Path.Combine(acPathContent, "content");

                return Directory.Exists(acPathContent);
            }
        }
    }
}

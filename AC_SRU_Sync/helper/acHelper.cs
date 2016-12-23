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
            return rootDir.lstFiles.Select(x => x.getSerie()).Distinct().Select(y => new MainDirectory(new FTPDirectory( y),rootDir)).ToList();
        }
        public static List<string> getContentTypes()
        {
            return Enum.GetNames(typeof(ContentTypes)).ToList();
        }

        public static List<FTPFile> CheckLocalFolder(string pathToExe, FTPDirectory rootDir, MainDirectory dirToCheck)
        {
            List<FTPFile> filesToSync = new List<FTPFile>();
           string acPath = Path.GetDirectoryName(pathToExe);

            foreach (FTPFile file in rootDir.lstFiles.Where(x => x.getSerie().Equals(dirToCheck.ftpDir.PathOnServer)).ToList()){
                if (hasDiff(acPath,file))
                {
                    filesToSync.Add(file);
                }


            }
            return filesToSync;
        }
        /// <summary>
        /// Recursive scan of files an folders
        /// If something not exists or a Filesize not the same it will retunr true for the hole subfolder
        /// </summary>
        /// <param name="path"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static Boolean hasDiff(string path, FTPDirectoryDirect toCheck)
        {
            foreach (FTPFileDirect ftpFile in toCheck.lstFiles)
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
            foreach (FTPDirectoryDirect ftpDir in toCheck.subDirectories)
            {
                if (hasDiff(Path.Combine(path, ftpDir._name), ftpDir))
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean hasDiff(string path, FTPFile toCheck)
        {
            toCheck.LocalFullPath = Path.Combine(path, toCheck.getPathForLocalWithContent());
            if (File.Exists(toCheck.LocalFullPath))
            {
                long length =  new FileInfo(toCheck.LocalFullPath).Length;
                toCheck.ExistsLocal = true;
                if (length != toCheck.SizeByte)
                {
                    return true;
                }
                else { return false; }
            }
            else
            {
                return true;
            }
            
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

        public static string getACSFolder()
        {
            try
            {
                string steamFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86)
                    + @"\Steam\steamapps\libraryfolders.vdf";
                string folder = "";
                if (File.Exists(steamFolder))
                {
                    string[] text = File.ReadAllLines(steamFolder);

                    foreach (string line in text)
                    {
                        
                        string[] splitty = line.Split('\t');
                        int num = 0;
                        if (splitty.Length > 1)
                        {
                            //Wenns mit einer Zahl beginnt
                            if (int.TryParse(splitty[1].Replace("\"",""),out num))
                            {
                                folder = splitty.Last().Replace("\"", "");
                                string acsfolder = folder.Replace("\\\\", "\\") + @"\steamapps\common\assettocorsa";
                                if (Directory.Exists(acsfolder))
                                {
                                    return acsfolder;
                                }
                            }
                        }
                    }
                    return "";
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }


        }
        public static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

    }
}

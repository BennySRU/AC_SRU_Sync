using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Library
{
    public class MainDirectory
    {
        public FTPDirectory ftpDir { get; set; }
        public List<FTPDirectory> ftpDirsToSync { get; set; }
        public List<FTPFile> ftpFilesAlreadyDone { get; set; }
        public FTPDirectory rootFolder { get; set; }
        public List<FTPFile> ftpFilesToSync { get; set; }
        public MainDirectory(FTPDirectory dir, FTPDirectory root)
        {
            rootFolder = root;
            ftpDir = dir;
            ftpFilesAlreadyDone = new List<FTPFile>();
        }
        public string InfoString()
        {
            string toReturn = ftpDir.GetSeriesName() + " (";
            foreach (string subdir in ACHelper.getContentTypes())
            {
                var dirs = rootFolder.lstFiles.Where(x => x.getSerie() == ftpDir.PathOnServer && x.getSubFolder(1) == subdir).Select(y => y.getSubFolder(2)).Distinct().ToList();

                toReturn += subdir + ": " + dirs.Count + " ";
                //FTPDirectoryDirect dir = ftpDir.Descendants().Where(x => x._name.Equals(subdir)).FirstOrDefault();
                //if (dir != null)
                //{
                //    toReturn += dir._name + ": " + dir.subDirectories.Count + " " ;
                //}
            }
            toReturn += ")";

            if (ftpDirsToSync!=null && ftpDirsToSync.Count > 0)
            {
                if (ftpDirsToSync.Where(x => x.toAdd).Count() > 0)
                {
                    toReturn += " toAdd: " + ftpDirsToSync.Where(x => x.toAdd).Count();
                }

                if (ftpDirsToSync.Where(x => !x.toAdd).Count() > 0)
                {
                    toReturn += " toSync: " + ftpDirsToSync.Where(x => !x.toAdd).Count();
                }
            }
            if (ftpFilesToSync != null && ftpFilesToSync.Count > 0)
            {
                 toReturn += " toSync: " + ftpFilesToSync.Count + " Files ";
                foreach (string subdir in ACHelper.getContentTypes())
                {
                    var lstSubFolders = ftpFilesToSync.Where(x => x.getSubFolder(1).Equals(subdir)).Select(y => y.getSubFolder(2)).Distinct().ToList();
                    if (lstSubFolders.Count()>0)
                    {
                        toReturn += ", " + lstSubFolders.Count() + " " +subdir ;
                    }
                }
                long size = ftpFilesToSync.Select(x=>x.SizeByte).Sum();
                toReturn += " with Total Size of " + ACHelper.FormatBytes(size);
            }
            return toReturn;
        }
    }
}

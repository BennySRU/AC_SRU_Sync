using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public class MainDirectory
    {
        public FTPDirectory ftpDir { get; set; }
        public List<FTPDirectory> ftpDirsToSync { get; set; }
        public MainDirectory(FTPDirectory dir)
        {
            ftpDir = dir;
        }
        public string InfoString()
        {
            string toReturn = ftpDir._name + " (";
            foreach (string subdir in ACHelper.getContentTypes())
            {
                FTPDirectory dir = ftpDir.Descendants().Where(x => x._name.Equals(subdir)).FirstOrDefault();
                if (dir != null)
                {
                    toReturn += dir._name + ": " + dir.subDirectories.Count + " " ;
                }
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
            return toReturn;
        }
    }
}

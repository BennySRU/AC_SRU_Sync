using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public static class ACHelper
    {
        public static List<MainDirectory> checkFolderForMainFolders(FTPDirectory rootDir)
        {
            List<MainDirectory> mainDirs = new List<MainDirectory>();
            foreach (FTPDirectory dir in rootDir.subDirectories)
            {
                List<FTPDirectory> foundDir = rootDir.Descendants().Where(x => x._name.Equals("content")).ToList();
                if (foundDir.Count > 0)
                {
                    foreach (FTPDirectory ftpDir in foundDir)
                    {
                        if (ftpDir.Descendants().Where(x => x._name.Equals("tracks")).Count()>0){
                            mainDirs.Add(new MainDirectory(ftpDir));
                        }
                    }
                }
            }
            return mainDirs;
        }
    }
}

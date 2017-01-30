using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Library
{
    public class FTPDirectory
    {
        public List<FTPDirectory> subDirectories = new List<FTPDirectory>();
        public List<FTPFile> lstFiles = new List<FTPFile>();
        public string PathOnServer { get; set; }
        public bool toAdd { get; set; }
        public FTPDirectory(string path)
        {
            PathOnServer = path;
        }
        public bool IsContentFolder()
        {
            if (PathOnServer.Trim().EndsWith("content"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetSeriesName()
        {
            return PathOnServer.Split('\\')[0];
        }
    }
}

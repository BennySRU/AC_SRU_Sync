using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public class FTPFile
    {
        public string FullPath { get; set; }
        public long SizeByte { get; set; }
        public bool ExistsLocal{ get; set; }
        public string LocalFullPath { get; set; }
        public FTPFile(string path,long sizeByte)
        {
            FullPath = path;
            SizeByte = sizeByte;
            ExistsLocal = false;
        }
        public string getSerie()
        {
            return FullPath.Split('/')[0];
        }
        public string getSubFolder(int stufe)
        {
            return FullPath.Split('/')[stufe +1];
        }
        public string getPathForLocalWithContent()
        {
            return FullPath.Substring(getSerie().Length + 1).Replace('/','\\');
        }

        internal string getLocalFolder()
        {
            return Path.GetDirectoryName(LocalFullPath);
        }
    }
}

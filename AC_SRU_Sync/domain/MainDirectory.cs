using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    class MainDirectory
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<string> SubDirectories = new List<string>();
        public MainDirectory(string name,string path)
        {
            Name = name;
            if (!path.EndsWith("/"))path += "/";
            Path = path+name;
            fillSubDirectories();
        }
        public void fillSubDirectories()
        {
            SubDirectories.Clear();
            SubDirectories = ftpHelper.GetAllFoldersFTP(Path);
        }
        
    }
}

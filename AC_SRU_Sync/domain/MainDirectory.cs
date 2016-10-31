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
        
        public MainDirectory(FTPDirectory dir)
        {
            ftpDir = dir;        
        }
    }
}

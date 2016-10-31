using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public class FTPDirectory
    {
        public FTPDirectory()
        {
        }
        public FTPDirectory(string name, string fullpath)
        {
            this._name = name;
            this._fullpath = fullpath;
        }
        public string _name { get; set; }
        public string _fullpath { get; set; }
        public List<FTPDirectory> subDirectories = new List<FTPDirectory>();
        public List<FTPFile> lstFiles = new List<FTPFile>();
        
    }
    public static class FTPDirHelper
    {
        public static IEnumerable<FTPDirectory> Descendants(this FTPDirectory root)
        {
            var nodes = new Stack<FTPDirectory>(new[] { root });
            while (nodes.Any())
            {
                FTPDirectory node = nodes.Pop();
                yield return node;
                foreach (var n in node.subDirectories) nodes.Push(n);
            }
        }
    }
}

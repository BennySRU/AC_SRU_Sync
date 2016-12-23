using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public class FTPDirectoryDirect
    {
        public FTPDirectoryDirect()
        {
        }
        public FTPDirectoryDirect(string name, string fullpath, FTPDirectoryDirect parentDir, int deep)
        {
            this._name = name;
            this._fullpath = fullpath;
            _parentDir = parentDir;
            _deep = deep;
        }
        public string _name { get; set; }
        public string _fullpath { get; set; }
        public string _localPath { get; set; }
        public int _deep { get; set; }
        public FTPDirectoryDirect _parentDir;
        public List<FTPDirectoryDirect> subDirectories = new List<FTPDirectoryDirect>();
        public List<FTPFileDirect> lstFiles = new List<FTPFileDirect>();
        public bool toAdd;
    }
    public static class FTPDirHelper
    {
        public static IEnumerable<FTPDirectoryDirect> Descendants(this FTPDirectoryDirect root)
        {
            var nodes = new Stack<FTPDirectoryDirect>(new[] { root });
            while (nodes.Any())
            {
                FTPDirectoryDirect node = nodes.Pop();
                yield return node;
                foreach (var n in node.subDirectories) nodes.Push(n);
            }
        }
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

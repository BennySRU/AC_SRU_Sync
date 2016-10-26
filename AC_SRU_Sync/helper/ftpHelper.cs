using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.FtpClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AC_SRU_Sync
{
    public static class ftpHelper
    {

        public static List<string> GetAllFoldersFTP(string ftpServer)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(getUri(ftpServer));
            ftpRequest.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                if (!line.Contains("."))
                {
                    directories.Add(line);
                }
                line = streamReader.ReadLine();
            }

            streamReader.Close();
            return directories;
        }
        private static Uri getUri(String ftp)
        {
            if (!ftp.StartsWith("ftp://"))
            {
                ftp = "ftp://" + ftp;
            }
            return new Uri(ftp);
        }
        public static List<FtpListItem> GetListItems(string path,string subfolder, string _username = "anonymous", string _password = "") {
            FtpClient ftpClient = new FtpClient();
            ftpClient.Host = path;
            if (_username.Equals("")) _username = "anonymous";
            ftpClient.Credentials = new NetworkCredential(_username, _password);
            ftpClient.Connect();
            return ftpClient.GetListing(subfolder).ToList();
        }

        public static List<ftpinfo> getFTPTree(string path,string _username="",string _password="")
        {
            FtpWebRequest request=(FtpWebRequest)FtpWebRequest.Create(getUri( path));
            request.Method=WebRequestMethods.Ftp.ListDirectoryDetails;
            List<ftpinfo> files=new List<ftpinfo>();

        //request.Proxy = System.Net.WebProxy.GetDefaultProxy();
        //request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
        request.Credentials = new NetworkCredential(_username, _password);
        Stream rs = (Stream)request.GetResponse().GetResponseStream();
            
        StreamReader sr = new StreamReader(rs);
        string strList = sr.ReadToEnd();
        string[] lines = null;

        if (strList.Contains("\r\n"))
        {
            lines=strList.Split(new string[] {"\r\n"},StringSplitOptions.None);
        }
        else if (strList.Contains("\n"))
        {
            lines=strList.Split(new string[] {"\n"},StringSplitOptions.None);
        }

        //now decode this string array

        if (lines==null || lines.Length == 0)
            return null;

        foreach(string line in lines)
        {
            if (line.Length==0)
                continue;
                //parse line
            string pattern = 
                    @"^" +                          //# Start of line
@"(?<dir>[\-ld])" +             //# File size          
@"(?<permission>[\-rwx]{9})" +  //# Whitespace          \n
@"\s+" +                        //# Whitespace          \n
@"(?<filecode>\d+)" +
@"\s+" +                        //# Whitespace          \n
@"(?<owner>\w+)" +
@"\s+" +                        //# Whitespace          \n
@"(?<group>\w+)" +
@"\s+" +                        //# Whitespace          \n
@"(?<size>\d+)" +
@"\s+" +                        //# Whitespace          \n
@"(?<timestamp>\d{1,2}\s+\w+\s+\d{2}:\d{2})" +    //# Time or year        \n
@"\s+" +                        //# Whitespace          \n
@"(?<filename>(.*))" +          //# Filename            \n
@"$";                           //# End of line
                Regex regy = new Regex(pattern);
            Match m = regy.Match(line);
            if (m==null) {
                //failed
                throw new ApplicationException("Unable to parse line: " + line);
            }
            ftpinfo item = new ftpinfo();
item.filename = m.Groups[0].Value.Trim('\r');
            item.path = path;
            item.size = Convert.ToInt64(m.Groups["size"].Value);
            item.permission = m.Groups["permission"].Value;
            string _dir = m.Groups["dir"].Value;
            if(_dir.Length>0  && _dir != "-")
            {
                item.fileType = directoryEntryTypes.directory;
            } 
            else
            {
                item.fileType = directoryEntryTypes.file;
            }

            try
            {
                item.fileDateTime = DateTime.Parse(m.Groups["timestamp"].Value);
            }
            catch
            {
                item.fileDateTime = DateTime.MinValue; //null;
            }

            files.Add(item);
        }

        return files;
        }
    }
    public enum directoryEntryTypes
    {
        directory,
        file
    }
    public class ftpinfo
    {
        public string filename { get; set; }
        public string path{ get; set; }
        public Int64 size { get; set; }
        public string permission  { get; set; }
        public directoryEntryTypes fileType { get; set; }
        public DateTime fileDateTime { get; set; }
        private List<ftpinfo> subFtpInfos;
        public List<ftpinfo> getSubdirectories(bool reload = false)
        {
            if (reload || subFtpInfos == null)
            {
                subFtpInfos = ftpHelper.getFTPTree(path);
            }
            return subFtpInfos; 
        }

    }
}

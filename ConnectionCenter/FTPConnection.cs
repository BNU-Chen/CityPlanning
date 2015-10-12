using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionCenter
{
    public class FTPConnection
    {
        private static string ftpIP;
        private static string ftpPort;
        private static string ftpUserName;
        private static string ftpPassword;
        private static string ftpCatalog;  //初始化目录
                
        //FTP
        public static string FtpIP
        {
            get { return ftpIP.Trim(); }
            set { ftpIP = value; }
        }
        public static string FtpPort
        {
            get { return ftpPort.Trim(); }
            set { ftpPort = value; }
        }
        public static string FtpUserName
        {
            get { return ftpUserName.Trim(); }
            set { ftpUserName = value; }
        }
        public static string FtpPassword
        {
            get { return ftpPassword.Trim(); }
            set { ftpPassword = value; }
        }
        public static string FtpCatalog
        {
            get { return FTPConnection.ftpCatalog; }
            set { FTPConnection.ftpCatalog = value; }
        }
    }
}

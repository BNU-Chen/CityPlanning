using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionCenter
{
    public class Config
    {
        //FTP
        private static string fTPSection = "FTP";

        public static string FTPSection
        {
            get { return Config.fTPSection; }
            set { Config.fTPSection = value; }
        }
        private static string fTPIP = "ip";

        public static string FTPIP
        {
            get { return INIFile.IniReadValue(fTPSection, fTPIP); }
            set { INIFile.IniWriteValue(fTPSection, fTPIP, value); }
        }
        private static string fTPUser = "user";

        public static string FTPUser
        {
            get { return INIFile.IniReadValue(fTPSection, fTPUser); }
            set { INIFile.IniWriteValue(fTPSection, fTPUser, value); }
        }
        private static string fTPPsd = "pass";

        public static string FTPPsd
        {
            get { return INIFile.IniReadValue(fTPSection, fTPPsd); }
            set { INIFile.IniWriteValue(fTPSection, fTPPsd, value); }
        }
        private static string fTPCatalog = "catalog";

        public static string FTPCatalog
        {
            get { return INIFile.IniReadValue(fTPSection, fTPCatalog); }
            set { INIFile.IniWriteValue(fTPSection, fTPCatalog, value); }
        }

        //数据库连接
        private static string dbSection = "Database";

        public static string DbSection
        {
            get { return Config.dbSection; }
            set { Config.dbSection = value; }
        }

        private static string dbIP = "ip";

        public static string DbIP
        {
            get { return INIFile.IniReadValue(dbSection, dbIP); }
            set { INIFile.IniWriteValue(dbSection, dbIP, value); }
        }
        private static string dbCatalog = "catalog";

        public static string DbCatalog
        {
            get { return INIFile.IniReadValue(dbSection, dbCatalog); }
            set { INIFile.IniWriteValue(dbSection, dbCatalog, value); }
        }
        private static string dbUser = "user";

        public static string DbUser
        {
            get { return INIFile.IniReadValue(dbSection, dbUser); }
            set { INIFile.IniWriteValue(dbSection, dbUser, value); }
        }
        private static string dbPsd = "pass";

        public static string DbPsd
        {
            get { return INIFile.IniReadValue(dbSection, dbPsd); }
            set { INIFile.IniWriteValue(dbSection, dbPsd, value); }
        }

        //用户
        private static string userSection = "User";

        public static string UserSection
        {
            get { return Config.userSection; }
            set { Config.userSection = value; }
        }

        private static string userName = "name";

        public static string UserName
        {
            get { return INIFile.IniReadValue(userSection, userName); }
            set { INIFile.IniWriteValue(userSection, userName, value); }
        }
        private static string userPsd = "pass";

        public static string UserPsd
        {
            get { return INIFile.IniReadValue(userSection, userPsd); }
            set { INIFile.IniWriteValue(userSection, userPsd, value); }
        }

        //地图关键词
        private static string mapKeywordSection = "MapKeyword";

        public static string MapKeywordSection
        {
            get { return Config.mapKeywordSection; }
            set { Config.mapKeywordSection = value; }
        }

        //系统文档路径
        private static string sectionDocConfig = "DocConfig";

        public static string SectionDocConfig
        {
            get { return Config.sectionDocConfig; }
            set { Config.sectionDocConfig = value; }
        }

        private static string keyPlanDoc = "PlanDoc";

        public static string PlanDoc
        {
            get { return INIFile.IniReadValue(sectionDocConfig, keyPlanDoc); }
            set { INIFile.IniWriteValue(sectionDocConfig, keyPlanDoc, value); }
        }
        private static string keyPlanDesc = "PlanDesc";

        public static string PlanDesc
        {
            get { return INIFile.IniReadValue(sectionDocConfig, keyPlanDesc); }
            set { INIFile.IniWriteValue(sectionDocConfig, keyPlanDesc, value); }
        }
        private static string keyThematicMap = "ThematicMap";

        public static string ThematicMap
        {
            get { return INIFile.IniReadValue(sectionDocConfig, keyThematicMap); }
            set { INIFile.IniWriteValue(sectionDocConfig, keyThematicMap, value); }
        }
        private static string keyPlanImg = "PlanImg";

        public static string PlanImg
        {
            get { return INIFile.IniReadValue(sectionDocConfig, keyPlanImg); }
            set { INIFile.IniWriteValue(sectionDocConfig, keyPlanImg, value); }
        }
        private static string keyPlanMap = "PlanMap";

        public static string PlanMap
        {
            get { return INIFile.IniReadValue(sectionDocConfig, keyPlanMap); }
            set { INIFile.IniWriteValue(sectionDocConfig, keyPlanMap, value); }
        }
    }
}

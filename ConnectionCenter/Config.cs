using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConnectionCenter
{
    public class Config
    {
        #region //软件数据项配置
        private static string mapTableIndexName = "专题数据对照表";      //地图和表格的对照表
        private static string mapTableIndexFieldThematic = "专题文档名称";    //“专题文档名称”字段
        private static string mapTableIndexFieldTable = "表名称";    //“表名称”字段
        private static string mapTableIndexFieldMap = "地图文档名称";    //“地图文档名称”字段

        public static string MapTableIndexFieldThematic
        {
            get { return mapTableIndexFieldThematic; }
        }

        public static string MapTableIndexFieldTable
        {
            get { return mapTableIndexFieldTable; }
        }

        public static string MapTableIndexFieldMap
        {
            get { return mapTableIndexFieldMap; }
        }

        public static string MapTableIndexName
        {
            get { return mapTableIndexName; }
        }

        #endregion 

        #region //文档数据路径配置
        //FTP  ---------------------------------------------
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

        //数据库连接  ---------------------------------------------
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

        //用户  ---------------------------------------------
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

        //地图关键词  ---------------------------------------------
        private static string mapKeywordSection = "MapKeyword";

        public static string MapKeywordSection
        {
            get { return Config.mapKeywordSection; }
            set { Config.mapKeywordSection = value; }
        }
        #endregion

        #region //规划文档路径  
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
        #endregion

        #region//专题地图
        private static string sectionThematic = "ThematicMap";
        public static string SectionThematic
        {
            get { return Config.sectionThematic; }
            set { Config.sectionThematic = value; }
        }
        //基本红线
        private static string keyRedLineMap = "RedLineMap";
        public static string RedLineMap
        {
            get { return INIFile.IniReadValue(sectionThematic, keyRedLineMap); }
            set { INIFile.IniWriteValue(sectionThematic, keyRedLineMap, value); }
        }
        //交通网络
        private static string keyThematicTraffic = "ThematicTraffic";
        public static string ThematicTraffic
        {
            get { return INIFile.IniReadValue(sectionThematic, keyThematicTraffic); }
            set { INIFile.IniWriteValue(sectionThematic, keyThematicTraffic, value); }
        }
        public static string ThematicTrafficAnalystedMap
        {
            get
            {
                return getAnalystedPath(ThematicTraffic);
            }
        }
        public static string ThematicTrafficAnalystedXls
        {
            get
            {
                return getAnalystedXls(ThematicTraffic);
            }
        }
        //电力网络
        private static string keyThematicElectricity = "ThematicElectricity";
        public static string ThematicElectricity
        {
            get { return INIFile.IniReadValue(sectionThematic, keyThematicElectricity); }
            set { INIFile.IniWriteValue(sectionThematic, keyThematicElectricity, value); }
        }
        public static string ThematicElectricityAnalystedMap
        {
            get
            {
                return getAnalystedPath(ThematicElectricity);
            }
        }
        public static string ThematicElectricityAnalystedXls
        {
            get
            {
                return getAnalystedXls(ThematicElectricity);
            }
        }
        //灾害风险
        private static string keyThematicDisaster = "ThematicDisaster";
        public static string ThematicDisaster
        {
            get { return  INIFile.IniReadValue(sectionThematic, keyThematicDisaster); }
            set { INIFile.IniWriteValue(sectionThematic, keyThematicDisaster, value); }
        }
        public static string ThematicDisasterAnalystedMap
        {
            get
            {
                return getAnalystedPath(ThematicDisaster);
            }
        }
        public static string ThematicDisasterAnalystedXls
        {
            get
            {
                return getAnalystedXls(ThematicDisaster);
            }
        }
        //生态服务
        private static string keyThematicZoology = "ThematicZoology";
        public static string ThematicZoology
        {
            get { return INIFile.IniReadValue(sectionThematic, keyThematicZoology); }
            set { INIFile.IniWriteValue(sectionThematic, keyThematicZoology, value); }
        }
        public static string ThematicZoologyAnalystedMap
        {
            get
            {
                return getAnalystedPath(ThematicZoology);
            }
        }
        public static string ThematicZoologyAnalystedXls
        {
            get
            {
                return getAnalystedXls(ThematicZoology);
            }
        }
        //GDP重心转移
        private static string keyThematicGDPTrans = "ThematicGDPTrans";
        public static string ThematicGDPTrans
        {
            get { return INIFile.IniReadValue(sectionThematic, keyThematicGDPTrans); }
            set { INIFile.IniWriteValue(sectionThematic, keyThematicGDPTrans, value); }
        }
        public static string ThematicGDPTransAnalystedMap
        {
            get
            {
                return getAnalystedPath(ThematicGDPTrans);
            }
        }
        public static string ThematicGDPTransAnalystedXls
        {
            get
            {
                return getAnalystedXls(ThematicGDPTrans);
            }
        }
        //三维地图位置
        private static string keyThematic3DMap = "Thematic3DMap";
        public static string Thematic3DMap
        {
            get { return FTPCatalog + INIFile.IniReadValue(sectionThematic, keyThematic3DMap); }
            set { INIFile.IniWriteValue(sectionThematic, keyThematic3DMap, value); }
        }

        //获取分析后的地图路径
        private static string getAnalystedPath(string preMxd){
            string path = "";
            if (!File.Exists(preMxd))
            {
                return path;
            }
            try
            {
                string dir = Path.GetDirectoryName(preMxd);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(preMxd);
                string NAMEADD = " 后";
                string ext = Path.GetExtension(preMxd);
                path = dir + "\\" + fileNameWithoutExt + NAMEADD + ext;
                if (!File.Exists(path))
                {
                    path = "";
                }
            }
            catch { }
            return path;
        }
        //获取分析后的xls路径
        private static string getAnalystedXls(string preMxd)
        {
            string path = "";
            if (!File.Exists(preMxd))
            {
                return path;
            }
            try
            {
                string dir = Path.GetDirectoryName(preMxd);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(preMxd);
                string ext = ".xls";
                string extx = ".xlsx";
                path = dir + "\\" + fileNameWithoutExt + ext;
                if (!File.Exists(path))
                {
                    path = dir + "\\" + fileNameWithoutExt + extx;
                    if (!File.Exists(path))
                    {
                        path = "";
                    }
                }
            }
            catch { }
            return path;
        }

        #endregion 


    }
}

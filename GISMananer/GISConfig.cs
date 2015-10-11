using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace GISManager
{
    public class GISConfig
    {
        private static Dictionary<string, string> fieldToConvert = new Dictionary<string, string>();
        private static Dictionary<string, string> fieldToHide = new Dictionary<string, string>();

        public static Dictionary<string, string> FieldToHide
        {
            get 
            {
                fieldToHide.Clear();
                fieldToHide.Add("object", "");
                fieldToHide.Add("shape", "");
                fieldToHide.Add("shape_length", "");
                return GISConfig.fieldToHide; 
            }
        }

        public static Dictionary<string, string> FieldToConvert
        {
            get
            {
                fieldToConvert.Clear();
                fieldToConvert.Add("BSM", "标识码");
                fieldToConvert.Add("YSDM", "要素代码");
                fieldToConvert.Add("TBBH", "图斑编号");
                fieldToConvert.Add("DLBM", "地类编码");
                fieldToConvert.Add("DLMC", "地类名称");
                fieldToConvert.Add("QSDWMC", "权属单位名称");
                fieldToConvert.Add("ZLDWDM", "坐落单位代码");
                fieldToConvert.Add("ZLDWMC", "坐落单位名称");
                fieldToConvert.Add("TBDLMJ", "图斑地类面积");
                fieldToConvert.Add("TBMJ", "图斑面积");
                fieldToConvert.Add("XZQDM", "行政区代码");
                fieldToConvert.Add("XZQMC", "行政区名称");
                fieldToConvert.Add("KZMJ", "控制面积");
                fieldToConvert.Add("MSSM", "描述说明");
                fieldToConvert.Add("JZQMJ", "集中区面积");
                fieldToConvert.Add("NYDMJ", "农用地面积");
                fieldToConvert.Add("GDMJ", "耕地面积");
                fieldToConvert.Add("JBNTMJ", "基本农田面积");
                fieldToConvert.Add("SM", "说明");
                fieldToConvert.Add("GZQLXDM", "管制区类型代码");
                fieldToConvert.Add("GZQMJ", "管制区面积");
                fieldToConvert.Add("GNFQLXDM", "功能分区类型代码");
                fieldToConvert.Add("TDLYGNFQBH", "土地利用功能分区编号");
                fieldToConvert.Add("GNFQMJ", "功能分区面积");
                fieldToConvert.Add("XZQDWDM", "行政区地物代码");
                fieldToConvert.Add("F1", "年份");
                fieldToConvert.Add("X0", "经度");
                fieldToConvert.Add("Y0", "纬度");
                fieldToConvert.Add("FID_国家下发地类图", "国家下发地类图");
                return GISConfig.fieldToConvert; 
            }
        }

        /// <summary>
        /// 转换字段名称
        /// </summary>
        /// <param name="originName"></param>
        /// <returns></returns>
        public static string ConvertFieldName(string originName)
        {
            string name = "";

            if (HasChineseCharacter(originName))
            {
                name = originName;
            }
            else if (FieldToConvert.ContainsKey(originName.ToLower()))
            {
                name = FieldToConvert[originName.ToLower()];
            }
            else if(FieldToHide.ContainsKey(originName.ToLower()))
            {
                name = "";
            }
            //else
            //{
            //    name = originName;        //保留原来的字段名称
            //}

            return name;
        }

        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool HasChineseCharacter(string str)
        {
            bool containUnicode = false;
            if (str == "")
            {
                return containUnicode;
            }
            if (char.GetUnicodeCategory(str[0]) == UnicodeCategory.OtherLetter)
            {
                containUnicode = true;
            }
            return containUnicode;
        }
    }
}

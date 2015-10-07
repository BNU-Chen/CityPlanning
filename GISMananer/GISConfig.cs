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
                fieldToHide.Add("OBJECT", "");
                fieldToHide.Add("Shape", "");
                fieldToHide.Add("Shape_Length", "");
                return GISConfig.fieldToHide; 
            }
        }

        public static Dictionary<string, string> FieldToConvert
        {
            get
            {
                fieldToConvert.Add("BSM", "标识码");
                fieldToConvert.Add("YSDM", "要素代码");
                fieldToConvert.Add("KZMJ", "kzmj");
                fieldToConvert.Add("Shape_Area", "");
                fieldToConvert.Add("Shape_Area", "");
                fieldToConvert.Add("Shape_Area", "");
                fieldToConvert.Add("Shape_Area", "");
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
            else if(FieldToHide.ContainsKey(originName))
            {
                name = "";
            }
            else if (FieldToConvert.ContainsKey(originName))
            {
                name = FieldToConvert[originName];
            }

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

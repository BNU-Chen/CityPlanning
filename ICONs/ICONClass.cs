using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Drawing;

namespace ICONs
{
    public class ICONClass
    {
        public static Bitmap GetIconBitmap(string extension)
        {
            Bitmap bm = null;
            Assembly _assembly = Assembly.GetExecutingAssembly();
            _assembly = Assembly.GetExecutingAssembly();
            Stream _imageStream = _assembly.GetManifestResourceStream("ICONs.icons." + extension.ToLower() + ".png");
            try
            {
                if (_imageStream == null)
                {
                    return null;
                }
                bm = new Bitmap(_imageStream);
            }
            catch
            {
                bm = null;
            }
            return bm;
        }

        public static Image GetIconImage(string extension)
        {
            Image img = null;
            Assembly _assembly = Assembly.GetExecutingAssembly();
            _assembly = Assembly.GetExecutingAssembly();
            Stream _imageStream = _assembly.GetManifestResourceStream("ICONs.icons." + extension.ToLower() + ".png");
            try
            {
                if (_imageStream == null)
                {
                    return null;
                }
                Bitmap bm = new Bitmap(_imageStream);
                img = (Image)bm;
            }
            catch
            {
                img = null;
            }
            return img;
        }
    }
}

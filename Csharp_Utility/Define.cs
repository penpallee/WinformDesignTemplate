using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIL_MODULE
{
    public sealed class Define
    {
        public static string PATH = Application.StartupPath.Replace(@"bin\x64\Debug", @"Files\");
        public static string PATH_IMAGE = Application.StartupPath.Replace(@"bin\x64\Debug", @"Files\") + @"IMAGE\";
        public static string PATH_MODEL = Application.StartupPath.Replace(@"bin\x64\Debug", @"Files\") + @"Model.ini";
    }
}

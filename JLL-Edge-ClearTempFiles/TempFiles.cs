using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLL_Edge_ClearTempFiles
{
    class TempFiles
    {
        public static void DeleteAppDataTemp()
        {
            string appDataTempPath = Path.GetTempPath(); System.Windows.Forms.MessageBox.Show(appDataTempPath);
            Console.WriteLine($"Temporary folder in %appdata%/temp{SizeConversion.GetBytesReadable(ApplicationEdge.GetDirectorySize(appDataTempPath)).PadLeft(25, '.')}");
            ulong AppDataTempSizeDeleted = ApplicationEdge.EmptyFolder(appDataTempPath);
            Console.WriteLine($@"Cleaned {SizeConversion.GetBytesReadable(AppDataTempSizeDeleted)}");
        }
    }
}

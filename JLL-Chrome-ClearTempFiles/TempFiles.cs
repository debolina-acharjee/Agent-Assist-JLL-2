using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLL_Chrome_ClearTempFiles
{
    class TempFiles
    {
        public static void DeleteAppDataTemp()
        {
            string appDataTempPath = Path.GetTempPath(); MessageBox.Show(appDataTempPath);
            Console.WriteLine($"Temporary folder in %appdata%/temp{SizeConversion.GetBytesReadable(ApplicationChrome.GetDirectorySize(appDataTempPath)).PadLeft(25, '.')}");
            ulong AppDataTempSizeDeleted = ApplicationChrome.EmptyFolder(appDataTempPath);
            Console.WriteLine($@"Cleaned {SizeConversion.GetBytesReadable(AppDataTempSizeDeleted)}");
        }
    }

}
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Chrome_ClearTempFiles
{
    class ClearChrome
    {
        public static void ClearChromeCache()

        {

            if (ApplicationChrome.CheckApplicationExists())

            {

                string[] deletefolderchromecache1 = { ApplicationChrome.UserProfile, @"AppData\Local\Google\Chrome\User Data\Default\Cache\*" };

                string[] deletefolderchromecache2 = { ApplicationChrome.UserProfile, @"AppData\Local\Google\Chrome\User Data\Default\Cache2\entries\*" };

                string[] deletefolderchromecache3 = { ApplicationChrome.UserProfile, @"AppData\Local\Google\Chrome\User Data\Default\Cookies" };

                string[] deletefolderchromecache4 = { ApplicationChrome.UserProfile, @"AppData\Local\Google\Chrome\User Data\Default\Media Cache" };

                string[] deletefolderchromecache5 = { ApplicationChrome.UserProfile, @"AppData\Local\Google\Chrome\User Data\Default\Cookies-Journal" };

                string[] deletefolderchromecache6 = { ApplicationChrome.UserProfile, @"AppData\Local\Google\Chrome\User Data\Default\ChromeDWriteFontCache" };



                string[] deletefolderchromecache = { Path.Combine(deletefolderchromecache1), Path.Combine(deletefolderchromecache2), Path.Combine(deletefolderchromecache3), Path.Combine(deletefolderchromecache4), Path.Combine(deletefolderchromecache5), Path.Combine(deletefolderchromecache6) };



                foreach (string item in deletefolderchromecache)

                {

                    ProcessInvoke.Initiate(string.Format("/C cd \"{0}\" & del /f /q \"{1}\"", Path.GetFullPath(Path.Combine(item, @"..")), Path.GetFileName(item.TrimEnd(Path.DirectorySeparatorChar))), "cmd.exe");



                }



            }

            else

            {

                Environment.Exit(-1);

            }



        }


    }
}



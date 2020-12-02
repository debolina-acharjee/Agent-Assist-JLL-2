using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Edge_ClearTempFiles
{
    class ClearEdge
    {
        public static void ClearEdgeCache()
        {
            if (ApplicationEdge.CheckApplicationExists())
            {
                string[] deletefolderEdgecache1 = { ApplicationEdge.UserProfile, @"AppData\Local\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\MicrosoftEdge\Cookies" };
                string[] deletefolderEdgecache2 = { ApplicationEdge.UserProfile, @"AppData\Local\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\#!001\MicrosoftEdge\Cookies" };
                string[] deletefolderEdgecache3 = { ApplicationEdge.UserProfile, @"AppData\Local\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\#!002\MicrosoftEdge\Cookies" };


                string[] deletefolderEdgecache = { Path.Combine(deletefolderEdgecache1), Path.Combine(deletefolderEdgecache2), Path.Combine(deletefolderEdgecache3) };

                foreach (string item in deletefolderEdgecache)
                {
                    //ProcessInvoke.Start(string.Format("del /f /q \"{0}\"", item), "cmd.exe");
                    ProcessInvoke.Initiate(string.Format("/C cd \"{0}\" & rd \"{0}\"", item), "cmd.exe");
                }

            }
            else

            {
                Environment.Exit(-1);
            }

        }
    }
}
    


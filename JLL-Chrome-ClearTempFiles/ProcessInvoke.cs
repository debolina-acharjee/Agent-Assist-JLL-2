using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Chrome_ClearTempFiles
{
    class ProcessInvoke
    {
        public static void Initiate(string Arguments, string FileName)

        {

            System.Diagnostics.Process.Start(new ProcessStartInfo()

            {

                Arguments =Arguments,

                WindowStyle = ProcessWindowStyle.Hidden,

                CreateNoWindow = true,

                FileName = FileName



            });



        }

    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Chrome_ClearTempFiles
{
    class DeleteOnConsoleClose
    {
        private static HandlerRoutine hr;



        [DllImport("Kernel32")]

        private static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        private delegate bool HandlerRoutine();

        private static bool InspectControlType()

        {

           // Console.WriteLine(AssignValues.rm.GetString("String12"));

            Environment.Exit(-1);

            return true;

        }

        public static void DeleteFixlet()

        {



            Process.Start(new ProcessStartInfo()

            {

                Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + "\"" + System.Windows.Forms.Application.ExecutablePath + "\"",

                WindowStyle = ProcessWindowStyle.Hidden,

                CreateNoWindow = true,

                FileName = "cmd.exe"

            });

        }

        public static void Enabled()

        {

            AppDomain.CurrentDomain.ProcessExit += (o, s) => DeleteOnConsoleClose.DeleteFixlet();

            hr = new HandlerRoutine(InspectControlType);

            SetConsoleCtrlHandler(hr,true);

        }

    }

}


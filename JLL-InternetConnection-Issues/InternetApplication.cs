using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace JLL_InternetConnection_Issues
{
    class InternetApplication
    {
        public static string UserProfile

        {

            get; set;

        }

        public static string UserName

        {

            get; set;

        }

        static DateTime Start

        {

            get; set;

        }

        static DateTime End

        {

            get; set;

        }

       public static void HeaderInfo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;


            var process = Process.GetCurrentProcess(); // Or whatever method you are using
            string thisAppfullPath = process.MainModule.FileName;
            Console.WriteLine($"Fixlet Name: {typeof(Program).Namespace}");
            Console.WriteLine($"Size: {new System.IO.FileInfo(thisAppfullPath).Length / 1024} KB");
            Start = DateTime.Now;
            Console.WriteLine($"Start Time: {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
        }
        public static void GetUserProfileDirectory()
        {
            string cDrive = Path.GetPathRoot(Environment.SystemDirectory);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            UserName = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            UserProfile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
        }

        public static void FootInfo()

        {

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(Environment.NewLine);

            End = DateTime.Now;

            Console.WriteLine($"End Time: {DateTime.Now.ToLongTimeString()}");

            Console.WriteLine($"Execution Time: {End.Subtract(Start).TotalSeconds} seconds");

            Console.ReadKey();

        }
    }
}

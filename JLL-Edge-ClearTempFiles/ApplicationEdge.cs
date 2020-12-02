using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Edge_ClearTempFiles
{
    class ApplicationEdge
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

        public static string EdgePath
        {
            get; set;
        }
       private static string GetEdgePath()
        {
            string getEdgePath = @"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe";
            if (File.Exists(getEdgePath))
            {
                EdgePath = getEdgePath;
                return EdgePath;
            }

            return "NOT FOUND";
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
        public static void FootInfo()

        {

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(Environment.NewLine);

            End = DateTime.Now;

            Console.WriteLine($" {DateTime.Now.ToLongTimeString()}");

            Console.WriteLine($" {End.Subtract(Start).TotalSeconds} seconds");

            Console.ReadKey();



        }
        public static bool CheckApplicationExists()
        {

            {
                if (GetEdgePath() == "NOT FOUND")
                {
                    System.Windows.Forms.MessageBox.Show("Currently we do not support the version of the application installed on your device");
                    return false;
                }
                return true;
            }

        }

        public static void GetUserProfileDirectory()
            {
                string cDrive = Path.GetPathRoot(Environment.SystemDirectory);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
                ManagementObjectCollection collection = searcher.Get();
                UserName = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                UserProfile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
            }

           
        public static void LaunchApplication()

                {

                    System.Diagnostics.Process.Start(EdgePath);

                    System.Threading.Thread.Sleep(4000);

                }
        public static ulong EmptyFolder(string directoryName)

        {

            ulong accum = 0;

            DirectoryInfo directory = new DirectoryInfo(directoryName);

            foreach (FileInfo file in directory.GetFiles())

            {

                try

                {

                    accum += (ulong)file.Length;

                    file.Delete();

                }

                catch

                {

                    accum -= (ulong)file.Length;

                }



            }

            foreach (DirectoryInfo subDirectory in directory.GetDirectories())

            {

                ulong subDirectorySize = GetDirectorySize(subDirectory.FullName);

                try

                {

                    accum += subDirectorySize;

                    EmptyFolder(subDirectory.FullName);

                    subDirectory.Delete(true);

                }

                catch

                {

                    accum -= subDirectorySize;

                }

            }

            return accum;

        }
                public static ulong GetDirectorySize(string folderPath)

                {

                    ulong length = (ulong)Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Sum(t => (new FileInfo(t).Length));

                    return length;

                }


               
            }

        }
    

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLL_Chrome_ClearTempFiles
{
    class ApplicationChrome
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
        public static string GetChromePath

        {

            get; set;


        }
       
        public static void GetUserProfileDirectory()

        {



            string cDrive = Path.GetPathRoot(Environment.SystemDirectory);

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");

            ManagementObjectCollection collection = searcher.Get();



            UserName = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            UserProfile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);

            //UserName = Path.GetFileName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

            //UserProfile = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);

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
        public static void FootInfo()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            End = DateTime.Now;
            Console.WriteLine($"End Time: {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine($"Execution Time: {End.Subtract(Start).TotalSeconds} seconds");
            Console.ReadKey();
        }







        private static string GetChromeVersion()

        {

            string getChrome64BitPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            string getChrome32BitPath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";





            if (File.Exists(getChrome64BitPath))

            {

                GetChromePath = getChrome64BitPath;

                return "64";

            }

            else if (File.Exists(getChrome32BitPath))

            {

                GetChromePath = getChrome32BitPath;

                return "32";

            }

            return "NOT FOUND";

        }
        public static bool CheckApplicationExists()

        {

            if (GetChromeVersion() == "NOT FOUND")

            {

                MessageBox.Show("Currently we do not support the version of the application installed on your device");

                return false;

            }

            return true;



        }
        public static void LaunchApplication()

        {

            System.Diagnostics.Process.Start(GetChromePath);

            System.Threading.Thread.Sleep(4000);

        }
        public static void CloseApplication()

        {

            CloseProcess.KillProcessByNameAndUserName("chrome", ApplicationChrome.UserName);

        }
        public static void RestartApplication()

        {

            CloseApplication();

            System.Threading.Thread.Sleep(1000);

            LaunchApplication();


        }
        public static ulong GetDirectorySize(string folderPath)

        {

            ulong length = (ulong)Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Sum(t => (new FileInfo(t).Length));

            return length;

        }

        public static void DeleteChromeHistory()

        {

            CloseProcess.KillProcessByNameAndUserName("chrome", Environment.UserName);

            string chromeDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string filesAndFoldersToDel = chromeDirectoryPath + @"\Local Settings\Application Data\Google\Chrome\User Data\";

            System.IO.DirectoryInfo di = new DirectoryInfo(filesAndFoldersToDel);

            foreach (FileInfo file in di.GetFiles())

            {

                if (file.FullName != filesAndFoldersToDel + "Default\\Login Data")

               {

                    if (file.FullName != filesAndFoldersToDel + "Default\\Login Data-journal")

                    {

                        if (file.FullName != filesAndFoldersToDel + "Default\\Bookmarks")

                        {

                            if (file.FullName != filesAndFoldersToDel + "Default\\Preferences")

                           {

                             file.Delete();

                           }

                        }

                    }

               }

            }

            foreach (DirectoryInfo dir in di.GetDirectories())

            {

               foreach (FileInfo f in dir.GetFiles())

           {

               if (f.FullName != filesAndFoldersToDel + "Default\\Login Data")

                    {

                        if (f.FullName != filesAndFoldersToDel + "Default\\Login Data-journal")

                       {

                            if (f.FullName != filesAndFoldersToDel + "Default\\Bookmarks")

                           {

                               if (f.FullName != filesAndFoldersToDel + "Default\\Preferences")

                               {

                                   f.Delete();

                               }

                           }

                       }

                 }

                }

            }

        }

    }
}




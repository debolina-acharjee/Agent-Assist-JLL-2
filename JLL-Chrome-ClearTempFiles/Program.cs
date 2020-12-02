using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace JLL_Chrome_ClearTempFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DeleteOnConsoleClose.Enabled();
                ApplicationChrome.HeaderInfo();



                #region PreliminaryChecks

                Console.WriteLine("Checking the application chrome");

                ApplicationChrome.CheckApplicationExists();

                ApplicationChrome.GetUserProfileDirectory();

                #endregion



                #region Disclaimer

                var discInput = UserPrompt.Disclaimer("The program will attempt to fix Chrome issues.\nTroubleshooting requires that Chrome is closed.\nDo you want to proceed ?");

                if (discInput.ToString() == "No")

                {

                    UserPrompt.Disclaimer("Permission denied, program will now exit!");

                    return;

                }

                #region Clear Windows Temp Files

                //TempFile.DeleteAppDataTemp();
                // Directory.DirectoryDelete(@"C: \AppData\Local\Temp", "*", System.IO.SearchOption.AllDirectories);
                TempFiles.DeleteAppDataTemp();


                #endregion

                CloseProcess.KillProcessByNameAndUserName("Chrome", ApplicationChrome.UserName);

                #endregion
                #region LaunchingChrome
                ApplicationChrome.CheckApplicationExists();
                ApplicationChrome.LaunchApplication();

                #endregion

              

                #region Clear Chrome Cache
                ClearChrome.ClearChromeCache();
                Console.WriteLine("Clearing the Chrome Cache");
                #endregion

                #region Closing Chrome

                Console.WriteLine(("Closing Chrome"));

                CloseProcess.KillProcessByNameAndUserName("Chrome", ApplicationChrome.UserName);

                #endregion

                #region EndOfProgram               

                Console.WriteLine(("All the troubleshooting steps have been performed. Please restart your machine for the change to take place."));

                UserPrompt.FinalConfirmation(("All the troubleshooting steps have been performed. Please restart your machine for the change to take place."));

                #endregion

            }

            catch (Exception ex)

            {
                Console.WriteLine("Error Occurred" + ex);
            }

            finally

            {
                ApplicationChrome.FootInfo();

                DeleteOnConsoleClose.DeleteFixlet();
            }
        }
    }
}



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Edge_ClearTempFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            try

            {
                DeleteOnConsoleClose.Enabled();

                ApplicationEdge.HeaderInfo();

                #region PreliminaryChecks


                ApplicationEdge.CheckApplicationExists();

                ApplicationEdge.GetUserProfileDirectory();

                #endregion

                #region Disclaimer

                var discInput = UserPrompt.Disclaimer("The program will attempt to fix Edge issues.\nTroubleshooting requires that edge is closed.\nDo you want to proceed ?");

                if (discInput.ToString() == "No")

                {

                    UserPrompt.Disclaimer("Permission denied, program will now exit!");

                    return;
                }
                

                CloseProcess.KillProcessByNameAndUserName("Edge", ApplicationEdge.UserName);
                #endregion



                #region Clear Windows Temp Files
                Console.WriteLine("Clearing the Temporaryfiles");
                TempFiles.DeleteAppDataTemp();

                #endregion


                #region LaunchingEdge

                Console.WriteLine(("Launching Edge"));

                ApplicationEdge.CheckApplicationExists();
                ApplicationEdge.LaunchApplication();


                #endregion

                #region Clear Edge Cache
                ClearEdge.ClearEdgeCache();
                Console.WriteLine("Clearing the edge Cache");
                #endregion



                #region Closing Edge

                Console.WriteLine(("Closing Edge"));

                CloseProcess.KillProcessByNameAndUserName("Edge", ApplicationEdge.UserName);

                #endregion





                #region EndOfProgram               

                Console.WriteLine(("All the troubleshooting steps have been performed, Please restart your machine for the change to take place"));

                UserPrompt.FinalConfirmation(("All the troubleshooting steps have been performed, Please restart your machine for the change to take place"));

                #endregion

            }

            catch (Exception ex)

            {

                Console.WriteLine(("Something Went Wrong") + ex.StackTrace + ex.Message + ex.InnerException);

            }

            finally

            {

                ApplicationEdge.FootInfo();

                DeleteOnConsoleClose.DeleteFixlet();



            }

        }



    }





}
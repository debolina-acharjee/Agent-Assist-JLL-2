using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_InternetConnection_Issues
{
    class Program
    {
        static void Main(string[] args)
        {
            try

            {



                InternetApplication.HeaderInfo();
                InternetApplication.GetUserProfileDirectory();


                #region Disclaimer

                var discInput = UserPrompt.Disclaimer("The program will attempt to fix internet issues.\nDo you want to proceed ?");

                if (discInput.ToString() == "No")

                {

                    UserPrompt.Disclaimer("Permission denied, program will now exit!");

                    return;

                }
                #endregion

                #region AssignNewIPAddress
                Console.WriteLine("Running Command ipconfig /renew to assign new IP Address ");
                ElevateProcess.Invoke("ipconfig /renew", true);
                


                #endregion

                #region ReleaseCurrentIPConfiguration
                Console.WriteLine("Running Command ipconfig /release to release current IP Configuration");
                ElevateProcess.Invoke("ipconfig /release", true);
               

                #endregion

                #region ClearingDNSCache
                Console.WriteLine("Running Command ipconfig /flushdns  to  clear Dns Cache.");
                ElevateProcess.Invoke("ipconfig /flushdns", true);
                


                #endregion


                #region EndOfProgram               

                Console.WriteLine(("All the troubleshooting steps have been performed. Please restart your machine for the change to take place."));

                UserPrompt.FinalConfirmation(("All the troubleshooting steps have been performed. Please restart your machine for the change to take place."));

                #endregion

            }

            catch (Exception ex)

            {
                Console.WriteLine("Something went Wrong , Please try again" + ex);
            }

            finally

            {
                InternetApplication.FootInfo();


            }
        }

      

    }
}


            
           
 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_InternetConnection_Issues
{
    class Commandline
    {
        

            static string output;

            public static string Output

            {

                get

                {

                    return output;

                }

                set

                {

                    output = value;

                }

            }









            public static void Invoke(string command, bool waitTillExit = false, bool closeOutputWindow = false)

            {

                Output = "";

                ProcessStartInfo ProcessInfo;

                Process Process = new Process();





                ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + command);





                ProcessInfo.CreateNoWindow = false;

                ProcessInfo.UseShellExecute = false;



                ProcessInfo.RedirectStandardOutput = true;

                ProcessInfo.RedirectStandardError = true;

                Process.EnableRaisingEvents = true;

                Process = Process.Start(ProcessInfo);





                Process.ErrorDataReceived += ConsoleDataReceived;

                Process.OutputDataReceived += ConsoleDataReceived;





                Process.BeginOutputReadLine();

                Process.BeginErrorReadLine();





                if (waitTillExit == true)

                {

                    Process.WaitForExit();

                }

                if (closeOutputWindow == true)

                {

                    Process.CloseMainWindow();

                }





                Process.Close();

                Output.ToString();



            }





            private static void ConsoleDataReceived(object sender, DataReceivedEventArgs e)

            {

                if (e.Data != null)

                {

                    Output = Output + e.Data;

                }

            }





        }

    }


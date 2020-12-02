using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLL_InternetConnection_Issues
{
    class ElevateProcess
    {
        /// <summary>
        /// Invoke the Commandline arguments from the command given with elevated previlages. 
        /// </summary>
        /// <param name="command">CMD command</param>
        /// <param name="waitTillExit">If you want to wait for the command to execute</param>
        /// <param name="closeOutputWindow">Closes main window after execution for UI based application</param>
        public static void Invoke(string command, bool waitTillExit = false, bool closeOutputWindow = false)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo ProcessInfo;
                System.Diagnostics.Process Process = new System.Diagnostics.Process();
                ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + command);
                ProcessInfo.CreateNoWindow = false;
                ProcessInfo.Verb ="runas";
                ProcessInfo.UseShellExecute= true;
                Process.EnableRaisingEvents= true;
                Process = System.Diagnostics.Process.Start(ProcessInfo);
                if (waitTillExit == true)
                {
                    Process.WaitForExit();
                }
                if (closeOutputWindow == true)
                {
                    Process.CloseMainWindow();
                }
                Process.Close();
            }
            catch
            {
            }
        }
    }
}

  
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JLL_Chrome_ClearTempFiles
{
    class CloseProcess
    {
        //To Close Process with Window Handle
        public static void KillProcessByNameAndUserName(string processName, string userName)
        {
            var processes = from p in Process.GetProcessesByName(processName)
                            where GetProcessOwner(p.Id) == userName
                            select p;
            foreach (Process p in processes)
            {
                System.Threading.Thread.Sleep(1500);
                try
                {
                    p.Kill();
                }
                catch
                {
                   
                }
                p.WaitForExit();
                processes = from p1 in Process.GetProcessesByName(processName)
                            where GetProcessOwner(p1.Id) == userName
                            select p1;
                if (processes.Count() < 1)
                {
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }
        static string GetProcessOwner(int processId)
        {
            try
            {
                string query = "SELECT * From Win32_Process Where ProcessID =" + processId;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection processList = searcher.Get();
                ManagementObject mo = processList.OfType<ManagementObject>().FirstOrDefault();
                if (mo["ExecutablePath"] != null)
                {
                    string[] OwnerInfo = new string[2];
                    mo.InvokeMethod("GetOwner", (object[])OwnerInfo);
                    return OwnerInfo[0];
                }
            }
            catch
            {
                
            }
            return "NO OWNER";
        }
        public static void CloseProcessByNameAndUserName(string processName, string userName)
        {
            var processes = from p in Process.GetProcessesByName(processName)
                            where GetProcessOwner(p.Id) == userName
                            select p;
            foreach (Process p in processes)
            {
                System.Threading.Thread.Sleep(1500);
                try
                {
                    p.CloseMainWindow();
                }
                catch
                {
                    Console.WriteLine("This exception can be ignored");
                }
                p.WaitForExit();
                processes = from p1 in Process.GetProcessesByName(processName)
                            where GetProcessOwner(p1.Id) == userName
                            select p1;
                if (processes.Count() < 1)
                {
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
        }

    }
}
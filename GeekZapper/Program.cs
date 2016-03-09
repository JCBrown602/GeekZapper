/*
 * Jason Brown - 8 March, 2016
 * University of Advancing Technology
 * 
 * I'm learning how to use multi-threading and C#'s System.Diagnositics.Process class with lots of help from
 * http://http://www.dotnetperls.com/thread. The objective of the program is to find two unwanted processes,
 * if they exist, and kill them. If they return again (which they do), the program terminates them again. It
 * does this by using a while loop in two separate threads. In the future, I hope to revisit this program
 * and use more efficient methods and do some performance testing between the versions.
 * 
 * https://github.com/JCBrown602/GeekZapper
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace GeekZapper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Option to close the program
            Console.WriteLine("*******************************************");
            Console.WriteLine("\tPress CTRL+C to exit");
            Console.WriteLine("*******************************************");

            // One thread each for GeekBuddy and NowUSeeItPlayer
            Thread threadGeek = new Thread(new ThreadStart(GeekThread));
            Thread threadNowUSeeIt = new Thread(new ThreadStart(NowUSeeItThread));

            threadGeek.Start();
            threadNowUSeeIt.Start();

            threadGeek.Join();
            threadNowUSeeIt.Join();
        }
        
        // Threads
        static void GeekThread()
        {
            while (true)
            {
                //Thread.Sleep(100);
                //string process = "geekbuddyrsp";
                string process = "notepad";
                //Console.WriteLine(process.ToUpper());
                Process[] killList = GetProcesses(process);
                Console.WriteLine("Thread context: " + Thread.CurrentContext.ToString());
                KillProcess(killList);
            }
        }

        static void NowUSeeItThread()
        {
            while (true)
            {
                //Thread.Sleep(100);
                //string process = "nowuseeitplayer";
                string process = "firefox";
                //Console.WriteLine(process.ToUpper());
                Process[] killList = GetProcesses(process);
                KillProcess(killList);
            }
        }

        static Process[] GetProcesses(string processName)
        {
            Process[] byNameArray = Process.GetProcessesByName(processName);
            return byNameArray;
        }

        static void KillProcess(Process[] byNameArray)
        {
            List<string> processesList = new List<string>();
            foreach (Process processName in byNameArray)
            {
                Console.WriteLine("Process: {0} ID: {1}", processName.ProcessName, processName.Id);
                processName.Kill();
            }
        }


    }
}

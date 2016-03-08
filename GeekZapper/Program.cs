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
            // Sanity check
            Console.WriteLine("Hello kitty!");

            // User input - Do you want to start the program?
            Console.Write("> Would you like to play a game? (type 'y' or 'n'): ");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                Console.WriteLine("Ok. Let's get started.");
            }
            else
            {
                Console.WriteLine("Bye!");
            }

            Process tgtProcess = new Process();
            string processName = "";

            if (processName == "")
                Console.WriteLine("Process not found - string is empty");

            //processName = tgtProcess.ProcessName.ToString();

            Process[] processList = Process.GetProcesses();
            foreach (Process theProcess in processList)
            {
                Console.WriteLine("Process: {0} ID: {1}", theProcess.ProcessName, theProcess.Id);
            }

            Console.WriteLine("***************************");
            Process[] byNameList = Process.GetProcessesByName("notepad");
            foreach (Process theProcess in byNameList)
            {
                Console.WriteLine("Process: {0} ID: {1}", theProcess.ProcessName, theProcess.Id);
                theProcess.Kill();
            }

            // Multi-threads
            Thread thread1 = new Thread(new ThreadStart(A));
            Thread thread2 = new Thread(new ThreadStart(B));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }

        static void A()
        {
            Thread.Sleep(10000);
            Console.WriteLine('A');
        }

        static void B()
        {
            Thread.Sleep(100);
            Console.WriteLine('B');
        }


    }
}

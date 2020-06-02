using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Recipe_Scaler
{
    class MainClass
    {
        static string[] versionNames = new string[20];
        static int[] actualVersion = new int[20], actualVersionKeep = new int[20];
        static int currentLoop = 0, removeTopVersion;
        public static void getVersions(int versions, string versionName)
        {
            versionNames[currentLoop] = versionName;
            actualVersion[currentLoop] = versions;
            currentLoop++;
        }
        public static void Main(string[] args)
        {
            // wait for all versions to be added before continuing
            Thread.Sleep(600);
            // setting a "keep" variable of versions a the original will be disposed
            actualVersionKeep = actualVersion;
            Console.WriteLine("<This is for version testing only>");
            Console.WriteLine("Which version would you like to run?");
            for(int i = 0; i < currentLoop; i++)
            {
                // locating the lowest value in the array that isn't 0 (overwritten) as there are no V0's
                removeTopVersion = Array.IndexOf(actualVersion, actualVersion.Where(x => x != 0));

                Console.Write($"V{actualVersion[removeTopVersion]}");
            }
            Console.ReadLine();
            MainClassV1.InputMain(new string [0]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Scaler
{
    class MainClass
    {
        static string[] versionNames = new string[20];
        static int[] actualVersion = new int[20];
        static int currentLoop = 0;
        public static void getVersions(int versions, string versionName)
        {
            versionNames[currentLoop] = versionName;
            actualVersion[currentLoop] = versions;
            currentLoop++;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("<This is for version testing only>");
            Console.WriteLine("Which version would you like to run?");
            for(int i = 0; i < currentLoop)
            {

            }
            Console.ReadLine();
            MainClassV1.InputMain(new string [0]);
        }
    }
}

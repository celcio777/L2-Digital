using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
// program is NOT related to project, only for version choice and development
namespace Recipe_Scaler
{
    class MainClass
    {
        static List<Action> programVersions = new List<Action>();
        static string[] versionNames = new string[] { "Input","ChangeIngreds"};
        static int[] actualVersion = new int[] { 1,2};
        static string versionToRun;
        static int parsedVersion;
        
        public static void Main(string[] args)
        {
            programVersions.Add(() => MainClassV1.InputMain(new string[0]));
            programVersions.Add(() => MainClassV2.ChangeMain(new string[0]));
            Console.WriteLine("<This is for version testing only>");
            Console.WriteLine("Which version would you like to run?");
            for(int i = 0; i < actualVersion.Length; i++)
            {
                Console.WriteLine($"V{actualVersion[i]}: {versionNames[i]}");
            }

            versionToRun = Console.ReadLine();
            // taking the input and converting it to only numbers so it can be parsed.
            if(versionToRun.Length > 0)
            {
                versionToRun = new string(versionToRun.Where(c => Char.IsDigit(c) || c == '.' || c == ',').ToArray());
            }
            // parsing the string into a float before int in case of decimals
            float decimals = float.Parse(versionToRun);
            if(decimals > 0 && decimals < actualVersion.Max())
            {
                // rounding float to 0dp so it can go into integer
                parsedVersion = (int)Math.Round(decimals - 1, 0);
            }
            

            Console.WriteLine($"Now running version: {versionToRun}");
            programVersions[parsedVersion].Invoke();
        }
    }
}

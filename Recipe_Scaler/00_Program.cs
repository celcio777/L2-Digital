using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;

namespace Recipe_Scaler
{
    
    class MainClass { 


        
        static float[] measurementVal = new float[20];
        static float tempVal, ingredNumOut;
        static string[] measurementUnit = new string[20], /* array for checking if unit is valid */ unitList = new string[] { "c", "l", "ml", "g", "tsp", "tbsp", "kg" };
        
        static string tempUnit, tempValConvert;
        static string recipeName = "";
        static bool completedInput = false, endOfRecipe = false;
        // function for checking in array for variable
        static void checkArray(Array arrayForCheck, string stringForCheck)
        {
            
            for (int loopTimes = 0; loopTimes < arrayForCheck.Length; loopTimes++)
            {
                //checking to see if the input has already been verified before proceeding
                if (!completedInput)
                {
                    for(int innerLoops = 0;innerLoops < unitList.Length; innerLoops++)
                    {
                        if(stringForCheck == unitList[innerLoops])
                        {
                            completedInput = true;
                            goto breakOut;
                        }
                    }
                }
            }
        breakOut:;
        }
        // The loading function is defined here
        static void waitingProceed(int loops, bool useDots)
        {
            // this function shows a "loading symbol" to show the user that the
            // program is running inbetween sections.
            for (int loopTimes = 0; loopTimes < loops; loopTimes++)
            {
                Thread.Sleep(400);
                if (useDots)
                {
                    Console.Write(".");
                }
                Console.WriteLine("");
                
            }
            
        }
        // User input function begins here
        static void input(int ingredNum)
        {
            completedInput = false;
            while (!completedInput)
            {
                tempValConvert = Console.ReadLine();
                completedInput = float.TryParse(tempValConvert, out tempVal);

                if (completedInput)
                {
                    measurementVal[ingredNum] = tempVal;
                    waitingProceed(3, true);
                    // Confirmation of success and next instructions
                    //Console.WriteLine("Great, that was successful!, Now enter the measurement unit");
                    //Console.WriteLine("in shorthand. E.g: Cups = C, Milliliters = Ml, grams = g etc.");
                }
                else
                {
                    Console.WriteLine("Uh Oh! It looks like that wasn't a number! Please try again.");
                }
                Console.WriteLine("String: " + tempValConvert + " parsed output: " + tempVal + " successful parsing? " + completedInput);
            }
            // receiving next user input (unit)
            tempUnit = Console.ReadLine();
            tempUnit = tempUnit.ToLower();

        }
        // This is the main program
        public static void Main(string[] args)
        
        {
            // First basic instructions
            Console.WriteLine(
                "This program can covert measurements," +
                "e.g: Cups to Ml or vice versa, and can also scale recipes up & down." +
                "Feel free to use it!"
                );
            waitingProceed(3,true);
            Console.WriteLine("First off, what is the name of your recipe? ");
            recipeName = Console.ReadLine();
            waitingProceed(2, false);
            Console.WriteLine("Brilliant! Start off by first entering the ingerdient name." +
                "After confirmation, please enter the measurement value of that ingredient."
                );
            waitingProceed(1, false);
            Console.WriteLine("After confirmation that the value was valid, enter the unit of the ingredient");
            waitingProceed(1, false);
            Console.WriteLine("If you have done so correctly you will get a message stating you may proceed." +
                " Go ahead, try it!");
            // Ensuring that the user has understood correctly
            input(0);
            
            
        }
    }
}

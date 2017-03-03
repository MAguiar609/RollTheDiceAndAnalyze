using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceRoller
{
    class Program
    {

        static void Main(string[] args)
        {
            
            //set initial variables
            string input_numberOfDiceSides = "6";
            string input_HowManyDice = "";
            int howManyDice = 0;
            int diceSides = 6;
            int howManyRolls = 1;
            string input_NumberOfSides = "0";
            string input_HowManyRolls = "";


            Console.WriteLine("Hello! Time to play the dice math game...");
            Console.WriteLine("Please enter how many dice you would like to roll.");
            input_HowManyDice = Console.ReadLine();
            howManyDice = Convert.ToInt32(input_HowManyDice);
            diceResults diceResult = new diceResults();
            die[] diceCollection = new die[howManyDice];

            Console.WriteLine("Great! Now lets set how many sides you would like them to have.");

            for (int i = 0; i < howManyDice; i++)
            {

                Console.WriteLine("How many sides would you like dice {0} to have?", i + 1);
                input_NumberOfSides = Console.ReadLine();
                diceSides = Convert.ToInt32(input_NumberOfSides);
                diceCollection[i] = new die()
                {
                    numberOfSides = diceSides
                };
            }
            Console.WriteLine("Ok how many times do you want me to roll these dice?", input_numberOfDiceSides);
            input_HowManyRolls = Console.ReadLine();
            howManyRolls = Convert.ToInt32(input_HowManyRolls);
            Console.WriteLine("When you are ready for me to roll your dice, press ENTER", diceSides, howManyRolls);
            Console.ReadKey();
            RollTheDie(diceCollection, howManyRolls, diceResult);
            AnalyzeResults(diceCollection, diceResult);
            var rawResultsList = diceResult.rawResults.Select(p => p.ToString()).ToList();
            Console.WriteLine("RESULTS!");
            Console.Write("Raw Roll Results: ");
            diceResult.rawResults.Sort();
            foreach (var item in diceResult.rawResults)
            {
                Console.Write("{0} ", item);
            }
            Console.Write("\n");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Results Average:            | {0}", Math.Round(diceResult.average, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("Results Median:             | {0}", diceResult.median);
            Console.WriteLine("Results Mode:               | {0}", diceResult.mode);
            Console.WriteLine("Results Standard Deviation: | {0}", Math.Round(diceResult.standardDeviation, 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("Roll Total is               | {0}", diceResult.rollTotal);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Thanks For Playing!");
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();


        }

        private static void AnalyzeResults(die[] diceCollection, diceResults diceResult)
        {
            List<int> resultsList = new List<int>();

            for (int i = 0; i < diceCollection.Length; i++)
            {
                resultsList.AddRange(diceCollection[i].rollResult);
            }
            //get total
            diceResult.rollTotal = resultsList.Sum();
            //get average
            diceResult.average = resultsList.Average();
            //get median
            resultsList.Sort();
            if (resultsList.Count % 2 != 0)
            {
                diceResult.median = resultsList[resultsList.Count / 2];
            }
            else
            {
                int middle = resultsList.Count / 2;
                double first = resultsList[middle];
                double second = resultsList[middle - 1];
                diceResult.median = (first + second) / 2;
            }
            //get mode
            int? modeValue = resultsList.GroupBy(x => x).OrderByDescending(x => x.Count()).ThenBy(x => x.Key).Select(x => (int?)x.Key).FirstOrDefault();
            diceResult.mode = modeValue;
            //get standard deviation
            double average = resultsList.Average();
            double calc2 = resultsList.Select(val => (val - average) * (val - average)).Sum();
            diceResult.standardDeviation = Math.Sqrt(calc2 / resultsList.Count);
        }

        private static void RollTheDie(die[] diceCollection, int totalRolls, diceResults diceResult)
        {
            Random rand;


            rand = new Random();
            int currentRoll = 0;
            List<int> rawData = new List<int>();
            for (int j = 0; j < diceCollection.Length; j++)
            {
                List<int> resultsByDice = new List<int>();
                for (int i = 0; i < totalRolls; i++)
                {
                    currentRoll = rand.Next(1, diceCollection[j].numberOfSides);
                    resultsByDice.Add(currentRoll);
                    rawData.Add(currentRoll);

                }
                diceCollection[j].rollResult = resultsByDice;

            }
            diceResult.rawResults = rawData;

        }

        public class die
        {
            public int numberOfSides { get; set; }
            public List<int> rollResult { get; set; }
        }
        public class diceResults
        {
            public List<int> rawResults { get; set; }
            public int rollTotal { get; set; }
            public double average { get; set; }
            public double median { get; set; }
            public int? mode { get; set; }
            public double standardDeviation { get; set; }
        }
    }
}

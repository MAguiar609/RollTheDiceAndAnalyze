using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberOfDiceSidesInput = "6";
            string numberOfRollsInput = "1";
            int currentRoll;
            int currentRollTotal = 0;
            int diceSides = 6;
            int howManyRolls = 1;
            Random rand;
            rand = new Random();
            Console.WriteLine("Hey Gage, lets play!");
            Console.WriteLine("Please enter size of dice needed");
            numberOfDiceSidesInput = Console.ReadLine();
            diceSides = Convert.ToInt32(numberOfDiceSidesInput);
            Console.WriteLine("Ok how many times do you want me to roll this {0} sided die?",numberOfDiceSidesInput);
            numberOfRollsInput = Console.ReadLine();
            howManyRolls = Convert.ToInt32(numberOfRollsInput);
            Console.WriteLine("When you are ready for me to roll this {0} sided die {1} times, press enter", diceSides, howManyRolls);
            Console.ReadKey();
            for (int i = 0; i < howManyRolls; i++)
            {
                
                currentRoll = rand.Next(1, diceSides);
                Console.WriteLine("Roll: " + currentRoll);
                currentRollTotal = currentRoll + currentRollTotal;
            }
            Console.WriteLine("Roll Total is {0}",currentRollTotal);
            Console.WriteLine("Hope That Helped Gage!");
            Console.ReadLine();
        }
    }
}

using SchoolMathAndProgramming.Blogg;
using System.Collections;
using System.Collections.Generic;

/*
            "Good code is its own best documentation."
            - Steve McConnell
*/

namespace SchoolMathAndProgramming
{
    public class Program
    {


        //static void Main(string[] args)
        //{
        //    Random rand = new Random();
        //    List<int> dice = new List<int>();

        //    bool run = true;
        //    Console.WriteLine("\n\tWelcome to the Dice Generator!");
        //    while (run)
        //    {
        //        Console.WriteLine(
        //            "\n\t[1] Roll dice\n" +
        //            "\t[2] Check result\n" +
        //            "\t[3] Clear dice list" +
        //            "\t[4] Exit");
        //        Console.Write("\tChoose: ");
        //        // Started translating but ran out of energy. At least all variables are in English now :)
        //        int val;
        //        int.TryParse(Console.ReadLine(), out val);

        //        switch (val)
        //        {
        //            case 1:
        //                Console.Write("\n\tHur många tärningar vill du rulla: ");
        //                bool input = int.TryParse(Console.ReadLine(), out int numDice);

        //                if (input)
        //                {
        //                    for (int i = 0; i < numDice; i++)
        //                    {
        //                        // här kallar vi på metoden RullaTärning
        //                        // och sparar det returnerade värdet i 
        //                        // listan tärningar

        //                        dice.Add(RollD6(rand));
        //                    }
        //                }
        //                break;
        //            case 2:
        //                int sum = 0; // Skapar en int som ska innehålla medelvärdet av alla tärningsrullningar.
        //                if (dice.Count <= 0)
        //                {
        //                    Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("\n\tRullade tärningar: ");
        //                    foreach (int die in dice)
        //                    {
        //                        sum += die;
        //                        Console.WriteLine("\t" + die);
        //                    }

        //                    sum = sum / dice.Count;
        //                    Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + sum); // Här ska medelvärdet skrivas ut
        //                }

        //                break;
        //            case 3:
        //                dice.Clear(); // Added to let the user manually clear the list.
        //                break;
        //            case 4:
        //                // Moved Exit to last case for organisation
        //                Console.WriteLine("\n\tTack för att du rullade tärning!");
        //                Thread.Sleep(1000);
        //                run = false;
        //                break;
        //            default:
        //                Console.WriteLine("\n\tVälj 1-3 från menyn.");
        //                break;
        //        }
        //    }
        //}


        static int RollD6(Random rand) // renamed from RullaTärning
        {
            // Directly returns the rolled number, max exclusive.
            return rand.Next(1, 7);
        }
        static bool TryReadInt(out int value)
        {
            string input = Console.ReadLine();

            return int.TryParse(input, out value);
        }

        static int RollAnyDie(Random rand, int sides, int numDice)
        {
            int result = 0;
            for(int i = 0; i < numDice; i++)
            {
                result = rand.Next(1, sides);
            }
            return result;
        }

        static void Case1(List<int> dice, Random rand)
        {
            Console.Write("\n\tHur många tärningar vill du rulla: ");
            bool input = int.TryParse(Console.ReadLine(), out int antal);

            if (input)
            {
                for (int i = 0; i < antal; i++)
                {
                    // här kallar vi på metoden RullaTärning
                    // och sparar det returnerade värdet i 
                    // listan tärningar

                    dice.Add(RollD6(rand));
                }
            }

        }
        static void Case2(List<int> dice)
        {
            int sum = 0; // Init variable for summing dice rolls
            if (dice.Count <= 0)
            {
                Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
            }
            else
            {
                Console.WriteLine("\n\tRullade tärningar: ");
                foreach (int die in dice)
                {
                    sum += die;
                    Console.WriteLine("\t" + die);
                }

                sum = sum / dice.Count; // get median value of all rolls.
                Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + sum); // Här ska medelvärdet skrivas ut
            }

        }

    } 
}
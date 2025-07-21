using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    internal class DiceRoller
    {
        static bool _runApp = true;                 // Controls the main application loop
        static List<int> _numDice = new();


        //___//
        static void main()
        {
            Random rand = new Random();
            List<int> dice = new List<int>();

            bool run = true;
            Console.WriteLine("\n\tWelcome to the Dice Generator!");
            while (run)
            {
                Console.WriteLine("\n\t[1] Roll dice\n" +
                    "\t[2] Check result\n" +
                    "\t[3] Exit");
                Console.Write("\tChoose: ");
                int val;
                int.TryParse(Console.ReadLine(), out val);

                switch (val)
                {                    
                    case 1:
                        dice.Clear(); // Added so that the list of dice doesn't keep increasing. Rolling new dice now works correctly.
                        Console.Write("\n\tHur många tärningar vill du rulla: ");
                        bool input = int.TryParse(Console.ReadLine(), out int antal);

                        if (input)
                        {
                            for (int i = 0; i < antal; i++)
                            {
                                // här kallar vi på metoden RullaTärning
                                // och sparar det returnerade värdet i 
                                // listan tärningar
                                
                                dice.Add(RollDie(rand));
                            }
                        }
                        break;
                    case 2:
                        int sum = 0; // Skapar en int som ska innehålla medelvärdet av alla tärningsrullningar.
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

                            sum = sum / dice.Count;
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + sum); // Här ska medelvärdet skrivas ut
                        }

                        break;
                    case 3:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        run = false;
                        break;
                    default:
                        Console.WriteLine("\n\tVälj 1-3 från menyn.");
                        break;
                }
            }
        }
        //___//

        public static void Start()
        {
            main();
            //Select();


        }
        static void Select()
        {
            

            while (_runApp)
            {
                
                MenuList("[1] Roll dice", "[2] Check result", "[3] Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int num = SelectNumDice();
                        Console.WriteLine(num);
                        RollDice(num);

                        break;
                    case 2:


                        break;
                    case 3:


                        break;
                }
            }
        }

        static int RollDice(int numDice)
        {
            int result = 0;
            for (int i = 0; i > numDice +1; i++)
            {
                Random rand = new Random();
                result += rand.Next(1, 7);
                Console.WriteLine($"Result: {result}");
            }
            
            return result;
        }

        static int RollDie(Random rand)
        {
            return rand.Next(1, 7);
        }

        static int SelectNumDice()
        {
            Console.Write("Select number of dice: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            
            return value;
        }

        static void MenuList(params string[] choices)
        {
             // Goal: Create an agnostic method where you can write
             // any number of strings and print to console
             // It should be compact and pref not require much code outside of the method.
            foreach(string choice in choices)
            {
                Console.WriteLine(choice);
            }
        }


        static bool TryReadInt(out int value)
        {
            string input = Console.ReadLine();
            return int.TryParse(input, out value);
        }

    }
}

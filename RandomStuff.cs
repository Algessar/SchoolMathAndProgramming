using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    internal class RandomStuff
    {
        private string _name;

        static void AddOrMultiply()
        {
            int number = ReadInt("Write a number: ");
            int secondNumber = ReadInt("Write a second number: ");

            int choice;
            while (true)
            {
                Console.WriteLine("Do you want to Add [1] or Multiply [2]");
                choice = ReadInt("Choice: ");
                if (choice == 1 || choice == 2)
                {
                    break;
                }
                Console.WriteLine("Invalid choice! Try again.");
            }

            if (choice == 1)
            {
                Console.WriteLine($"Result: {number} + {secondNumber} = {number + secondNumber} ");
            }
            else if (choice == 2)
            {
                Console.WriteLine($"Result: {number} * {secondNumber} = {number * secondNumber} ");
            }

            //Console.WriteLine("Write a number!");
            //string input = Console.ReadLine();
            //int number;


            //// 
            //if(int.TryParse(input, out number))
            //{
            //    Console.WriteLine("Write a second number!");
            //    string secondInput = Console.ReadLine();
            //    int secondNumber;
            //    if(int.TryParse(secondInput, out secondNumber))
            //    {
            //        Console.WriteLine("Do you want to Add [1] or Multiply [2]");

            //        string choiceInput = Console.ReadLine();
            //        int choice;
            //        if (int.TryParse(choiceInput, out choice))
            //        {
            //            if(choice == 1)
            //            {
            //                int addedNumber = number + secondNumber;
            //                Console.WriteLine($"Result from addition: {number} + {secondNumber} = {addedNumber}");
            //            }
            //            if(choice == 2)
            //            {
            //                int multipliedNumber = number * secondNumber;
            //                Console.WriteLine($"Result from multiplication: {number} * {secondNumber} = {multipliedNumber}");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Invalid choice!");                    
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid input!");                
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input!");            
            //}
        }

        static void DumbSwedishSchoolExample()
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            int number;
            if (int.TryParse(input, out number))
            {
                Console.WriteLine($"Add or subtract 100?");
                Console.WriteLine("[1] Add 100");
                Console.WriteLine("[2] Subtract 100");

                string choiceInput = Console.ReadLine();
                int choice;

                if (int.TryParse(choiceInput, out choice))
                {
                    if (choice == 1)
                    {
                        number += 100;
                    }
                    else
                    {
                        number -= 100;
                    }

                    Console.WriteLine($" Result is: {number}");
                }
                else
                {
                    Console.WriteLine($"Invalid choice.");
                }
            }
            else
            {
                Console.WriteLine("Invalid number");
            }

            //Console.WriteLine("Var god skriv in en siffra:");
            //int siffra = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Vill du lägga till eller ta bort 100?");
            //Console.WriteLine("[1] Lägga till 100");
            //Console.WriteLine("[2] Ta bort 100");
            //int svar = Convert.ToInt32(Console.ReadLine());
            //if (svar == 1)
            //    siffra += 100;
            //else
            //    siffra -= 100;
            //Console.WriteLine("Resultatet är " + siffra);

        }

        static void Skip()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    //Console.WriteLine("Skipped 5");
                    continue;
                }
                Console.WriteLine($"Iteration {i}: ");
                Console.WriteLine("Done.");
            }

        }

        static void UseAGodDamnDict()
        {
            Dictionary<string, string> Dogs = new Dictionary<string, string>();



            Console.WriteLine("Input name of your dog.");
            string name = Console.ReadLine();
            Console.WriteLine("Input race of your dog.");
            string race = Console.ReadLine();
            Console.WriteLine("Input the owner's name.");
            string ownerName = Console.ReadLine();



            Dogs = new Dictionary<string, string>
        {
            {"Name", name},
            {"Race", race},
            {"Owner", ownerName }
        };

            //foreach( string key in Dogs.Keys)
            //{
            //    Console.WriteLine($"Definition: {key}");
            //}
            //foreach (string value in Dogs.Values)
            //{
            //    Console.WriteLine($"Definition: {value}");
            //}
            foreach (var element in Dogs)
            {
                Console.WriteLine($"Definition: {element.Key}, {element.Value}");
            }

        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }

                Console.WriteLine("Invalid input! Try again.");
            }
        }

        public void Write(string output)
        {
            Console.WriteLine(output);
        }

        static void CountTo100()
        {
            for (int i = 0; i < 101; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Count1To20()
        {
            for (int i = 1; i < 21; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}

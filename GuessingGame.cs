using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    internal class GuessingGame
    {
        static bool _runApp = true;
        static void StartProgram()
        {
            //Guess guess = new Guess();

            int input = 0;

            Console.WriteLine("Press [1] to play the fixed version of the supplied .cs GuessingGame.");
            Console.WriteLine("Press [2] to play the re-written and improved version!");
            while (_runApp)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input == 1)
                    {
                        GuessingGameFix();
                    }
                    if (input == 2)
                    {
                        MyGuessingGame();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, type [0] or [1]");
                }
            }
        }

        static void MyGuessingGame()
        {
            // Initiate variables
            bool run = true;
            int goalNumber = 0;
            int userGuess = 0;
            int numGuesses = 0;
            int rounds = 0;

            var random = new Random();
            // Roll a new number when the game starts
            goalNumber = random.Next(1, 21);
            Console.ForegroundColor = ConsoleColor.Magenta;

            //Tell the user what to do to win the game
            Console.WriteLine("\n\tWelcome to Elric's guessing game. Guess a number between 1 and 20 to test yourself!");


            while (run)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\n\tGuess a number between 1-20: ");
                // Get user input with error handling
                if (Int32.TryParse(Console.ReadLine(), out userGuess))
                {
                    // Iterate on guesses for "score" tracking
                    numGuesses++;

                    // Check win/lose conditions
                    if (userGuess < goalNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\tYou guessed too low!");
                    }
                    else if (userGuess > goalNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\tYou guessed too high!");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"\tYou guessed correctly! You win!\n");
                        Console.WriteLine($"\tYou got it after {numGuesses} guesses.");



                        rounds++;
                        Console.WriteLine($"\tYou've played {rounds} rounds");
                        // Ask if the user wants to play again
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nDo you want to play again? Continue: [1] Exit: [2] : ");
                        int input = 0;

                        // Input with error handling
                        if (Int32.TryParse(Console.ReadLine(), out input))
                        {
                            if (input == 1)
                            {
                                Console.Clear();
                                //run = true;
                                goalNumber = random.Next(1, 21);
                                //Console.WriteLine($"Guess a number between 1-20!");
                                numGuesses = 0;


                                if (rounds == 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine($"You've played {rounds} rounds. Is this really worth your time?");
                                    //NOTE: Should probably present the option to exit here, but eh. Exiting the game could also be a continous option.
                                }

                            }
                            else if (input == 2)
                            {
                                //Console.Clear();
                                run = false;
                                _runApp = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input was incorrect, type 1 or 2");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\tYour input was not a number, try again");
                }

            }
        }
        static void GuessingGameFix()
        {
            // Deklaration av variabler
            Random slumpat = new Random(); // skapar ett random objekt
            int speltal = slumpat.Next(1, 21); // anropar Next metoden för att skapa ett slumptal mellan 1 och 20 // Fault: not defining a range of numbers: 1-21, max exclusive.
            // läs på, vad är overload metoder? https://msdn.microsoft.com/en-us/library/system.random.next(v=vs.110).aspx
            bool spela = true; // Variabel för att kontrollera om spelet ska fortsätta köras

            while (spela) // Fault: Checking if false, but the bool is true at start
            {
                Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
                int tal = 0; // shitty error handling. Crashed on string input

                if (Int32.TryParse(Console.ReadLine(), out tal)) // changed error handling.
                {
                    if (tal < speltal)
                    {
                        Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");
                    }

                    else if (tal > speltal) //Fault: should be else if
                    {
                        Console.WriteLine("\tDet inmatade talet " + tal + " är för stort, försök igen."); // missing a sceond + after tal
                    }
                    //Fault: syntax error, = instead of == , if should be else, and the condition needs to be removed.
                    else
                    {
                        Console.WriteLine("\tGrattis, du gissade rätt!");
                        spela = false;
                        _runApp = false; // Addition to make game selection work.
                                         // Preference; always using braces .... actually not sure why adding braces made the code work. Before: ending after input. After braces: staying in the while loop.
                    }
                }
                else
                {
                    Console.WriteLine("\tFel input, skriv en siffra mellan 1 och 20."); // Added error message.
                }

            }
        }

    }
}

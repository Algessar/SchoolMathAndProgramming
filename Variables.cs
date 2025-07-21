using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    public class Variables
    {

        private int someInt;
        public void StringToIntConversion()
        {
            someInt = 1;
            // Tell the user what to do.
            Console.WriteLine("Type a number.");

            // Get the input.
            string input = Console.ReadLine();
            // "integer" is bad naming, but I'm honestly not sure what to call it otherwise. initialNumberInput?
            int integer = Convert.ToInt32(Console.ReadLine());

            // Inform what happened.
            Console.WriteLine("You wrote the number: " + integer);

            // Next instruction for the user.
            Console.WriteLine("Write another number to add to the first.");

            // Convert from string to int.
            //NOTE: This name (integer2) is also quite bad. I'll keep it like this for simplicity, but should maybe be renamed to numberToAdd.
            int integer2 = Convert.ToInt32(Console.ReadLine()); //NOTE: I honestly find this a bit confusing. It reads backwards to me, since declaration/initialization
                                                                // and the conversion is both integers in the code. I know ofc that the *input* (Console.ReadLine() is what
                                                                // is getting converted, but it's quite ... strange.        

            Console.WriteLine("Your second number to add is: " + integer2);
            Console.WriteLine("The result of both numbers added is: " + (integer + integer2));

        }

        static void StringToIntConversionWithErrorHandling()
        {
            Console.WriteLine("Type a number.");

            string input = Console.ReadLine();
            int integer = 2;

            if (int.TryParse(input, out int value))
            {
                Console.WriteLine("input + integer is: " + (value + integer));
                //or if you want to be fancy:
                //Console.WriteLine($"input + integer is (formatted) {value + integer}");
            }
            else
            {
                Console.WriteLine("Not a number!");
            }
            Console.WriteLine("Press any key to exit.");

        }


    }
}

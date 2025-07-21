using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    internal class Inventory2
    {
        // Program for a simple inventory management console app.

        static string[] _inventory = new string[5]; // Fixed-size inventory array (max 5 items) // NOTE: using an array in accordance to task, though a List would be better.

        static bool _runApp = true;                 // Controls the main application loop
        static bool _inventoryOpen = false;         // Tracks if the inventory menu is open
        static bool _addingItems = false;           // Tracks if the user is currently adding items

        //static void Main(string[] args)
        //{
        //    RunApp(); // Start the main application loop
        //}

        static void RunApp()
        {
            // Main application loop: alternates between closed and opened inventory menus
            while (_runApp)
            {
                // Show menu when inventory is closed
                do // testing do/while loop (works well, but can't say I quite understand it yet.)
                {
                    ShowClosedInventoryMenu();
                }
                while (!_inventoryOpen && !_addingItems);

                // Show menu when inventory is open
                do
                {
                    ShowOpenedInventoryMenu();
                }
                while (_inventoryOpen && !_addingItems);
            }
        }

        // Shows the menu when the inventory is closed and handles user input
        static void ShowClosedInventoryMenu()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            MenuTitle("Closed");

            Console.WriteLine();

            string[] choices = new string[]
            {
                "[1] - Open Inventory",
                "[2] - Close the program.\n"

            };
            foreach (string choice in choices)
            {
                Console.WriteLine($"{choice}");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            // Handle user input for closed menu
            //TryReadInt is a helper method at the bottom of the class. It calls TryParse and Readline.
            if (TryReadInt(out int value))
            {
                Console.WriteLine();

                switch (value)
                {
                    case 1:
                        _inventoryOpen = true;

                        break;
                    case 2:
                        Console.WriteLine("Closing the app.");
                        _runApp = false;
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"Input was not a number, please select between 1 and {choices.Length}\n");
            }
        }

        // Shows the menu when the inventory is open and handles user input
        static void ShowOpenedInventoryMenu()
        {
            _inventoryOpen = true;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            MenuTitle("Opened");

            Console.WriteLine("________");
            Console.WriteLine();

            string[] choices = new string[]
            {   "[1] - Add Items to your inventory",
                "[2] - Search items in the inventory",
                "[3] - Show all items in inventory.",
                "[4] - Empty Inventory.",
                "[5] - Close Inventory.\n",
                "[6] - Close the program.\n",

            };
            foreach (string choice in choices)
            {
                Console.WriteLine($"{choice}");
            }

            // Handle user input for opened menu
            if (TryReadInt(out int value))
            {
                switch (value)
                {
                    case 1:
                        AddToInventory();
                        break;
                    case 2:
                        SearchInventory();
                        break;
                    case 3:
                        ShowAllItems();
                        break;
                    case 4:
                        RemoveAllItems();
                        break;
                    case 5:
                        _inventoryOpen = false;
                        break;
                    case 6:
                        _inventoryOpen = false;
                        _runApp = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid input, choose between [1] and [6]\n");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Input was not a number, please select between 1 and {choices.Length}\n");
            }
        }

        // Prints the inventory menu title with current status (Opened/Closed)
        static void MenuTitle(string status)
        {
            Console.WriteLine("Inventory Menu");

            Console.WriteLine($"[Inventory Is {status}]");

        }

        // Prints a message and returns to the menu
        static void BackToMenu()
        {
            // Set text color to yellow to make it clear we're going back
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Going back to Menu.\n");
        }

        /// Case 1
        // Adds up to 5 items to the inventory array
        static void AddToInventory()
        {
            Console.WriteLine();
            Console.WriteLine("Add 5 items to your inventory: ");
            _addingItems = true;
            //NOTE: Debug
            //Console.WriteLine($"Bool addingItems = {_addingItems}");
            _inventory = new string[5]; // Reset inventory

            while (_addingItems)
            {
                for (int i = 0; i < _inventory.Length; i++)
                {
                    _inventory[i] = Console.ReadLine();
                    if (!string.IsNullOrEmpty(_inventory[i]))
                    {
                        var item = _inventory[i];
                        Console.WriteLine($"You added {item} to your inventory.");
                    }
                    else
                    {
                        i--;
                        Console.WriteLine("You didn't add an item. Try again: ");
                        continue;
                    }
                }
                _addingItems = false; // Stop adding after 5 items
            }
            Console.WriteLine();
            BackToMenu();
        }

        /// case 2
        // Searches for an item in the inventory by name (case-insensitive)
        static void SearchInventory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Write an item name to search for: ");
            Console.WriteLine();

            string search = Console.ReadLine();
            bool itemFound = false;

            if (!string.IsNullOrEmpty(search))
            {
                Console.WriteLine($"Searching through your inventory for {search}\n");
                for (int i = 0; i < _inventory.Length; i++)
                {
                    if (search.ToUpper() == _inventory[i].ToUpper()) // Try switching this
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"You searched for {search} and found it at index {i}!\n");
                        itemFound = true;
                        return;
                    }
                }

                if (itemFound == false)
                {
                    Console.WriteLine("The item you searched for doesn't exist! Try again\n");
                }
                BackToMenu();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You didn't write anything.");
                BackToMenu();
            }
        }

        /// case 3
        // Displays all items in the inventory, or a message if empty
        static void ShowAllItems()
        {
            Console.WriteLine();

            if (!_inventory.Contains(null))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var item in _inventory)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("(This makes Search a bit redundant, but including it since I had it in the Backpack (old Inventory) code.)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No items in inventory.\n");
            }
        }

        /// case 4
        // Clears all items from the inventory
        static void RemoveAllItems()
        {
            Console.WriteLine();
            _inventory = new string[5];
        }

        /// case 5
        // Set bool _inventoryOpen to false

        /// case 6
        // Set bool _runApp to false


        // Helper methods for TryParse. Gets repetitive writing the whole thing.
        // Tried really hard on my own for these, but since they are not part of the exercise I elected to ask CoPilot.
        // ... It also kinda feels like cheating that I can just let CoPilot generate a summary. (This is the only method I did it for.)
        /// <summary>
        /// Attempts to read an integer value from the console input.
        /// </summary>
        /// <remarks>This method reads a line of input from the console and attempts to parse it as an
        /// integer.  If the input is not a valid integer, the method returns <see langword="false"/> and sets 
        /// <paramref name="value"/> to 0.</remarks>
        /// <param name="value">When this method returns, contains the integer value parsed from the input,  if the parsing succeeded;
        /// otherwise, contains 0. This parameter is passed uninitialized.</param>
        /// <returns><see langword="true"/> if the input was successfully parsed as an integer;  otherwise, <see
        /// langword="false"/>.</returns>
        static bool TryReadInt(out int value)
        {
            string input = Console.ReadLine();

            return int.TryParse(input, out value);
        }

        static int ReadInt(string prompt = "Enter a number: ")
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Invalid input! Try again.");
            }
        }

        static void Color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }


    }
}

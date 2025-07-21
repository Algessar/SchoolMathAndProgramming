using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming
{
    public class Inventory
    {
        static List<string> _items = new();
        static bool _inventoryOpened = false;
        public void RunInventory()
        {
            bool run = true;

            // Keep the program running as long as run is true
            while (run)
            {
                //check if the inventory is opened or closed
                if (!_inventoryOpened)
                {
                    ShowClosedInventoryMenu();
                }
                else if (_inventoryOpened)
                {
                    ShowOpenedInventoryMenu();
                }

                // Wait for user input
                string menuInput = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(menuInput, out int value))
                {
                    switch (value)
                    {
                        case 1: // Opening the inventory.
                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            _inventoryOpened = true;
                            Console.WriteLine($"Inventory was opened!\n");

                            break;

                        case 2: // Add an item to your inventory.


                            if (!_inventoryOpened)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Inventory is not opened. Cannot add an item!");
                                BackToMenu();

                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Add an Item (write any word you like!): ");

                            string newItem = Console.ReadLine();
                            Console.WriteLine();

                            //Check if the user actually wrote anything
                            if (newItem.Length > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                _items.Add(newItem);
                                Console.WriteLine($"Successfully added {newItem} to your inventory!\n");
                                BackToMenu();
                                break;
                            }
                            // if not, return to menu without doing anything.
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("It doesn't seem like you wrote anything. Do so and THEN press Enter :)");

                                BackToMenu();
                                //Console.WriteLine();
                                break;
                            }

                        case 3:
                            if (_inventoryOpened)
                            {

                                Console.WriteLine("Closing inventory...\n");
                                BackToMenu();
                                _inventoryOpened = false;
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Inventory already closed! Ya silly goose!\n");
                                BackToMenu();
                                break;
                            }

                        case 4:
                            if (_items.Count < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are no items in the inventory, cannot show what doesn't exist.");
                                BackToMenu();
                                break;
                            }
                            if (_inventoryOpened)
                            {
                                int itemNumber = 0;
                                Console.WriteLine("These are you current items: ");
                                foreach (var item in _items)
                                {
                                    itemNumber++;

                                    Console.WriteLine(itemNumber + ". " + item + ", ");

                                }
                                Console.WriteLine("________\n");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Inventory not opened. You cannot see your items like this!");
                                BackToMenu();
                                break;
                            }
                            break;

                        case 5:
                            //Deleting all items.
                            if (!_inventoryOpened)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You can't remove your items when the inventory is closed!");

                                BackToMenu();
                                break;
                            }
                            if (_items.Count < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are no items in the inventory, cannot remove what doesn't exist.");
                                BackToMenu();
                                break;
                            }

                            if (_inventoryOpened)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Press [1] to Confirm deleting ALL items. Press [2] to Cancel.");
                                int choice = Convert.ToInt32(Console.ReadLine());
                                if (choice == 1)
                                {
                                    Console.WriteLine("You dumped all your items on the ground. The inventory is now empty!");
                                    BackToMenu();
                                    _items.Clear();
                                    //break; // Since the next condition is false, it goes to end break; Not sure I like
                                    //this since it's not explicit.

                                }
                                else if (choice == 2)
                                {
                                    Console.WriteLine("Seems you changed your mind. What do you want to do next?");
                                    BackToMenu();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input, choose [1] or [2]");

                                    BackToMenu();
                                    //break ; // last else goes out of the conditions and calls the end break;
                                }
                            }
                            break;

                        case 6:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("You sure you want to close the program? [1] to Accept, [2] to Cancel");
                            int confirm = Convert.ToInt32(Console.ReadLine());
                            if (confirm == 1)
                            {
                                Console.WriteLine("Closing the program. Press any key to close the window.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;

                                run = false;
                            }
                            else if (confirm == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("You want to stay? That's so nice of you :)");
                                BackToMenu();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input, select [1] or [2]!");
                            }
                            break;

                        default:
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("You need to choose one of available menu options.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not a number!");
                }
            }
        }

        static void ShowClosedInventoryMenu()
        {
            /*
                I would like this to be clearer for the user by only showing the available options.
                But at that point perfectionism kicks in and I'd want to add two switch statements depending on 
                if the inventory is opened or closed.
            */
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Inventory Menu");

            Console.WriteLine("________");
            Console.WriteLine();
            Console.WriteLine("[1] - Open Inventory");

            Console.WriteLine("These options are only available if you open your inventory!");

            Console.WriteLine("[2] - Add an Item to your inventory");

            Console.WriteLine("[3] - Close Inventory"); // should not be available, but making it unavailable seems like a pain

            Console.WriteLine("[4] - Show all items in the inventory"); // should not be available, but making it unavailable seems like a pain

            Console.WriteLine("[5] - Remove all items from Inventory"); // should not be available, but making it unavailable seems like a pain

            Console.WriteLine("[6] - Close the program.\n");

        }

        static void ShowOpenedInventoryMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("Inventory Menu");

            Console.WriteLine("[Inventory Is Opened]");

            Console.WriteLine("________");
            Console.WriteLine();

            Console.WriteLine("[2] - Add an Item to your inventory");

            Console.WriteLine("[3] - Close Inventory");

            Console.WriteLine("[4] - Show all items in the inventory");

            Console.WriteLine("[5] - Remove all items from Inventory");

            Console.WriteLine("[6] - Close the program.\n");
        }

        static void BackToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Going back to Menu.\n");

        }
    }    
}

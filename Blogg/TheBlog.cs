using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming.Blogg
{
    /*  Naming Conventions 
     * 
     *      Methods: PascalCase
     *      Properties: PascalCase
     *      Private variables: _camelCaseWithUnderline
     *      Public variables: camelCase
     *      Local variables: camelCase
     *      Arguments: camelCase
     *      Constants: ALL_CAPS
     *      Enums: PascalCase (both enum name and member names)
     */


    public class TheBlog
    {

        private static bool _runApp = true;
        private static bool _inMenu = true;
        private static bool _writePost = false;
        private static bool _editPost = false;
        private static int _searchCount = 0;

        private static List<string[,]> _blog = new List<string[,]>();
        private static string[,] _blogEntries = new string[0, 0]; 

        

        //static void Main(string[] args)
        //{
        //    while (_runApp)
        //    {
        //        Menu();
        //    }            
        //}
        static void Menu()
        {


            while (_inMenu && !_writePost)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\tWelcome to the amazing Console App blog post creator!\n");

                Console.ForegroundColor = ConsoleColor.Green;
                string[] choices = NumberedMenuList(
                    "Create post",
                    "Edit post",
                    "Search post",
                    "Print all posts",
                    "Delete a post",
                    "Sort posts",
                    "Exit");

                if (TryReadInt(out int value))
                {
                    switch (value)
                    {
                        case 1:
                            _inMenu = false;
                            CreatePost();
                            break;

                        case 2:
                            // Edit a post
                            _editPost = true;
                            break;

                        case 3:
                            // Search for a specific post and print it out
                            //SearchPost();
                            SearchPosts();
                            break;

                        case 4:
                            //Print out all written posts
                            PrintPosts();
                            break;

                        case 5:
                            // Delete a post
                            // Will include the search?
                            //DisplayTitles();
                            RemovePost();
                            break;

                        case 6:
                            // Sort
                            break;

                        case 7:
                            _inMenu = false;
                            _runApp = false;
                            break;

                        case 8:
                            _inMenu = true;
                            break;
                        default:
                            Console.WriteLine($"Input number not an option, choose between 1 and {choices.Length}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Input was not a number, try again and choose between 1 and {choices.Length}");
                }
            }

            static void CreatePost()
            {
                //TODO: If you write a title and the post, press enter and keep writing, this bugs out.

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Creating a post. Press Ctrl+E to save your post");
                _writePost = true;

                //while (_writePost)
                {                    
                    while (_writePost)
                    {
                        Console.WriteLine("Add a title and press enter: ");
                        var title = Console.ReadLine();
                        Console.WriteLine("Write your post: ");
                        var line = Console.ReadLine();

                        string[,] newPost = new string[1, 2];

                        string[] new1DPost = new string[2];

                        new1DPost[0] = title;
                        new1DPost[1] = line;
                        
                        ConsoleKeyInfo input = Console.ReadKey(true);
                        
                        newPost[0, 0] = title;
                        newPost[0, 1] = line;
                        if (input.Modifiers == ConsoleModifiers.Control && input.Key == ConsoleKey.E)
                        {
                            if (!string.IsNullOrEmpty(title))
                            {

                                _writePost = false;
                                _inMenu = true;
                                
                                SavePost(newPost);
                                PrintPosts();                                
                            }
                        }

                        //if(Console.ReadLine() == "SAVE")
                        //{
                        //    _writePost = false;
                        //    _inMenu = true;
                        //    newPost[0, 0] = title;
                        //    newPost[0, 1] = line;
                        //    _blogEntries = newPost;
                        //    SavePost(newPost);
                        //    PrintPosts();
                        //    //break;
                        //}
                    }
                }
            }

            static void SavePost(string[,] newPost)
            {
                _blog.Add(newPost);
                //_writePost = false;
                //PrintPosts(newPost);

            }

            // Required method:

            static void CountSearches()
            {
                _searchCount++;

                Console.Write($"Number of searches made: {_searchCount}");
            }




            //static int FindPost(string title)
            //{
            //    bool postFound = false;
            //    for (int i = 0; i < _blog.Count; i++)
            //    {
            //        foreach (var post in _blog)
            //        {
            //            if (title.ToUpper() == post[i, 0])
            //            {
            //                Console.WriteLine($"Search result: {title}");
            //                postFound = true;
            //                break;
            //            }                        
                            
            //        }
            //    }                    
            //    return 0;
            //}
            static void SearchPosts()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Write the title of a post to search for: ");
                Console.WriteLine();

                string search = Console.ReadLine();
                bool itemFound = false;

                if (!string.IsNullOrEmpty(search))
                {
                    Console.WriteLine($"Searching through posts for {search}\n");
                    for (int i = 0; i < _blog.Count; i++)
                    {
                        if (search.ToUpper() == _blog[i][0,0].ToUpper()) // Try switching this
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(value: $"You searched for {search} and found it at index {i}!\n");
                            itemFound = true;
                            return;
                        }
                    }

                    if (itemFound == false)
                    {
                        Console.WriteLine("The title you searched for doesn't exist! Try again\n");
                    }
                    //BackToMenu();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You didn't write anything.");
                    //BackToMenu();
                }
            }

            static void BinarySearch()
            {
                // Sort the list first

            }

            static void PrintPosts()
            {
                foreach (var str in _blog)
                {
                    for (int i = 0; i < str.GetLength(0); i++)
                    {
                        if (!string.IsNullOrEmpty(str[i, 0]) && !string.IsNullOrEmpty(str[i, 1]))
                        {
                            Console.WriteLine($"Title: {str[i, 0]}, Text: {str[i, 1]}");
                        }
                        //TODO: prints out content just fine, but requires error handling and dynamic search
                    }
                }
            }

            static void RemovePost()
            {
                DisplayTitles();
                Console.Write("Select the index # to delete: ");
                if(TryReadInt(out int index))
                {
                    _blog.RemoveAt(index-1);
                }
                
            }

            static bool TryReadInt(out int value)
            {
                string input = Console.ReadLine();

                return int.TryParse(input, out value);
            }

            /// <summary>
            /// Displays a list of menu options to the console. params argument allows for "option1, option2" as input instead of an array.
            /// </summary>
            /// <remarks>If no arguments are provided, the method will not display any output.</remarks>
            /// <param name="choices">An array of strings representing the menu options to display. Each string is written to the console on a new
            /// line.</param>
            static string[] MenuList(params string[] choices)
            {

                foreach (string choice in choices)
                {
                    Console.WriteLine(choice);
                }
                return choices;
            }

            static string[] NumberedMenuList(params string[] choices)
            {
                int index = 0;
                foreach (string choice in choices)
                {
                    index++;
                    Console.WriteLine($"\t[{index}] {choice}");
                }
                return choices;
            }

            static void DisplayTitles()
            {
                Console.WriteLine($"\t Titles of current blog posts: ");
                int index = 0;
                foreach (var str in _blog)
                {
                    index++;
                    for (int i = 0; i < str.GetLength(0); i++)
                    {
                        if (!string.IsNullOrEmpty(str[i, 0]) && !string.IsNullOrEmpty(str[i, 1]))
                        {
                            Console.WriteLine($"[{index}]\t Title: {str[i, 0]}");

                        }
                        //TODO: prints out content just fine, but requires error handling and dynamic search
                    }
                }
            }
        }

        public struct Post
        {

        }
    }
}


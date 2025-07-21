

namespace SchoolMathAndProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.Json;
    using System.Threading.Tasks;

    internal class TheBlog2
    {
        public static List<string[]> _blog = new List<string[]>();
        static bool _runApp = true;
        static bool _inMenu = true;
        static bool _isWriting = false;
        private static bool _editPost = false;
        static int _numSearches = 0;

        static void Main(string[] args)
        {
            while (_runApp)
            {
                Menu();
            }
        }

        private static void CountSearches()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if(_numSearches == 0)
            {
                Console.WriteLine("No searches have been made before.");
                _numSearches++;
                Console.WriteLine($"Number of searches is now: {_numSearches}");
            }
            else
            {
                _numSearches++;
                Console.WriteLine($"Number of searches is now: {_numSearches}");
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tWelcome to the amazing Console App blog post creator!\n");

            GenerateTestData(100);


            while (_inMenu && !_isWriting)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\tMain menu");
                Console.WriteLine("\t_________\n");

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
                    Console.WriteLine();
                    switch (value)
                    {
                        case 1:
                            _inMenu = false;
                            CreatePost();
                            break;

                        case 2:
                            // Edit a post
                            _editPost = true;
                            EditPost();
                            break;

                        case -11:
                            // Search for a specific post and print it out
                            
                            int time = SearchPosts();
                            time = MyStopWatch();
                            Console.WriteLine($"Time for linear search: {time}");
                            break;

                        case 3:
                            
                            int binaryTime = BinarySearch();
                            binaryTime = MyStopWatch();
                            Console.WriteLine($"Time for binary search: {binaryTime}");

                            break;

                        case 4:
                            //Print out all written posts
                            PrintPosts();
                            break;

                        case 5:
                            // Delete a post

                            PostRemoval();
                            //RemovePost();
                            break;

                        case 6:
                            // Sort
                            BubbleSort();
                            break;

                        case 7:
                            _inMenu = false;
                            _runApp = false;
                            break;

                        case 8:
                            SaveToJson();
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
        }

        private static void CreatePost()
        {
            //Console.WriteLine("Writing post. Press Ctrl+E to save your post and exit");
            _isWriting = true;
            string[] newPost = new string[2];
            while (_isWriting)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\tEnter a title: \n");
                newPost[0] = Console.ReadLine();

                if (CheckDuplicate(newPost))
                {
                    Warning("A title of that name already exists. Try again.");
                    continue;
                }

                Console.WriteLine("\tWrite your post: \n");
                newPost[1] = Console.ReadLine();

                

                if (string.IsNullOrEmpty(newPost[0]) || string.IsNullOrEmpty(newPost[1]))
                {
                    Warning("Title or post was empty, try again");
                    
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nYour post was saved. Returning to menu");
                    SavePost(newPost);
                    PrintPosts();
                    _inMenu = true;
                    _isWriting = false;
                    break;
                }
            }
            

            //Console.WriteLine();

            //while (!_isWriting)
            //{

            //    Console.WriteLine("You pressed enter; press Ctrl+E to save.)\n");
            //    ConsoleKeyInfo keyInput = Console.ReadKey(true);

            //    if (keyInput.Modifiers == ConsoleModifiers.Control && keyInput.Key == ConsoleKey.E)
            //    {                    
                    
            //        _inMenu = true;
                    
            //        SavePost(newPost);
            //        PrintPosts();
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Press Ctrl + E, nothing else please.");
            //    }
            //}
            //_isWriting = false;
            Console.WriteLine();

        }

        static bool CheckDuplicate(string[] input) 
        {
            // Linear search to check all posts
            foreach(var title in _blog)
            {
                if (title[0] == input[0])
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        private static void SavePost(string[] newPost)
        {
            _blog.Add(newPost);
        }

        static void EditPost()
        {
            // User should be able to find a title and write *either* a new title or post.
            // Which means that there needs to be selection by index
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Search for a post to edit: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("This will force you to rewrite the title or blog post.");

            Console.ForegroundColor = ConsoleColor.Yellow;

            int index = BinarySearch(); //SearchPosts();

            while (_editPost) 
            {
                bool entered = false;
                

                if (index == -1)
                {
                    Warning("Post wasn't found. Going back to menu.");
                    
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Type [0] to edit the title or [1] to edit your post: ");
                    if (TryReadInt(out int value))
                    {
                        entered = true;
                        switch (value)
                        {
                            case 0:
                                //Edit Title
                                //index is the index of the List _blog

                                // Make a new array
                                string[] newArray = new string[2];

                                //save the post in a temp variable
                                var getPost = _blog[index][1];

                                Console.WriteLine("Write your new title: ");
                                newArray[0] = Console.ReadLine();
                                newArray[1] = getPost;

                                _blog[index] = newArray;

                                Console.WriteLine("Do you wish to continue editing, press ctrl + Y. Otherwise press ctrl + N.");
                                //_editPost = false;
                                break;

                            case 1:
                                //Edit Post
                                //index is the index of the List _blog

                                // I need to make a new array
                                string[] newBlogPost = new string[2];

                                //save the post in a temp variable
                                var getTitle = _blog[index][0];

                                Console.WriteLine("Write your new blog post: ");
                                //string newTitle = 
                                newBlogPost[0] = getTitle;
                                newBlogPost[1] = Console.ReadLine();

                                _blog[index] = newBlogPost;
                                //_editPost = false;
                                Console.WriteLine("Do you wish to continue editing, press ctrl + Y. Otherwise press ctrl + N.");

                                break;
                        }
                    }
                    else
                    {
                        Warning("Not a number. Type [0] or [1].");
                        
                    }
                    if (Input(ConsoleModifiers.Control, ConsoleKey.N) && entered)
                    {
                        _editPost = false;
                    }
                    else
                    {
                        _editPost = true;
                    }
                }
            }
        }

        private static void PrintPosts()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if(_blog.Count > 0)
            {
                foreach (string[] post in _blog)
                {
                    Console.WriteLine($"\nTitle: {post[0]}. Post: {post[1]}");
                }
            }
            else
            {
                Warning("There are no current posts.");
            }

        }

        private static int SearchPosts()
        {
            // Search by title name
            // Returns the index of _blog if a title is found
            // else returns -1

            CountSearches();

            //Error handling and checks
            if (_blog.Count < 1)
            {
                Warning("There are no blog posts.\n");
                
                return -1;
            }
            Console.WriteLine("Enter a title to search for: \n");
            string search = Console.ReadLine();

            if (string.IsNullOrEmpty(search))
            {
                Warning("You did not write anything, aborting.\n");
                
                return -1;
            }

            for(int i = 0; i < _blog.Count; i++)
            {
                // if index [0] of string[] in _blog at index i is == search
                // then print message && return i
                //foreach (string[] post in _blog)
                {

                    if (_blog[i][0] == search)
                    {
                        var title = _blog[i][0];

                        //Print out title name and index
                        Console.WriteLine($"Title: {title} index: {i}");
                        return i;
                    }
                }
            }

            // Use as if(var == -1){ handle error}
            return -1;
        }

        static int BinarySearch()
        {
            /* pseudo-code from textbook
             * 
             * key = value to search for
             * first = index of first element in list
             * last = index of last element in list (list length - 1)
             * 
             * WHILE first <= last
             *      mid = (first+last) / 2
             *      IF key > list[mid]
             *          first = mid+1
             *      ELSE IF key < list[mid]
             *          last = mid - 1
             *      ELSE
             *          return mid
             *      END IF
             *             
             */


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\tSorting the list.\n");
            BubbleSort();
            CountSearches();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"Enter your search key: ");
            string key = Console.ReadLine();//

            int first = 0;
            int mid = 0;
            int last = _blog.Count -1;

            if (!string.IsNullOrEmpty(key))
            { 
                // Set condition → if first is larger than last, we're getting index out of bounds.
                // If it's equal, it has either found the key or exits the loop and returns -1
                while(first <= last)
                {
                    mid = (first + last) / 2;

                    // Returns +1 in relation to the search, then compares to 0: List{A, B, C}. Key = D. D returns > 0.
                    // Returns -1 in relation to the search, then compares to 0: List{A, B, C}. Key = D. D returns < 0
                    // so if mid is higher than the search, it returns +1
                    // if mid is lower, it returns -1

                    //for each iteration, first and last "shrinks", closing in on the key
                    if (string.Compare(key.ToUpper(), _blog[mid][0].ToUpper()) > 0 || string.Compare(key.ToUpper(), _blog[mid][2].ToUpper()) > 0)    
                    {
                        Console.WriteLine($"Key: {key} Compare: {string.Compare(key, _blog[mid][0])}");
                        // increments first relative to mid with 1
                        first = mid + 1;
                        
                        Console.WriteLine(mid);
                    }
                    else if(string.Compare(key.ToUpper(), _blog[mid][0].ToUpper()) < 0 || string.Compare(key.ToUpper(), _blog[mid][2].ToUpper()) < 0) 
                    {
                        Console.WriteLine($"Key: {key} Compare: {string.Compare(key, _blog[mid][0])}");

                        //decrements last relative to mid
                        last = mid - 1;
                        
                    }
                    else
                    {
                        
                        Console.WriteLine($"Found title {_blog[mid][0]} from search key {key} at index {mid}");
                        return mid;
                    }

                }
            }
            Warning("\nTitle not found.");
                        
            return -1;            
        }
        int Search(int[] arr, int x)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high && x >= arr[low] && x <= arr[high])
            {
                int pos = low + ((x - arr[low]) * (high - low)) / (arr[high] - arr[low]);
                if (arr[pos] == x) return pos;
                if (arr[pos] < x) low = pos + 1;
                else high = pos - 1;
            }
            return -1;
        }

        static void PostRemoval()
        {
            if (_blog.Count < 1)
            {
                Warning("No posts to delete.");
                return;
            }
            int index = BinarySearch(); //SearchPosts();
            RemovePostByIndex(index);
        }

        private static void RemovePostByIndex(int index)
        {
            Console.Write($"Deleted post at index {index}: ");


            _blog.RemoveAt(index);            
        }

        private static void BubbleSort()
        {
            //TODO: Bubble sort

            /*
             * Pseudo-code from the textbook.
            FOR i = 0 to length of list - 1
                counter

                FOR j = 0 to length of list - 1 - i
                    IF list[j] > list[j+1] THEN
                    Swap list[j] and list[j+1]                    
            */

            int max = _blog.Count -1;           

            for (int i = 0; i < max; i++)
            {
                // Decrement titlesLeft so we don't go through the whole list each time (or get stuck I guess?)
                int titlesLeft = max - i; // Since max is Count -1, this is max - i - 1 so it does match the pseudo code
                // iterate on
                for(int j = 0; j < titlesLeft; j++)
                {
                    // Comparing the title strings of current list[index] and list[index +1]
                    if (string.Compare(_blog[j][0], _blog[j+1][0]) > 0)
                    {
                        //Swapping the order of the list indexes (not array indexes)
                        var temp = _blog[j];
                        _blog[j] = _blog[j+1];
                        _blog[j + 1] = temp;
                    }
                }
            }
            //PrintPosts();

        }

        #region Helper methods

        /// <summary>
        /// Displays an array of numbered menu options to the console. The params argument allows for "option1, option2" as input instead of an array.
        /// </summary>
        /// <remarks>If no arguments are provided, the method will not display any output.</remarks>
        /// <param name="choices">An array of strings representing the menu options to display. Each string is written to the console on a new
        /// line.</param>
        static string[] NumberedMenuList(params string[] choices)
        {
            int index = 0;
            foreach (string choice in choices)
            {
                index++;
                Console.WriteLine($"\t[{index}] {choice}");
            }
            Console.WriteLine();
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
                    if (!string.IsNullOrEmpty(str[i]))
                    {
                        Console.WriteLine($"[{index}]\t Title: {str[i][0]}");

                    }
                    //TODO: prints out content just fine, but requires error handling and dynamic search
                }
            }
        }

        static bool Input(ConsoleModifiers modifiers, ConsoleKey key)
        {
            ConsoleKeyInfo keyInput = Console.ReadKey(true);

            if(keyInput.Modifiers == modifiers && keyInput.Key == key)
            {
                return true;
            }
            return false;
        }

        static bool TryReadInt(out int value)
        {
            string input = Console.ReadLine();

            return int.TryParse(input, out value);
        }



        static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine();
        }
        static void NullString(string message, string nullString)
        {
            if (string.IsNullOrEmpty(nullString) || string.IsNullOrEmpty(nullString))
            {
                Warning(message);
            }
        }

        static void SaveToJson()
        {
            var json = JsonSerializer.Serialize(_blog);
            File.WriteAllText("blogEntries.json", json);

        }


        // This is from GPT, please don't yell at me :(
        static int MyStopWatch()
        {
            var data = new int[1000000];
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            int target = 999999;

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            int result = (int)stopWatch.ElapsedMilliseconds;
            stopWatch.Stop();
            

            return result;
        }

        private static void GenerateTestData(int count)
        {
            Random rng = new Random();
            for (int i = 0; i < count; i++)
            {
                string title = $"Post_{i:D5}"; // Keeps titles lexicographically sortable (e.g., Post_00001, Post_00002, ...)
                string post = $"This is the content of blog post number {i}. Random number: {rng.Next(1000, 9999)}";
                _blog.Add(new string[] { title, post });
            }
        }
    }



    #endregion
}



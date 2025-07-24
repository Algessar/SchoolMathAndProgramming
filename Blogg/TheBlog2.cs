

namespace SchoolMathAndProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    //TODO: Remove auto PrintPosts();
    internal class TheBlog2
    {
        public static List<string[]> _blog = new List<string[]>();
        private static bool _runApp = true;
        private static bool _inMenu = true;
        private static bool _isWriting = false;
        private static bool _editPost = false;
        private static int _numSearches = 0;

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
            if (_numSearches == 0)
            {
                Console.WriteLine("\tNo searches have been made before.");
                _numSearches++;
                Console.WriteLine($"\t\tNumber of searches is now: {_numSearches}");
            }
            else
            {
                _numSearches++;
                Console.WriteLine($"\t\tNumber of searches is now: {_numSearches}");
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\tWelcome to the amazing Console App blog post creator!\n");

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
                    "Save to json",
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
                        case -3:
                            // Search for a specific post and print it out                            
                            LinearSearch();

                            break;
                        case 3:
                            //Binary search
                            Console.WriteLine("\tDo you want to search by title [1] or date [2]");
                            if(TryReadInt(out int index))
                            {
                                switch (index)
                                {
                                    case 1:
                                        BinarySearch(_blog, 0);
                                        break;
                                    case 2:
                                        BinarySearch(_blog, 2);

                                        break;
                                }
                            }
                            
                            //BinarySearch(_blog);

                            break;
                        case 4:
                            //Print out all written posts
                            PrintPosts();

                            break;
                        case 5:
                            // Delete a post
                            RemovePost();

                            break;
                        case 6:
                            // Sort
                            BubbleSort();

                            break;
                        case 7:
                            //Additonal json saving.
                            SaveToJson();

                            break;
                        case 8:


                            _inMenu = false;
                            _runApp = false;

                            break;
                        default:
                            Console.WriteLine($"\tInput number not an option, choose between 1 and {choices.Length}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"\tInput was not a number, try again and choose between 1 and {choices.Length}");
                }
            }
        }

        private static void CreatePost()
        {
            Console.Clear();
            _isWriting = true;
            string[] newPost = new string[3];
            while (_isWriting)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("\tEnter a title: ");
                newPost[0] = Console.ReadLine();

                if (string.IsNullOrEmpty(newPost[0]))
                {
                    Warning("\tTitle or post was empty, try again");
                    continue;
                }
                else if (CheckDuplicate(newPost[0]))
                {
                    Console.Clear();
                    Warning("\n\tA title of that name already exists. Try again.");

                    continue;
                }

                Console.WriteLine("\tWrite your post: \n");
                newPost[1] = Console.ReadLine();
                if (string.IsNullOrEmpty(newPost[1]))
                {
                    Warning("\tTitle or post was empty, try again");

                    continue;
                }

                Console.WriteLine("\tDo you want to add a date [1] or not [2]?");
                bool addingDate = true;
                if (TryReadInt(out int value))
                {
                    switch (value)
                    {
                        case 1:
                            //sub while loop to be able to go back if invalid date.
                            while (addingDate)
                            {
                                string date = AddDate();
                                if (DateTime.TryParse(date, out DateTime result))
                                {

                                    addingDate = false;
                                    newPost[2] = date;
                                    
                                    Console.WriteLine($"\tDate is saved to your post. Press enter to go back to menu.");
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Warning("\tInvalid date, try again.");
                                    continue;
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("\tSkipping date. Press enter to go back to menu.");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("\tNot a number or not an option, creating post without a date. Press enter to go back to menu.");
                            Console.ReadLine();
                            break;
                    }
                    
                }


                if (string.IsNullOrEmpty(newPost[0]) || string.IsNullOrEmpty(newPost[1]))
                {
                    Warning("\t\tTitle or post was empty, try again");

                    continue;
                }
                else
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nYour post was saved. Returning to menu");
                    SavePost(newPost);
                    PrintPosts();
                    _inMenu = true;
                    _isWriting = false;
                    break;
                }
            }

            #region
            #endregion
            Console.WriteLine();

        }

        static string AddDate()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine("\tOnly numbers are valid.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            /*
             * What counts as a valid date?
             * EU (obv): 2025-07-23 
             * How do I check for this?
             * I can split input in 3: year/month/date
             * 
             * Checks for max (month < 31
             * 
             * 
             * NEVERMIND: I'll just use DateTime instead of being a mupper.
             */
            string date = "";
            int yearSet;
            int monthSet;
            int daySet;
            Console.Write("\tYear: ");
            if (TryReadInt(out int year))
            {
                date += year;

            }
            Console.Write("\tMonth: ");
            if (TryReadInt(out int month))
            {

                date += "-" + month;

            }
            Console.Write("\tDay: ");
            if (TryReadInt(out int day))
            {
                date += "-" + day;
            }

            return date;
        }

        static bool CheckDuplicate(string input)
        {
            // Linear search to check all posts
            int max = _blog.Count;
            foreach (var title in _blog)
            {
                for (int i = 0; i < max; i++)
                {
                    if (_blog[i][0] == input)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void SavePost(string[] newPost)
        {
            _blog.Add(newPost);
        }

        static void EditPost()
        {
            Console.Clear();
            // User should be able to find a title and write *either* a new title or post.
            // Which means that there needs to be selection by index
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\tSearch for a post to edit: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            

            Console.ForegroundColor = ConsoleColor.Yellow;

            int index = BinarySearch(_blog);

            while (_editPost)
            {
                //bool entered = false;


                if (index == -1)
                {
                    Warning("\tPost wasn't found. Try again.");

                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\tType [1] to edit the title or [2] to edit your post. Type [3] to edit the date: ");
                    if (TryReadInt(out int value))
                    {
                        //entered = true;
                        switch (value)
                        {
                            case 1:
                                //Edit Title
                                //index is the index of the List _blog

                                // Make a new array
                                string[] newTitle = new string[3];

                                //save the post in a temp variable
                                var getPost = _blog[index][1];
                                var getDate = _blog[index][2];

                                Console.Write("\tWrite your new title: ");
                                newTitle[0] = Console.ReadLine();
                                newTitle[1] = getPost;

                                _blog[index] = newTitle;
                                Console.WriteLine($"\tYour new post: Title: {newTitle[0]}, Post: {newTitle[1]}, Date: {newTitle[2]}");

                                Console.Write("\tDo you wish to continue editing [1] or go to menu [2]");
                                if (TryReadInt(out int choice1))
                                {
                                    // Sub switch to go back and keep editing
                                    switch (choice1)
                                    {
                                        case 1:
                                            Warning("\tContinuing edit.");

                                            continue;
                                        case 2:
                                            Warning("\tLeaving to menu.");
                                            _editPost = false;

                                            break;
                                    }
                                }
                                //_editPost = false;
                                break;

                            case 2:
                                //Edit Post
                                //index is the index of the List _blog

                                // I need to make a new array
                                string[] newBlogPost = new string[3];

                                //save the post in a temp variable
                                var getTitle1 = _blog[index][0];
                                var getDate1 = _blog[index][2];

                                Console.WriteLine("\tWrite your new blog post: ");
                                //string newTitle = 
                                newBlogPost[0] = getTitle1;
                                newBlogPost[1] = Console.ReadLine();
                                newBlogPost[2] = getDate1;

                                _blog[index] = newBlogPost;
                                Console.WriteLine($"\tYour new post: Title: {newBlogPost[0]}, Post: {newBlogPost[1]}, Date: {newBlogPost[2]}");
                                //_editPost = false;
                                //Console.WriteLine("Do you wish to continue editing, press ctrl + Y. Otherwise press ctrl + N.");
                                Console.WriteLine("\tDo you wish to continue editing [1] or go to menu [2]");
                                if (TryReadInt(out int choice2))
                                {
                                    switch (choice2)
                                    {
                                        case 1:
                                            Warning("\tContinuing edit.");

                                            continue;
                                        case 2:
                                            Warning("\tLeaving to menu.");
                                            _editPost = false;

                                            break;
                                    }
                                }

                                break;
                            case 3:

                                bool editingDate = true;
                                string[] newDate = new string[3];
                                while (editingDate)
                                {
                                    //Edit Post
                                    //index is the index of the List _blog
                                    Console.WriteLine("\tEnter new date: ");

                                    //save the post in a temp variable
                                    var getTitle2 = _blog[index][0];
                                    var getPost2 = _blog[index][1];

                                    string date = AddDate();
                                    if (DateTime.TryParse(date, out DateTime result))
                                    {
                                        newDate[2] = date;
                                        newDate[0] = getTitle2;
                                        newDate[1] = getPost2;

                                        _blog[index] = newDate;

                                        editingDate = false;
                                        break;
                                    }
                                    else
                                    {
                                        Warning("\tNot a valid date.");
                                        continue;
                                    }
                                }
                                Console.WriteLine("\tDo you wish to continue editing [1] or go to menu [2]");
                                if (TryReadInt(out int choice))
                                {
                                    switch (choice)
                                    {
                                        case 1:
                                            Warning("\tContinuing edit.");

                                            continue;
                                        case 2:
                                            Warning("\tLeaving to menu.");
                                            _editPost = false;

                                            break;
                                    }
                                }

                                Console.WriteLine($"\tYour new post: Title: {newDate[0]}, Post: {newDate[1]}, Date: {newDate[2]}");
                                break;

                            default:
                                Warning("\tSomething went wrong, going back to menu.");

                                break;
                        }
                    }
                    else
                    {
                        Warning("\tNot a number. Type [0], [1] or [2].");

                        continue;
                    }

                    //entered = false;

                }
            }
        }

        private static void PrintPosts()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\tYour current posts: ");
            if (_blog.Count > 0)
            {
                foreach (string[] post in _blog)
                {
                    Console.WriteLine($"\n\tTitle: {post[0]}. Post: {post[1]}. Date: {post[2]}");
                }
            }
            else
            {
                Warning("\tThere are no current posts.");
            }

        }

        private static int LinearSearch()
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

            for (int i = 0; i < _blog.Count; i++)
            {

                if (_blog[i][0] == search)
                {
                    var title = _blog[i][0];

                    //Print out title name and index
                    Console.WriteLine($"Title: {title} index: {i}");
                    return i;
                }
                
            }

            // Use as if(var == -1){ handle error}
            return -1;
        }

        //NOTE: Would love a more generic BinarySearch, but that's out of scope.
        static int BinarySearch(List<string[]> listToSearch, int index = 0)
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
            int last = _blog.Count - 1;

            if (!string.IsNullOrEmpty(key))
            {
                // Set condition → if first is larger than last, we're getting index out of bounds.
                // If it's equal, it has either found the key or exits the loop and returns -1
                while (first <= last)
                {
                    mid = (first + last) / 2;

                    // Returns +1 in relation to the search, then compares to 0: List{A, B, C}. Key = D. D returns > 0.
                    // Returns -1 in relation to the search, then compares to 0: List{A, B, C}. Key = D. D returns < 0
                    // so if mid is higher than the search, it returns +1
                    // if mid is lower, it returns -1

                    //for each iteration, first and last "shrinks", closing in on the key
                    if (string.Compare(key.ToUpper(), listToSearch[mid][index].ToUpper()) > 0)
                    {
                        Console.WriteLine($"Key: {key} Compare: {string.Compare(key, listToSearch[mid][0])}");
                        // increments first relative to mid with 1
                        first = mid + 1;

                        Console.WriteLine(mid);
                    }
                    else if (string.Compare(key.ToUpper(), listToSearch[mid][index].ToUpper()) < 0)
                    {
                        Console.WriteLine($"Key: {key} Compare: {string.Compare(key, listToSearch[mid][0])}");

                        //decrements last relative to mid
                        last = mid - 1;

                    }
                    else
                    {
                        if(index == 0)
                            Console.WriteLine($"\tFound title {listToSearch[mid][index]} from search key {key} at index {mid}");
                        else if(index == 2)
                            Console.WriteLine($"\tFound post created on the date {listToSearch[mid][index]} from search key {key} at index {mid}");

                        return mid;
                    }
                }
            }
            Warning("\nTitle not found.");

            return -1;
        }

        static void RemovePost() 
        {
            Console.Clear();
            if (_blog.Count < 1)
            {
                Warning("No posts to delete.");
                return;
            }            
            else
            {
                int index = BinarySearch(_blog); //SearchPosts();
                Console.Write($"Deleted post at index {index}: ");
                _blog.RemoveAt(index);
            }
            

            
            //RemovePostByIndex(index);
        }

        //private static void RemovePostByIndex(int index)
        //{
        //    if(index == -1 || _blog.Count < 1)
        //    {
        //        Warning($"No posts to remove");
        //        return;
        //    }

        //    Console.Write($"Deleted post at index {index}: ");
        //    _blog.RemoveAt(index);
        //}

        private static void BubbleSort()
        {

            /*
             * Pseudo-code from the textbook.
            FOR i = 0 to length of list - 1
                counter

                FOR j = 0 to length of list - 1 - i
                    IF list[j] > list[j+1] THEN
                    Swap list[j] and list[j+1]                    
            */

            int max = _blog.Count - 1;

            for (int i = 0; i < max; i++)
            {
                // Decrement titlesLeft so we don't go through the whole list each time (or get stuck I guess?)
                int titlesLeft = max - i; // Since max is Count -1, this is max - i - 1 so it does match the pseudo code
                // iterate on
                for (int j = 0; j < titlesLeft; j++)
                {
                    // Comparing the title strings of current list[index] and list[index +1]
                    if (string.Compare(_blog[j][0], _blog[j + 1][0]) > 0)
                    {
                        //Swapping the order of the list indexes (not array indexes)
                        var temp = _blog[j];
                        _blog[j] = _blog[j + 1];
                        _blog[j + 1] = temp;
                    }
                }
            }

            PrintPosts();
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
                }
            }
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
        static bool NullString(string nullString, string message)
        {
            if (string.IsNullOrEmpty(nullString) || string.IsNullOrEmpty(nullString))
            {
                Warning(message);
                return true;
            }
            return false;
        }

        static void SaveToJson()
        {
            var json = JsonSerializer.Serialize(_blog);
            File.WriteAllText("blogEntries.json", json);

        }
    }

    #endregion
}



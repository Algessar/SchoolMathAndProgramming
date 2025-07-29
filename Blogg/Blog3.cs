using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static SchoolMathAndProgramming.Blogg.TheBlog;

namespace SchoolMathAndProgramming.Blogg
{
    internal class Blog3
    {
        static bool _run = true;
        static bool _inMenu = true;
        static bool _isWriting = false;
        static List<BlogPost> _blogList = new();

        static void Main(string[] args)
        {
            Console.WriteLine("Start of app");
            while (_run)
            {
                Menu();
            }
        }

        static void Menu()
        {

            _inMenu = true;
            Console.ForegroundColor = ConsoleColor.Green;
            var menu = new List<(string Label, Action Handler)>
            {
                ("Create post", CreatePost),
                ("Search post", SearchPost),
                ("Edit post", EditPost),
                ("Print all posts", PrintAllPosts),
                ("Delete a post", DeletePost),
                ("Save to json", SaveToJson),
                ("Exit", ExitApp)
            };
            
            Console.WriteLine();

            // Menu display
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"\t[{i + 1}] {menu[i].Label}");
            }

            // Get input and call action
            if (TryReadInt(out int index))
            {
                if(index > 0 && index <= menu.Count)
                {
                    menu[index - 1].Handler.Invoke();
                }
            }
            else
            {
                Console.WriteLine("\tInvalid choice.");
            }
                     
        }

        static void CreatePost()
        {
            _inMenu = false;
            _isWriting = true;
            while (_isWriting)
            {
                bool hasAddedTitle = false;

                string title = "";
                if (!hasAddedTitle)
                {
                    Console.WriteLine(value: "\tWrite your Title: ");
                    title = Console.ReadLine();
                    if (string.IsNullOrEmpty(title))
                    {
                        Warning("Title is empty. Try again");
                        continue;
                    }
                }

                Console.WriteLine(value: "\tWrite your Post: ");
                string postEntry = Console.ReadLine();
                if (string.IsNullOrEmpty(postEntry))
                {
                    Warning("Post is empty, try again");
                    continue;
                }

                var _post = new BlogPost(title, postEntry);
                Console.WriteLine("Do you want to add a date? [1] or [2]");
                bool addingDate = true;
                if(TryReadInt(out int value))
                {
                    
                    switch (value)
                    {
                        case 1:
                            while (addingDate)
                            {
                                if (TryReadInt(out int date))
                                {
                                    if (date < 1)
                                    {
                                        Warning("Date not valid, try again.");
                                        continue;
                                    }
                                var newPost = new BlogPost(title, postEntry, date);
                                    _post = newPost;
                                    _blogList.Add(newPost);
                                    addingDate = false;

                                }                                    
                                else
                                {
                                    Warning("Not a number.");
                                    break;
                                }
                            }
                        break;
                                
                        case 2:
                            Warning("Case 2.");
                            _blogList.Add(_post);
                            addingDate = false;

                            break;
                        default:
                            Warning("Case 3.");

                            _blogList.Add(_post);
                            addingDate = false;
                            _isWriting = false;

                            break;
                    }
                }
                Warning("Left adding date state.");
                //addingDate = false;
                _isWriting = false;
                break;
            }
        }

        private static void SearchPost()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //if(TryReadInt(out int value))
            //{
            //    Console.WriteLine("\n\t Do you want to search on title [1] or date [2]?");
            //    switch (value)
            //    {
            //        case 1:
                        
                        
            //            break;
            //        case 2:


            //            break;
            //    }
            //}

            Console.WriteLine("\nType in the title of a post to search for");
            string input = Console.ReadLine();
            int index = 0;
            if (!string.IsNullOrEmpty(input))
            {
                Search(input, out index);
                if(index == -1)
                {
                    Warning("Could not find post from menu");
                    return;
                }
            }
            else
            {
                Warning("Input was empty");
            }
        }

        private static int Search(string input, out int index)
        {
            
            for (int i = 0; i < _blogList.Count; i++)
            {
                // Check all titles that start with the same letters as input
                // This loop iterates on every element.
                index = 0;
                foreach(var post in _blogList)
                {
                    bool success = post.Title.StartsWith(input, System.StringComparison.CurrentCultureIgnoreCase);
                    bool dateSuccess = post.overrideDate.ToString().StartsWith(input, StringComparison.CurrentCultureIgnoreCase);
                    index = _blogList.IndexOf(post);

                    if (success || dateSuccess)
                    {
                        Success($"Post(s) found containing search {input} : Title {post.Title}, Date {post.overrideDate}, at {index}");                        
                    }
                    else 
                    {
                        Warning("\nNot found.");
                    }
                }
                
                return index;
            }

            //foreach (var post in _blogList)
            //{
            //    // I wonder how I can display all titles starting with the same letter...
            //    bool ignoreCase = post.Title.StartsWith(input, System.StringComparison.CurrentCultureIgnoreCase);
            //    if (ignoreCase)
            //    {
            //        index = _blogList.IndexOf(post);
            //        Success($"Title found: {post.Title}, at {index}");

            //        return index;
            //    }
            //}

            Warning($"Title not found, return -1.");
            index = -1;
            return -1;
        }


        static void EditPost()
        {
            //string a = Console.ReadLine();
            
            foreach (var b in _blogList)
            {
                Success($"\n\tTitle: {b.Title}, Post: {b.Post}, Date: {b.date}.");
                //Console.WriteLine(b.Post);
                //Console.WriteLine(b.overrideDate);
            }
        }

        private static void ExitApp()
        {
            throw new NotImplementedException();
        }

        private static void SaveToJson()
        {
            throw new NotImplementedException();
        }

        private static void DeletePost()
        {
            string input = Console.ReadLine();
            Search(input, out int index);
            //if(TryReadInt(out index))
            {               

                PostDeletion(index);
            }
        }
        private static void PostDeletion(int index)
        {
            _blogList.RemoveAt(index);
            Console.WriteLine($"Post was deleted at {index}");
        }

        private static void PrintAllPosts()
        {
            foreach(var title in _blogList)
            {
                Console.WriteLine($"{title.Title}");
            }
        }



        #region

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
        /// <summary>
        /// Converts a string to int with error handling.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static bool TryReadInt(out int value)
        {
            Console.WriteLine();
            Console.Write("\t");
            string input = Console.ReadLine();

            return int.TryParse(input, out value);
        }

        static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.WriteLine();
        }

        static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed; //Shouldn't this be Red?
            Console.WriteLine(message);
            Console.WriteLine();
        }
        #endregion

    }
}

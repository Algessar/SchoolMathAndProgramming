using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMathAndProgramming.Blogg
{
    internal class BlogPost
    {
        public string Title;
        public string Post;
        public DateTime date;
        public int overrideDate;

        public BlogPost(string title, string post, int date = 0)
        {
            Title = title;
            Post = post;
            overrideDate = date;
        }



        public bool CheckDate()
        {           
            if(overrideDate == -1)
            {
                overrideDate = DateTime.Now.Year;
                return true;
            }
            Console.WriteLine("You have not set a date. Would you like to do so?");
            return false;

        }

    }
}

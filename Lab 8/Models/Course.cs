using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab_6.Models
{
    public class Course
    {
        private string code;
        private string title;
        private int weeklyHours;

        public string Code { 
            get { return code; }
        }
        public string Title { 
            get { return title; }
        }
        public int WeeklyHours
        {
            get { return weeklyHours; }
            set { weeklyHours = value; }
        }

        public Course(string c, string t)
        {
            code = c;
            title = t;
        }
    }
}
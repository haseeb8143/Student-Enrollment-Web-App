using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Helper
/// </summary>
namespace Lab_6.Models
{
    public class Helper
    {
        public static List<Course> GetAvailableCourses()
        {
            List<Course> courses = new List<Course>();

            Course course = new Course("CST8282", "Introduction to Database Systems");
            course.WeeklyHours = 4;
            courses.Add(course);

            course = new Course("CST8253", "Web Programming II");
            course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8256", "Web Programming Language I");
            course.WeeklyHours = 5;
            courses.Add(course);

            course = new Course("CST8255", "Web Imaging and Animations");
            course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8254", "Network Operating System");
            course.WeeklyHours = 1;
            courses.Add(course);

            course = new Course("CST2200", "Data Warehouse Design");
            course.WeeklyHours = 3;
            courses.Add(course);

            course = new Course("CST2240", "Advance Database topics");
            course.WeeklyHours = 1;
            courses.Add(course);

            return courses;
        }

        public static Course GetCourseByCode(string code)
        {
            foreach (Course c in GetAvailableCourses())
            {
                if (c.Code == code)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
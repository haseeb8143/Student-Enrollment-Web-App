using Lab_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace Lab_7.Models
{
    public class Student
    {
        private string stuName;
        private int stuId;
        private List<Course> registeredCourses = new List<Course>();

        public List<Course> Courses { get { return registeredCourses; } }
        public string StudentName 
        { 
           get { return stuName;}
        }
        public int StudentID 
        { 
           get { return stuId;} 
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses != null)
            {
                registeredCourses.Clear();
                registeredCourses.AddRange(selectedCourses);
            }
        }

        public virtual int TotalWeeklyHours()
        {
            int totalHours = 0;
            foreach (var course in registeredCourses)
            {
                totalHours += course.WeeklyHours;
            }
            return totalHours;
        }

       
        public Student(string name) 
        {
            stuName = name;
            Random rnd = new Random();
            stuId = rnd.Next(900000, 1000000);
        }
    }

   

    public class FullTimeStudent : Student
    {
        public static int MaxWeeklyHours;
        public FullTimeStudent(string name) : base(name)
        { 
            
    }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalHours = 0;
            foreach (var course in selectedCourses)
            {
                totalHours += course.WeeklyHours;
            }

            if (totalHours > MaxWeeklyHours)
            {
                throw new InvalidOperationException($"Total weekly hours for all registered courses cannot exceed {MaxWeeklyHours} hours for full-time students.");
            }
            else
            {
                base.RegisterCourses(selectedCourses);
            }
        }

        public override string ToString()
        {
            return $"{StudentID} - {StudentName} ({GetType().Name})";
        }
    }

    public class PartTimeStudent : Student
    {
        public static int MaxNumOfCourses;
        public PartTimeStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalCourses = 0;
            foreach(var course in selectedCourses)
            {
                totalCourses += 1;
            }
            if (totalCourses <= MaxNumOfCourses)
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new InvalidOperationException($"Total courses cannot exceed {MaxNumOfCourses} courses for part-time students.");
            }
        }

        public override string ToString()
        {
            return $"{StudentID} - {StudentName} ({GetType().Name})";
        }
    }

    public class CoopStudent : Student
    {
        public static int MaxNumOfCourses;
        public static int MaxWeeklyHours;
        public CoopStudent(string name) : base(name)
        {
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalCourses = 0;
            int totalHours = 0;
            foreach (var course in selectedCourses)
            {
                totalCourses += 1;
                totalHours += course.WeeklyHours;
            }
            if (totalCourses <= MaxNumOfCourses && totalHours <= MaxWeeklyHours) 
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new InvalidOperationException($"Total courses cannot exceed {MaxNumOfCourses} courses and {MaxWeeklyHours} hours for coop-time students.");
            }
            
               
        }

        public override string ToString()
        {
            return $"{StudentID} - {StudentName} ({GetType().Name})";
        }
    }
}
using Lab_6.Models;
using Lab_7.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Lab_8
{

    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Student> sessionStudents = Session["StudentList"] as List<Student>;

            if (!IsPostBack)
            {
                PopulateChecklist();
                if (sessionStudents != null)
                {
                    AddDropDownItems(sessionStudents);
                }
            }


        }


        //populates drop down list using session storage
        public void AddDropDownItems(List<Student> allStudents)
        {
            foreach (Student student in allStudents)
            {
                ListItem item = new ListItem();
                item.Text = student.ToString();
                item.Value = student.StudentID.ToString();

                studentList.Items.Add(item);
            }
        }



        //populates checklist from the helper file
        public void PopulateChecklist()
        {
            List<Course> courses = Helper.GetAvailableCourses();
            foreach (Course course in courses)
            {
                string checkText = course.Title + " - " + course.WeeklyHours + " hours/week";
                ListItem checkbox = new ListItem();
                checkbox.Text = checkText;
                checkbox.Value = course.Code.ToString();
                chklist.Items.Add(checkbox);
            }
        }


        //click event of the drop down list
        public void StudentChanged(object sender, EventArgs e)
        {
            chklist.ClearSelection();
            confirm.Text = "";
            error.Text = "";
            //runs the function and if the an active student is returned it updates the prompts and checkboxes
            if (ActiveStudent() != null)
            {
                PrecheckBoxes();
                DisplayMessage();
            }
        }



        //creates a new class instance for the selected student
        public Student ActiveStudent()
        {
            List<Student> sessionStudents = Session["StudentList"] as List<Student>;

            Student activeStudent = null;
            foreach (Student stu in sessionStudents)
            {
                if (stu.StudentID.ToString() == studentList.SelectedValue)
                {
                    activeStudent = stu;
                }
            }

            return activeStudent;
        }



        //goes through all the the selected courses for the active student and checks the boxes accordingly
        public void PrecheckBoxes()
        {
            List<Student> sessionStudents = Session["StudentList"] as List<Student>;
            Student activeStudent = null;
            foreach (Student stu in sessionStudents)
            {
                if (stu.StudentID.ToString() == studentList.SelectedValue)
                {
                    activeStudent = stu;
                }
            }

            foreach (Course stuCourse in activeStudent.Courses)
            {
                foreach (ListItem box in chklist.Items)
                {
                    if (box.Value == stuCourse.Code.ToString())
                    {
                        box.Selected = true;
                    }
                }
            }
        }



        //updates the prompts and if any errors present
        public void DisplayMessage()
        {
            List<Student> sessionStudents = Session["StudentList"] as List<Student>;
            Student activeStudent = null;
            foreach (Student stu in sessionStudents)
            {
                if (stu.StudentID.ToString() == studentList.SelectedValue)
                {
                    activeStudent = stu;
                }
            }

            int total = activeStudent.Courses.Count;
            int hours = activeStudent.TotalWeeklyHours();
            confirm.Text = $"The selected student has {total} courses, with {hours} Weekly hours";
        }

        


        //gets all the selected courses returns them as list
        public List<Course> GetSelectedCourses()
        {
            List<Course> courses = new List<Course>();

            foreach (ListItem box in chklist.Items)
            {
                if (box.Selected)
                {
                    courses.Add(Helper.GetCourseByCode(box.Value));
                }
            }
            return courses;
        }



        //operates on the button click event
        public void SaveEvent(object sender, EventArgs e)
        {
            error.Text = "";
            try
            {
                //calls the appropriate functions to assign an active student, and save the selected courses to it
                ActiveStudent().RegisterCourses(GetSelectedCourses());
                //updates the messages according to the newly saved courses
                DisplayMessage();
            }
            catch (Exception err)
            {
                error.Text = err.Message;
            }
        }
    }
}
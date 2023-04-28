using Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Lab_8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                List<Student> studentList = (List<Student>)Session["StudentList"];
                if (studentList != null)
                {
                    HtmlTable stutbl = (HtmlTable)FindControl("stutbl");
                    HtmlTableRow rowToRemove = stutbl.FindControl("rowtormv") as HtmlTableRow;
                    if (rowToRemove != null)
                    {
                        stutbl.Rows.Remove(rowToRemove);
                    }
                }
            if (!IsPostBack)
            {
            
                PopulateTableFromSession();
            }
            addbtn.Click += new EventHandler(ClickEvent);
        }


        private void PopulateTableFromSession()
        {
            List<Student> studentList = (List<Student>)Session["StudentList"];
            if (studentList != null)
            {
                HtmlTable table = (HtmlTable)FindControl("stutbl");
                foreach (Student student in studentList)
                {
                    HtmlTableRow NewRow = new HtmlTableRow();
                    HtmlTableCell cell1 = new HtmlTableCell();
                    HtmlTableCell cell2 = new HtmlTableCell();

                    cell1.InnerText = student.StudentID.ToString();
                    cell2.InnerText = student.StudentName;

                    NewRow.Cells.Add(cell1);
                    NewRow.Cells.Add(cell2);

                    table.Rows.Add(NewRow);
                }
            }
        }

        public void ClickEvent(object sender, EventArgs e)
        {
            List<Student> studentList = (List<Student>)Session["StudentList"];

            if (studentList == null)
            {
                studentList = new List<Student>();
            }

            if (name.Value != "")
            {

                Student student = null;
                if (choosetime.SelectedIndex == 1)
                {
                    student = new FullTimeStudent(name.Value);
                }
                else if (choosetime.SelectedIndex == 2)
                {
                    student = new PartTimeStudent(name.Value);


                }
                else if (choosetime.SelectedIndex == 3)
                {
                    student = new CoopStudent(name.Value);

                }
                else
                {
                    //err.InnerText = "Invalid selection";
                    PopulateTableFromSession();
                }


                if (student != null)
                {

                    bool studentExists = false;
                    foreach (Student stu in studentList)
                    {
                        if (stu.StudentName == student.StudentName && stu.GetType() == student.GetType())
                        {
                            studentExists = true;
                            PopulateTableFromSession();
                            break;
                        }
                    }

                    if (studentExists == false)
                    {
                        HtmlTable stutbl = (HtmlTable)FindControl("stutbl");
                        HtmlTableRow rowToRemove = stutbl.FindControl("rowtormv") as HtmlTableRow;
                        if (rowToRemove != null)
                        {
                            stutbl.Rows.Remove(rowToRemove);
                        }
                        err.InnerText = "";
                        studentList.Add(student);
                        Session["StudentList"] = studentList;
                        PopulateTableFromSession();
                    }
                }
            }
            else
            {
                //err.InnerText = "Name is empty";

                PopulateTableFromSession();
            }

            name.Value = "";
            choosetime.SelectedIndex = 0;

        }
    }
}
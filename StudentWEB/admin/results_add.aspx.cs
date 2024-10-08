using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_results_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Student.Model.User> userList = Student.BLL.User.List();

            for (int i = 0; i < userList.Count; i++)
            {
                this.username.Items.Add(new ListItem(userList[i].Name + "/" + userList[i].Menu.Title, userList[i].Id.ToString()));
            }

            if (userList.Count > 0)
            {
                GetCourseList(userList[0].Menu.Id);
            }


        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.Results results = new Student.Model.Results();

        results.Student = Student.BLL.User.Getuser(int.Parse(this.username.Text));
        results.Course = Student.BLL.Course.Getcourse(int.Parse(this.coursename.Text));
        results.Menu = Student.BLL.User.Getuser(int.Parse(this.username.Text)).Menu;
        results.Num = int.Parse(this.num.Text);
        results.Adddate = DateTime.Now;

        int i = Student.BLL.Result.List(int.Parse(this.username.Text), int.Parse(this.coursename.Text)).Count;

        if (i > 0)
        {
            Student.JsHelper.AlertAndRedirect("The result already existed", "results.aspx");
        }
        else
        {
            bool res = Student.BLL.Result.add(results);

            if (res)
            {
                Student.JsHelper.AlertAndRedirect("Add succeed!", "results.aspx");
            }
            else
            {
                Student.JsHelper.AlertAndRedirect("Add failed!", "results.aspx");
            }
        }
        
        
    }

    protected void username_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.coursename.Items.Clear();

        int menu = Student.BLL.User.Getuser(int.Parse(this.coursename.Text)).Menu.Id;

        GetCourseList(menu);
    }

    private void GetCourseList(int menu)
    {
        List<Student.Model.Course> courseList = Student.BLL.Course.List(menu);

        for (int i = 0; i < courseList.Count; i++)
        {
            this.coursename.Items.Add(new ListItem(courseList[i].Title + "/" + courseList[i].Menu.Title, courseList[i].Id.ToString()));
        }
    }
}
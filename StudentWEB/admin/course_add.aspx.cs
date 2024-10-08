using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_course_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Student.Model.Menu> list = Student.BLL.Menu.List();

            for (int i = 0; i < list.Count; i++)
            {
                this.major.Items.Add(new ListItem(list[i].Title, list[i].Id.ToString()));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.Course course = new Student.Model.Course();

        course.Title = this.title.Text;
        course.Professor = this.professor.Text;
        course.Menu = Student.BLL.Menu.GetMenu(int.Parse(this.major.Text));
        course.Num = int.Parse(this.num.Text);
        course.Detail = this.detail.Text;
        course.State = int.Parse(this.state.Text);
        course.Adddate = DateTime.Now;

        //Console.WriteLine(course.Title + " " + course.Professor + " " + course.Menu + " " + course.Num + " " + course.Detail);

        bool res = Student.BLL.Course.add(course);

        if (res)
        {
            Student.JsHelper.AlertAndRedirect("Add succeed!", "course.aspx");
        }
        else
        {
            Student.JsHelper.AlertAndRedirect("Add fail!", "course.aspx");
        }
    }
}

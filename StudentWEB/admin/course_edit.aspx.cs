using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_course_edit : System.Web.UI.Page
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

            string id = Request.QueryString["id"];

            Student.Model.Course course = Student.BLL.Course.Getcourse(int.Parse(id));

            this.id.Value = course.Id.ToString();
            this.title.Text = course.Title;
            this.professor.Text = course.Professor;
            this.major.Text = course.Menu.Id.ToString();
            this.num.Text = course.Num.ToString();
            //this.startdate.Text = course.Startdate.ToString();
            this.detail.Text = course.Detail;
            this.state.Text = course.State.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.Course course = new Student.Model.Course();

        course.Id = int.Parse(this.id.Value);
        course.Title = this.title.Text;
        course.Professor = this.professor.Text;
        course.Menu = Student.BLL.Menu.GetMenu(int.Parse(this.major.Text));
        course.Num = int.Parse(this.num.Text);
        //course.Startdate = this.startdate.Text;
        course.Detail = this.detail.Text;
        course.State = int.Parse(this.state.Text);
        course.Adddate = DateTime.Now;

        bool res = Student.BLL.Course.update(course);

        if (res)
        {
            Student.JsHelper.AlertAndRedirect("Update succeed!", "course.aspx");
        }
        else
        {
            Student.JsHelper.AlertAndRedirect("Update fail!", "course.aspx");
        }
    }
}
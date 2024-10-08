using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Student.Model.Menu> list = Student.BLL.Menu.List();

        if(!IsPostBack)
        {
            for (int i = 0; i < list.Count; i++)
            {
                this.menulist.Items.Add(new ListItem(list[i].Title, list[i].Id.ToString()));
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.User user = new Student.Model.User();

        string username = this.username.Text;

        if (Student.BLL.User.Search(username))
        {
            JsHelper.AlertAndRedirect("Sorry, the username already existed!", "/user/reg.aspx");
        }

        user.Username = username;
        user.Password = this.password.Text;
        user.Name = this.name.Text;
        user.Menu = Student.BLL.Menu.GetMenu(int.Parse(this.menulist.Text));
        user.State = 1;
        user.Adddate = DateTime.Now;

        if (Student.BLL.User.add(user))
        {
            JsHelper.AlertAndRedirect("Register succeed!", "/user/login.aspx");
        }
    }
}
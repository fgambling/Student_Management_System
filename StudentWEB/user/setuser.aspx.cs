using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_setuser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null || Session["user"].ToString() == "")
        {
            Response.Redirect("/user/login.aspx");
        }

        if (!IsPostBack) {
            Student.Model.User user = new Student.Model.User();
            user = (Student.Model.User)Student.SessionHelper.GetSession("user");

            this.username.Text = user.Username;
            this.password.Text = user.Password;
            this.name.Text = user.Name;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.User user = new Student.Model.User();
        user = (Student.Model.User)Student.SessionHelper.GetSession("user");

        user.Password = this.password.Text;
        user.Name = this.name.Text;

        if (Student.BLL.User.update(user))
        {
            JsHelper.AlertAndRedirect("Save succeed", "/user/setuser.aspx");
        }
    }
}
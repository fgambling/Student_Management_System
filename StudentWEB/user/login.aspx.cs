using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = this.username.Text.Trim();
        string password = this.password.Text.Trim();

        if (Student.BLL.User.Login(username, password))
        {
            Student.Model.User user = Student.BLL.User.Getuser(username);

            if (user.State == 1)
            {
                SessionHelper.SetSession("user", user);
                JsHelper.Redirect("/user/index.aspx");
            }

            else
            {
                JsHelper.AlertAndRedirect("This account is unactive", "/user/login.aspx");
            }
        }
        else
        {
            JsHelper.AlertAndRedirect("Login failed", "/user/login.aspx");
        }
    }

    protected void password_TextChanged(object sender, EventArgs e)
    {

    }
}
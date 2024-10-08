using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_user_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];
            Student.Model.User user = Student.BLL.User.Getuser(id);

            this.username.Text = user.Username;
            this.password.Text = user.Password;
            this.name.Text = user.Name;
            this.state.Text = user.State.ToString();
            this.id.Value = user.Id.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.User user = Student.BLL.User.Getuser(int.Parse(this.id.Value));

        user.Password = this.password.Text;
        user.Name = this.name.Text;
        user.State = int.Parse(this.state.Text);

        if (Student.BLL.User.update(user))
        {
            JsHelper.AlertAndRedirect("Save succeed", "user.aspx");
        }
    }
}
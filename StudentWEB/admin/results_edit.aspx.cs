using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_results_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["id"];

            Student.Model.Results results = Student.BLL.Result.Getresult(int.Parse(id));

            this.username.Text = results.Student.Name;
            this.coursename.Text = results.Course.Title;
            this.num.Text = results.Num.ToString();
            this.id.Value = results.Id.ToString();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        int id = int.Parse(this.id.Value);

        int num = int.Parse(this.num.Text);

        bool res = Student.BLL.Result.update(num, id);

        if (res)
        {
            Student.JsHelper.AlertAndRedirect("Edit succeed", "results.aspx");
        }

        else
        {
            Student.JsHelper.AlertAndRedirect("Edit succeed", "results.aspx");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_menu_list_edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = int.Parse(Request.QueryString["id"]);
            Student.Model.Menu menu = Student.BLL.Menu.GetMenu(id);
            this.title.Text = menu.Title;
            this.id.Value = menu.Id.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.Menu menu = new Student.Model.Menu();
        menu.Title = this.title.Text;
        menu.Id = int.Parse(this.id.Value);

        bool res = Student.BLL.Menu.update(menu);

        if (res)
        {
            Student.JsHelper.AlertAndRedirect("Edit succeed!", "menu_list.aspx");
        }
        else
        {
            Student.JsHelper.AlertAndRedirect("Edit failed!", "menu_list.aspx");
        }

    }
}
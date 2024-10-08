using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student;

public partial class admin_menu_list_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Student.Model.Menu menu = new Student.Model.Menu();
        menu.Title = this.title.Text;

        bool res = Student.BLL.Menu.add(menu);

        if (res) 
        {
            Student.JsHelper.AlertAndRedirect("Add succeed!", "menu_list.aspx");
        }
        else
        {
            Student.JsHelper.AlertAndRedirect("Add fail!", "menu_list.aspx");
        }

    }
}
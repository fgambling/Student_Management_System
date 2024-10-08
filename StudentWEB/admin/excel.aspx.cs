using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_excel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Student.Model.User> userList = Student.BLL.User.List();

            this.username.Items.Add(new ListItem("All", "0"));

            for (int i = 0; i < userList.Count; i++)
            {
                this.username.Items.Add(new ListItem(userList[i].Name, userList[i].Id.ToString()));
            }

            List<Student.Model.Course> courseList = Student.BLL.Course.List();

            this.coursename.Items.Add(new ListItem("All", "0"));

            for (int i = 0; i < courseList.Count; i++)
            {
                this.coursename.Items.Add(new ListItem(courseList[i].Title, courseList[i].Id.ToString()));
            }

            List<Student.Model.Menu> list = Student.BLL.Menu.List();

            this.menu.Items.Add(new ListItem("All", "0"));

            for (int i = 0; i < list.Count; i++)
            {
                this.menu.Items.Add(new ListItem(list[i].Title, list[i].Id.ToString()));
            }


        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int userId = int.Parse(this.username.Text);

        int courseId = int.Parse(this.coursename.Text);

        int menuId = int.Parse(this.menu.Text);

        string title = this.title.Text;

        string strsql = "1=1";

        if (userId != 0)
        {
            strsql = strsql + " and student=" + userId;
        }

        if (courseId != 0)
        {
            strsql = strsql + " and course=" + courseId;
        }

        if (menuId != 0)
        {
            strsql = strsql + " and menu=" + menuId;
        }


        List<Student.Model.Results> results = Student.BLL.Result.List();

        string filename = title + ".xls";

        ExportToExcel(filename, GetExcelContent(results));
    }

    private string GetExcelContent(List<Student.Model.Results> results)
    {
        StringBuilder str = new StringBuilder();

        str.Append("<table border='1'>");

        str.Append("<tr><td>Id</td><td>Name</td><td>Course</td><td>Major</td><td>Result</td><td>Date</td></tr>");

        for (int i = 0; i < results.Count; i++)
        {
            str.Append("<tr>");
            str.Append("<td>" + (i + 1) +"</td>");
            str.Append("<td>" + Student.BLL.User.Getuser(results[i].Student.Id).Name + "</td>");
            str.Append("<td>" + Student.BLL.Course.Getcourse(results[i].Course.Id).Title + "</td>");
            str.Append("<td>" + Student.BLL.Menu.GetMenu(results[i].Menu.Id).Title + "</td>");
            str.Append("<td>" + results[i].Num + "</td>");
            str.Append("<td>" + results[i].Adddate + "</td>");
            str.Append("</tr>");
        }

        str.Append("</table>");

        return str.ToString();
    }

    public static void ExportToExcel(string filename, string content)
    {
        var res = HttpContext.Current.Response;

        res.Clear();
        res.Buffer = true;
        res.Charset = "GB2312";
        res.AddHeader("Content-Disposition", "attachment; filename" + filename);
        res.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        res.ContentType = "application/ms-excel;charset=GB2312";
        res.Write(content);
        res.Flush();
        res.End();
    }
}
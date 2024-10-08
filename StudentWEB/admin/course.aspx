<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course.aspx.cs" Inherits="admin_course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" align="center" width="80%">
                <tr align="center">
                    <td>Id</td>
                    <td>Title</td>
                    <td>Major</td>
                    <td>Professor</td>
                    <td>Length</td>
                    <td>State</td>
                    <td>Add Date</td>
                    <td>Manage</td>
                </tr>

                <%

                    string id = Request.QueryString["id"];

                    if (id != null)
                    {
                        Student.BLL.Menu.del(int.Parse(id));
                        Student.JsHelper.AlertAndRedirect("Delete succeed!", "course.aspx");
                    }

                    List<Student.Model.Course> courseList = Student.BLL.Course.List();

                    for (int i = 0; i < courseList.Count; i++)
                    {

                %>
                <tr align="center">
                    <td><%=i + 1 %></td>
                    <td><%=courseList[i].Title %></td>
                    <td><%=courseList[i].Menu.Title %></td>
                    <td><%=courseList[i].Professor %></td>
                    <td><%=courseList[i].Num %></td>
                    <td>&nbsp;Normal</td>
                    <td><%=courseList[i].Adddate %></td>
                    <td><a href="course_edit.aspx?id=<%=courseList[i].Id %>">Edit</a> | <a href="course.aspx?id=<%=courseList[i].Id %>">Delete</a></td></tr>

                <% } %>
            </table>
        </div>
    </form>
</body>
</html>

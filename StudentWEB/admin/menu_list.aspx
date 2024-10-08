<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu_list.aspx.cs" Inherits="admin_menu_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" align="center" width="80%">
                <tr align="center"><td>Id</td><td>Major</td><td>Manage</td></tr>

                <%
                    string id = Request.QueryString["id"];
                    if (id != null)
                    {
                        Student.BLL.Menu.del(int.Parse(id));
                        Student.JsHelper.AlertAndRedirect("Delete succeed!", "menu_list.aspx");

                    }
                    List<Student.Model.Menu> menuList = Student.BLL.Menu.List();

                    for (int i = 0; i < menuList.Count; i++)
                    {

                %>
                <tr align="center"><td><%=i + 1 %></td><td><%=menuList[i].Title %></td><td><a href="menu_list_edit.aspx?id=<%=menuList[i].Id %>">Edit</a> | <a href="menu_list.aspx?id=<%=menuList[i].Id %>">Delete</a></td></tr>

                <% } %>
            </table>
        </div>
    </form>
</body>
</html>

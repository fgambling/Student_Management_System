<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user.aspx.cs" Inherits="admin_user" %>

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
                    <td>Username</td>
                    <td>Name</td>
                    <td>Major</td>
                    <td>State</td>
                    <td>Date</td>
                    <td>Manage</td>
                </tr>

                <%

                    string id = Request.QueryString["id"];
                    if (id != null)
                    {
                        if (Student.BLL.Result.List(int.Parse(id)).Count > 0)
                        {
                            Student.JsHelper.AlertAndRedirect("This student cannot be deleted", "user.aspx");
                        }
                        else
                        {
                            Student.BLL.User.del(int.Parse(id));
                            Student.JsHelper.AlertAndRedirect("Delete succeed!", "user.aspx");
                        }
                    }
                    List<Student.Model.User> userList = Student.BLL.User.List();

                    for (int i = 0; i < userList.Count; i++)
                    {
                        string str = "";

                        if (userList[i].State == 1)
                        {
                            str = "Active";
                        }
                        else
                        {
                            str = "Unactive";
                        }

                %>
                <tr align="center">
                    <td><%=i + 1 %></td>
                    <td><%=userList[i].Username %></td>
                    <td><%=userList[i].Name %></td>
                    <td><%=userList[i].Menu.Title %></td>
                    <td><%=str %></td>
                    <td><%=userList[i].Adddate %></td>
                    <td>Edit | <a href="user.aspx?id=<%=userList[i].Id %>">Delete</a></td></tr>

                <% } %>
            </table>

        </div>
    </form>
</body>
</html>

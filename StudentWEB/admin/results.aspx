<%@ Page Language="C#" AutoEventWireup="true" CodeFile="results.aspx.cs" Inherits="admin_results" %>

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
                    <td>Name</td>
                    <td>Course</td>
                    <td>Major</td>
                    <td>Result</td>
                    <td>Add date</td>
                    <td>Manage</td></tr>

                <%
                    string id = Request.QueryString["id"];
                    if (id != null)
                    {
                        Student.BLL.Result.del(int.Parse(id));
                        Student.JsHelper.AlertAndRedirect("Delete succeed!", "results.aspx");

                    }
                    List<Student.Model.Results> resultList = Student.BLL.Result.List();

                    for (int i = 0; i < resultList.Count; i++)
                    {

                %>
                <tr align="center">
                    <td><%=i + 1 %></td>
                    <td><%=resultList[i].Student.Name %></td>
                    <td><%=resultList[i].Course.Title %></td>
                    <td><%=resultList[i].Student.Menu.Title %></td>
                    <td><%=resultList[i].Num %></td>
                    <td><%=resultList[i].Adddate %></td>
                    <td><a href="results_edit.aspx?id=<%=resultList[i].Id %>">Edit</a> | <a href="results.aspx?id=<%=resultList[i].Id %>">Delete</a></td></tr>

                <% } %>
            </table>
        </div>
    </form>
</body>
</html>

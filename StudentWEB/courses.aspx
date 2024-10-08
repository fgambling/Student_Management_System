<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courses.aspx.cs" Inherits="courses" %>

<%@ Register Src="~/inc/menu.ascx" TagPrefix="uc2" TagName="menu" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc2" TagName="down" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/xb.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:menu runat="server" ID="menu" />
        <div class="center">
            <table border="1" align="center" width="100%" cellpadding="0" cellspacing="0" bordercolor="#DEDEDE">
                <tr align="center" style="height:30px; color:white;">
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Id</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Title</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Major</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Professor</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Length</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Detail</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">State</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Add Date</td>
                </tr>

                <%

                    List<Student.Model.Course> courseList = Student.BLL.Course.List();

                    for (int i = 0; i < courseList.Count; i++)
                    {

                        string st = "";
                        st = courseList[i].State == 0 ? "Offline" : "Online";

                %>
                <tr align="center" style="height:30px;">
                    <td><%=i + 1 %></td>
                    <td><%=courseList[i].Title %></td>
                    <td><%=courseList[i].Menu.Title %></td>
                    <td><%=courseList[i].Professor %></td>
                    <td><%=courseList[i].Num %></td>
                    <td><%=courseList[i].Detail %></td>
                    <td><%=st %></td>
                    <td><%=courseList[i].Adddate %></td>
                    </tr>
                <% } %>
            </table>
        </div>
        <uc2:down runat="server" ID="down" />
    </form>
</body>
</html>

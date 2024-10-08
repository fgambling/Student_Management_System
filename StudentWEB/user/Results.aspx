<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="user_Results" %>

<%@ Register Src="~/inc/menu.ascx" TagPrefix="uc2" TagName="menu" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc2" TagName="down" %>
<%@ Register Src="~/user/usermenu.ascx" TagPrefix="uc2" TagName="usermenu" %>

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
            <uc2:usermenu runat="server" ID="usermenu" />
            <div class="usercenter">
              <table border="1" align="center" width="100%" cellpadding="0" cellspacing="0" bordercolor="#DEDEDE">
                <tr align="center" style="height:30px; color:white;">
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Id</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Course</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Major</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Result</td>
                    <td bgcolor="#3082AE" style="height:30px; color:white;">Add Date</td>
                </tr>

                <%

                    Student.Model.User user = new Student.Model.User();
                    user = (Student.Model.User)Student.SessionHelper.GetSession("user");

                    List<Student.Model.Results> resultList = Student.BLL.Result.List(user.Id);

                    for (int i = 0; i < resultList.Count; i++)
                    {
                %>
                <tr align="center" style="height:30px;">
                    <td><%=i + 1 %></td>
                    <td><%=resultList[i].Course.Title %></td>
                    <td><%=resultList[i].Menu.Title %></td>
                    <td><%=resultList[i].Num %></td>
                    <td><%=resultList[i].Adddate %></td>
                    </tr>
                <% } %>
            </table>

            </div>
        </div>
        <uc2:down runat="server" ID="down" />
    </form>
</body>
</html>


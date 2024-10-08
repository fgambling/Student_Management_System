<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="admin_menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style=""background:#808080">
    <form id="form1" runat="server">
        <div>
            <table width="80%" align="center" style="background:#ffffff">
                <tr><td align="center"><a href="user.aspx" target="studentManage">Management</a></td></tr>
                <tr><td align="center"><a href="menu_list.aspx" target="studentManage">Major Management</a></td></tr>
                <tr><td align="center"><a href="menu_list_add.aspx" target="studentManage">Add Major</a></td></tr>
                <tr><td align="center"><a href="course.aspx" target="studentManage">Course Mangement</a></td></tr>
                <tr><td align="center"><a href="course_add.aspx" target="studentManage">Add Course</a></td></tr>
                <tr><td align="center"><a href="results.aspx" target="studentManage">Result Management</a></td></tr>
                <tr><td align="center"><a href="results_add.aspx" target="studentManage">Add result</a></td></tr>
                <tr><td align="center"><a href="excel.aspx" target="studentManage">Get results</a></td></tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="user_index" %>

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
            <div class="usercenter" style="height:400px; font-size:20px; text-align:center;">

                <%
                    Student.Model.User user = new Student.Model.User();
                    user = (Student.Model.User)Student.SessionHelper.GetSession("user");
                    %>
                <br /><br /><br /><br />
                Welcome-<%=user.Name %>

            </div>
        </div>
        <uc2:down runat="server" ID="down" />
    </form>
</body>
</html>

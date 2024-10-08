<%@ Page Language="C#" AutoEventWireup="true" CodeFile="setuser.aspx.cs" Inherits="user_setuser" %>

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
                <table widthe="40%" border="0" align="center" cellpadding="10" cellspacing="10">
                    <tr><td>Username: </td><td><asp:Label ID="username" runat="server" Text="Label"></asp:Label></td></tr>
                    <tr><td>Password: </td><td><asp:TextBox ID="password" runat="server"></asp:TextBox></td></tr>
                    <tr><td>Name: </td><td><asp:TextBox ID="name" runat="server"></asp:TextBox></td></tr>
                    <tr><td></td><td><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" /></td></tr>
                </table>
            </div>
        </div>
        <uc2:down runat="server" ID="down" />
    </form>
</body>
</html>

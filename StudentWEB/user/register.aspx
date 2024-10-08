<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="user_register" %>

<%@ Register Src="~/inc/menu.ascx" TagPrefix="uc2" TagName="menu" %>
<%@ Register Src="~/inc/down.ascx" TagPrefix="uc2" TagName="down" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Student Register</title>
    <link href="../css/xb.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <uc2:menu runat="server" ID="menu" />
        <div class="center">
            <table widthe="40%" border="0" align="center" cellpadding="10" cellspacing="10">
                <tr><td>Username: </td><td><asp:TextBox ID="username" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="No username" ControlToValidate="username" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></tr>
                <tr><td>Password: </td><td><asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="No password" ControlToValidate="password" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></tr>
                <tr><td>Name: </td><td><asp:TextBox ID="name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="No name" ControlToValidate="name" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></tr>
                <tr><td>Major: </td><td><asp:DropDownList ID="menulist" runat="server"></asp:DropDownList></td></tr>
                <tr><td></td><td><asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" /></td></tr>
            </table>
        </div>
        <uc2:down runat="server" ID="down" />
    </form>
</body>
</html>

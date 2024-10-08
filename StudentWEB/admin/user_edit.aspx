<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_edit.aspx.cs" Inherits="admin_user_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table widthe="40%" border="0" align="center" cellpadding="10" cellspacing="10">
                <tr><td>Username: </td><td><asp:Label ID="username" runat="server" Text="Label"></asp:Label></td></tr>
                <tr><td>Password: </td><td><asp:TextBox ID="password" runat="server"></asp:TextBox></td></tr>
                <tr><td>Name: </td><td><asp:TextBox ID="name" runat="server"></asp:TextBox></td></tr>
                <tr><td>State:</td><td>
                    <asp:DropDownList ID="state" runat="server">
                        <asp:ListItem Value="1">Active</asp:ListItem>
                        <asp:ListItem Value="0">Unactive</asp:ListItem>
                    </asp:DropDownList>
                    </td></tr>
                <tr><td></td><td><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                    <asp:HiddenField ID="id" runat="server"/>
                    </td></tr>
            </table>
        </div>
    </form>
</body>
</html>

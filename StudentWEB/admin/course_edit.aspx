<%@ Page Language="C#" AutoEventWireup="true" CodeFile="course_edit.aspx.cs" Inherits="admin_course_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table widthe="40%" border="0" align="center" cellpadding="10" cellspacing="10">
                <tr><td align="right">Course Name:</td><td><asp:TextBox ID="title" runat="server"></asp:TextBox></td></tr>
                <tr><td>Professor:</td><td><asp:TextBox ID="professor" runat="server"></asp:TextBox></td></tr>
                <tr><td>Major:</td><td><asp:DropDownList ID="major" runat="server"></asp:DropDownList></td></tr>
                <tr><td>Number:</td><td><asp:TextBox ID="num" runat="server"></asp:TextBox></td></tr>
                <tr><td>Detail:</td><td><asp:TextBox ID="detail" runat="server"></asp:TextBox></td></tr>
                <tr><td>State:</td><td><asp:DropDownList ID="state" runat="server">
                    <asp:ListItem Value="1">Online</asp:ListItem>
                    <asp:ListItem Value="0">Offline</asp:ListItem>
                    </asp:DropDownList></td></tr>
                <tr><td>&nbsp;</td><td><asp:Button ID="Button1" runat="server" Text="Update course" OnClick="Button1_Click" /></td></tr>
                    <asp:HiddenField ID="id" runat="server" />
            </table>
        </div>
    </form>
</body>
</html>

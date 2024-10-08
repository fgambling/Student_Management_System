<%@ Page Language="C#" AutoEventWireup="true" CodeFile="results_add.aspx.cs" Inherits="admin_results_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table widthe="40%" border="0" align="center" cellpadding="10" cellspacing="10">
                <tr><td align="right">Student:</td><td>
                    <asp:DropDownList ID="username" runat="server" OnSelectedIndexChanged="username_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td></tr>
                <tr><td align="right">Course:</td><td><asp:DropDownList ID="coursename" runat="server"></asp:DropDownList></td></tr>
                <tr><td align="right">Result:</td><td><asp:TextBox ID="num" runat="server"></asp:TextBox></td></tr>
                <tr><td>&nbsp;</td><td><asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /></td></tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="results_edit.aspx.cs" Inherits="admin_results_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table widthe="40%" border="0" align="center" cellpadding="10" cellspacing="10">
                <tr><td align="right">Student:</td><td><asp:Label ID="username" runat="server"></asp:Label></td></tr>
                <tr><td align="right">Course:</td><td><asp:Label ID="coursename" runat="server"></asp:Label></td></tr>
                <tr><td align="right">Result:</td><td><asp:TextBox ID="num" runat="server"></asp:TextBox></td></tr>
                <tr><td>&nbsp;</td><td><asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                    <asp:HiddenField ID="id" runat="server"></asp:HiddenField>
                </td></tr>
            </table>
        </div>
    </form>
</body>
</html>

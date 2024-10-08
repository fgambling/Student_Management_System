<%@ Page Language="C#" AutoEventWireup="true" CodeFile="excel.aspx.cs" Inherits="admin_excel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Student Name: <asp:DropDownList ID="username" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        Course Name: <asp:DropDownList ID="coursename" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        Major: <asp:DropDownList ID="menu" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        Document Name: <asp:TextBox ID="title" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Export data" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu_list_add.aspx.cs" Inherits="admin_menu_list_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr><td>Major: </td><td>
                    <asp:TextBox ID="title" runat="server"></asp:TextBox>
                    </td><td>
                        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"></asp:Button>
                         </td>

                </tr>
            </table>
            
        </div>
    </form>
</body>
</html>

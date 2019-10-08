<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="txtUsername"  runat="server" CssClass="form-control" Text="TestUser"></asp:TextBox>
            <asp:TextBox ID="txtpassword"  runat="server" CssClass="form-control" Text="Password"></asp:TextBox>

             <asp:LinkButton ID="btnLogin" runat="server"  CssClass="btn btn-info btn-lg btn-block" Text="Login " OnClick="btnLogin_Click"></asp:LinkButton>

        </div>
    </form>
</body>
</html>

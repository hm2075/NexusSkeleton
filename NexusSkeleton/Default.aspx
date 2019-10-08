<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome &nbsp; &nbsp;   <asp:Label  runat="server" ID="lblusername"></asp:Label>
            <br />

            <asp:LinkButton ID="btnLogout" runat="server"  CssClass="btn btn-info btn-lg btn-block" Text="Logout " OnClick="btnLogout_Click"></asp:LinkButton>



        </div>
    </form>
</body>
</html>

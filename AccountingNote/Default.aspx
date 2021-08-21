<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AccountingNote.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>流水帳管理系統</h1>
            <a href="Default2.aspx">登入系統</a>
        </div>
        <div>
            <label>登入</label>
            <br />
            <asp:PlaceHolder ID="plclogin" runat="server" Visible="false">
                <!--控制項-->
                Account
                <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
                <br />
                Password
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Literal ID="ltlMessage" runat="server"></asp:Literal>
            </asp:PlaceHolder>
            <br />
        </div>
      
    </form>
</body>
</html>

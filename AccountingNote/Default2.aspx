<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="AccountingNote.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        table {
            border-collapse: collapse;
        }

        tr {
            border-bottom: 1pt solid black;
        }
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登入系統-資料內容</title>
</head>

<body>
    <form id="form1" runat="server">
        <div style="display:inline-flex">
            <h1>流水帳管理系統 </h1>
           
            <a href="Default.aspx">登入系統</a>
        </div>
        <br />
        <div>
            <asp:PlaceHolder ID="plcRecord" runat="server" Visible="true">
                <table>
                    <tr>
                        <th>初次記帳</th>
                        <th>&nbsp &nbsp<asp:Label runat="server" ID="lblFirst"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>最後記帳</th>
                        <th>&nbsp&nbsp 
                            <asp:Label runat="server" ID="lblLast"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>記帳數量</th>
                        <th>
                            <asp:Label runat="server" ID="lblAmount"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <th>會員數</th>
                        <th>
                            <asp:Label runat="server" ID="lblMemCount"></asp:Label>
                        </th>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </div>
    </form>
</body>

</html>

<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserChangeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>帳號</th>
            <td>
                <asp:Literal ID="ltlAccount" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>名字</th>
            <td>
                <asp:Literal ID="ltlName" runat="server"></asp:Literal>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>Email</th>
            <td>
                <asp:Literal ID="ltlEmail" runat="server"></asp:Literal>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>會員等級</th>
            <td>
                <asp:Literal ID="ltlUserLevel" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>創立時間</th>
            <td>
                <asp:Literal ID="ltlDateTime" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSave" Text="SAVE" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnLogout" Text="登出" OnClick="btnLogout_Click" />

    <asp:Button runat="server" ID="btnChange" Text="前往變更密碼" OnClick="btnChange_Click" />
</asp:Content>

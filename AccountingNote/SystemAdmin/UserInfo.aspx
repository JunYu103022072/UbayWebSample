<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>個人資訊</h2>
    <table border="1px">
        <tr><td>帳號</td><td><asp:Literal runat="server" ID="ltlAccount"></asp:Literal></td></tr>
        <tr><td>姓名</td><td><asp:Literal runat="server" ID="ltlName"></asp:Literal></td></tr>
        <tr><td>Email</td><td><asp:Literal runat="server" ID="ltlEmail"></asp:Literal></td></tr>
    </table>
    <asp:Button runat="server" ID="btnLogout" Text="登出" OnClick="btnLogout_Click"/>
</asp:Content>

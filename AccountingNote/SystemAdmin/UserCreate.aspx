<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserCreate.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1>流水帳管理系統-加入會員</h1>
    <table>
          <tr><th>帳號</th>
          <td> <asp:TextBox runat="server" ID="txtAccount"></asp:TextBox></td></tr>
        <tr><th>密碼</th>
          <td> <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox></td></tr>
        <tr><th>姓名</th>
          <td> <asp:TextBox runat="server" ID="txtName"></asp:TextBox></td></tr>
        <tr><th>Email</th>
          <td> <asp:TextBox runat="server" ID="txtEmail" TextMode="Email"></asp:TextBox></td></tr>
        <tr><th>電話號碼</th>
          <td><asp:TextBox runat="server" ID="txtPhone" TextMode="Phone"></asp:TextBox></td></tr>
    </table>
    <asp:Button runat="server" ID="btnAdd" OnClick="btnAdd_Click" Text="完成註冊"/>
</asp:Content>

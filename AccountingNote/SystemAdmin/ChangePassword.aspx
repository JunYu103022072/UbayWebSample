<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AccountingNote.SystemAdmin.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        th {
            text-align:left;
        }
        #ltlMsg{
            color:red;
        }
    </style>
     <h2>會員管理 - 變更密碼</h2>
    <table>
       
        <tr>
            <th>帳號</th>
            <td><asp:Literal runat="server" ID="ltlAccount"></asp:Literal></td>
        </tr>
        <tr>
            <th>輸入原密碼</th>
            <td><asp:TextBox runat="server" ID="txtPWD" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
            <th>輸入新密碼</th>
            <td><asp:TextBox runat="server" ID="txtNewPWD"></asp:TextBox></td>
        </tr>
        <tr>
            <th>再次輸入新密碼</th>
            <td><asp:TextBox runat="server" ID="txtNewPWD2"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button runat="server" Text="變更密碼" ID="btnPwdChange" OnClick="btnPwdChange_Click"/>
    <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
</asp:Content>


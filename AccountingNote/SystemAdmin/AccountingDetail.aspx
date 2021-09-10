<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingDetail1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Type:  
    <asp:DropDownList ID="ddlActType" runat="server">
        <asp:ListItem Value="0">支出</asp:ListItem>
        <asp:ListItem Value="1">收入</asp:ListItem>
    </asp:DropDownList>
    <br />
    Amount :<asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox><br />
    Caption :<asp:TextBox ID="txtCaption" runat="server"></asp:TextBox><br />
    Desc :<asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox><br />
    Img :<asp:FileUpload runat="server" ID="fileCover" />
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    &nbsp 
    <!--空格拉-->
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <br />
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

<%@ Register Src="~/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" Text="Add" ID="btnAdd" />
    <asp:GridView ID="gvUserList" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Act">
                <ItemTemplate>
                    <a href="/SystemAdmin/UserDetail.aspx?ID=<%# Eval("Account") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <uc1:ucPager runat="server" ID="ucPager" />
</asp:Content>

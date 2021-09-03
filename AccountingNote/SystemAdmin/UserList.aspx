<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList" %>

<%@ Register Src="~/UserControl/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" Text="增加會員" ID="btnAdd" OnClick="btnAdd_Click" />
    <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvUserList_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Account" HeaderText="帳號" />
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:TemplateField HeaderText="會員等級">
                <ItemTemplate>
                    <asp:Label ID="lblUserLevel" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DateTime" HeaderText="建立時間" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Act">
                <ItemTemplate>
                    <a href="/SystemAdmin/UserDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <uc1:ucPager runat="server" ID="ucPager" />
</asp:Content>

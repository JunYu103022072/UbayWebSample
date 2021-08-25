<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserList2.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" ID="btnAdd" Text="增加會員" />
    <asp:GridView runat="server" ID="gvUserInfo">
        <Columns>
            <asp:BoundField DataField="Account" HeaderText="帳號" />
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:TemplateField HeaderText="等級">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Datetime" HeaderText="建立時間" />
            <asp:TemplateField HeaderText="Edit">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

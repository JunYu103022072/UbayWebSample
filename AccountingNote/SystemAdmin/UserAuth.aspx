<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserAuth.aspx.cs" Inherits="AccountingNote.SystemAdmin.UserAuth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>Account</th>
            <td>
                <asp:Literal runat="server" ID="ltlAccount"></asp:Literal></td>
        </tr>
        <tr>
            <th>Add Roles</th>
            <td>
                <asp:CheckBoxList ID="ckbRoleList" runat="server" DataValueField="ID" DataTextField="RoleName"></asp:CheckBoxList>
                <asp:Button ID="btnSave" runat="server" Text="Save" />
            </td>
        </tr>
        <tr>
            <th>Roles</th>
            <td>
                <asp:Repeater runat="server" ID="rptRoleList" OnItemCommand="rptRoleList_ItemCommand">
                    <ItemTemplate>
                        <div>
                            <%# Eval("RoleName") %>
                            <asp:Button runat="server" Text="Remove" CommandName="DeleteRole" CommandArgument='<%# Eval("ID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPager2.ascx.cs" Inherits="AccountingNote.UserControl.ucPager2" %>
<div>
    <a runat="server" href="#" id="aLinkFirst">First</a> &nbsp;
    <a runat="server" href="#" id="aLink1">1</a> &nbsp;
    <a runat="server" href="#" id="aLink2">2</a> &nbsp;
    <asp:Literal runat="server" ID="ltlCurrentPage"></asp:Literal>
    <a runat="server" href="#" id="aLink4">4</a> &nbsp;
    <a runat="server" href="#" id="aLink5">5</a> &nbsp;
    <a runat="server" href="#" id="aLinkLast">Last</a> &nbsp;
    <asp:Literal runat="server" ID="ltlPager"></asp:Literal>
</div>
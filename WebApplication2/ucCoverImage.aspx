<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ucCoverImage.aspx.cs" Inherits="WebApplication2.WebForm2" %>


<div runat="server" style="background-color:darkkhaki" id="divMain">
    <img runat="server" id="imgCover" src="~/image/Risu.jpg" width="300"/>
    <span>
        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
    </span>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
</div>
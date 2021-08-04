<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%@ Register Src="~/WebUserControl1.ascx" TagName="WebUserControl1" TagPrefix="ur1" %>
<%@ Register Src="~/ucCoverImage.aspx" TagName="ucCoverImage" TagPrefix="ur1" %>
<%@ Register Src="~/ucCoverImage.ascx" TagPrefix="uc1" TagName="ucCoverImage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:WebUserControl1 runat="server" id="WebUserControl1" />
    <uc1:ucCoverImage runat="server" id="ucCoverImage" />
</asp:Content>
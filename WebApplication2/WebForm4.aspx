<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<%@ Register Src="~/ucDomSample.ascx" TagPrefix="uc1" TagName="ucDomSample" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   
        <uc1:ucDomSample runat="server" ID="ucDomSample" />
    </form>
</body>
</html>

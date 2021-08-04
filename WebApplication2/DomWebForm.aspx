<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DomWebForm.aspx.cs" Inherits="WebApplication2.DomWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> My title </title>
    <style>
        p:last-child{background-color:blueviolet}
        span{color:blue;}
        #s2{color:green;}
        .p1{color:red;}
        .p2{color:plum;}
        p > span {background-color:bisque}
    </style>
</head>
<body>
    <div>
        <p class="p1">P Text1</p>
        <p>
            <span>One</span>
            <span id="s2">Two</span>
            <span>Three</span>
        </p>
        <p class="p2">PT2</p> <p>ddd</p>
    </div>
</body>
</html>

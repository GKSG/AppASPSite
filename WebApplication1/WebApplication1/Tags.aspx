<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tags.aspx.cs" Inherits="WebApplication1.Tags" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url(http://il8.picdn.net/shutterstock/videos/6673919/thumb/1.jpg); background-repeat: no-repeat; background-size:cover">
    <form id="form1" runat="server">
    <center>
            <asp:Table ID="Tages" BackColor="#cccc1e" BorderStyle="Ridge" runat="server" OnLoad="Tages_Load" GridLines="Both" />
    </center>
    </form>
</body>
</html>

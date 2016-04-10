<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vocabulary.aspx.cs" Inherits="EasyUKRaine.kuchmynda.Vocabulary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="StyleCSS/StyleSheet1.css"/>
</head>
<body style="background-image: url(http://il8.picdn.net/shutterstock/videos/6673919/thumb/1.jpg); background-repeat: no-repeat; background-size:cover">
    <form id="form1" runat="server">
    <div>
        <asp:Panel BackColor="#cccc1e" runat="server">
            <center>
            <asp:Label runat="server" ID="Header" />
            <asp:Table ID="Words" BorderStyle="Ridge" runat="server" OnLoad="List_Load" GridLines="Both" />
                </center>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

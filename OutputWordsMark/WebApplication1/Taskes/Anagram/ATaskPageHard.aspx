<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ATaskPageHard.aspx.cs" Inherits="WebApplication1.Taskes.ATaskPageHard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body style="background-image: url(http://il8.picdn.net/shutterstock/videos/6673919/thumb/1.jpg); background-repeat: no-repeat; background-size:cover">
    <form id="form1" runat="server">
    <center>
        <asp:Panel runat="server" ID="MainPanel" OnLoad="MainPanel_Load" BackColor="White" HorizontalAlign="Center"/>
        <br />
        <br />
        <asp:TextBox runat="server" ID="InputWord" BorderColor="Blue" Font-Size="30" Font-Names="Helvetica" TextMode="SingleLine" style="text-align: center"/>
        <br />
        <asp:ImageButton ImageUrl="https://cdn3.iconfinder.com/data/icons/web-icons-21/111/validate-2-128.png" runat="server" OnClick="Unnamed_Click"  />
    </center>
    </form>
</body>
</html>

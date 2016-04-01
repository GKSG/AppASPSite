<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountLogin.aspx.cs" Inherits="EasyUKRaine.Pages.AccountLogin" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
    
    <style>
div.details { margin-bottom: 20px; }
div { margin-top: 5px; }
label { width: 90px; display: inline-block; }
button {margin: 10px 10px 0 0;}
</style>
</head>
<body>
<div class="details">The request is authenticated: <%: GetRequestStatus() %></div>
<div class="details">The current user is: <%: GetUser() %></div>
<form id="form1" runat="server">
<div><label>User:</label><input name="user"/></div>
<div><label>Password:</label><input type="password" name="pass"/></div>
<div>
<button name="action" value="login" type="submit">Log In</button>
<button name="action" value="logout" type="submit">Log Out</button>
</div>
</form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Autorization.ascx.cs" Inherits="EasyUKRaine.Controls.Autorization"
    EnableViewState="false" %>

<div id="autrConrtol">
    <div id="noAutor" runat="server">
<span class="caption">
    <div id="rightInput">
        <b>Login:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>&nbsp;<input name="user" type="text" /> <br>
    </div>
    <div id="rightInput">
        <b>Password:</b>
        <input type="password" name="pass" >
    </div>
</span><br>
    <button name="action" value="login" type="submit">Log In</button>
    <a id="regLink" runat="server">Registration</a>
</div>
    <div id="yesAutor" runat="server"><strong>User:&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label_User" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; online<br />
        Score:&nbsp;&nbsp; 
        <asp:Label ID="Label_Score" runat="server" ></asp:Label>
        <br />
        Level:&nbsp;&nbsp;
        <asp:Label ID="Label_Level" runat="server"></asp:Label>
        </strong>
        <input id="singOutSub" name="logout" type="submit" value="Sing Out"/>

    </div>
    </div>
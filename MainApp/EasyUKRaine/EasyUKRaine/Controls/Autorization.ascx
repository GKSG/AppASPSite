<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Autorization.ascx.cs"  EnableViewState="false" Inherits="EasyUKRaine.Controls.Autorization"
     %>

<div id="autrConrtol">

    <div id="noAutor" runat="server">
           <!--
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
    &nbsp; -->
           <br />
           <br />
           <br />
           <br />
           <br />
           <a id="regLink" runat="server">Registration</a>
        <a id="singInLink" runat="server">Sign In</a>
</div>
    <div id="yesAutor" runat="server"><strong>User:&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label_User"  runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; online<br />
        Score:&nbsp;&nbsp; 
        <asp:Label ID="Label_Score"  runat="server" ></asp:Label>
        <br />
        Level:&nbsp;&nbsp;
        <asp:Label ID="Label_Level"  runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </strong>
        <input id="singOutSub" name="logout" type="submit" value="Sing Out" class="btn btn-lg btn-primary btn-block"/></div>
    </div>
<p>
    &nbsp;</p>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="EasyUKRaine.Controls.MenuControl" %>



    <ul class="nav nav-tabs">

<%= CreateHomeLinkHtml() %>
<% 
    foreach (string cat in GetCategories()) {
        Response.Write(CreateLinkHtml(cat));
    }
%>
                        
    </ul>

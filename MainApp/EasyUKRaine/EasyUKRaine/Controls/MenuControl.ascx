<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuControl.ascx.cs" Inherits="EasyUKRaine.Controls.MenuControl" %>


<%= CreateHomeLinkHtml() %>
<% 
    foreach (string cat in GetCategories()) {
        Response.Write(CreateLinkHtml(cat));
    }
%>
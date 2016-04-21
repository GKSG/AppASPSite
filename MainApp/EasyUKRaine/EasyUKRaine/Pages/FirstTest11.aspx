<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="FirstTest11.aspx.cs" Inherits="EasyUKRaine.Pages.FirstTest11" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="EasyUKRaine.Models.Repository" %>
<%@ Import Namespace="System.Web.Routing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <center>
        <asp:Panel runat="server" ID="MainPanel" OnLoad="MainPanel_Load" BackColor="Transparent" HorizontalAlign="Center"/>
        <br />
        </center> 
        <script lang="text/javascript">
            function click() {<%Unnamed_Click(this, null);%>}
        </script>
    
</asp:Content>

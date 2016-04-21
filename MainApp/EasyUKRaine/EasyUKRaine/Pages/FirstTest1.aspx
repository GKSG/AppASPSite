<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="FirstTest1.aspx.cs" Inherits="EasyUKRaine.Pages.FirstTest1" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="EasyUKRaine.Models.Repo" %>
<%@ Import Namespace="System.Web.Routing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <center>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true"  runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                <fieldset>
                <legend>TESTS</legend>
        <asp:Panel runat="server" ID="MainPanel" OnLoad="MainPanel_Load" BackColor="Transparent" HorizontalAlign="Center"/>
        <br />
        
    </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ImageButton ImageUrl="https://cdn3.iconfinder.com/data/icons/web-icons-21/111/validate-2-128.png" runat="server" OnClick="Unnamed_Click"  />
        </center> 
        <script lang="text/javascript">
            function click() {<%Unnamed_Click(this, null);%> }
            
        </script>
    
</asp:Content>

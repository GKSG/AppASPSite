<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="EasyUKRaine.Pages.Games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
  <div>
     
&nbsp;&nbsp; &#9;&#9;&#9;
     <center>
<asp:Table runat="server" Width="744px" Height="273px">
    <asp:TableRow runat="server">

            <asp:TableCell runat="server"><asp:ImageButton runat="server" OnClick="OnClick" src="Content/Image/images.jpg" ToolTip="Vocabulary"/></asp:TableCell>

            <asp:TableCell runat="server"><asp:ImageButton runat="server" OnClick="Action_findWords" src="Content/Image/findWords.jpg"/></asp:TableCell>
    </asp:TableRow>
</asp:Table>
         </center>
      </div>
</asp:Content>

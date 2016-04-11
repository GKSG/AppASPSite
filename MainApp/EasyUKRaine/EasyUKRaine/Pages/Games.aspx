<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="EasyUKRaine.Pages.Games" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
  <div>
     
&nbsp;&nbsp; &#9;&#9;&#9;
     <center>
<asp:Table runat="server" Width="744px" Height="273px">
    <asp:TableRow runat="server">

            <asp:TableCell runat="server"><asp:ImageButton runat="server" OnClick="OnClick" ImageUrl="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcS5ln_RajPE7gfSKU8CXs0qbc_wdFEopONi4KP5uGleJ5ggc_IZ" ToolTip="Vocabulary"/></asp:TableCell>

            <asp:TableCell runat="server"><asp:ImageButton runat="server" OnClick="Action_findWords" ImageUrl="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRDyqZQjCq_2hJxigYI6_AosWwGZFTflmB8MZKTQDb3VwBDonef_A"/></asp:TableCell>
    </asp:TableRow>
</asp:Table>
         </center>
      </div>
</asp:Content>

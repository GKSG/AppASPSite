<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="/Pages/MainWindow.Master" CodeBehind="WebForm1.aspx.cs" Inherits="game.WebForm1" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">   
   
    <table>
        <tr>
        <td>
    <div id="buttons" runat="server" style="position:relative;width:450px;height:450px">
            <asp:Table ID="Table1" runat="server" Height="400px" Width="400px" BackColor="#FFFF66" BorderColor="#3333CC" BorderWidth="10px" CaptionAlign="Top" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="Both" HorizontalAlign="Center">            
                <asp:TableRow>
                    <asp:TableCell Height="95px" Width="95px" style="padding-left:15px" ><asp:Button runat="server"  Width="60px" Height="60px"  ID="b1" Text="м" OnClick="b1_Click" Font-Size="30" ViewStateMode="Inherit" Font-Overline="False" BorderStyle="NotSet" CausesValidation="True" ClientIDMode="Inherit" /></asp:TableCell>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="/Pages/MainWindow.Master" CodeBehind="WebForm1.aspx.cs" Inherits="game.WebForm1" %>

<asp:Content ContentPlaceHolderID="bodyContent"  runat="server">   
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
    <table >
        <tr>
        <td>   
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset>         
    <div id="buttons" runat="server" style="position:relative;width:450px;height:450px">
            <asp:Table ID="Table1" runat="server" Height="400px" Width="400px" BackColor="Transparent" BorderColor="#3333CC" BorderWidth="10px" CaptionAlign="Top" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="Both" HorizontalAlign="Center">            
                <asp:TableRow>
                    <asp:TableCell Height="95px" Width="95px" style="padding-left:15px" ><asp:Button runat="server"  Width="60px" Height="60px"  ID="b1" Text="м"  OnClick="b1_Click"  Font-Size="30" ViewStateMode="Inherit" Font-Overline="False" BorderStyle="NotSet" CausesValidation="True" ClientIDMode="Inherit" /></asp:TableCell>
>>>>>>> origin/Andrew
                     <asp:TableCell Height="95px" Width="95px" style="padding-left:15px" ><asp:Button Width="60px" Height="60px" runat="server" ID="b2" Text="о" OnClick="b2_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b3" Text="м" OnClick="b3_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b4" Text="а" OnClick="b4_Click" Font-Size="30"/></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b5" Text="м" OnClick="b5_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b6" Text="о" OnClick="b6_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b7" Text="о" OnClick="b7_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b8" Text="о" OnClick="b8_Click" Font-Size="30"/></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b9" Text="м" OnClick="b9_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b10" Text="о" OnClick="b10_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b11" Text="о" OnClick="b11_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b12" Text="о" OnClick="b12_Click" Font-Size="30"/></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b13" Text="м" OnClick="b13_Click" Font-Size="30" /></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b14" Text="о" OnClick="b14_Click" Font-Size="30" /></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b15" Text="о" OnClick="b15_Click" Font-Size="30"/></asp:TableCell>
                     <asp:TableCell Width="95px" Height="95px" style="padding-left:15px"><asp:Button Width="60px" Height="60px" runat="server" ID="b16" Text="о" OnClick="b16_Click" Font-Size="30" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
<<<<<<< HEAD
        </div> 
            </td>   
       
            
        <td>
    <div id="tb" runat="server" style="position:relative">
        <asp:Table ID="Table_res" runat="server" Height="130px" Width="325px" BackColor="#6699FF" BorderColor="#FFFF99" Font-Size="Medium" BorderStyle="Groove" BorderWidth="10px" CaptionAlign="NotSet" CellPadding="2" CellSpacing="2"  GridLines="Both" HorizontalAlign="Center">
            </asp:Table>
        </div>
=======
        </div>
             </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel> 
               
            </td> 
        <td>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <fieldset> 
    <div id="tb" runat="server" style="position:relative">
        <asp:Table ID="Table_res" runat="server" Height="130px" Width="325px" BorderColor="Transparent" Font-Names="Hevletica" Font-Size="18" BorderStyle="Groove" BorderWidth="10px" CaptionAlign="NotSet" CellPadding="2" CellSpacing="2"  GridLines="Both" HorizontalAlign="Center">
            </asp:Table>
        </div>
                    </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel> 
>>>>>>> origin/Andrew
        </td>
            </tr>
        <tr>
            <td>
<<<<<<< HEAD
 <div runat="server" style="position:relative">              
    <div runat="server"   style="position:relative">
        <asp:TextBox style="position:relative; left:100px" runat="server" ReadOnly="true" ID="Text1"/>              
    </div>
        <div style="position:relative; left:100px; top: 0px; width: 234px;"  runat="server">
             <asp:Button   runat="server"  Text="Clear" OnClick="button_clear_Click" />
            <asp:Button runat="server"  Text="Submit" OnClick="button_submit_Click"/> 
        </div >
            </div>
                </td>
        </tr>
        </table>
    
=======
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <fieldset> 
 <div runat="server" style="position:relative">              
    <div runat="server"   style="position:relative">
        <asp:TextBox Font-Names="Hevletica" Font-Size="18" style="position:relative; left:100px" runat="server" ReadOnly="true" ID="Text1"/>              
    </div>
        <div style="position:relative; left:100px; top: 0px; width: 234px;"  runat="server">
             <asp:Button Font-Names="Hevletica" Width="95" style="padding:5px; margin:5px" Font-Size="18"  runat="server"  Text="Clear" OnClick="button_clear_Click" />
            <asp:Button Font-Names="Hevletica" Width="95" style="padding:5px; margin:5px" Font-Size="18" runat="server"  Text="Submit" OnClick="button_submit_Click"/> 
        </div >
            </div>
                    </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel> 
                </td>
        </tr>
        </table>
        </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel> 
>>>>>>> origin/Andrew

</asp:Content>


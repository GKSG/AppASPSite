<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="/Pages/MainWindow.Master" CodeBehind="WebForm1.aspx.cs" Inherits="game.WebForm1" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
<div id="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />        
        <asp:Timer ID="Timer1" Interval="10000" OnTick="Timer1_Tick" runat="server"></asp:Timer>
        <asp:Label ID="timeLabel" runat="server"></asp:Label>
         <div id="res_form" runat="server" style="position:absolute; width: 328px; height: 134px; left: 428px;">
        <asp:Table ID="Table_res" runat="server" Height="130px" Width="325px" BackColor="#6699FF" BorderColor="#FFFF99" BorderStyle="Groove" BorderWidth="10px" CaptionAlign="Top" CellPadding="2" CellSpacing="2" ForeColor="White" GridLines="Both" HorizontalAlign="Justify">
            </asp:Table>
    </div>     
            <asp:Table ID="Table1" runat="server" Height="400px" Width="400px" BackColor="#FFFF66" BorderColor="#3333CC" BorderWidth="10px" CaptionAlign="Top" CellPadding="2" CellSpacing="2" ForeColor="Black" GridLines="Both" HorizontalAlign="Center">            
                <asp:TableRow>
                    <asp:TableCell Height="95px" Width="95px" style="padding-left:15px" ><asp:Button  Width="60px" Height="60px" runat="server" ID="b1" Text="м" OnClick="b1_Click" Font-Size="30" ViewStateMode="Inherit" Font-Overline="False" BorderStyle="NotSet" CausesValidation="True" ClientIDMode="Inherit" /></asp:TableCell>
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
    <div runat="server" style="position:absolute; top: 438px; left: 106px;">
        <asp:TextBox Width="200px" runat="server" ID="Text1"/>              
    </div>
        <div style="position:absolute; top: 471px; left: 153px;"  runat="server">
             <asp:Button style="position:absolute; top: 4px; left: -50px; height: 25px; width: 85px;" runat="server" ID="button_clear" Text="Clear" OnClick="button_clear_Click" />
        <asp:Button style="position:absolute; top: 4px; width: 85px; height: 25px; left: 80px;" runat="server" ID="button_submit" Text="Submit" OnClick="button_submit_Click"/> 
        </div>
</div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EasyUKRaine.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
<div id="content">
			<div id="div-regForm">
				<fieldset>
					<h2 align="center">Реєстрація</h2>

							<table>
							<tbody>
							<tr>
								<td>Input login<label for="fname">:</label></td>
								<td><div class="input-container">
									<input name="login" id="login" type="text" size="32" runat="server"/>
								</div></td>
							</tr>
							<tr>
								<td><label for="lname">Password:</label></td>
								<td><div class="input-container">
									<input name="password" id="password" type="password" size="32" runat="server"/>
								</div></td>
							</tr>
							<tr>
								<td>Re-type<label for="lname"> password:</label></td>
								<td><div class="input-container">
									<input name="password2" id="password2" type="password" size="32" />
								</div>
							</tr>
							<tr>
								<td>
                                    <label for="email">Input your e-mail:</label></td>
								<td><div class="input-container">
									<input name="email" id="email" type="text" size="32" runat="server" />
								</div></td>
							</tr>
							
							<tr>
								<td>Name<label for="fname">:</label></td>
								<td><div class="input-container">
									<input name="fname" id="fname" type="text" size="32" runat="server"/>
								</div></td>
							</tr>
							<tr>
								<td>
                                    <label for="lname" >Surname:</label></td>
								<td><div class="input-container">
									<input name="lname" id="lname" type="text" size="32" runat="server"/>
								</div></td>
							</tr>
                                
                           <tr>
								<td>
                                    Country<label for="country" >:</label></td>
								<td><div class="input-container">
									<input name="Country" id="country" type="text" size="32" runat="server"/>
								</div></td>
							</tr>
                                
                           <tr>
								<td>
                                    City<label for="city" >:</label></td>
								<td><div class="input-container">
									<input name="City" id="city" type="text" size="32" runat="server"/>
								</div></td>
							</tr>
							
							<tr>
								<td>&nbsp;</td>
								<td>
									<div class="input-container">
										
										&nbsp;&nbsp;
                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                            <NextPrevStyle VerticalAlign="Bottom" />
                                            <OtherMonthDayStyle ForeColor="#808080" />
                                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                            <SelectorStyle BackColor="#CCCCCC" />
                                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <WeekendDayStyle BackColor="#FFFFCC" />
                                        </asp:Calendar>
									</div>
								</td>
							</tr>
							
							
							<tr>
								<td>
                                    <asp:Button ID="Button1" runat="server" Text="Registered" OnClick="Button1_Click" />
								</td>
							</tr>
							</tbody>
							</table>

					<div id="error">
						&nbsp;
					</div>
				</fieldset>

			</div>
		</div>
    
</asp:Content>

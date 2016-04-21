<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true"  EnableEventValidation="false"  CodeBehind="Registration.aspx.cs" Inherits="EasyUKRaine.Pages.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
            <div id="content" >

        
             <div class="col-xs-6" >

                    <h3>Register</h3>
                    <form class="form-horizontal" >

                        <fieldset>
                            <div class="control-group">

                                <label class="control-label" for="login">Login</label><asp:Label ID="check_login" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
&nbsp;<div class="controls">
                                    <input type="text" id="login" name="login" placeholder="" class="form-control input-lg" runat="server"/>
                                    <p class="help-block">Login can contain any letters or numbers, without spaces</p>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label" for="email">E-mail</label><br/><asp:Label ID="check_email" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="email" id="email" name="email" placeholder="" class="form-control input-lg" runat="server"/>
                                    <p class="help-block">Please provide your E-mail</p>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="password">Password</label><br/><asp:Label ID="check_pass" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="password" id="password" name="password" placeholder="" class="form-control input-lg" runat="server"/>
                                    <p class="help-block">Password should be at least 6 characters</p>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="password_confirm">Password (Confirm)</label><br/><asp:Label ID="check_Confpass" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="password" id="password_confirm" name="password_confirm" placeholder="" class="form-control input-lg" runat="server"/>
                                    <p class="help-block">Please confirm password</p>
                                </div>
                            </div>
                                                
                            <div class="control-group">
                                <label class="control-label" for="fname">Name</label><br/><asp:Label ID="check_name" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="text" id="fname" name="fname" placeholder="" class="form-control input-lg" runat="server"/>
                                    <p class="help-block">Please provide your Name</p>
                                </div>
                            </div>     
                                                
                                                         <div class="control-group">
                                <label class="control-label" for="lname">Surname</label><br/><asp:Label ID="check_surname" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="text" id="lname" name="lname" placeholder="" class="form-control input-lg" runat="server"/> 
                                    <p class="help-block">Please provide your Surname</p>
                                </div>
                            </div>  
                            
                                                
                                                
                                                 <div class="control-group">
                                <label class="control-label" for="country">Country</label><br/><asp:Label ID="check_Country" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="text" id="country" name="country" placeholder="" class="form-control input-lg" runat="server"/> 
                                    <p class="help-block">Please provide your Country</p>
                                </div>
                            </div>  
                            
                            <div class="control-group">
                                <label class="control-label" for="city">City</label><br/><asp:Label ID="check_City" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                                <div class="controls">
                                    <input type="text" id="city" name="city" placeholder="" class="form-control input-lg" runat="server" />
                                    <p class="help-block">Please provide your City</p>
                                </div>
                            </div>  
                                                                           
                                                
                            <div class="control-group">
                                <!-- Button -->
                                <div class="controls">
                                     <asp:Button ID="Button1" runat="server" Text="Registered" OnClick="Button1_Click" class="btn btn-success" />
                                </div>
                            </div>
                        </fieldset>

                     </form>
                 
                 </div>
                </div>

    
</asp:Content>

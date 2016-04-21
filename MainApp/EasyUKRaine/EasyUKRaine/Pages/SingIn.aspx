<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master"  EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="SingIn.aspx.cs" Inherits="EasyUKRaine.Pages.SingIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent"  runat="server">

           <div class="col-xs-4" id="singInYet" style="top: 29px; left: 221px" runat="server">
                <form class="form-signin" >
                    <h2 class="form-signin-heading">Sign In</h2>
                    <asp:Label ID="check_login" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                    <asp:Label ID="check_pass" runat="server" Text="Label" ForeColor="Red" style="font-weight: 700"></asp:Label>
                    <label for="inputEmail" class="sr-only">Email address</label>

                    <input type="text" id="inputLogin" class="form-control" placeholder="Login" required="" autofocus="" runat="server"/>

                    <label for="inputPassword" class="sr-only">Password</label>
                    <input type="password" id="inputPassword" class="form-control" placeholder="Password" lang="en" required="" runat="server"/>
                    <br/>
                    <br/>
                    <asp:Button ID="button_SingIn" runat="server" Text="Sign In" class="btn btn-lg btn-primary btn-block" />
                    <div>
                        If you don`t have account, please sign up!
                        <br/>
                        <a id="regLink" runat="server">Registration</a>
                    </div>
                    <br />

                </form>
               
            </div>
    
            <div class="col-xs-4"  id="singInAlready" style="top: 29px; left: 221px" runat="server">
                <h2 class="form-signin-heading">You have already sing in as <%=  GetUser() %></h2>
                <asp:Button ID="button_SingOut" runat="server" Text="Sing Out" class="btn btn-lg btn-primary btn-block" OnClick="button_SingOut_Click" />
            </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master"  EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="SingIn.aspx.cs" Inherits="EasyUKRaine.Pages.SingIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent"  runat="server">

           <div class="col-xs-4" id="singInYet" style="top: 29px; left: 221px" runat="server">
                <form class="form-signin" >
                    <h2 class="form-signin-heading">Вхід</h2>
                    <label for="inputEmail" class="sr-only">Email address</label>

                    <input type="text" id="inputLogin" class="form-control" placeholder="Login" required="" autofocus="" runat="server"/>
                    <label for="inputPassword" class="sr-only">Password</label>
                    <input type="password" id="inputPassword" class="form-control" placeholder="Password" required="" runat="server"/>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" value="remember-me"> Запам'ятати
                        </label>
                    </div>
                    <asp:Button ID="button_SingIn" runat="server" Text="Sing In" class="btn btn-lg btn-primary btn-block" />

                </form>
               
            </div>
    
            <div class="col-xs-4"  id="singInAlready" style="top: 29px; left: 221px" runat="server">
                <h2 class="form-signin-heading">You have already sing in as <%=  GetUser() %></h2>
                <asp:Button ID="button_SingOut" runat="server" Text="Sing Out" class="btn btn-lg btn-primary btn-block" OnClick="button_SingOut_Click" />
            </div>
</asp:Content>

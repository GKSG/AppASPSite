using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Controls;
using EasyUKRaine.Models.Repository;

namespace EasyUKRaine.Pages
{
    public partial class SingIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            regLink.HRef = RouteTable.Routes.GetVirtualPath(null, "registration", null).VirtualPath;
            check_pass.Visible = false;
            check_login.Visible = false;

            if (IsPostBack)
            {
                if (Validation())
                {
                    string user = inputLogin.Value;
                    string pass = inputPassword.Value;

                    Repository.GetInstance().singIn.Login(user, pass, this);

                    if (!Page.User.Identity.IsAuthenticated)
                    {
                        singInYet.Visible = true;
                        singInAlready.Visible = false;
                    }
                    else
                    {
                        singInYet.Visible = false;
                        singInAlready.Visible = true;
                    }
                    Repository.GetInstance().CurrentUser =
                        Repository.GetInstance()
                            .UsersAccounts.FirstOrDefault(x => x.UserName == user && x.UserPassword == pass);
                    if (Repository.GetInstance().CurrentUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(user, false);
                        Response.Redirect(RouteTable.Routes.GetVirtualPath(null, null).VirtualPath);

                    }
                    else
                    {
                        // ModelState.AddModelError("fail", "Login failed. Please try again");

                        FormsAuthentication.SignOut();
                        Repository.GetInstance().CurrentUser = null;
                    }
                    //Response.Redirect(Request.Path);
                }

            }
            else
            {
                if (!Page.User.Identity.IsAuthenticated)
                {
                    singInYet.Visible = true;
                    singInAlready.Visible = false;
                }
                else
                {
                    singInYet.Visible = false;
                    singInAlready.Visible = true;
                }
                
            }
        }

        private bool Validation()
        {
            bool check = true;
            if (Repository.GetInstance().UsersAccounts.FirstOrDefault(x => x.UserName == inputLogin.Value) == null)
            {
                check_login.Text = "Incorrect login! Please try again!";
                check_login.Visible = true;
                check = false;
            }
            else if (Repository.GetInstance().UsersAccounts.FirstOrDefault(x => x.UserPassword == inputPassword.Value) == null)
            {
                check_login.Text = "Incorrect password! Please try again!";
                check_login.Visible = true;
                check = false;
            }

            return check;
        }

        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<a href='{0}'>Home</a>", path);
        }

        protected string GetUser()
        {
            return Repository.GetInstance().CurrentUser.UserName;
        }

        protected void button_SingOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Repository.GetInstance().CurrentUser = null;
        }
    }

}
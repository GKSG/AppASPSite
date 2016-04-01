using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models;
using EasyUKRaine.Models.Repository;

namespace EasyUKRaine.Controls
{
    public partial class Autorization : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.IsAuthenticated)
            {
                noAutor.Visible = true;
                yesAutor.Visible = false;
            }
            else
            {
                Label_User.Text = GetUser();
                Label_Level.Text = Repository.GetInstance().CurrentUser.Level.ToString();
                Label_Score.Text = Repository.GetInstance().CurrentUser.Score.ToString();

                noAutor.Visible = false;
                yesAutor.Visible = true;
            }
            regLink.HRef = RouteTable.Routes.GetVirtualPath(null, "registration", null).VirtualPath;
            if (IsPostBack)
            {

                string user = Request["user"];
                string pass = Request["pass"];
                string action = Request["action"];
                Repository.GetInstance().CurrentUser = Repository.GetInstance().UsersAccounts.FirstOrDefault(x => x.UserName == user && x.UserPassword == pass);
                if (action == "login" && Repository.GetInstance().CurrentUser != null)
                {
                    
                        noAutor.Visible = false;
                        yesAutor.Visible = true;
                        FormsAuthentication.SetAuthCookie(user, false);
                        Label_User.Text = user;
                        Label_Level.Text = Repository.GetInstance().CurrentUser.Level.ToString();
                        Label_Score.Text = Repository.GetInstance().CurrentUser.Score.ToString();

                }
                else {
                    FormsAuthentication.SignOut();
                    noAutor.Visible = true;
                    yesAutor.Visible = false;
                    Label_User.Text = "";
                    Label_Level.Text = "";
                    Label_Score.Text = "";
                    Repository.GetInstance().CurrentUser = null;
                }
                //Response.Redirect(Request.Path);
            }
        }

        protected string GetUser()
        {
            return Context.User.Identity.Name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace EasyUKRaine.Models
{
    public class SingIn
    {

        public void Login(string user, string pass, Page This)
        {
            Repository.Repository.GetInstance().CurrentUser = Repository.Repository.GetInstance().UsersAccounts.FirstOrDefault(x => x.UserName == user && x.UserPassword == pass);
            if (Repository.Repository.GetInstance().CurrentUser != null)
            {
                FormsAuthentication.SetAuthCookie(user, false);

            }
            else {
                ScriptManager.RegisterClientScriptBlock(This, This.GetType(), "alertMessage", "alert('Wrong login or password!')", true);
                FormsAuthentication.SignOut();
                Repository.Repository.GetInstance().CurrentUser = null;
            }
        }

    }
}
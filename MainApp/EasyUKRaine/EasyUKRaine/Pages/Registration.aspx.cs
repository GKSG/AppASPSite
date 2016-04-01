using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models;
using EasyUKRaine.Models.Repository;

namespace EasyUKRaine.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount();
            UserInfo userInfo = new UserInfo();
            userAccount.Level = 0;
            userAccount.Score = 0;
            userAccount.Donut = "no";
            userAccount.UserName = login.Value;
            userAccount.UserPassword = password.Value;


            userInfo.Name = fname.Value;
            userInfo.Surname = lname.Value;
            userInfo.Country = country.Value;
            userInfo.Location = city.Value;
            userInfo.E_mail = email.Value;
            userInfo.DateOfBirth = Convert.ToDateTime("1995.10.12");
            userInfo.DateOfReg = Convert.ToDateTime("2016.03.22");


            
            Repository.GetInstance().SaveUser(userInfo,userAccount);
        }
    }
}
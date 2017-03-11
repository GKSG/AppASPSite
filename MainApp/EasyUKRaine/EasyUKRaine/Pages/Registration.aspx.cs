using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
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
            check_login.Visible = false;
            check_City.Visible = false;
            check_Confpass.Visible = false;
            check_Country.Visible = false;
            check_email.Visible = false;
            check_name.Visible = false;
            check_pass.Visible = false;
            check_surname.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "hgvjbkln" + "');", true);
            if (Validation())
            {
                UserAccount userAccount = new UserAccount();
                UserInfo userInfo = new UserInfo();
                userAccount.Level = 0;
                userAccount.Score = 0;
                userAccount.Donut = "no";

                userAccount.UserName = login.Value;
                userAccount.UserPassword = password.Value;
<<<<<<< HEAD

=======
                userAccount.Check_FirstTest = false;
>>>>>>> origin/Andrew

                userInfo.Name = fname.Value;
                userInfo.Surname = lname.Value;
                userInfo.Country = country.Value;
                userInfo.Location = city.Value;
                userInfo.E_mail = email.Value;
<<<<<<< HEAD
                userInfo.DateOfBirth = Convert.ToDateTime("1995.10.12");
                userInfo.DateOfReg = DateTime.Today;
=======
                userInfo.DateOfBirth = null;
                userInfo.DateOfReg = DateTime.Today;
                
>>>>>>> origin/Andrew


                Repository.GetInstance().SaveUser(userInfo, userAccount);
                Repository.GetInstance().singIn.Login(userAccount.UserName, userAccount.UserPassword, this);
                Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "firstTest", null).VirtualPath);
            }
        }

        bool Validation()
        {
            bool check = true;


            UserAccount u = Repository.GetInstance()
                            .UsersAccounts.FirstOrDefault(x => x.UserName == login.Value);

            UserInfo em = Repository.GetInstance()
                .UsersInfos.FirstOrDefault(x => x.E_mail == email.Value);

            string i = "kjdsgn";
            switch (login.Value)
            {
                case "":
                    {
                        check_login.Text = "Pease enter login";
                        check_login.Visible = true;
                        check = false;
                        break;
                    }
                default:
                    check = true;
                    break;
            }
            if (password.Value.Length < 6)
            {
                check_pass.Text = "Your password so short!";
                check_pass.Visible = true;
                check = false;
            }
            if (password.Value != password_confirm.Value)
            {
                check_Confpass.Text = "Your passwords not equals!";
                check_Confpass.Visible = true;
                check = false;
            }
            if (u != null)
            {
                check_login.Text = "its login already has existed!";
                check_login.Visible = true;
                check = false;
            }

            if (em != null)
            {
                check_email.Text = "its email already has existed!";
                check_email.Visible = true;
                check = false;
            }

            if (fname.Value == "")
            {
                check_name.Text = "Input First Name!!";
                check_name.Visible = true;
                check = false;
            }
            if (lname.Value == "")
            {
                check_surname.Text = "Input Last Name!!";
                check_surname.Visible = true;
                check = false;
            }




            return check;
        }
    }
}
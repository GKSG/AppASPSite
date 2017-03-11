using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repository;

namespace EasyUKRaine.Controls
{
    public partial class MenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<string> GetCategories()
        {
            return Repository.GetInstance().GetCategoryList;
        }

        protected string CreateHomeLinkHtml()
        {
            string path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return string.Format("<li><a href='{0}'>Home</a></li>", path);
        }

        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];

            string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "category", category }, { "page", "1" } }).VirtualPath;

            // string result = string.Format("<a href='{0}' {1}>{2}</a>", path, category == selectedCategory ? "class='selected'" : "", category);
            switch (category)
            {
<<<<<<< HEAD
                path = RouteTable.Routes.GetVirtualPath(null, "firstTest", null).VirtualPath;
            }

            if (category == "Games")
            {
                path = RouteTable.Routes.GetVirtualPath(null, "Games", null).VirtualPath;
            }
=======
                case "Test":
                    if (Repository.GetInstance().CurrentUser != null &&
                    Repository.GetInstance().CurrentUser.Check_FirstTest == false)
                    {
                        path = RouteTable.Routes.GetVirtualPath(null, "firstTest", null).VirtualPath;
                    }

                    else if (Repository.GetInstance().CurrentUser != null)
                    {
                        path = RouteTable.Routes.GetVirtualPath(null, "vocabularyTest", null).VirtualPath;
                    }

                    else if (Repository.GetInstance().CurrentUser == null)
                    {
                        path = RouteTable.Routes.GetVirtualPath(null, "SingIn", null).VirtualPath;
                    }
                    break;
                case "Games":
                    path = RouteTable.Routes.GetVirtualPath(null, "Games", null).VirtualPath;
                    break;

                case "Grammar":
                    path = RouteTable.Routes.GetVirtualPath(null, "Grammar", null).VirtualPath;
                    break;
                case "About":
                    path = RouteTable.Routes.GetVirtualPath(null, "about", null).VirtualPath;
                    break;
                case "Vocabulary":
                    path = RouteTable.Routes.GetVirtualPath(null, "Tags", null).VirtualPath;
                    break;
                case "Video":
                    path = RouteTable.Routes.GetVirtualPath(null, "video", null).VirtualPath;
                    break;
>>>>>>> origin/Andrew

            if (category == "Grammar")
            {
                path = RouteTable.Routes.GetVirtualPath(null, "Grammar", null).VirtualPath;
            }

            if (category == "About")
            {
                path = RouteTable.Routes.GetVirtualPath(null, "about", null).VirtualPath;
            }
            

            return  string.Format("<li><a href='{0}' >{1}</a></li>",path,  category);
        }
    }
}
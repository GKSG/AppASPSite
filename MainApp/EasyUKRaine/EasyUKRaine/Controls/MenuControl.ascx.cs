﻿using System;
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
            return string.Format("<a href='{0}'>Home</a>", path);
        }

        protected string CreateLinkHtml(string category)
        {
            string selectedCategory = (string)Page.RouteData.Values["category"] ?? Request.QueryString["category"];

            string path = RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() { { "category", category }, { "page", "1" } }).VirtualPath;

           // string result = string.Format("<a href='{0}' {1}>{2}</a>", path, category == selectedCategory ? "class='selected'" : "", category);
            if (category == "Test")
            {
                path = RouteTable.Routes.GetVirtualPath(null, "firstTest", null).VirtualPath;

            }

            return  string.Format("<a href='{0}' {1}>{2}</a>", path, category == selectedCategory ? "class='selected'" : "", category);
        }
    }
}
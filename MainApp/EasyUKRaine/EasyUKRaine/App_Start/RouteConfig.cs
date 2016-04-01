using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace EasyUKRaine.App_Start
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, "main/{category}/{page}", "~/Pages/MainForm.aspx");
            routes.MapPageRoute(null, "main/{page}", "~/Pages/MainForm.aspx");
            routes.MapPageRoute(null, "", "~/Pages/MainForm.aspx");
            routes.MapPageRoute(null, "main", "~/Pages/MainForm.aspx");

            routes.MapPageRoute("registration", "registration", "~/Pages/Registration.aspx");
            routes.MapPageRoute("account", "account", "~/Pages/Account_Login.aspx");
            //routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");

            //routes.MapPageRoute("admin_orders", "admin/orders", "~/Pages/Admin/Orders.aspx");
            //routes.MapPageRoute("admin_products", "admin/products", "~/Pages/Admin/Products.aspx");
        }
    }
}
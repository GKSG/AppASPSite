using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyUKRaine.Pages
{
    public partial class Games : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "Tags", null).VirtualPath);
        }
    }
}
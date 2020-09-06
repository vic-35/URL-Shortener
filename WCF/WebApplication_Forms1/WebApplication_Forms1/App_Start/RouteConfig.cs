using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebApplication_Forms1
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("default", "", "~/Default.aspx");
            routes.MapPageRoute("default2", "About", "~/About.aspx");
            routes.MapPageRoute("default1", "{id}", "~/Default.aspx");
        }
    }
}

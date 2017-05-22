using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UmbracoExample.Site.Events
{
    internal static class RouteBuilder
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapHttpRoute(
            //    name: "GetMyBookmarks",
            //    routeTemplate: "api/mybookmarks/get/",
            //    defaults: new {controller = "Custom", action = "GetMyBookmarks"});

            //RouteTable.Routes.MapRoute(
            //    name: "MyBookmarksApiController",
            //    url: "MyBookmarksApi/{action}/{ids}",
            //    defaults: new
            //    {
            //        controller = "MyBookmarksApi",
            //        action = "GetMyBookmarks",
            //        ids = UrlParameter.Optional
            //    });
        }
    }
}
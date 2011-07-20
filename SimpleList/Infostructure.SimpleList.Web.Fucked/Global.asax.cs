using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using System.ServiceModel.Activation;
//using Infostructure.SimpleList.Web.Service;

namespace Infostructure.SimpleList.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}.aspx/{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            // Edit the base address of Service1 by replacing the "Service1" string below
            //RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));

            //routes.MapRoute(
            //    "SimpleList_Default",
            //    "{action}",
            //    new {
            //        controller = "SimpleList", 
            //        action = "Index"
            //    } // Parameter defaults
            //);

            //routes.MapRoute(
            //    "SimpleList_ListItems",
            //    "Lists/{simpleListId}/ListItems",
            //    new
            //    {
            //        controller = "SimpleList",
            //        action = "ListItems"
            //    }
            //);

            //routes.MapRoute(
            //    "SimpleList_NewListItem",
            //    "Lists/{simpleListId}/Create",
            //    new
            //    {
            //        controller = "SimpleList",
            //        action = "NewListItem"
            //    }
            //);

            //routes.MapRoute(
            //    "Account_Default",
            //    "Account/{action}/{id}",
            //    new
            //    {
            //        controller = "Account",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }
            //);

            //routes.MapRoute(
            //    "Default",
            //    "{controller}.aspx/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}
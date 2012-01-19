using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ServiceModel.Activation;
using Microsoft.Web.Mvc;
using Infostructure.SimpleList.Web.Services;

namespace Infostructure.SimpleList.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    // http://zayko.net/post/About-using-WCF-RESTful-services-together-with-ASPNET-MVC-projects.aspx - This works, so long as the URL does not use "Api" or "Service" as the endpoint, which is weird.
    // http://stackoverflow.com/questions/8170650/actionlink-behavior-with-asp-net-wcf-and-routes-add-in-mvc-application
    // http://stephenwalther.com/blog/archive/2008/08/07/asp-net-mvc-tip-30-create-custom-route-constraints.aspx
    // http://stackoverflow.com/questions/6250426/wcf-rest-web-api-and-mvc-on-same-server-and-port

    public class MvcApplication : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
        }
         
        private void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new { controller = "^(?!ApiService).*" }
            );

            routes.Add(new ServiceRoute("ApiService", new WebServiceHostFactory(), typeof(ApiService)));

            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
        }
    }
}
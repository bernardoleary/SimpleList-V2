using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ServiceModel.Activation;
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
                "Default", // Route name
                "{controller}.aspx/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }); // Parameter defaults

            // Edit the base address of Service1 by replacing the "Service1" string below
            //RouteTable.Routes.Add(new ServiceRoute("SimpleListService.svc", new WebServiceHostFactory(), typeof(SimpleListService)));

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            AutoMapper.Mapper.CreateMap<DataModel.Models.SimpleListItem, Models.SimpleListItemViewModel>();
            AutoMapper.Mapper.CreateMap<DataModel.Models.SimpleList, Models.SimpleListViewModel>();
        }
    }
}
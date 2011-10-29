using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infostructure.SimpleList.Web.Controllers
{
    public static class ControllerExtension
    {                  
        public static bool? GetIsAspnetAuthenticated(this Controller controller)
        {
            string userName = controller.Request.QueryString["userName"];
            string password = controller.Request.QueryString["password"];
            return controller.User.Identity.IsAuthenticated ? new bool?(true) : (userName != null && password != null ? new bool?(false) : null);
        }
    }
}
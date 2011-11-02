using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Infostructure.SimpleList.Web.Models;

namespace Infostructure.SimpleList.Web.Controllers
{
    public static class ControllerExtension
    {
        public static bool IsUserAuthenticated(this Controller controller)
        {
            // tes if we've been Forms Authenticated by ASP.NET
            if (controller.User.Identity.IsAuthenticated) return true;

            // test if we are using the API for authentication
            string userName = controller.Request.QueryString["userName"];
            string password = controller.Request.QueryString["password"];
            return IsUserAuthenticated(controller, userName, password);
        }

        public static bool IsUserAuthenticated(this Controller controller, string userName, string password)
        {
            if (userName != null && password != null)
            {
                IMembershipService membershipService = new AccountMembershipService();
                return membershipService.ValidateUser(userName, password);
            }
            else
                return false;
        }
    }
}
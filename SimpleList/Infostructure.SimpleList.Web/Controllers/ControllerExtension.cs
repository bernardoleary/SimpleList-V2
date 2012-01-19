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
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.BusinessLogic.Repositories;

namespace Infostructure.SimpleList.Web.Controllers
{
    public static class ControllerExtension
    {
        private static UserRepository _userRepository = new UserRepository();

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

        /// <summary>
        /// This method has been implemented so as we can refactor the entire application to use the Infostructure.SimpleList.Web.Service.Api class, which takes a userName and password parameter for every call.
        /// This method returns the User object for an authenticated user, whether they have come in through the service or the web front-end.
        /// There is still a bit of a "smell" about this method and some of the authetication architecture, in particular that I'm passing around unencrypted passwords, but it's tollerable for the time being.
        /// Since the API service is accessed directly, there should be no need to use this method where the user is not ASP.NET authenticated.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>A Infostructure.SimpleList.DataModel.Models.User instance if authetication is successful.</returns>
        public static User GetUserCredentials(this Controller controller)
        {
            // Get the username and password off the quesry string, if they're there.
            string userName = controller.Request.QueryString["userName"];
            string password = controller.Request.QueryString["password"];

            if (userName != null && password != null) // This is where we would go if we've come in via the service.
            {
                IMembershipService membershipService = new AccountMembershipService();
                if (membershipService.ValidateUser(userName, password))
                    return _userRepository.GetUser(userName);
                else
                    return null;
            }
            else if (controller.User.Identity.IsAuthenticated) // This is where we go if we've come in via the web front-end, since the request will not be ASP.NET authenticated by the service.
                return _userRepository.GetUser(userName);
            else // User has not been successfully authenticated.
                return null;
        }
    }
}
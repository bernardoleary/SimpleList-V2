using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.DataModel.Extensions;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.Web.Models;
using Infostructure.SimpleList.Web.Models.Mapping;

namespace Infostructure.SimpleList.Web.Services
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class ApiService : IApiService
    {
        private SimpleListRepository _simpleListRepository = null;
        private SimpleListItemRepository _simpleListItemRepository = null;
        private UserRepository _userRepository = null;

        public SimpleListViewModel GetSimpleList(int simpleListId)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return null;

            var mapper = new Mapper();
            _simpleListRepository = new SimpleListRepository();
            return mapper.SimpleListToSimpleListViewModel(_simpleListRepository.GetSimpleList(user.ID, simpleListId), true);
        }

        public IEnumerable<SimpleListViewModel> GetSimpleLists(bool populateSubStructures)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return null;

            var mapper = new Mapper();
            _simpleListRepository = new SimpleListRepository();
            var simpleLists = _simpleListRepository.GetSimpleLists(user.ID);
            return mapper.SimpleListsToSimpleListViewModels(simpleLists, populateSubStructures);
        }

        public int CreateSimpleList(SimpleListViewModel simpleListViewModel)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return 0;

            var mapper = new Mapper();
            var simpleList = mapper.SimpleListViewModelToSimpleList(simpleListViewModel);
            simpleList.UserID = user.ID;
            simpleList.DateAdded = DateTime.Now;
            _simpleListRepository = new SimpleListRepository();
            return _simpleListRepository.AddSimpleList(simpleList);
        }

        public int CloneSimpleList(int simpleListIdOriginal, string simpleListNameNew, bool includeDoneSimpleListItems)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return 0;
 
            _simpleListRepository = new SimpleListRepository();
            var simpleListToClone = _simpleListRepository.GetSimpleList(user.ID, simpleListIdOriginal);
            var simpleListCloned = simpleListToClone.Clone(user.ID, includeDoneSimpleListItems, simpleListNameNew);
            return _simpleListRepository.AddSimpleList(simpleListCloned);
        }

        public int CreateSimpleListItem(SimpleListItemViewModel simpleListItemViewModel) 
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return 0;

            var mapper = new Mapper();
            var simpleListItem = mapper.SimpleListItemViewModelToSimpleListItem(simpleListItemViewModel);
            _simpleListItemRepository = new SimpleListItemRepository();
            return _simpleListItemRepository.AddSimpleListItem(simpleListItem);
        }

        public int DeleteSimpleListItem(int simpleListItemId)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return 0;

            _simpleListItemRepository = new SimpleListItemRepository();
            return _simpleListItemRepository.DeleteSimpleListItem(user.ID, simpleListItemId);
        }

        public int DeleteSimpleList(int simpleListId)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return 0;

            _simpleListRepository = new SimpleListRepository();
            return _simpleListRepository.DeleteSimpleList(user.ID, simpleListId);
        }

        public int ToggleDone(int simpleListItemId)
        {
            // Authenticate.
            var user = GetUserCredentials();
            if (user == null) return 0;

            _simpleListItemRepository = new SimpleListItemRepository();
            return _simpleListItemRepository.ToggleSimpleListItemDone(user.ID, simpleListItemId);
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
        private User GetUserCredentials()
        {
            _userRepository = new UserRepository();

            // Get the username and password off the query string, if they're there.
            string userName = HttpContext.Current.Request.QueryString["userName"];
            string password = HttpContext.Current.Request.QueryString["password"];

            // This is where we would go if we've come in via the service.
            if (userName != null && password != null) 
            {
                IMembershipService membershipService = new AccountMembershipService();
                if (membershipService.ValidateUser(userName, password))
                    return _userRepository.GetUser(userName);
                else
                    return null;
            }
            // This is where we go if we've come in via the web front-end, since the request will not be ASP.NET authenticated by the service.
            else if (HttpContext.Current.User.Identity.IsAuthenticated)
                return _userRepository.GetUser(HttpContext.Current.User.Identity.Name);
            // User has not been successfully authenticated.
            else
                return null;
        }
    }
}

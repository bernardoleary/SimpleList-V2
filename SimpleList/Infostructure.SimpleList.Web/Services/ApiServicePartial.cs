using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infostructure.SimpleList.Web.Services
{
    /// <summary>
    /// This part of the partial class is used as a wrapper for the methods that do the actual work.
    /// It allows us to implement a "proper" RESTful interface from the service front-end.
    /// All this really does actually is allow us to put the UID and PW as part of the "help" page that .NET provide.
    /// Goes against the Code Complete principle of programming "into" a language to some extent, but there's a benefit.
    /// </summary>
    public partial class ApiService : IApiService
    {
        public int CloneSimpleList(string userName, string password, string simpleListIdOriginal, string simpleListNameNew, string includeDoneSimpleListItems)
        {
            return CloneSimpleList(int.Parse(simpleListIdOriginal), simpleListNameNew, bool.Parse(includeDoneSimpleListItems));
        }

        public Models.SimpleListViewModel GetSimpleList(string userName, string password, string simpleListId)
        {
            return GetSimpleList(int.Parse(simpleListId));
        }

        public IEnumerable<Models.SimpleListViewModel> GetSimpleLists(string userName, string password, string populateSubStructures)
        {
            return GetSimpleLists(bool.Parse(populateSubStructures));
        }

        public int CreateSimpleListItem(string userName, string password, string simpleListId, Models.SimpleListItemViewModel simpleListItemViewModel)
        {
            return CreateSimpleListItem(simpleListItemViewModel);
        }

        public int DeleteSimpleListItem(string userName, string password, string simpleListId, string simpleListItemId)
        {
            return DeleteSimpleListItem(int.Parse(simpleListItemId));
        }

        public int DeleteSimpleList(string userName, string password, string simpleListItemId)
        {
            return DeleteSimpleList(int.Parse(simpleListItemId));
        }

        public int ToggleDone(string userName, string password, string simpleListId, string simpleListItemId)
        {
            return ToggleDone(int.Parse(simpleListItemId));
        }

        public int CreateSimpleList(string userName, string password, Models.SimpleListViewModel simpleListViewModel)
        {
            return CreateSimpleList(simpleListViewModel);
        }
    }
}

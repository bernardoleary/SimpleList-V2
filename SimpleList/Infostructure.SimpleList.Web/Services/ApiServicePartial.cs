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
    /// </summary>
    public partial class ApiService : IApiService
    {
        public Models.SimpleListViewModel GetSimpleList(string simpleListId)
        {
            return GetSimpleList(int.Parse(simpleListId));
        }

        public IEnumerable<Models.SimpleListViewModel> GetSimpleLists(string populateSubStructures)
        {
            return GetSimpleLists(bool.Parse(populateSubStructures));
        }

        public int CreateSimpleListItem(string simpleListId, Models.SimpleListItemViewModel simpleListItemViewModel)
        {
            return CreateSimpleListItem(simpleListItemViewModel);
        }

        public int DeleteSimpleListItem(string simpleListId, string simpleListItemId)
        {
            return DeleteSimpleListItem(int.Parse(simpleListItemId));
        }

        public int DeleteSimpleList(string simpleListItemId)
        {
            return DeleteSimpleList(int.Parse(simpleListItemId));
        }

        public int ToggleDone(string simpleListId, string simpleListItemId)
        {
            return ToggleDone(int.Parse(simpleListItemId));
        }
    }
}

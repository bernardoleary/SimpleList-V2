﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.Web.Models;

namespace Infostructure.SimpleList.Web.Services
{
    [ServiceContract]
    // http://stackoverflow.com/questions/5084239/wcf-restful-json-web-service-post-nested-list-of-object
    // http://dotnetninja.wordpress.com/2008/05/02/rest-service-with-wcf-and-json/
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public interface IApiService
    {
        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListIdOriginal}?userName={userName}&password={password}&simpleListNameNew={simpleListNameNew}",
            Method = "POST",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int CloneSimpleList(string userName, string password, string simpleListIdOriginal, string simpleListNameNew, string includeDoneSimpleListItems);

        [WebGet(
            UriTemplate = "SimpleList/{simpleListId}?userName={userName}&password={password}",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        SimpleListViewModel GetSimpleList(string userName, string password, string simpleListId);

        [WebGet(
            UriTemplate = "SimpleList?userName={userName}&password={password}&populateSubStructures={populateSubStructures}",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        IEnumerable<Models.SimpleListViewModel> GetSimpleLists(string userName, string password, string populateSubStructures);

        [WebInvoke(
            UriTemplate = "SimpleList?userName={userName}&password={password}",
            Method = "POST",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int CreateSimpleList(string userName, string password, SimpleListViewModel simpleListViewModel);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}/SimpleListItem?userName={userName}&password={password}",
            Method = "POST",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CreateSimpleListItem(string userName, string password, string simpleListId, SimpleListItemViewModel simpleListItemViewModel);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}/SimpleListItem/{simpleListItemId}?userName={userName}&password={password}", 
            Method = "DELETE",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        int DeleteSimpleListItem(string userName, string password, string simpleListId, string simpleListItemId);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}?userName={userName}&password={password}", 
            Method = "DELETE",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int DeleteSimpleList(string userName, string password, string simpleListId);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}/SimpleListItem/{simpleListItemId}?userName={userName}&password={password}", 
            Method = "PUT",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int ToggleDone(string userName, string password, string simpleListId, string simpleListItemId);
    }
}
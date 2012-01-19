using System;
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
        [WebGet(
            UriTemplate = "SimpleList/{simpleListId}",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        SimpleListViewModel GetSimpleList(string simpleListId);

        [WebGet(
            UriTemplate = "SimpleList?populateSubStructures={populateSubStructures}",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        IEnumerable<Models.SimpleListViewModel> GetSimpleLists(string populateSubStructures);

        [WebInvoke(
            UriTemplate = "SimpleList",
            Method = "POST",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int CreateSimpleList(SimpleListViewModel simpleListViewModel);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}/SimpleListItem",
            Method = "POST",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        int CreateSimpleListItem(string simpleListId, SimpleListItemViewModel simpleListItemViewModel);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}/SimpleListItem/{simpleListItemId}", 
            Method = "DELETE",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        int DeleteSimpleListItem(string simpleListId, string simpleListItemId);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}", 
            Method = "DELETE",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int DeleteSimpleList(string simpleListId);

        [WebInvoke(
            UriTemplate = "SimpleList/{simpleListId}/SimpleListItem/{simpleListItemId}", 
            Method = "PUT",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json,
            RequestFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        int ToggleDone(string simpleListId, string simpleListItemId);
    }
}
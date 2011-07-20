using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Infostructure.SimpleList.Web.Service
{
    [ServiceContract]
    // http://stackoverflow.com/questions/5084239/wcf-restful-json-web-service-post-nested-list-of-object
    // http://dotnetninja.wordpress.com/2008/05/02/rest-service-with-wcf-and-json/
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public interface ISimpleListService
    {
        //[System.ServiceModel.OperationContract]
        [WebGet(
            UriTemplate = "{userName}|{password}/Lists",
            ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, 
            BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        List<Models.SimpleListModel> GetSimpleLists(string userName, string password);

        [WebInvoke(UriTemplate = "", Method = "POST", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        SampleItem Create(SampleItem instance);

        [WebGet(UriTemplate = "{id}", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        SampleItem Get(string id);

        [WebInvoke(UriTemplate = "{id}", Method = "PUT", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        SampleItem Update(string id, SampleItem instance);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        void Delete(string id);
    }
}
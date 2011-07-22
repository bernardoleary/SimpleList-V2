using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.DataModel;

namespace Infostructure.SimpleList.Web.Service
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleListService : ISimpleListService
    {
        private SimpleListRepository _simpleListRepository = null;
        private SimpleListItemRepository _simpleListItemRepository = null;

        public List<Models.SimpleListModel> GetSimpleLists(string userName, string password)
        {
            _simpleListRepository = new SimpleListRepository();
            var simpleLists = _simpleListRepository.GetSimpleLists(userName, password);
            return (from simpleList in simpleLists
                    select new Models.SimpleListModel
                    {
                        ID = simpleList.ID,
                        UserID = simpleList.UserID,
                        Name = simpleList.Name,
                        AllDone = simpleList.AllDone,
                        DateAdded = simpleList.DateAdded
                    }).ToList();
        }

        public List<Models.SimpleListItemModel> GetSimpleListItems(string userName, string password, string simpleListId)
        {
            _simpleListItemRepository = new SimpleListItemRepository();
            var simpleListItems = _simpleListItemRepository.GetSimpleListItems(int.Parse(simpleListId));
            return (from simpleListItem in simpleListItems
                    select new Models.SimpleListItemModel
                    {
                        ID = simpleListItem.ID,
                        Description = simpleListItem.Description,
                        Done = simpleListItem.Done,
                        SimpleListID = simpleListItem.SimpleListID
                    }).ToList();
        }

        public SampleItem Create(SampleItem instance)
        {
            // TODO: Add the new instance of SampleItem to the collection
            throw new NotImplementedException();
        }

        public SampleItem Get(string id)
        {
            // TODO: Return the instance of SampleItem with the given id
            throw new NotImplementedException();
        }

        public SampleItem Update(string id, SampleItem instance)
        {
            // TODO: Update the given instance of SampleItem in the collection
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            // TODO: Remove the instance of SampleItem with the given id from the collection
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infostructure.SimpleList.Web.Models;
using Infostructure.SimpleList.DataModel.Models;

namespace Infostructure.SimpleList.Web.Models.Mapping
{
    public class Mapper
    {
        public SimpleListViewModel SimpleListToSimpleListViewModel(DataModel.Models.SimpleList simpleList, bool populateSubStructures = true)
        {
            SimpleListViewModel simpleListViewModel = new SimpleListViewModel();
            simpleListViewModel.ID = simpleList.ID;
            simpleListViewModel.Name = simpleList.Name;
            simpleListViewModel.UserID = simpleList.UserID;
            simpleListViewModel.AllDone = simpleList.AllDone;
            simpleListViewModel.DateAdded = simpleList.DateAdded;
            simpleListViewModel.SimpleListItems = SimpleListItemsToSimpleListItemViewModels(simpleList.SimpleListItems.AsEnumerable<DataModel.Models.SimpleListItem>());
            return simpleListViewModel;
        }

        public SimpleListItemViewModel SimpleListItemToSimpleListItemViewModel(DataModel.Models.SimpleListItem simpleListItem)
        {
            SimpleListItemViewModel simpleListItemViewModel = new SimpleListItemViewModel();
            simpleListItemViewModel.ID = simpleListItem.ID;
            simpleListItemViewModel.Done = simpleListItem.Done;
            simpleListItemViewModel.Description = simpleListItem.Description;
            simpleListItemViewModel.SimpleListID = simpleListItem.SimpleListID;
            return simpleListItemViewModel;
        }

        public IEnumerable<SimpleListItemViewModel> SimpleListItemsToSimpleListItemViewModels(IEnumerable<DataModel.Models.SimpleListItem> simpleListItems)
        {
            var simpleListItemViewModels = new List<SimpleListItemViewModel>();
            foreach (var simpleListItem in simpleListItems)
                simpleListItemViewModels.Add(SimpleListItemToSimpleListItemViewModel(simpleListItem));
            return simpleListItemViewModels;
        }

        public IEnumerable<SimpleListViewModel> SimpleListsToSimpleListViewModels(IEnumerable<DataModel.Models.SimpleList> simpleLists, bool populateSubStructures = true)
        {
            var simpleListItemViewModels = new List<SimpleListViewModel>();
            foreach (var simpleList in simpleLists)
                simpleListItemViewModels.Add(SimpleListToSimpleListViewModel(simpleList));
            return simpleListItemViewModels;
        }
    }
}
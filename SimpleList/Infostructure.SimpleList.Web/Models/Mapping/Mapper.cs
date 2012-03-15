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
            // We only populate the SimpleListItems if specifically requested.
            if (populateSubStructures)
                simpleListViewModel.SimpleListItems = SimpleListItemsToSimpleListItemViewModels(simpleList.SimpleListItems.AsEnumerable<DataModel.Models.SimpleListItem>());
            return simpleListViewModel;
        }

        public DataModel.Models.SimpleList SimpleListViewModelToSimpleList(SimpleListViewModel simpleListViewModel)
        {
            DataModel.Models.SimpleList simpleList = new DataModel.Models.SimpleList();
            simpleList.ID = simpleListViewModel.ID;
            simpleList.Name = simpleListViewModel.Name;            
            simpleList.AllDone = simpleListViewModel.AllDone;
            simpleList.DateAdded = simpleListViewModel.DateAdded;
            // We only populate the UserID if we have a value to populate.
            if (simpleListViewModel.UserID.HasValue)
                simpleList.UserID = simpleListViewModel.UserID.Value;
            return simpleList;
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

        public SimpleListItem SimpleListItemViewModelToSimpleListItem(SimpleListItemViewModel simpleListItemViewModel)
        {
            SimpleListItem simpleListItem = new SimpleListItem();
            simpleListItem.ID = simpleListItemViewModel.ID;
            simpleListItem.Done = simpleListItemViewModel.Done;
            simpleListItem.Description = simpleListItemViewModel.Description;
            simpleListItem.SimpleListID = simpleListItemViewModel.SimpleListID;
            return simpleListItem;
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
                simpleListItemViewModels.Add(SimpleListToSimpleListViewModel(simpleList, populateSubStructures));
            return simpleListItemViewModels;
        }

        public User UserViewModelToUser(UserViewModel userViewModel)
        {
            User user = new User();
            user.ID = userViewModel.ID;
            user.Name = userViewModel.Name;
            user.Password = userViewModel.Password;
            user.ShowDoneListItems = userViewModel.ShowDoneListItems;
            user.ShowDoneLists = userViewModel.ShowDoneLists;
            return user;
        }

        public UserViewModel UserToUserViewModel(User user)
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.ID = user.ID;
            userViewModel.Name = user.Name;
            userViewModel.Password = user.Password;
            userViewModel.ShowDoneListItems = user.ShowDoneListItems;
            userViewModel.ShowDoneLists = user.ShowDoneLists;
            return userViewModel;
        } 
    }
}
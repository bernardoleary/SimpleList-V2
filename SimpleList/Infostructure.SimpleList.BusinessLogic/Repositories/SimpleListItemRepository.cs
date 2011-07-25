using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.DataModel.DataAccess;

namespace Infostructure.SimpleList.BusinessLogic.Repositories
{
    public class SimpleListItemRepository
    {
        private SimpleListEntities _simpleListEntities = null;

        public SimpleListItemRepository()
        {
            _simpleListEntities = new SimpleListEntities();
        }

        public SimpleListItemRepository(SimpleListEntities _simpleListEntities)
        {
            this._simpleListEntities = _simpleListEntities;
        }

        public IEnumerable<SimpleListItem> GetSimpleListItems(SimpleList.DataModel.Models.SimpleList simpleList)
        {
            var simpleListItems = from simpleListItem in _simpleListEntities.SimpleListItems
                                  where simpleListItem.SimpleListID == simpleList.ID
                                  select simpleListItem;
            return simpleListItems;
        }

        public IEnumerable<SimpleListItem> GetSimpleListItems(int simpleListId)
        {
            var simpleListItems = from simpleListItem in _simpleListEntities.SimpleListItems
                                  where simpleListItem.SimpleListID == simpleListId
                                  select simpleListItem;
            return simpleListItems;
        }

        public SimpleListItem GetSimpleListItem(int simpleListItemId)
        {
            var simpleListItemOut = (from simpleListItem in _simpleListEntities.SimpleListItems
                                  where simpleListItem.ID == simpleListItemId
                                  select simpleListItem).FirstOrDefault();
            return simpleListItemOut;
        }

        public IEnumerable<SimpleListItem> GetSimpleListItems(User user)
        {
            var simpleListItems = from simpleListItem in _simpleListEntities.SimpleListItems
                                  join simpleList in _simpleListEntities.SimpleLists on simpleListItem.SimpleListID equals simpleList.ID
                                  where simpleList.UserID == user.ID
                                  select simpleListItem;
            return simpleListItems;
        }

        public void AddSimpleListItem(SimpleListItem simpleListItem)
        {
            _simpleListEntities.SimpleListItems.Add(simpleListItem);
            _simpleListEntities.SaveChanges();
        }

        public void DeleteSimpleListItem(SimpleListItem simpleListItem)
        {
            _simpleListEntities.SimpleListItems.Remove(simpleListItem);
            _simpleListEntities.SaveChanges();
        }
    }
}

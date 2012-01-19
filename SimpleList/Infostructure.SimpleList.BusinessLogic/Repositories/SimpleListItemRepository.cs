﻿using System;
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

        public int AddSimpleListItem(SimpleListItem simpleListItem)
        {
            _simpleListEntities.SimpleListItems.Add(simpleListItem);
            return _simpleListEntities.SaveChanges();
        }

        public int DeleteSimpleListItem(int simpleListItemId)
        {
            var simpleListItem = GetSimpleListItem(simpleListItemId);
            _simpleListEntities.SimpleListItems.Remove(simpleListItem);
            return _simpleListEntities.SaveChanges();
        }

        public int UpdateSimpleListItem(SimpleListItem simpleListItem)
        {
            var entry = _simpleListEntities.Entry<SimpleListItem>(simpleListItem);
            entry.State = System.Data.EntityState.Modified;
            return _simpleListEntities.SaveChanges();
        }

        public int ToggleSimpleListItemDone(int simpleListItemId)
        {
            var simpleListItem = GetSimpleListItem(simpleListItemId);
            simpleListItem.Done = !simpleListItem.Done;
            return UpdateSimpleListItem(simpleListItem);
        }
    }
}

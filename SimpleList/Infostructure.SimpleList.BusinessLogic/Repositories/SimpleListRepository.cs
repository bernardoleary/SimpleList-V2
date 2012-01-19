using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.Utilities.Exceptions;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.DataModel.DataAccess;

namespace Infostructure.SimpleList.BusinessLogic.Repositories
{
    public class SimpleListRepository
    {
        private SimpleListEntities _simpleListEntities = null;

        public SimpleListRepository()
        {
            _simpleListEntities = new SimpleListEntities();
        }

        public SimpleListRepository(SimpleListEntities _simpleListEntities)  
        {
            this._simpleListEntities = _simpleListEntities;
        }

        public SimpleList.DataModel.Models.SimpleList GetSimpleList(int simpleListId)
        {
            var simpleListOut = (from simpleList in _simpleListEntities.SimpleLists
                              where simpleList.ID == simpleListId
                              select simpleList).FirstOrDefault();
            return simpleListOut;
        }

        public IEnumerable<SimpleList.DataModel.Models.SimpleList> GetSimpleLists(int userId)
        {
            var simpleLists = from simpleList in _simpleListEntities.SimpleLists
                              where simpleList.UserID == userId
                              select simpleList;
            return simpleLists;
        }

        public int AddSimpleList(SimpleList.DataModel.Models.SimpleList simpleList)
        {
            _simpleListEntities.SimpleLists.Add(simpleList);
            return _simpleListEntities.SaveChanges();
        }

        public int DeleteSimpleList(int simpleListId)
        {
            var simpleListItemRepository = new SimpleListItemRepository(_simpleListEntities);
            var simpleListItems = simpleListItemRepository.GetSimpleListItems(simpleListId);
            if (simpleListItems.Count() > 0)
                throw new NonEmptyEntityException(NonEmptyEntityException.GetExceptionMessage(typeof(SimpleList.DataModel.Models.SimpleList), typeof(SimpleListItem)));
            var simpleList = GetSimpleList(simpleListId);
            _simpleListEntities.SimpleLists.Remove(simpleList);
            return _simpleListEntities.SaveChanges();
        }
    }
}

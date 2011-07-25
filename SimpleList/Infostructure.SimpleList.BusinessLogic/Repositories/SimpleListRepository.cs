﻿using System;
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

        public IEnumerable<SimpleList.DataModel.Models.SimpleList> GetSimpleLists(User user)
        {
            var simpleLists = from simpleList in _simpleListEntities.SimpleLists
                              where simpleList.UserID == user.ID
                              select simpleList;
            return simpleLists;
        }

        public SimpleList.DataModel.Models.SimpleList GetSimpleList(int simpleListId)
        {
            var simpleListOut = (from simpleList in _simpleListEntities.SimpleLists
                              where simpleList.ID == simpleListId
                              select simpleList).FirstOrDefault();
            return simpleListOut;
        }

        public IEnumerable<SimpleList.DataModel.Models.SimpleList> GetSimpleLists(string userName)
        {
            var simpleLists = from simpleList in _simpleListEntities.SimpleLists
                              join user in _simpleListEntities.Users on simpleList.UserID equals user.ID
                              where user.Name == userName
                              select simpleList;
            return simpleLists;
        }

        public IEnumerable<SimpleList.DataModel.Models.SimpleList> GetSimpleLists(string userName, string password)
        {
            var simpleLists = from simpleList in _simpleListEntities.SimpleLists
                              join user in _simpleListEntities.Users on simpleList.UserID equals user.ID
                              where user.Name == userName && user.Password == password
                              select simpleList;
            return simpleLists;
        }

        public void AddSimpleList(SimpleList.DataModel.Models.SimpleList simpleList)
        {
            _simpleListEntities.SimpleLists.Add(simpleList);
            _simpleListEntities.SaveChanges();
        }

        public void DeleteSimpleList(SimpleList.DataModel.Models.SimpleList simpleList)
        {
            var simpleListItemRepository = new SimpleListItemRepository(_simpleListEntities);
            var simpleListItems = simpleListItemRepository.GetSimpleListItems(simpleList);
            if (simpleListItems.Count() > 0)
                throw new NonEmptyEntityException(NonEmptyEntityException.GetExceptionMessage(typeof(SimpleList.DataModel.Models.SimpleList), typeof(SimpleListItem)));
            _simpleListEntities.SimpleLists.Remove(simpleList);
            _simpleListEntities.SaveChanges();
        }
    }
}

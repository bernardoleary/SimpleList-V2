using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infostructure.SimpleList.Utilities.Exceptions;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.DataModel.DataAccess;

namespace Infostructure.SimpleList.BusinessLogic.Repositories
{
    public class UserRepository
    {
        private SimpleListEntities _simpleListEntities = new SimpleListEntities();

        public User GetUser(string userName, string password)
        {
            var users = from user in _simpleListEntities.Users
                        where user.Name == userName && user.Password == password
                        select user;
            return users.FirstOrDefault();
        }

        public User GetUser(string userName)
        {
            var users = from user in _simpleListEntities.Users
                        where user.Name == userName
                        select user;
            return users.FirstOrDefault();
        }

        public User GetUser(int userId)
        {
            var users = from user in _simpleListEntities.Users
                        where user.ID == userId
                        select user;
            return users.FirstOrDefault();
        }

        public int AddUser(User user)
        {
            _simpleListEntities.Users.Add(user);
            return _simpleListEntities.SaveChanges();
        }

        public int  UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            var userForUpdate = GetUser(userName, oldPassword);
            userForUpdate.Password = newPassword;
            return _simpleListEntities.SaveChanges();
        }

        public int UpdateEmail(User user, string newEmail)
        {
            var userForUpdate = GetUser(user.Name, user.Password);
            userForUpdate.Email = newEmail;
            return _simpleListEntities.SaveChanges();
        }

        public int UpdateShowDoneLists(string userName, string oldPassword, bool showDoneLists)
        {
            var userForUpdate = GetUser(userName, oldPassword);
            userForUpdate.ShowDoneLists = showDoneLists;
            return _simpleListEntities.SaveChanges();
        }

        public int UpdateShowDoneListItems(string userName, string oldPassword, bool showDoneListItems)
        {
            var userForUpdate = GetUser(userName, oldPassword);
            userForUpdate.ShowDoneListItems = showDoneListItems;
            return _simpleListEntities.SaveChanges();
        }

        public int UpdateUser(User user)
        {
            var entry = _simpleListEntities.Entry<User>(user);
            entry.State = System.Data.EntityState.Modified;
            return _simpleListEntities.SaveChanges();
        }

        public int DeleteUser(User user)
        {
            var simpleListRepository = new SimpleListRepository(_simpleListEntities);
            var simpleLists = simpleListRepository.GetSimpleLists(user.ID);
            if (simpleLists.Count() > 0)
                throw new NonEmptyEntityException(NonEmptyEntityException.GetExceptionMessage(typeof(User), typeof(SimpleList.DataModel.Models.SimpleListItem)));
            _simpleListEntities.Users.Remove(user);
            return _simpleListEntities.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infostructure.SimpleList.Utilities.Exceptions;
using Infostructure.SimpleList.DataModel;

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

        public void AddUser(User user)
        {
            _simpleListEntities.Users.AddObject(user);
            _simpleListEntities.SaveChanges();
        }

        public void UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            var userForUpdate = GetUser(userName, oldPassword);
            userForUpdate.Password = newPassword;
            _simpleListEntities.SaveChanges();
        }

        public void UpdateEmail(User user, string newEmail)
        {
            var userForUpdate = GetUser(user.Name, user.Password);
            userForUpdate.Email = newEmail;
            _simpleListEntities.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            var simpleListRepository = new SimpleListRepository(_simpleListEntities);
            var simpleLists = simpleListRepository.GetSimpleLists(user);
            if (simpleLists.Count() > 0)
                throw new NonEmptyEntityException(NonEmptyEntityException.GetExceptionMessage(typeof(User), typeof(SimpleList.DataModel.SimpleListItem)));
            _simpleListEntities.Users.DeleteObject(user);
            _simpleListEntities.SaveChanges();
        }
    }
}

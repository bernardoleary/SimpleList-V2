using Infostructure.SimpleList.BusinessLogic.Repositories;
using System;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.DataModel.Models;
using NUnit.Framework;

namespace Infostructure.SimpleList.BusinessLogic.Tests.Unit
{
    [TestFixture]
    public class UserRepositoryUnitTest
    {
        [Test]
        public void GetUserByUserNameAndPasswordTest()
        {
            UserRepository target = new UserRepository();
            string userName = "bernard";
            string password = "password";
            User expected = new User
            {
                ID = 1,
                Name = "bernard",
                Password = "password",
                Email = "bernard.oleary@gmail.com"
            };
            User actual;
            actual = target.GetUser(userName, password);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [Test]
        public void AddUserTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.AddUser(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [Test]
        public void DeleteUserTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.DeleteUser(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [Test]
        public void UpdateEmailTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            string newEmail = string.Empty; // TODO: Initialize to an appropriate value
            target.UpdateEmail(user, newEmail);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [Test]
        public void UpdatePasswordTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            string newPassword = string.Empty; // TODO: Initialize to an appropriate value
            //target.UpdatePassword(user, newPassword);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}

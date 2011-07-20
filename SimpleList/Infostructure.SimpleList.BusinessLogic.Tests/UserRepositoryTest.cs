using Infostructure.SimpleList.BusinessLogic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Infostructure.SimpleList.DataModel;

namespace Infostructure.SimpleList.BusinessLogic.Tests
{
    
    
    /// <summary>
    ///This is a test class for UserRepositoryTest and is intended
    ///to contain all UserRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetUserByUserNameAndPassword
        ///</summary>
        [TestMethod()]
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

        /// <summary>
        ///A test for AddUser
        ///</summary>
        [TestMethod()]
        public void AddUserTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.AddUser(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        [TestMethod()]
        public void DeleteUserTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            target.DeleteUser(user);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateEmail
        ///</summary>
        [TestMethod()]
        public void UpdateEmailTest()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            string newEmail = string.Empty; // TODO: Initialize to an appropriate value
            target.UpdateEmail(user, newEmail);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdatePassword
        ///</summary>
        [TestMethod()]
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

using Infostructure.SimpleList.Web.Models.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.Web.Models;

namespace Infostructure.SimpleList.Web.Tests
{
    
    
    /// <summary>
    ///This is a test class for MapperTest and is intended
    ///to contain all MapperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MapperTest
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
        ///A test for SimpleListToSimpleListViewModel
        ///</summary>
        [TestMethod()]
        public void SimpleListToSimpleListViewModelTest()
        {
            Mapper target = new Mapper();
            DataModel.Models.SimpleList simpleList = new DataModel.Models.SimpleList
                {
                    ID = 1,
                    DateAdded = DateTime.Now,
                    AllDone = false,
                    UserID = 1,
                    Name = "test list 1",
                    SimpleListItems = new List<DataModel.Models.SimpleListItem>
                    {
                        new DataModel.Models.SimpleListItem { ID = 1, Description = "test list item 1", Done = false, SimpleListID = 1 },
                        new DataModel.Models.SimpleListItem { ID = 2, Description = "test list item 2", Done = true, SimpleListID = 1 }
                    }
                };
            SimpleListViewModel expected = new SimpleListViewModel
            {
                ID = 1,
                DateAdded = DateTime.Now,
                AllDone = false,
                UserID = 1,
                Name = "test list 1",
                SimpleListItems = new List<Models.SimpleListItemViewModel>
                    {
                        new Models.SimpleListItemViewModel { ID = 1, Description = "test list item 1", Done = false, SimpleListID = 1 },
                        new Models.SimpleListItemViewModel { ID = 2, Description = "test list item 2", Done = true, SimpleListID = 1 }
                    }
            };
            SimpleListViewModel actual;
            actual = target.SimpleListToSimpleListViewModel(simpleList);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for SimpleListItemToSimpleListItemViewModel
        ///</summary>
        [TestMethod()]
        public void SimpleListItemToSimpleListItemViewModelTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            SimpleListItem simpleListItem = new DataModel.Models.SimpleListItem { ID = 1, Description = "test list item 1", Done = false, SimpleListID = 1 };
            SimpleListItemViewModel expected = new SimpleListItemViewModel { ID = 1, Description = "test list item 1", Done = false, SimpleListID = 1 };
            SimpleListItemViewModel actual;
            actual = target.SimpleListItemToSimpleListItemViewModel(simpleListItem);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Done, actual.Done);
            Assert.AreEqual(expected.ID, actual.ID);
            Assert.AreEqual(expected.SimpleListID, actual.SimpleListID);
        }
    }
}

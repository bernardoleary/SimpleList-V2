using Infostructure.SimpleList.Web.Models.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.Web.Models;
using System.Collections.Generic;

namespace Infostructure.SimpleList.BusinessLogic.Tests
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
        ///A test for SimpleListItemToSimpleListItemViewModel
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\WebApps\\SimpleList\\Infostructure.SimpleList.Web", "/")]
        [UrlToTest("http://localhost:5900/")]
        public void SimpleListItemToSimpleListItemViewModelTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            SimpleListItem simpleListItem = null; // TODO: Initialize to an appropriate value
            SimpleListItemViewModel expected = null; // TODO: Initialize to an appropriate value
            SimpleListItemViewModel actual;
            actual = target.SimpleListItemToSimpleListItemViewModel(simpleListItem);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleListItemViewModelToSimpleListItem
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\WebApps\\SimpleList\\Infostructure.SimpleList.Web", "/")]
        [UrlToTest("http://localhost:5900/")]
        public void SimpleListItemViewModelToSimpleListItemTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            SimpleListItemViewModel simpleListItemViewModel = null; // TODO: Initialize to an appropriate value
            SimpleListItem expected = null; // TODO: Initialize to an appropriate value
            SimpleListItem actual;
            actual = target.SimpleListItemViewModelToSimpleListItem(simpleListItemViewModel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleListItemsToSimpleListItemViewModels
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\WebApps\\SimpleList\\Infostructure.SimpleList.Web", "/")]
        [UrlToTest("http://localhost:5900/")]
        public void SimpleListItemsToSimpleListItemViewModelsTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListItem> simpleListItems = null; // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListItemViewModel> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListItemViewModel> actual;
            actual = target.SimpleListItemsToSimpleListItemViewModels(simpleListItems);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleListToSimpleListViewModel
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\WebApps\\SimpleList\\Infostructure.SimpleList.Web", "/")]
        [UrlToTest("http://localhost:5900/")]
        public void SimpleListToSimpleListViewModelTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            SimpleList simpleList = null; // TODO: Initialize to an appropriate value
            bool populateSubStructures = false; // TODO: Initialize to an appropriate value
            SimpleListViewModel expected = null; // TODO: Initialize to an appropriate value
            SimpleListViewModel actual;
            actual = target.SimpleListToSimpleListViewModel(simpleList, populateSubStructures);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SimpleListsToSimpleListViewModels
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\WebApps\\SimpleList\\Infostructure.SimpleList.Web", "/")]
        [UrlToTest("http://localhost:5900/")]
        public void SimpleListsToSimpleListViewModelsTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            IEnumerable<SimpleList> simpleLists = null; // TODO: Initialize to an appropriate value
            bool populateSubStructures = false; // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListViewModel> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListViewModel> actual;
            actual = target.SimpleListsToSimpleListViewModels(simpleLists, populateSubStructures);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

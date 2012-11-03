using Infostructure.SimpleList.Web.Models.Mapping;
using System;
using System.Collections.Generic;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.Web.Models;
using NUnit.Framework;

namespace Infostructure.SimpleList.Web.Tests.Unit
{
    [TestFixture]
    public class MapperUnitTest
    {
        [Test]
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

        [Test]
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

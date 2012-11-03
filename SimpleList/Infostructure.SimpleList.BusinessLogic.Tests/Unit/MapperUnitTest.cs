using Infostructure.SimpleList.Web.Models.Mapping;
using System;
using Infostructure.SimpleList.DataModel.Models;
using Infostructure.SimpleList.Web.Models;
using System.Collections.Generic;
using NUnit.Framework;

namespace Infostructure.SimpleList.BusinessLogic.Tests.Unit
{
    [TestFixture]
    public class MapperUnitTest
    {
        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void SimpleListToSimpleListViewModelTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            Infostructure.SimpleList.DataModel.Models.SimpleList simpleList = null; // TODO: Initialize to an appropriate value
            bool populateSubStructures = false; // TODO: Initialize to an appropriate value
            SimpleListViewModel expected = null; // TODO: Initialize to an appropriate value
            SimpleListViewModel actual;
            actual = target.SimpleListToSimpleListViewModel(simpleList, populateSubStructures);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [Test]
        public void SimpleListsToSimpleListViewModelsTest()
        {
            Mapper target = new Mapper(); // TODO: Initialize to an appropriate value
            IEnumerable<Infostructure.SimpleList.DataModel.Models.SimpleList> simpleLists = null; // TODO: Initialize to an appropriate value
            bool populateSubStructures = false; // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListViewModel> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<SimpleListViewModel> actual;
            actual = target.SimpleListsToSimpleListViewModels(simpleLists, populateSubStructures);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}

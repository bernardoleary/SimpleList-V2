using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infostructure.SimpleList.DataModel.Extensions;
using Infostructure.SimpleList.DataModel.Models;
using NUnit.Framework;

namespace Infostructure.SimpleList.DataModel.Tests.Unit
{
    [TestFixture]
    public class SimpleListUnitTest
    {
        private Infostructure.SimpleList.DataModel.Models.SimpleList _simpleListToTest = null;
        private Infostructure.SimpleList.DataModel.Models.User _userForTest = null;

        [SetUp]
        public void SetUp()
        {
            _simpleListToTest = new DataModel.Models.SimpleList
            {
                ID = 0,
                Name = "test list 1",
                DateAdded = DateTime.Now,
                AllDone = false,
                UserID = 1,
                SimpleListItems = new System.Collections.Generic.List<Infostructure.SimpleList.DataModel.Models.SimpleListItem>
                {
                    new Infostructure.SimpleList.DataModel.Models.SimpleListItem
                    {
                        Description = "test list 1, descr 1",
                        Done = true,
                        ID = 1234,
                        SimpleListID = 0
                    },
                    new Infostructure.SimpleList.DataModel.Models.SimpleListItem
                    {
                        Description = "test list 1, descr 2",
                        Done = false,
                        ID = 12345,
                        SimpleListID = 0
                    },
                    new Infostructure.SimpleList.DataModel.Models.SimpleListItem
                    {
                        Description = "test list 1, descr 3",
                        Done = false,
                        ID = 123456,
                        SimpleListID = 0
                    }
                }
            };
            _userForTest = new User
            {
                ID = 1,
                Email = "bernard.oleary@gmail.com",
                Name = "Bernard",
                Password = "pw",
                ShowDoneListItems = false,
                ShowDoneLists = false,
                SimpleLists = null
            };
        }

        [Test]
        public void CloneAllTest()
        {
            Infostructure.SimpleList.DataModel.Models.SimpleList simpleListClonedAll = _simpleListToTest.Clone(_userForTest.ID, true, "cloned list 1");
            Assert.AreEqual(simpleListClonedAll.SimpleListItems.Count, 3);
            Assert.AreEqual(simpleListClonedAll.Name, "cloned list 1");
        }

        [Test]
        public void CloneDoneTest()
        {
            Infostructure.SimpleList.DataModel.Models.SimpleList simpleListClonedDone = _simpleListToTest.Clone(_userForTest.ID, false, "cloned list 2");
            Assert.AreEqual(simpleListClonedDone.SimpleListItems.Count, 2);
            Assert.AreEqual(simpleListClonedDone.Name, "cloned list 2");
        }
    }
}

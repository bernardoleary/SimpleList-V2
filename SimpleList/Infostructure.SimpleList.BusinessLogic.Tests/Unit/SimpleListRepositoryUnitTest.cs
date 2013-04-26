using Infostructure.SimpleList.BusinessLogic.Repositories;
using System;
using Infostructure.SimpleList.DataModel;
using Infostructure.SimpleList.DataModel.Models;
using NUnit.Framework;

namespace Infostructure.SimpleList.BusinessLogic.Tests.Unit
{
    [TestFixture]
    public class SimpleListRepositoryUnitTest
    {
        private User _userForTest = null;

        [SetUp]
        public void SetUp()
        {
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
        public void GetSimpleListByIdTest()
        {
            SimpleListRepository target = new SimpleListRepository();
            int simpleListId = 1;
            Infostructure.SimpleList.DataModel.Models.SimpleList actual;
            actual = target.GetSimpleList(_userForTest.ID, simpleListId);
            Assert.IsNotNull(actual);
        }
    }
}

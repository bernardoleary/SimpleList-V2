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
    public class SimpleListItemUnitTest
    {
        [Test]
        public void CloneTest()
        {
            var user = new User
                           {
                               ID = 1,
                               Email = "bernard.oleary@gmail.com",
                               Name = "Bernard",
                               Password = "pw",
                               ShowDoneListItems = false,
                               ShowDoneLists = false,
                               SimpleLists = null
                           };
            var simpleListItem = new Infostructure.SimpleList.DataModel.Models.SimpleListItem
                                                {
                                                    Description = "test list 1, descr 1",
                                                    Done = true,
                                                    ID = 1234,
                                                    SimpleListID = 0
                                                };
            var clonedSimpleListItem = simpleListItem.Clone(user.ID);
            Assert.AreNotEqual(simpleListItem, clonedSimpleListItem);
        }
    }
}

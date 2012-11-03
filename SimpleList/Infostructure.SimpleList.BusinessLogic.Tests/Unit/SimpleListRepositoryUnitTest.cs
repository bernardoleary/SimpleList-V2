using Infostructure.SimpleList.BusinessLogic.Repositories;
using System;
using Infostructure.SimpleList.DataModel;
using NUnit.Framework;

namespace Infostructure.SimpleList.BusinessLogic.Tests.Unit
{
    [TestFixture]
    public class SimpleListRepositoryUnitTest
    {
        [Test]
        public void GetSimpleListByIdTest()
        {
            SimpleListRepository target = new SimpleListRepository();
            int simpleListId = 1;
            Infostructure.SimpleList.DataModel.Models.SimpleList actual;
            actual = target.GetSimpleList(simpleListId);
            Assert.IsNotNull(actual);
        }
    }
}

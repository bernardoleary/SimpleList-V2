using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infostructure.SimpleList.BusinessLogic.Repositories;
using Infostructure.SimpleList.BusinessLogic.Tests.Properties;
using Infostructure.SimpleList.DataModel.DataAccess;
using Infostructure.SimpleList.DataModel.Extensions;
using NUnit.Framework;

namespace Infostructure.SimpleList.BusinessLogic.Tests.Integration
{
    [TestFixture]
    public class SimpleListRepositoryIntegrationTest
    {
        [Test]
        public void CloneSimpleListTest()
        {
            var simpleListEntities = new SimpleListEntities(Settings.Default.connectionString);
            var simpleListRespository = new SimpleListRepository(simpleListEntities);
            var userRespository = new UserRepository(simpleListEntities);
            var user = userRespository.GetUser("bernard");
            var simpleListOriginalFromDb = simpleListRespository.GetSimpleLists(user.ID).FirstOrDefault();
            var simpleListCloned = simpleListOriginalFromDb.Clone(user.ID, true, simpleListOriginalFromDb.Name + " - CLONED");
            simpleListRespository.AddSimpleList(simpleListCloned);
            var simpleListClonedFromDb =
                simpleListRespository.GetSimpleLists(user.ID).Where(l => l.Name == simpleListCloned.Name);
            Assert.IsNotNull(simpleListClonedFromDb);
        }
    }
}

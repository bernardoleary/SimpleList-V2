using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Infostructure.SimpleList.DataModel.DataAccess
{
    public class SimpleListEntities : DbContext
    {
        public SimpleListEntities()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Models.User> Users
        {
            get;
            set;
        }

        public DbSet<Models.SimpleList> SimpleLists
        {
            get;
            set;
        }

        public DbSet<Models.SimpleListItem> SimpleListItems
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infostructure.SimpleList.Web.Models
{
    public class SimpleListViewModel
    {

        #region ISimpleList Members

        public bool AllDone
        {
            get;
            set;
        }

        public DateTime DateAdded
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ICollection<DataModel.Models.SimpleListItem> SimpleListItems
        {
            get;
            set;
        }

        public int? UserID
        {
            get;
            set;
        }

        #endregion
    }
}
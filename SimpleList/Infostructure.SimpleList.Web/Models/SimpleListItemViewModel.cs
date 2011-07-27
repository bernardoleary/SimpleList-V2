using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infostructure.SimpleList.Web.Models
{
    public class SimpleListItemViewModel
    {
        public string Description
        {
            get;
            set;
        }

        public bool Done
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public int SimpleListID
        {
            get;
            set;
        }
    }
}
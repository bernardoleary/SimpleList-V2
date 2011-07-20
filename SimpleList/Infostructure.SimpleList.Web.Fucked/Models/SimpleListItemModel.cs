using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infostructure.SimpleList.Web.Models
{
    public class SimpleListItemModel
    {
        public string Description { get; set; }
        public int SimpleListId { get; set; }
        public bool Done { get; set; }
    }
}
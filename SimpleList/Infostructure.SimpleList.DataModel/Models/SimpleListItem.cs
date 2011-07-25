using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infostructure.SimpleList.DataModel.Models
{
    [Table("SimpleListItem", Schema = "dbo")]
    public class SimpleListItem
    {
        [Key]
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
    }
}

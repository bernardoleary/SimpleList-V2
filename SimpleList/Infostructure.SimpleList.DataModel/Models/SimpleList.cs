using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infostructure.SimpleList.DataModel.Models
{
    [Table("SimpleList", Schema = "dbo")]
    public class SimpleList
    {
        [Key]
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
        
        public int UserID
        {
            get;
            set;
        }

        public System.DateTime DateAdded
        {
            get;
            set;
        }
    
        public bool AllDone
        {
            get;
            set;
        }

        public virtual ICollection<SimpleListItem> SimpleListItems
        {
            get;
            set;
        }
    }
}

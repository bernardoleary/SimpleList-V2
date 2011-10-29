using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Infostructure.SimpleList.DataModel.Models
{
    [Table("User", Schema = "dbo")]
    public class User
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

        public string Password
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public bool ShowDoneLists
        {
            get;
            set;
        }

        public bool ShowDoneListItems
        {
            get;
            set;
        }

        public virtual ICollection<SimpleList> SimpleLists
        {
            get;
            set;
        }
    }
}

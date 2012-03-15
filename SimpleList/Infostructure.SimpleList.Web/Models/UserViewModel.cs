using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infostructure.SimpleList.Web.Models
{
    public class UserViewModel
    {
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
    }
}
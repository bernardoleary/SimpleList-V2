using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infostructure.SimpleList.DataModel.Extensions
{
    public static class ExtensionMethods
    {
        public static SimpleList.DataModel.Models.SimpleList Clone(this SimpleList.DataModel.Models.SimpleList simpleListToClone, int userId, bool includeDoneSimpleListItems, string clonedListName)
        {
            var clonedSimpleList = new SimpleList.DataModel.Models.SimpleList
                                       {
                                           Name = clonedListName,
                                           DateAdded = DateTime.Now,
                                           AllDone = false,
                                           UserID = simpleListToClone.UserID,
                                           SimpleListItems = new List<SimpleList.DataModel.Models.SimpleListItem>()
                                       };
            foreach (var item in simpleListToClone.SimpleListItems)
                if (!includeDoneSimpleListItems && item.Done)
                    continue;
                else
                    clonedSimpleList.SimpleListItems.Add(item.Clone(userId));

            return clonedSimpleList;
        }

        public static SimpleList.DataModel.Models.SimpleListItem Clone(this SimpleList.DataModel.Models.SimpleListItem simpleListItemToClone, int userId)
        {
            return new SimpleList.DataModel.Models.SimpleListItem
                       {
                           Description = simpleListItemToClone.Description,
                           Done = simpleListItemToClone.Done,
                           SimpleListID = simpleListItemToClone.SimpleListID
                       };
        }
    }
}

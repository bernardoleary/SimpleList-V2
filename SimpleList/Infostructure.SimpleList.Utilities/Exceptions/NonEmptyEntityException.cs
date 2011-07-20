using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infostructure.SimpleList.Utilities.Exceptions
{
    public class NonEmptyEntityException : Exception
    {
        public NonEmptyEntityException(string message) : base(message) { }

        public static string GetExceptionMessage(Type parent, Type child)
        {
            var message = "The " + parent.FullName + " has associated " + child.FullName + "(s), which must be removed before deletion.";
            return message;
        }
    }
}

using System;
namespace Infostructure.SimpleList.DataModel
{
    public interface IUser
    {
        string Email { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string Password { get; set; }
    }
}

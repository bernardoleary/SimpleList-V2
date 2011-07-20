using System;
namespace Infostructure.SimpleList.DataModel
{
    public interface ISimpleList
    {
        bool AllDone { get; set; }
        DateTime DateAdded { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        int? UserID { get; set; }
    }
}

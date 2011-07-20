using System;
namespace Infostructure.SimpleList.DataModel
{
    public interface ISimpleListItem
    {
        string Description { get; set; }
        bool Done { get; set; }
        int ID { get; set; }
        int SimpleListID { get; set; }
    }
}

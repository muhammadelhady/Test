using Test.Models.Event;
using Test.ViewModels.Address;

namespace Test.ViewModels.Event
{
    public class EventEditModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZoneInfoId { get; set; }
        public EventTypeEnum EventType { get; set; }
        public AddressEditModel Address { get; set; }

    }
}

using Test.Models.Event;
using Test.ViewModels.Address;

namespace Test.ViewModels.Event
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverUrl { get; set; }
        public String OwnerUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZoneInfoId { get; set; }
        public EventTypeEnum EventType { get; set; }
        public AddressViewModel Address { get; set; }

    }
}


namespace Test.Models.Event
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TimeZoneInfoId { get; set; } = TimeZoneInfo.Utc.Id;
        public EventTypeEnum EventType { get; set; }
        public int AddressId { get; set; }
        public Test.Models.Address.Address Address { get; set; }

    }

    public enum EventTypeEnum
    {
        offilne=1,
        online
    }
}

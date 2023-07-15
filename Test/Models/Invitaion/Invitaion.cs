
namespace Test.Models.Invitaion
{
    public class Invitaion : BaseEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public InvitaionResponseStatusEnum ResponseStatus { get; set; } = InvitaionResponseStatusEnum.NotReplayed;
        public DateTime? ExpirationDate { get; set; }

    }
    public enum InvitaionResponseStatusEnum
    {
        NotReplayed=1,
        Accepted, 
        Rejected,
        Maybe
    }
}

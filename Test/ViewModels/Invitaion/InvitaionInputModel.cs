using Test.Models.Invitaion;

namespace Test.ViewModels.Invitaion
{
    public class InvitaionInputModel
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool Response { get; set; }
        public InvitaionResponseStatusEnum ResponseStatus { get; set; } = InvitaionResponseStatusEnum.NotReplayed;
        public DateTime? ExpirationDate { get; set; }
    }
}

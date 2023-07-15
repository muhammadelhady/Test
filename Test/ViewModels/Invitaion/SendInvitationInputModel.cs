namespace Test.ViewModels.Invitaion
{
    public class SendInvitationInputModel
    {
        public List<int> UserIds { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Message { get; set; }
    }
}

using Test.Helpers;
using Test.ViewModels.Invitaion;

namespace Test.Services.Invetation
{
    public interface IInvitaionService
    {
        Task<bool> Send(int eventId,SendInvitationInputModel sendInvitationInputModel);
        Task<List<InvitaionViewModel>> GetUserInvitaions(BaseQueryParameters baseQueryParameters, int userid);
        Task<bool> Respond(InvitaionResponseInputModel invitaionResponseInputModel,int invitaionId);

    }
}

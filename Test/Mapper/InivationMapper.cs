using AutoMapper;
using Test.Models.Event;
using Test.Models.Invitaion;
using Test.Services.Events;
using Test.Services.Users;
using Test.ViewModels.Invitaion;

namespace Test.Mapper
{
    public class InivationMapper
    {
        private readonly IUserService _userService;
        private readonly IEventServices _eventServices;

        public InivationMapper(IUserService userService,IEventServices eventServices)
        {
            _userService = userService;
            _eventServices = eventServices;
        }
        public async Task<List<Invitaion>> MapUserInvitaions(int eventId,SendInvitationInputModel sendInvitationInputModel)
        {
            var eventObj = await _eventServices.GetById(eventId);
            var usersList = await _userService.GetByIds(sendInvitationInputModel.UserIds);
            List<Invitaion> invitaions = new List<Invitaion>();
            foreach (var user in usersList)
            {
                invitaions.Add(new Invitaion
                {
                    CreatedBy="User From UserContext",
                    EventId=eventObj.Id,
                    ExpirationDate=sendInvitationInputModel.ExpirationDate,
                    Message=sendInvitationInputModel.Message,
                    UserId=user.Id                                       
                });
            }
            return invitaions;
        }
    }
}

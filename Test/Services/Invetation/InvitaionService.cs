using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Database;
using Test.Helpers;
using Test.Mapper;
using Test.ViewModels.Invitaion;

namespace Test.Services.Invetation
{
    public class InvitaionService : IInvitaionService
    {
        private readonly EventContext _eventContext;
        private readonly ReadOnlyContext _readOnlyContext;
        private readonly ILogger<IInvitaionService> _logger;
        private readonly IMapper _mapper;
        private readonly InivationMapper _inivationMapper;

        public InvitaionService(EventContext eventContext, ReadOnlyContext readOnlyContext,ILogger<IInvitaionService> logger,IMapper mapper, InivationMapper inivationMapper )
        {
            _eventContext = eventContext;
            _readOnlyContext = readOnlyContext;
            _logger = logger;
            _mapper = mapper;
            _inivationMapper = inivationMapper;
        }
        public async Task<List<InvitaionViewModel>> GetUserInvitaions(BaseQueryParameters baseQueryParameters,int userid)
        {
            _logger.LogInformation("load User invitaions by user id ", userid);
            var invitaions = await _readOnlyContext.invitaions
                .Where(i => i.ExpirationDate > DateTime.UtcNow &&
                i.IsDeleted == false &&
                i.UserId == userid)
                .ToListAsync();
            return _mapper.Map<List<InvitaionViewModel>>(invitaions);

        }

        public async Task<bool> Respond(InvitaionResponseInputModel invitaionResponseInputModel, int invitaionId)
        {
            _logger.LogInformation("load User invitaion by id ", invitaionId);
            //should get user id here from UserContext to validate the invitation ownership 
            var invitaion = await _readOnlyContext.invitaions
                .FirstOrDefaultAsync(i=>i.Id==invitaionId&&i.IsDeleted==false);
            if(invitaion == null)
            {
                _logger.LogInformation("User invitaion not found or Expired ", invitaionId);
                throw new Exception("User invitaion not found");
            }
            if(invitaion.ExpirationDate<DateTime.UtcNow)
            {
                _logger.LogInformation("User invitaion Expired ", invitaionId);
                throw new Exception("User invitaion Expired");
            }
            if (invitaion.ResponseStatus != Models.Invitaion.InvitaionResponseStatusEnum.NotReplayed)
            {
                _logger.LogInformation("User invitaion Already replayed ", invitaionId);
                throw new Exception("User invitaion Already replayed");
            }
            invitaion.ResponseStatus = invitaionResponseInputModel.Response;
            return await _eventContext.SaveChangesAsync()>0;
        }

        public async Task<bool> Send(int eventId, SendInvitationInputModel sendInvitationInputModel)
        {
            _logger.LogInformation("Start Creating Event Invitaions", sendInvitationInputModel);
            var invitaion = await _inivationMapper.MapUserInvitaions(eventId,sendInvitationInputModel);
            await _eventContext.invitaions.AddRangeAsync(invitaion);
            return await _eventContext.SaveChangesAsync() > 0;
        }
    }
}

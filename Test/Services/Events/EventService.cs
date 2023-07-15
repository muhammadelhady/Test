using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Database;
using Test.Helpers;
using Test.Models.Event;
using Test.Services.Invetation;
using Test.ViewModels.Event;

namespace Test.Services.Events
{
    public class EventService : IEventServices
    {
        private readonly EventContext _eventContext;
        private readonly ReadOnlyContext _readOnlyContext;
        private readonly ILogger<IInvitaionService> _logger;
        private readonly IMapper _mapper;

        public EventService(EventContext eventContext, ReadOnlyContext readOnlyContext, ILogger<IInvitaionService> logger, IMapper mapper)
        {
            _eventContext = eventContext;
            _readOnlyContext = readOnlyContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<EventViewModel> Create(EventInputModel eventInputModel)
        {
            _logger.LogInformation("start saving event ", eventInputModel);
            var eventObj = _mapper.Map<Event>(eventInputModel);
            await _eventContext.events.AddAsync(eventObj);
            var result = await _eventContext.SaveChangesAsync() > 0;
            if(!result)
            {
                _logger.LogInformation("Failed to save event ", eventInputModel);
                throw new Exception("Failed to save event");
            }
            return _mapper.Map<EventViewModel>(eventObj);
        }

        public async Task<bool> Delete(int id)
        {
            _logger.LogInformation("start Loading event with id ", id);
            var eventObj = await _readOnlyContext.events
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);
            if (eventObj == null)
            {
                _logger.LogInformation(" event with id is not exists ", id);
                throw new Exception("Event Not found ");
            }
            eventObj.IsDeleted=true;
            eventObj.DeletedBy = "User From UserContext";
            eventObj.DeletedOn = DateTime.UtcNow;
            _eventContext.Entry(eventObj).State= EntityState.Modified;
            return await _eventContext.SaveChangesAsync() > 0;
        }

        public async Task<EventViewModel> Edit(EventEditModel eventEditInputModel, int eventId)
        {
            _logger.LogInformation("start Loading event with id ", eventId);
            var eventObj = await _readOnlyContext.events
                .FirstOrDefaultAsync(e => e.Id == eventId && e.IsDeleted == false);
            if (eventObj == null)
            {
                _logger.LogInformation(" event with id is not exists ", eventId);
                throw new Exception("Event Not found ");
            }
            var UpdatedEvent = _mapper.Map(eventEditInputModel, eventObj);
            _eventContext.Entry(UpdatedEvent).State= EntityState.Modified;
            var result =  await _eventContext.SaveChangesAsync() > 0;
            if(result)
            {
                _logger.LogInformation("Event Update Error ", UpdatedEvent);
                throw new Exception("Event Update Error");
            }
            return _mapper.Map<EventViewModel>(UpdatedEvent);
        }

        public async Task<EventViewModel> GetById(int id)
        {
            _logger.LogInformation("start Loading event with id ", id);
            var eventObj= await _readOnlyContext.events
                .Where(e => e.Id == id&&e.IsDeleted==false)
                .Include(e=>e.Address)
                .FirstOrDefaultAsync();
            if(eventObj == null)
            {
                _logger.LogInformation(" event with id is not exists ", id);
                throw new Exception("Event Not found ");
            }
            return _mapper.Map<EventViewModel>(eventObj);
        }

        public async Task<List<EventViewModel>> GetEvents(BaseQueryParameters baseQueryParameters)
        {
            _logger.LogInformation("start Loading all events with query ", baseQueryParameters);
            var eventsList= await _readOnlyContext.events
                .Where(e => e.IsDeleted == false).Page(baseQueryParameters)
                .Include(e=>e.Address)
                .ToListAsync();
            return _mapper.Map<List<EventViewModel>>(eventsList);
        }
    }
}

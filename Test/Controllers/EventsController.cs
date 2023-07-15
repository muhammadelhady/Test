using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Test.Helpers;
using Test.Models.User;
using Test.ModelValidations;
using Test.Services.Events;
using Test.ViewModels.Event;
using Test.ViewModels.User;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventServices _eventServices;
        private readonly IValidator<EventInputModel> _inputValidator;
        private readonly IValidator<EventEditModel> _editvalidator;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "eventCachKey";

        public EventsController(IEventServices eventServices,
            IValidator<EventInputModel> inputValidator,
            IValidator<EventEditModel> editvalidator,
            IMemoryCache memoryCache)
        {
            _eventServices = eventServices;
            _inputValidator = inputValidator;
            _editvalidator = editvalidator;
            _memoryCache = memoryCache;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var eventObj = await _eventServices.GetById(id);
            if (eventObj == null)
            {
                return NotFound();
            }
            return Ok(eventObj);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery]BaseQueryParameters baseQueryParameters)
        {
            if (_memoryCache.TryGetValue(CacheKey, out List<EventViewModel> events))
                return Ok(events);
             events =  await _eventServices.GetEvents(baseQueryParameters);
            if (events != null)
            {
                var cacheOptions = new MemoryCacheEntryOptions()
               .SetSlidingExpiration(TimeSpan.FromSeconds(10))
               .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                _memoryCache.Set(CacheKey, events, cacheOptions);
                return Ok(events);
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EventInputModel eventInputModel)
        {
            var validationResult = await _inputValidator.ValidateAsync(eventInputModel);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var eventObj = await _eventServices.Create(eventInputModel);
            if(eventObj != null)
            {
                return Ok(eventObj);
            }    
            return BadRequest("Event Creation Failed");
        }
        [HttpPut("{id:int}/update")]
        public async Task<IActionResult> Edit(int id,[FromBody]EventEditModel eventEditModel)
        {
            var validationResult = await _editvalidator.ValidateAsync(eventEditModel);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var eventObj = await _eventServices.Edit(eventEditModel,id);
            if (eventObj != null)
            {
                return Ok(eventObj);
            }
            return BadRequest("Event Update Failed");
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _eventServices.Delete(id);
            if (result)
                return Ok("Deleted");
            return BadRequest("Failed To delete Event");
        }
    }
}

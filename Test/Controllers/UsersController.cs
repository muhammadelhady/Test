using Bogus.DataSets;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Test.Helpers;
using Test.Models.User;
using Test.Services.Users;
using Test.ViewModels.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserInputModel> _userValidator;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "UserCachKey";


        public UsersController(IUserService userService,
            IValidator<UserInputModel> userValidator,IMemoryCache memoryCache)
        {
            _userService = userService;
            _userValidator = userValidator;
            _memoryCache = memoryCache;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll([FromQuery] BaseQueryParameters baseQueryParameters)
        {
            

            if (_memoryCache.TryGetValue(CacheKey, out List<UserViewModel> users))
                return Ok(users);

             users = await _userService.GetAll(baseQueryParameters);
            if (users != null)
            {
                var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
                _memoryCache.Set(CacheKey, users, cacheOptions);
                return Ok(users);
            }
            return BadRequest("Failed To get Users");
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetById(id); 
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UserInputModel userInputModel)
        {
            var validationResult = await _userValidator.ValidateAsync(userInputModel);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var user = await _userService.Create(userInputModel);
            if (user != null)
                return Ok(user);
            return BadRequest("Failed To Create User");
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Test.Database;
using Test.Helpers;
using Test.Models.User;
using Test.ViewModels.User;

namespace Test.Services.Users
{
    public class UserService : IUserService
    {
        private readonly EventContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly ReadOnlyContext _readOnlyContext;

        public UserService(EventContext context,IMapper mapper,ILogger<UserService> logger,ReadOnlyContext readOnlyContext)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _readOnlyContext = readOnlyContext;
        }
        public async Task<UserViewModel> Create(UserInputModel userInputModel)
        {
            var user = _mapper.Map<User>(userInputModel);
            _logger.LogInformation("Start Add User To Database", user);
            await _context.users.AddAsync(user);
            var result = await _context.SaveChangesAsync()>0;
            if (!result)
            {
                _logger.LogInformation("Failed Adding User To Database", user);
                throw new Exception("Failed Adding User To Database");
            }
            _logger.LogInformation("User Saved To Database", user);
            return _mapper.Map<UserViewModel>(user);

        }

        public async Task<List<UserViewModel>> GetAll(BaseQueryParameters baseQueryParameters)
        {
            _logger.LogInformation("Start loading Users list ");
            var users = await _readOnlyContext.users
                .Where(user => user.IsDeleted != true)
                .Page(baseQueryParameters)
                .ToListAsync();
            
            var mappedUsers = _mapper.Map<List<UserViewModel>>(users);

            _logger.LogInformation("return user list for query",baseQueryParameters);
            return mappedUsers;
        }

        public async Task<UserViewModel> GetById(int id)
        {
            _logger.LogInformation("Start load User with id ",id);
            var user = await _readOnlyContext.users
                .FirstOrDefaultAsync(u=>u.Id==id&&u.IsDeleted==false);
            if(user == null)
            {
                _logger.LogInformation("User with id Not Found ", id);
                throw new Exception("User Not Found");
            }
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<List<UserViewModel>> GetByIds(List<int> userIds)
        {
            _logger.LogInformation("Start load Users with list of ids", userIds);
            var users = await _readOnlyContext.users
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
    }
}

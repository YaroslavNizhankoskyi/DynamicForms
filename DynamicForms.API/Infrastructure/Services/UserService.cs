using Application.Interfaces;
using Application.Models;
using Infrastructure.Data.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    internal class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainDbContext _dbContext;

        public UserService(UserManager<User> userManager, ICurrentUserService currentUserService,
            IDomainDbContext dbContext)
        {
            this._userManager = userManager;
            this._currentUserService = currentUserService;
            this._dbContext = dbContext;
        }

        public async Task<UserDetails> GetUserDetailsById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var role = (await _userManager.GetRolesAsync(user)).First();

            var domainUser = _dbContext.DomainUsers.FirstOrDefault(x => x.UserAuthId == user.Id);

            var userDetails = new UserDetails(
                user.Email,
                role,
                user.UserName,
                user.Id,
                domainUser.Id
            );

            return userDetails;
        }

        public async Task<UserDetails> GetUserDetailsByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var domainUser = _dbContext.DomainUsers.FirstOrDefault(x => x.UserAuthId == user.Id);

            var userDetails = new UserDetails(
                user.Email,
                role,
                user.UserName,
                user.Id,
                domainUser.Id
            );

            return userDetails;
        }

        public async Task<UserDetails> GetCurrentUserDetails()
        {
            var email = _currentUserService.GetUserEmail();

            return await GetUserDetailsByEmail(email);
        }

        public async Task<List<UserDetails>> GetAllUsers()
        {
            List<Task<UserDetails>> tasks = new();

            foreach (var user in _userManager.Users.ToList())
            {
                tasks.Add(GetUserDetailsById(user.Id));
            }

            var results = await Task.WhenAll(tasks);

            return results.ToList();
        }
    }
}

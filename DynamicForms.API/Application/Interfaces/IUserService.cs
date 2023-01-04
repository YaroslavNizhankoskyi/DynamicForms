using Application.Models;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDetails> GetUserDetailsById(Guid id);
        Task<UserDetails> GetUserDetailsByEmail(string email);
        Task<List<UserDetails>> GetAllUsers();
        Task<UserDetails> GetCurrentUserDetails();
    }
}

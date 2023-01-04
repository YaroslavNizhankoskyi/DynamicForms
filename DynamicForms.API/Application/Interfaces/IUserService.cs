using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

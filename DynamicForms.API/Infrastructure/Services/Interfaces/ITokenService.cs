using Infrastructure.Data.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(string userEmail);
    }  
}

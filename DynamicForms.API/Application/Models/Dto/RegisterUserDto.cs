using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto
{
    public record RegisterUserDto
    (
        string UserName,
        string Email,
        string Password
    );
}

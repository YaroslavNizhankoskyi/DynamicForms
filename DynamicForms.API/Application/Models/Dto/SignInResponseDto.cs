using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Dto
{
    public record SignInResponseDto
    (
        string Email,
        Guid Id,
        string UserName,
        string Role,
        string Token
    );
}

using Application.Interfaces;
using System.Security.Claims;

namespace Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public string GetUserEmail() => 
            _httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.Email);
        public Guid GetUserId() =>
            Guid.Parse(
                _httpContextAccessor.HttpContext.User
                    .FindFirstValue(ClaimTypes.NameIdentifier));

        public string GetRole() => 
            _httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.Role);
    }
}

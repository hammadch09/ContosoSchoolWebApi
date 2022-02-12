using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ContosoSchool.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }

            return result;
        }

        public string GetHammad(string hammad)
        {
            if (_httpContextAccessor.HttpContext != null)
                return hammad;

            return hammad;
        }
    }
}

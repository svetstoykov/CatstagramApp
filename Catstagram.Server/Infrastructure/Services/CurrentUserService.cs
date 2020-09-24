using System.Security.Claims;
using Catstagram.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace Catstagram.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal _user;


        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this._user = httpContextAccessor.HttpContext?.User;
        }

        public string GetUserName()
        {
            return this._user
                ?.Identity
                ?.Name;
        }

        public string GetId()
        {
            return this._user?.GetId();
        }
    }
}

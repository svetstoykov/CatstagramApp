using System.Threading.Tasks;
using Catstagram.Server.Features.Follows.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Features.Follows
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly IFollowsService _followsService;
        private readonly ICurrentUserService _currentUserService;

        public FollowsController(IFollowsService followsService, ICurrentUserService currentUserService)
        {
            this._followsService = followsService;
            this._currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var followerId = this._currentUserService.GetId();

            var result = await this._followsService.Follow(model.UserId, followerId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}

using System.Threading.Tasks;
using Catstagram.Server.Features.Follows;
using Catstagram.Server.Features.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Catstagram.Server.Infrastructure.WebConstants;

namespace Catstagram.Server.Features.Profiles
{
    [Authorize]
    public class ProfilesController : ApiController
    {
        private readonly IProfileService _profileService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IFollowsService _followsService;

        public ProfilesController(IProfileService profileService, ICurrentUserService currentUserService, IFollowsService followsService)
        {
            this._profileService = profileService;
            this._currentUserService = currentUserService;
            this._followsService = followsService;
        }


        [HttpGet]
        public async Task<ProfileServiceModel> GetCurrentUserDetails()
        {
            var userId = this._currentUserService.GetId();

            var userDetails = await this._profileService
                .GetUserDetails(userId, isPublic: true);

            return userDetails;
        }

        [HttpGet]
        [Route(IdForRoute)]
        public async Task<ProfileServiceModel> GetUserDetails(string id)
        {
            var currentUser = this._currentUserService.GetId();

            var includeAllInfo = await this._followsService.IsFollower(id, currentUser);

            if (!includeAllInfo)
            {
                includeAllInfo = await this._profileService.IsPublic(id);
            }

            return await this._profileService.GetUserDetails(id, includeAllInfo);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this._currentUserService.GetId();

            var result = await this._profileService.UpdateUserDetails(model, userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }
}

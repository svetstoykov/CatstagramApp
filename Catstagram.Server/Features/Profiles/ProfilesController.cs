using System.Threading.Tasks;
using Catstagram.Server.Features.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Features.Profiles
{
    [Authorize]
    public class ProfilesController : ApiController
    {
        private readonly IProfileService _profileService;
        private readonly ICurrentUserService _currentUserService;

        public ProfilesController(IProfileService profileService, ICurrentUserService currentUserService)
        {
            this._profileService = profileService;
            this._currentUserService = currentUserService;
        }


        [HttpGet]
        public async Task<ActionResult<ProfileResponseModel>> GetUserDetails()
        {
            var userId = this._currentUserService.GetId();

            var userDetails = await this._profileService
                .GetUserDetails(userId);

            return userDetails;
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this._currentUserService.GetId();

            var result = await this._profileService.UpdateUserDetail(model, userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }
}

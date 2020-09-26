using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Server.Features.Profiles
{
    [Authorize]
    public class ProfilesController : ApiController
    {
        private readonly CatstagramDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public ProfilesController(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<ProfileResponseModel>> GetUserDetails(string id)
        {
            var user = await this._dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return BadRequest();
            }

            var userDetail = new ProfileResponseModel
            {
                Name = user.Profile.Name,
                Biography = user.Profile.Biography,
                Gender = user.Profile.Gender,
                IsPrivateProfile = user.Profile.IsPrivateProfile,
                ProfilePhotoUrl = user.Profile.ProfilePhotoUrl,
                Username = user.UserName,
                Website = user.Profile.Website
            };

            return userDetail;
        }

    }
}

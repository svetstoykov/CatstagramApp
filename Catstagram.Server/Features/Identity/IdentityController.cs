using System.Threading.Tasks;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Features.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Catstagram.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly IIdentityService _identityService;
        private readonly ApplicationSettings _applicationSettings;
        

        public IdentityController(UserManager<User> userManager, IOptions<ApplicationSettings> applicationSettings, IIdentityService identityService)
        {
            this._userManager = userManager;
            this._identityService = identityService;
            this._applicationSettings = applicationSettings.Value;
        }



        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Username
            };

            var result = await this._userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {

            var user = await this._userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this._userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this._identityService
                .GenerateJwtToken(user, this._applicationSettings);

            return new LoginResponseModel(token);
        }
    }
}

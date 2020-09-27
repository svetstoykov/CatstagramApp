using System.Collections.Generic;
using System.Threading.Tasks;

using Catstagram.Server.Features.Cats.Models;
using Catstagram.Server.Infrastructure.Extensions;
using Catstagram.Server.Infrastructure.Services;
using static Catstagram.Server.Infrastructure.WebConstants;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Features.Cats
{
    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService _catService;
        private readonly ICurrentUserService _currentUserService;

        public CatsController(ICatService catService, ICurrentUserService currentUserService)
        {
            this._catService = catService;
            this._currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListServiceModel>> Mine()
        {
            var userId = this._currentUserService.GetId();

            return await this._catService.ByUser(userId);
        }

        [HttpGet]
        [Route(IdForRoute)]
        public async Task<CatDetailsServiceModel> Details(int id)
        { 
            return await this._catService.GetDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this._currentUserService.GetId();

            var catId = await this._catService.Create(model, userId);

            return Created(nameof(this.Create), catId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this._currentUserService.GetId();

            var result = await this._catService.Update(model, userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(IdForRoute)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this._currentUserService.GetId();

            var result = await this._catService.Delete(id, userId);

            if (!result.Succeeded)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }

}

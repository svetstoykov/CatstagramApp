using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Cats.Models;
using Catstagram.Server.Infrastructure.Extensions;
using static Catstagram.Server.Infrastructure.WebConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Features.Cats
{
    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            this._catService = catService;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListServiceModel>> Mine()
        {
            var userId = this.GetUserId();

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
            var userId = this.GetUserId();

            var catId = await this._catService.Create(model, userId);

            return Created(nameof(this.Create), catId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.GetUserId();

            var result = await this._catService.Update(model, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(IdForRoute)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.GetUserId();

            var isDeleted = await this._catService.Delete(id, userId);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        private string GetUserId()
            => this.User.GetId();

    }

}

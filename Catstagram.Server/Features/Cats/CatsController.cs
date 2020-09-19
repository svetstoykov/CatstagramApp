using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Cats.Models;
using Catstagram.Server.Infrastructure.Extensions;
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
            var userId = this.User.GetId();

            return await this._catService.ByUser(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        { 
            return await this._catService.GetDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var catId = await this._catService.Create(model, userId);

            return Created(nameof(this.Create), catId);
        }

    }

}

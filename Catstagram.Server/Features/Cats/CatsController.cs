using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Features.Cats
{
    public class CatsController : ApiController
    {
        private readonly ICatService _catService;

        public CatsController(ICatService catService)
        {
            this._catService = catService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CatListResponseModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this._catService.ByUser(userId);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var catId = await this._catService.Create(model, userId);

            return Created(nameof(this.Create), catId);
        }

    }
}

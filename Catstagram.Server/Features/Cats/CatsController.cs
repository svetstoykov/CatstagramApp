using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Features.Cats
{
    public class CatsController : ApiController
    {
        private readonly CatstagramDbContext _dbContext;
        private readonly ICatService _catService;

        public CatsController(CatstagramDbContext dbContext, ICatService catService)
        {
            this._dbContext = dbContext;
            this._catService = catService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var catId = this._catService.Create(model, userId);

            return Created(nameof(this.Create), catId);
        }

    }
}

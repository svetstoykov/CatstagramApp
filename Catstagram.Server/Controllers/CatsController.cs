using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Infrastructure.Extensions;
using Catstagram.Server.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Controllers
{
    public class CatsController : ApiController
    {
        private readonly CatstagramDbContext _dbContext;

        public CatsController(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();

            var cat = new Cat()
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this._dbContext.Add(cat);

            await this._dbContext.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }

    }
}

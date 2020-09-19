using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Server.Features.Cats
{
    public class CatService : ICatService
    {
        private readonly CatstagramDbContext _dbContext;

        public CatService(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<int> Create(CreateCatRequestModel model, string userId)
        {
            var cat = new Cat()
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this._dbContext.Add(cat);

            await this._dbContext.SaveChangesAsync();

            return cat.Id;
        }


        public async Task<IEnumerable<CatListResponseModel>> ByUser(string userId)
        {
            var catsForUser = await this._dbContext.Cats
                .Where(c => c.UserId == userId)
                .Select(c => new CatListResponseModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

            return catsForUser;
        }
    }
}

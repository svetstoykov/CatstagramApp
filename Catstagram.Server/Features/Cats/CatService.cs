using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Features.Cats.Models;
using Catstagram.Server.Infrastructure.Services;
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


        public async Task<Result> Delete(int catId, string userId)
        {
            var cat = await this.GetCatByIdAndUserId(catId, userId);

            if (cat == null)
            {
                return "The cat does not exist or it does not belong to you.";
            }

            this._dbContext.Cats.Remove(cat);

            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Result> Update(UpdateCatRequestModel model, string userId)
        {
            var cat = await this.GetCatByIdAndUserId(model.Id, userId);

            if (cat == null)
            {
                return "The cat does not exist or it does not belong to you.";
            }

            cat.Description = model.Description;

            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CatListServiceModel>> ByUser(string userId)
        {
            var catsForUser = await this._dbContext.Cats
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CatListServiceModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

            return catsForUser;
        }

        public async Task<CatDetailsServiceModel> GetDetails(int catId)
        {
            var cat = await this._dbContext.Cats
                .Where(c => c.Id == catId)
                .Select(c => new CatDetailsServiceModel
                {
                    Description = c.Description,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    UserId = c.UserId,
                    Username = c.User.UserName
                })
                .FirstOrDefaultAsync();

            return cat;
        }

        private async Task<Cat> GetCatByIdAndUserId(int catId, string userId)
         => await this._dbContext.Cats
             .Where(c => c.Id == catId && c.UserId == userId)
             .FirstOrDefaultAsync();
    }
}

using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;

namespace Catstagram.Server.Features.Cats
{
    public class CatService : ICatService
    {
        private readonly CatstagramDbContext _dbContext;

        public CatService(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

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
    }
}

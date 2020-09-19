using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Cats.Models;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatService
    {
        public Task<int> Create(CreateCatRequestModel model, string userId);

        public Task<IEnumerable<CatListServiceModel>> ByUser(string userId);

        public Task<CatDetailsServiceModel> GetDetails(int catId);
    }
}

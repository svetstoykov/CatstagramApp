using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Cats.Models;
using Catstagram.Server.Infrastructure.Services;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatService
    {
        Task<int> Create(CreateCatRequestModel model, string userId);

        Task<Result> Update(UpdateCatRequestModel model, string userId);

        Task<Result> Delete(int catId, string userId);

        Task<IEnumerable<CatListServiceModel>> ByUser(string userId);

        Task<CatDetailsServiceModel> GetDetails(int catId);
    }
}

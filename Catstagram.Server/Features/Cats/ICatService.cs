using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Cats.Models;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatService
    {
        Task<int> Create(CreateCatRequestModel model, string userId);

        Task<bool> Update(UpdateCatRequestModel model, string userId);

        Task<bool> Delete(int catId, string userId);

        Task<IEnumerable<CatListServiceModel>> ByUser(string userId);

        Task<CatDetailsServiceModel> GetDetails(int catId);
    }
}

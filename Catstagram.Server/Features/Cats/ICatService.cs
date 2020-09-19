using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Features.Cats
{
    public interface ICatService
    {
        public Task<int> Create(CreateCatRequestModel model, string userId);

        public Task<IEnumerable<CatListResponseModel>> ByUser(string userId);
    }
}

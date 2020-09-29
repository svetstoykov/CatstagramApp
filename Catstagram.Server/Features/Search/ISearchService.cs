using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Search.Models;

namespace Catstagram.Server.Features.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query);


    }
}

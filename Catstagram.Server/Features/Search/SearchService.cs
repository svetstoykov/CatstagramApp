using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Features.Search.Models;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Server.Features.Search
{
    public class SearchService : ISearchService
    {
        private readonly CatstagramDbContext _dbContext;

        public SearchService(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
        {
            var searchResult = await this._dbContext.Users
                .Where(u => u.UserName.ToLower().Contains(query.ToLower()) ||
                            u.Profile.Name.ToLower().Contains(query.ToLower()))
                .Select(u => new ProfileSearchServiceModel
                {
                    UserId = u.Id,
                    Username = u.UserName,
                    ProfilePhotoUrl = u.Profile.ProfilePhotoUrl,
                })
                .ToListAsync();

            return searchResult;
        }
    }
}

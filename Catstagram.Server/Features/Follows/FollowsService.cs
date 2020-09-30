using System.Linq;
using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Server.Features.Follows
{
    public class FollowsService : IFollowsService
    {
        private readonly CatstagramDbContext _dbContext;

        public FollowsService(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Result> Follow(string userId, string followerId)
        {
            var userAlreadyFollowed = await this._dbContext.Follows
                .AnyAsync(f => f.UserId == userId && f.FollowerId == followerId);

            if (userAlreadyFollowed)
            {
                return "This user is already followed.";
            }

            var isPublicProfile = await this._dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => !u.Profile.IsPrivateProfile)
                .FirstOrDefaultAsync();

            await this._dbContext.Follows.AddAsync(new Follow
            {
                UserId = userId,
                FollowerId = followerId,
                IsApproved = isPublicProfile
            });

            await this._dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsFollower(string userId, string followerId)
        {
            var isFollowed = await this._dbContext.Follows
                .AnyAsync(f => f.UserId == userId && 
                               f.FollowerId == followerId && 
                               f.IsApproved);

            return isFollowed;
        }
    }
}

using System.Threading.Tasks;
using Catstagram.Server.Infrastructure.Services;

namespace Catstagram.Server.Features.Follows
{
    public interface IFollowsService
    {

        Task<Result> Follow(string userId, string followerId);

    }
}

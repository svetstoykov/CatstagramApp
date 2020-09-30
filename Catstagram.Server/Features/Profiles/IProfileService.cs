using System.Threading.Tasks;
using Catstagram.Server.Features.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;

namespace Catstagram.Server.Features.Profiles
{
    public interface IProfileService
    {
        Task<ProfileServiceModel> GetUserDetails(string userId, bool isPublic = false);

        Task<Result> UpdateUserDetails(UpdateProfileRequestModel model, string userId);

        Task<bool> IsPublic(string userId);
    }
}

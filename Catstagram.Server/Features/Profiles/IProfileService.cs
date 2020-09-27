using System.Threading.Tasks;
using Catstagram.Server.Features.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;

namespace Catstagram.Server.Features.Profiles
{
    public interface IProfileService
    {
        Task<ProfileResponseModel> GetUserDetails(string userId);

        Task<Result> UpdateUserDetail(UpdateProfileRequestModel model, string userId);
    }
}

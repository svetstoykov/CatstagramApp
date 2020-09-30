using Catstagram.Server.Data.Models;

namespace Catstagram.Server.Features.Profiles.Models
{
    public class ProfileServiceModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public bool IsPrivateProfile { get; set; }
    }
}

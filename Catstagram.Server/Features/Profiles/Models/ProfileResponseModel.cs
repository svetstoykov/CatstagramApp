using Catstagram.Server.Data.Models;

namespace Catstagram.Server.Features.Profiles.Models
{
    public class ProfileResponseModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public string Gender { get; set; }

        public bool IsPrivateProfile { get; set; }
    }
}

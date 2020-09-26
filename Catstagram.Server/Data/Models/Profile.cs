using System.ComponentModel.DataAnnotations;

using static Catstagram.Server.Data.ValidationConstants.User;

namespace Catstagram.Server.Data.Models
{
    public class Profile
    {
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string Website { get; set; }

        [MaxLength(MaxBiographyLength)]
        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivateProfile { get; set; }
    }
}

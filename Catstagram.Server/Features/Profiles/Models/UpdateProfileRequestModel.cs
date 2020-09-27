using System.ComponentModel.DataAnnotations;

using Catstagram.Server.Data.Models;
using static Catstagram.Server.Data.ValidationConstants.User;

namespace Catstagram.Server.Features.Profiles.Models
{
    public class UpdateProfileRequestModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }

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

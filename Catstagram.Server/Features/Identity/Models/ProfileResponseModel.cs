using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catstagram.Server.Data.Models;

namespace Catstagram.Server.Features.Identity.Models
{
    public class ProfileResponseModel
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public string Website { get; set; }

        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivateProfile { get; set; }
    }
}

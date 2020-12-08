using System.Collections.Generic;

namespace Catstagram.Server.Features.Profiles.Models
{
    public class PublicProfileServiceModel : ProfileServiceModel
    {
        public List<string> CatPictures { get; set; }
    }
}

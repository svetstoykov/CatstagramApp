using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Features.Cats
{
    using static Data.ValidationConstants.Cat;
    public class CreateCatRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}

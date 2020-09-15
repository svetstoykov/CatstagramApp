

namespace Catstagram.Server.Models.Cats
{
    using System.ComponentModel.DataAnnotations;
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

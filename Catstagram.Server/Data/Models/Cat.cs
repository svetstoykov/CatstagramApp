using System.ComponentModel.DataAnnotations;

using Catstagram.Server.Data.Models.Base;
using static Catstagram.Server.Data.ValidationConstants.Cat;

namespace Catstagram.Server.Data.Models
{
    public class Cat : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}

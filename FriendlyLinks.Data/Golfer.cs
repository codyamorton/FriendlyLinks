using System;
using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Data
{
    public class Golfer
    {
        [Key]
        public int GolferId { get; set; }

        [Required]
        [Display(Name = "Your Name")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public Guid OwnerId { get; set; }
    }
}
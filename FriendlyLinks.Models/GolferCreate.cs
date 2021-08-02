using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Models
{
    public class GolferCreate
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
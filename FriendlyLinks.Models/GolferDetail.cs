using System;
using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Models
{
    public class GolferDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
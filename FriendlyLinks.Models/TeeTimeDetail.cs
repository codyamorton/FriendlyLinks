using System;
using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Models
{
    public class TeeTimeDetail
    {
        public int TeeTimeId { get; set; }
        public int CoursePrice { get; set; }
        public int TeeOffTime { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
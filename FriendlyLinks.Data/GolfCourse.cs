using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Data
{
    public class GolfCourse
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Info { get; set; }

        public virtual ICollection<TeeTime> TeeTime { get; set; }
    }
}
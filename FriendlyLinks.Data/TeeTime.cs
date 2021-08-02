using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FriendlyLinks.Data
{
    public class TeeTime
    {
        [Key]
        public int TeeTimeId { get; set; }

        // [Required]
        // public string CourseName { get; set; }

        // [Required]
        // public string CourseCity { get; set; }

        public int CoursePrice { get; set; }

        [Required]
        public int TeeOffTime { get; set; }

        [ForeignKey(nameof(GolfCourse))]
        public int GolfCourseId { get; set; }

        public virtual GolfCourse GolfCourse { get; set; }
    }
}
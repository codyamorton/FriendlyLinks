using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Models
{
    public class GolfCourseCreate
    {
        [Required]
        public string CourseName { get; set; }

        public string CourseCity { get; set; }
        public string CourseState { get; set; }

        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string CourseInfo { get; set; }
    }
}
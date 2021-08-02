using System;
using System.ComponentModel.DataAnnotations;

namespace FriendlyLinks.Models
{
    public class GolfCourseDetail
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCity { get; set; }
        public string CourseState { get; set; }
        public string CourseInfo { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
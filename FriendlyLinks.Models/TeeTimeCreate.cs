using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FriendlyLinks.Models
{
    public class TeeTimeCreate
    {
        [Required]
        public Guid TeeTimeId { get; set; }
        public string CourseName { get; set; }
        public string CourseCity { get; set; }
        public int CoursePrice { get; set; }
        public int  TeeOffTime { get; set; }

    }
}
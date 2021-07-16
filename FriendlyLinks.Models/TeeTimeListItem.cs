using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FriendlyLinks.Models
{
    public class TeeTimeListItem
    {
        public Guid TeeTimeId { get; set; }
        [UIHint ("Starred")]
        public bool IsStarred { get; set; }
        public string CourseName { get; set; }
        public string CourseCity { get; set; }
        public decimal CoursePrice { get; set; }

    }
}
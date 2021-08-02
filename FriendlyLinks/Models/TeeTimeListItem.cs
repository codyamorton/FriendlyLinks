using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriendlyLinks.Models
{
    public class TeeTimeListItem
    {
        public int TeeTimeId { get; set; }
        public string CourseName { get; set; }
        public string CourseCity { get; set; }
        public decimal CoursePrice { get; set; }

    }
}
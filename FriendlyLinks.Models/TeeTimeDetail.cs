using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLinks.Models
{
    public class TeeTimeDetail
    {
        public Guid TeeTimeId { get; set; }
        public string CourseName { get; set; }
        public string CourseCity { get; set; }
        public int  CoursePrice { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}

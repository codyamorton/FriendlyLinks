using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLinks.Models
{
  public  class TeeTimeEdit
    {
        public Guid TeeTimeId { get; set; }
        public string CourseName { get; set; }
        public string CourseCity { get; set; }
        public int CoursePrice { get; set; }
    }
}

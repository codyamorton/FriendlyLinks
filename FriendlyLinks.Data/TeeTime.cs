using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLinks.Data
{
    public class TeeTime
    {
        [Key]
        public int TeeTimeId { get; set; }
        [Required]
        public GolfCourse Location { get; set; }
        [Required]
        public DateTime TeeOffTime { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}

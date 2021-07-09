using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLinks.Data
{
   public class Golfer
    {
        [Key]
        public int GolferId { get; set; }
        [Required]
        [Display(Name ="Your Name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }




    }
}

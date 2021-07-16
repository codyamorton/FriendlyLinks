﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendlyLinks.Data
{
    public class TeeTime
    {
        [Key]
        public Guid TeeTimeId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCity { get; set; }
        public int CoursePrice { get; set; }
        [Required]
        public int TeeOffTime { get; set; }
        [DefaultValue(false)]
        public bool IsStarred { get; set; }

    }
}

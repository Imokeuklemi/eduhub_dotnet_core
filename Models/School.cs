using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace eduhub.Models
{

    public partial class School
    {
        [Key]
        public string Code { get; set; } = null!;
        [Display(Name ="Academic School  Name")]        public string SchoolName { get; set; } = null!;
    }
}

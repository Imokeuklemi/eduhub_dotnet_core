using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace eduhub.Models
{
    public partial class Programme
    {
        public Programme()
        {
            DeptProgs = new HashSet<DeptProg>();
        }

        public int Id { get; set; }
          [Display(Name = "Programme(s)")]
        public string? ProgName { get; set; }
         public virtual ICollection<DeptProg> DeptProgs { get; set; }
    }
}

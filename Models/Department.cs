using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Department
    {
        public Department()
        {
            Courses = new HashSet<Course>();
            DeptProgs = new HashSet<DeptProg>();
        }

        public int Id { get; set; }
        public string DeptName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<DeptProg> DeptProgs { get; set; }
    }
}

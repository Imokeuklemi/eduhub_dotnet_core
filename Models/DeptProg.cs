using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class DeptProg
    {
        public DeptProg()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int ProgrammeId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Programme Programme { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
    }
}

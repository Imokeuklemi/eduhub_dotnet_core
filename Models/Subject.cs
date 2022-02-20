using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Subject
    {
        public int Id { get; set; }
        public int QualificationId { get; set; }
        public string Subject1 { get; set; } = null!;
        public string Grade { get; set; } = null!;
        public string ExamType { get; set; } = null!;

        public virtual Qualification Qualification { get; set; } = null!;
    }
}

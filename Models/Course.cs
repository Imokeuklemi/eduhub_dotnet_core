using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Course
    {
        public long Id { get; set; }
        public short? Programme { get; set; }
        public int? Department { get; set; }
        public string? Semester { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseTitle { get; set; }
        public int Lectures { get; set; }
        public int Text { get; set; }
        public string? Practical { get; set; }
        public int CreditUnit { get; set; }
        public int CreditHours { get; set; }
        public string? Prerequisite { get; set; }
        public string CourseType { get; set; } = null!;
        public short Level { get; set; }
        public int? DepartmentNavigationId { get; set; }

        public virtual Department? DepartmentNavigation { get; set; }
    }
}

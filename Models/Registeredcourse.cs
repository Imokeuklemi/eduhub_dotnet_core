using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Registeredcourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseLevel { get; set; }
        public string Semester { get; set; } = null!;
        public string CourseCode { get; set; } = null!;
        public string Session { get; set; } = null!;
        public decimal? AssessmentScore { get; set; }
        public decimal? ExamScore { get; set; }
        public string? Alphagrade { get; set; }
        public short? GradePoint { get; set; }
        public int? Cgp { get; set; }
        public string? GradeClass { get; set; }
        public short? Status { get; set; }
        public string? Remarks { get; set; }
        public long CourseId { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace eduhub.Models
{
    public partial class Qualification
    {
        public Qualification()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Institute { get; set; } = null!;
        public short YearGraduated { get; set; }
        public string CertificateObtained { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string? ScannedCert { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}

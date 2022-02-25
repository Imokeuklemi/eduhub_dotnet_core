using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace eduhub.Models
{
    public partial class Student
    {
        public Student()
        {
            Addresses = new HashSet<Address>();
            Credentials = new HashSet<Credential>();
            Payments = new HashSet<Payment>();
            Posts = new HashSet<Post>();
            Qualifications = new HashSet<Qualification>();
            Referees = new HashSet<Referee>();
            Registeredcourses = new HashSet<Registeredcourse>();
        }


        public int Id { get; set; }
        [Display(Name = "Registration Number")]
        public string? RegistrationNumber { get; set; }
        public string Surname { get; set; } = null!;
         [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
         [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
         [Display(Name = "Maiden Name (Female Only)")]
        public string? MaidenName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; } = null!;
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; } = null!;
        public string Email { get; set; } = null!;
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; } = null!;
        public int ZipCode { get; set; }
        [Display(Name = "City of Origin")]
        public string CtOfOrigin { get; set; } = null!;
        [Display(Name = "LGA of Origin")]
        public int LgaOfOrigin { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int Programme { get; set; }
        [Display(Name = "Course of Study (First Choice)")]
        public int CourseOfStudy { get; set; }
        [Display(Name = "Course of Study (Second Choice)")]
        public int AlternateCourseOfStudy { get; set; }
        public string? ModeOfStudy { get; set; }
        public int? CourseApproved { get; set; }
        public int? CourseApprovedNavigationId { get; set; }
        public int? LgaOfOriginNavigationId { get; set; }

        public virtual DeptProg? CourseApprovedNavigation { get; set; }
        public virtual Local? LgaOfOriginNavigation { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Credential> Credentials { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Qualification> Qualifications { get; set; }
        public virtual ICollection<Referee> Referees { get; set; }
        public virtual ICollection<Registeredcourse> Registeredcourses { get; set; }
    }
}

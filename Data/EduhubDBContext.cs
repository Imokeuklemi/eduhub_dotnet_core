using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using eduhub.Models;

namespace eduhub.Data
{
    public partial class EduhubDBContext : DbContext
    {
        public EduhubDBContext()
        {
        }

        public EduhubDBContext(DbContextOptions<EduhubDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Credential> Credentials { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DeptProg> DeptProgs { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<Local> Locals { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Programme> Programmes { get; set; } = null!;
        public virtual DbSet<Qualification> Qualifications { get; set; } = null!;
        public virtual DbSet<Referee> Referees { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Registeredcourse> Registeredcourses { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Addresses_StudentId");

                entity.Property(e => e.ContactPhone).HasMaxLength(11);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Addresses_Students");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Regions");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.DepartmentNavigationId, "IX_Courses_DepartmentNavigationId");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentNavigationId);
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Credentials_UsersId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Credentials)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credentials_Students");
            });

            modelBuilder.Entity<DeptProg>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_DeptProgs_DeptId");

                entity.HasIndex(e => e.ProgrammeId, "IX_DeptProgs_ProgId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DeptProgs)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_DeptProgs_Departments_DeptId");

                entity.HasOne(d => d.Programme)
                    .WithMany(p => p.DeptProgs)
                    .HasForeignKey(d => d.ProgrammeId)
                    .HasConstraintName("FK_DeptProgs_Programmes_ProgId");
            });

            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasIndex(e => e.StateId, "IX_Locals_StateId");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Payments_UsersId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Students");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.AuthorId, "IX_Posts_AuthorId");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Posts_Personalinfos_AuthorId");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Qualifications_StudentId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Qualifications)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Qualifications_Students");
            });

            modelBuilder.Entity<Referee>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Referees_StudentId");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Referees)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Referees_Students");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regions_Countries");
            });

            modelBuilder.Entity<Registeredcourse>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Registeredcourses_UsersId");

                entity.Property(e => e.AssessmentScore).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExamScore).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Registeredcourses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Registeredcourses_Students");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Code);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_States_CountryId");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.CourseApprovedNavigationId, "IX_Personalinfos_CourseApprovedNavigationId");

                entity.HasIndex(e => e.LgaOfOriginNavigationId, "IX_Personalinfos_LgaOfOriginNavigationId");

                entity.Property(e => e.MobileNumber).HasMaxLength(11);

                entity.HasOne(d => d.CourseApprovedNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseApprovedNavigationId)
                    .HasConstraintName("FK_Personalinfos_DeptProgs_CourseApprovedNavigationId");

                entity.HasOne(d => d.LgaOfOriginNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.LgaOfOriginNavigationId)
                    .HasConstraintName("FK_Personalinfos_Locals_LgaOfOriginNavigationId");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.QualificationId, "IX_Subjects_QualificationId");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.QualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subjects_Qualifications");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

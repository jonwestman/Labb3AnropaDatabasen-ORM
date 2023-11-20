using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Labb3.Models;

namespace Labb3.Data
{
    public partial class NewSchoolContext : DbContext
    {
        public NewSchoolContext()
        {
        }

        public NewSchoolContext(DbContextOptions<NewSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<FacultyType> FacultyTypes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("YOUR_CONNECTION_STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.PkClassId)
                    .HasName("PK__Class__CCB73664405A67C9");

                entity.ToTable("Class");

                entity.Property(e => e.PkClassId).HasColumnName("PK_ClassId");

                entity.Property(e => e.ClassName).HasMaxLength(50);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.PkFacultyId)
                    .HasName("PK__Faculty__6D22529DA5F66F4F");

                entity.ToTable("Faculty");

                entity.Property(e => e.PkFacultyId).HasColumnName("PK_FacultyId");

                entity.Property(e => e.FkFacultyTypeId).HasColumnName("FK_FacultyTypeId");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.HasOne(d => d.FkFacultyType)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.FkFacultyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_FacultyType");
            });

            modelBuilder.Entity<FacultyType>(entity =>
            {
                entity.HasKey(e => e.PkFacultyTypeId);

                entity.ToTable("FacultyType");

                entity.Property(e => e.PkFacultyTypeId).HasColumnName("PK_FacultyTypeId");

                entity.Property(e => e.FacultyType1)
                    .HasMaxLength(50)
                    .HasColumnName("FacultyType");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.PkGradeId)
                    .HasName("PK__Grade__B62E54542B34B294");

                entity.ToTable("Grade");

                entity.Property(e => e.PkGradeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PK_GradeId");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.PkStudentId)
                    .HasName("PK__Student__168480D11AFC1AF2");

                entity.ToTable("Student");

                entity.Property(e => e.PkStudentId).HasColumnName("PK_StudentId");

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.PersonId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StudentGrade");

                entity.Property(e => e.DateOfGrade).HasColumnType("date");

                entity.Property(e => e.FkFacultyId).HasColumnName("FK_FacultyId");

                entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.Property(e => e.FkSubjectId).HasColumnName("FK_SubjectId");

                entity.HasOne(d => d.FkFaculty)
                    .WithMany()
                    .HasForeignKey(d => d.FkFacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Faculty");

                entity.HasOne(d => d.FkGrade)
                    .WithMany()
                    .HasForeignKey(d => d.FkGradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Grade");

                entity.HasOne(d => d.FkStudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Student");

                entity.HasOne(d => d.FkSubject)
                    .WithMany()
                    .HasForeignKey(d => d.FkSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentGrade_Subject");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.PkSubjectId)
                    .HasName("PK__Subject__26328D7477036727");

                entity.ToTable("Subject");

                entity.Property(e => e.PkSubjectId).HasColumnName("PK_SubjectId");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Data;

public partial class Lab4DBContext : DbContext
{
    public Lab4DBContext()
    {
    }

    public Lab4DBContext(DbContextOptions<Lab4DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffType> StaffTypes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ELVIRAS_LAPTOP;Database=Lab4DB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC077B069C66");

            entity.ToTable("Class", tb => tb.HasTrigger("TRG_Class_Teacher_StaffNotTeacher"));

            entity.Property(e => e.ClassTitle).HasMaxLength(150);

            entity.HasOne(d => d.Teacher).WithMany(p => p.Classes)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Class_TeacherId");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Course__3214EC077EE141CA");

            entity.ToTable("Course", tb => tb.HasTrigger("TRG_Course_Class_CourseDatesOutOfBounds"));

            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC072B64CA01");

            entity.ToTable("Department");

            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC07644BCE23");

            entity.ToTable("Enrollment");

            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_Grade_Student_Course").IsUnique();

            entity.Property(e => e.Grade).HasColumnType("numeric(3, 1)");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grade_CourseId");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grade_StudentId");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grade_TeacherId");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Staff__3214EC071FF264BA");

            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_DepartmentId");

            entity.HasOne(d => d.StaffType).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StaffTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_StaffTypeId");
        });

        modelBuilder.Entity<StaffType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StaffTyp__3214EC072EDF779D");

            entity.ToTable("StaffType");

            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0717DD3F84");

            entity.ToTable("Student");

            entity.HasIndex(e => e.Personnummer, "UQ__Student__245B03C1F2FDCEFC").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Personnummer).HasMaxLength(13);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_ClassId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

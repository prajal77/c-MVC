using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginRegi.Models;

public partial class EmployeeDatabaseContext : DbContext
{
    public EmployeeDatabaseContext()
    {
    }

    public EmployeeDatabaseContext(DbContextOptions<EmployeeDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Department Name:");
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.Property(e => e.DesignationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Designation Name:");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

            entity.HasIndex(e => e.DesignationId, "IX_Employees_DesignationId");

            entity.Property(e => e.EmployeeAddress)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Employee Address:");
            entity.Property(e => e.EmployeeEmail)
                .HasMaxLength(300)
                .HasColumnName("Employee Email:");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Employee Name:");
            entity.Property(e => e.EmployeePhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Employee Phone Number:");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasForeignKey(d => d.DepartmentId);

            entity.HasOne(d => d.Designation).WithMany(p => p.Employees).HasForeignKey(d => d.DesignationId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Users__3213E83F79552D2C");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.age)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("age");
            entity.Property(e => e.email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

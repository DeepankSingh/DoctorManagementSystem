using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoctorManagement.DAL.Entities;

public partial class HealthcareManagementContext : DbContext
{
    public HealthcareManagementContext()
    {
    }

    public HealthcareManagementContext(DbContextOptions<HealthcareManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DoctorRegistration> DoctorRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HealthcareManagement;Integrated Security=True;Command Timeout=0;Encrypt=False;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorRegistration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK__DoctorRe__6EF5881044A9E259");

            entity.HasIndex(e => e.LicenseNumber, "UQ__DoctorRe__E8890166367DA3A2").IsUnique();

            entity.Property(e => e.ContactNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("Y");
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

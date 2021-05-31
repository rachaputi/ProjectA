using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TransportManagementSystem.Models
{
    public partial class TransportManagementSystemUpdatedContext : DbContext
    {
        public TransportManagementSystemUpdatedContext()
        {
        }

        public TransportManagementSystemUpdatedContext(DbContextOptions<TransportManagementSystemUpdatedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleAllocation> VehicleAllocation { get; set; }
        public virtual DbSet<Microsoft.AspNetCore.Identity.IdentityUser> IdentityUser { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-5KCNCLR8;Database=TransportManagementSystemUpdated;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RouteNumber);

                entity.Property(e => e.Stop1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stop2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stop3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleNumber);

                entity.Property(e => e.VehicleNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EveningArrival).HasColumnType("datetime");

                entity.Property(e => e.EveningDepature).HasColumnType("datetime");

                entity.Property(e => e.IsAc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsOperable)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MorningArrival).HasColumnType("datetime");

                entity.Property(e => e.MorningDepature).HasColumnType("datetime");

                entity.HasOne(d => d.RouteNumberNavigation)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.RouteNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Route");
            });

            modelBuilder.Entity<VehicleAllocation>(entity =>
            {
                entity.HasKey(e => e.AllocationId);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.VehicleAllocation)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleAllocation_Employee");

                entity.HasOne(d => d.RouteNumberNavigation)
                    .WithMany(p => p.VehicleAllocation)
                    .HasForeignKey(d => d.RouteNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleAllocation_Route");

                entity.HasOne(d => d.VehicleNumberNavigation)
                    .WithMany(p => p.VehicleAllocation)
                    .HasForeignKey(d => d.VehicleNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehicleAllocation_Vehicle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

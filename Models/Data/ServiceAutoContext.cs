using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Models;

namespace Raul_Moldovan_Medii.Data
{
    public class ServiceAutoContext : IdentityDbContext
    {
        public ServiceAutoContext(DbContextOptions<ServiceAutoContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Mechanic> Mechanic { get; set; } = default!;
        public DbSet<ServiceType> ServiceType { get; set; } = default!;
        public DbSet<Appointment> Appointment { get; set; } = default!;
        public DbSet<AppointmentService> AppointmentService { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.Vin)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.PlateNumber)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Cars)
                .HasForeignKey(c => c.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany(cl => cl.Appointments)
                .HasForeignKey(a => a.ClientID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Car)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CarID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Mechanic)
                .WithMany(m => m.Appointments)
                .HasForeignKey(a => a.MechanicID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(x => x.Appointment)
                .WithMany(a => a.AppointmentServices)
                .HasForeignKey(x => x.AppointmentID);

            modelBuilder.Entity<AppointmentService>()
                .HasOne(x => x.ServiceType)
                .WithMany(s => s.AppointmentServices)
                .HasForeignKey(x => x.ServiceTypeID);

            modelBuilder.Entity<AppointmentService>()
                .HasIndex(x => new { x.AppointmentID, x.ServiceTypeID })
                .IsUnique();
        }
    }
}



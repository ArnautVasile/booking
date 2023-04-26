using Booking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Persistance.Context
{
    public class DataContext: DbContext
    {
        public DbSet<Barbershop> Barbershops { get; set; }
        public DbSet<BaseUserEntity> BaseUserEntities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EmployeeAvailability> EmployeeAvailabilities { get; set; }
        public DbSet<UserAppointment> UserAppointments { get; set; }
        public DataContext():base("name=booking")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barbershop>()
               .HasMany<Employee>(b => b.Employees).WithMany();

            modelBuilder.Entity<Barbershop>()
                 .HasMany<Service>(b => b.Services).WithMany();

            modelBuilder.Entity<Employee>()
                .HasMany<Service>(e => e.Services).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}

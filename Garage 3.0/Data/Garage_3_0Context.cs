using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_3._0.Models;

namespace Garage_3._0.Data
{
    public class Garage_3_0Context : DbContext
    {
        public Garage_3_0Context (DbContextOptions<Garage_3_0Context> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .Property(b => b.TimeOfArrival)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Vehicle>()
                .HasIndex(b => b.RegNr)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasData(
                  new Vehicle { Id = 1, MemberId = 1, RegNr = "US_LM126", VehicleTypeId = 1, NrOfWheels = 4, Color = "White", Brand ="aaa", Model ="model1", TimeOfArrival = DateTime.Now - new TimeSpan(1, 1, 30, 0) },
                  new Vehicle { Id = 2, MemberId = 2, RegNr = "BVG17", VehicleTypeId = 2, NrOfWheels = 1, Color = "Black", Brand = "bbb", Model = "model2", TimeOfArrival = DateTime.Now - new TimeSpan(1, 1, 30, 0) },
                  new Vehicle { Id = 3, MemberId = 3, RegNr = "BUS123", VehicleTypeId = 3, NrOfWheels = 6, Color = "Blue", Brand = "ccc", Model = "model3", TimeOfArrival = DateTime.Now - new TimeSpan(1, 1, 30, 0) },
                  new Vehicle { Id = 4, MemberId = 4, RegNr = "ABC123", VehicleTypeId = 4, NrOfWheels = 4, Color = "Red", Brand = "ddd", Model = "model4", TimeOfArrival = DateTime.Now - new TimeSpan(1, 1, 30, 0) },
                  new Vehicle { Id = 5, MemberId = 1, RegNr = "ADZ967", VehicleTypeId = 2, NrOfWheels = 2, Color = "Yellow", Brand = "eee", Model = "model5" }
                 );

            modelBuilder.Entity<Member>()
            .HasIndex(b => b.Email)
            .IsUnique();

            modelBuilder.Entity<Member>()
                .HasData(
                  new Member { Id = 1, FirstName = "Johan", LastName = "Andersson", Email = "johan.andersson@gmail.com"},
                  new Member { Id = 2, FirstName = "Anna", LastName = "Lind", Email = "anna.lind@yahoo.se" },
                  new Member { Id = 3, FirstName = "Dimitris", LastName = "Björlingh", Email = "dimman@lexicon.se" },
                  new Member { Id = 4, FirstName = "Bruce", LastName = "Lee", Email = "bruce.lee@jeetkunedo.cn" },
                  new Member { Id = 5, FirstName = "Sakari", LastName = "Kivimäki", Email = "saka.kivi@soumi.fi" }
                 );

            modelBuilder.Entity<VehicleType>()
                .HasData(
                  new VehicleType { Id = 1, TypeName = "Airplane", Size = 2 },
                  new VehicleType { Id = 2, TypeName = "Car", Size = 2 },
                  new VehicleType { Id = 3, TypeName = "Motorcycle", Size = 2 },
                  new VehicleType { Id = 4, TypeName = "Bus", Size = 2 }
                 );
        }
    }
}

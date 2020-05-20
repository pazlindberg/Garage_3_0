﻿// <auto-generated />
using System;
using Garage_3._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage_3._0.Migrations
{
    [DbContext(typeof(Garage_3_0Context))]
    partial class Garage_3_0ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garage_3._0.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "johan.andersson@gmail.com",
                            FirstName = "Johan",
                            LastName = "Andersson"
                        },
                        new
                        {
                            Id = 2,
                            Email = "anna.lind@yahoo.se",
                            FirstName = "Anna",
                            LastName = "Lind"
                        },
                        new
                        {
                            Id = 3,
                            Email = "dimman@lexicon.se",
                            FirstName = "Dimitris",
                            LastName = "Björlingh"
                        },
                        new
                        {
                            Id = 4,
                            Email = "bruce.lee@jeetkunedo.cn",
                            FirstName = "Bruce",
                            LastName = "Lee"
                        },
                        new
                        {
                            Id = 5,
                            Email = "saka.kivi@soumi.fi",
                            FirstName = "Sakari",
                            LastName = "Kivimäki"
                        });
                });

            modelBuilder.Entity("Garage_3._0.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<int?>("ParkingSpaceId")
                        .HasColumnType("int");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("TimeOfArrival")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RegNr")
                        .IsUnique();

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "aaa",
                            Color = "White",
                            MemberId = 1,
                            Model = "model1",
                            NrOfWheels = 4,
                            RegNr = "US_LM126",
                            TimeOfArrival = new DateTime(2020, 5, 19, 12, 5, 49, 71, DateTimeKind.Local).AddTicks(6968),
                            VehicleTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Brand = "bbb",
                            Color = "Black",
                            MemberId = 2,
                            Model = "model2",
                            NrOfWheels = 1,
                            RegNr = "BVG17",
                            TimeOfArrival = new DateTime(2020, 5, 19, 12, 5, 49, 73, DateTimeKind.Local).AddTicks(5456),
                            VehicleTypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Brand = "ccc",
                            Color = "Blue",
                            MemberId = 3,
                            Model = "model3",
                            NrOfWheels = 6,
                            RegNr = "BUS123",
                            TimeOfArrival = new DateTime(2020, 5, 19, 12, 5, 49, 73, DateTimeKind.Local).AddTicks(5492),
                            VehicleTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            Brand = "ddd",
                            Color = "Red",
                            MemberId = 4,
                            Model = "model4",
                            NrOfWheels = 4,
                            RegNr = "ABC123",
                            TimeOfArrival = new DateTime(2020, 5, 19, 12, 5, 49, 73, DateTimeKind.Local).AddTicks(5499),
                            VehicleTypeId = 4
                        },
                        new
                        {
                            Id = 5,
                            Brand = "eee",
                            Color = "Yellow",
                            MemberId = 1,
                            Model = "model5",
                            NrOfWheels = 2,
                            RegNr = "ADZ967",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleTypeId = 2
                        });
                });

            modelBuilder.Entity("Garage_3._0.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Size = 2.0,
                            TypeName = "Airplane"
                        },
                        new
                        {
                            Id = 2,
                            Size = 2.0,
                            TypeName = "Car"
                        },
                        new
                        {
                            Id = 3,
                            Size = 2.0,
                            TypeName = "Motorcycle"
                        },
                        new
                        {
                            Id = 4,
                            Size = 2.0,
                            TypeName = "Bus"
                        });
                });

            modelBuilder.Entity("Garage_3._0.Models.Vehicle", b =>
                {
                    b.HasOne("Garage_3._0.Models.Member", "Member")
                        .WithMany("Vehicles")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage_3._0.Models.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

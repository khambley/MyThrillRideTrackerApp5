﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyThrillRideTrackerApp5.Models;

namespace MyThrillRideTrackerApp5.Migrations
{
    [DbContext(typeof(ThrillRideTrackerDbContext))]
    [Migration("20210421123529_AddNotesToRideModel")]
    partial class AddNotesToRideModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.ImageFileName", b =>
                {
                    b.Property<int>("ImageFileNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParkId")
                        .HasColumnType("int");

                    b.Property<int?>("RideId")
                        .HasColumnType("int");

                    b.Property<int?>("VisitId")
                        .HasColumnType("int");

                    b.Property<int?>("VisitRideId")
                        .HasColumnType("int");

                    b.HasKey("ImageFileNameId");

                    b.HasIndex("ParkId");

                    b.HasIndex("RideId");

                    b.HasIndex("VisitId");

                    b.HasIndex("VisitRideId");

                    b.ToTable("ImageFileNames");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParkMapLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Ride", b =>
                {
                    b.Property<int>("RideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BuildDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GForce")
                        .HasColumnType("int");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<string>("RideType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThrillType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopSpeed")
                        .HasColumnType("int");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RideId");

                    b.HasIndex("ParkId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Visit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<string>("VisitComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitRating")
                        .HasColumnType("int");

                    b.HasKey("VisitId");

                    b.HasIndex("ParkId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.VisitRide", b =>
                {
                    b.Property<int>("VisitRideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RideId")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.Property<string>("VisitRideComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitRideRating")
                        .HasColumnType("int");

                    b.HasKey("VisitRideId");

                    b.HasIndex("RideId");

                    b.HasIndex("VisitId");

                    b.ToTable("VisitRides");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.ImageFileName", b =>
                {
                    b.HasOne("MyThrillRideTrackerApp5.Models.Park", "Park")
                        .WithMany("ImageFiles")
                        .HasForeignKey("ParkId");

                    b.HasOne("MyThrillRideTrackerApp5.Models.Ride", "Ride")
                        .WithMany("ImageFiles")
                        .HasForeignKey("RideId");

                    b.HasOne("MyThrillRideTrackerApp5.Models.Visit", "Visit")
                        .WithMany("ImageFiles")
                        .HasForeignKey("VisitId");

                    b.HasOne("MyThrillRideTrackerApp5.Models.VisitRide", "VisitRide")
                        .WithMany("ImageFiles")
                        .HasForeignKey("VisitRideId");

                    b.Navigation("Park");

                    b.Navigation("Ride");

                    b.Navigation("Visit");

                    b.Navigation("VisitRide");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Ride", b =>
                {
                    b.HasOne("MyThrillRideTrackerApp5.Models.Park", "Park")
                        .WithMany("Rides")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Park");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Visit", b =>
                {
                    b.HasOne("MyThrillRideTrackerApp5.Models.Park", "Park")
                        .WithMany("Visits")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Park");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.VisitRide", b =>
                {
                    b.HasOne("MyThrillRideTrackerApp5.Models.Ride", "Ride")
                        .WithMany()
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyThrillRideTrackerApp5.Models.Visit", "Visit")
                        .WithMany("VisitRides")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ride");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Park", b =>
                {
                    b.Navigation("ImageFiles");

                    b.Navigation("Rides");

                    b.Navigation("Visits");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Ride", b =>
                {
                    b.Navigation("ImageFiles");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.Visit", b =>
                {
                    b.Navigation("ImageFiles");

                    b.Navigation("VisitRides");
                });

            modelBuilder.Entity("MyThrillRideTrackerApp5.Models.VisitRide", b =>
                {
                    b.Navigation("ImageFiles");
                });
#pragma warning restore 612, 618
        }
    }
}

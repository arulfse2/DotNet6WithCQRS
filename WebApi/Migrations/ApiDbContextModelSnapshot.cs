﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Data;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EstablishedYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7cf02d2b-0190-41b9-a8f0-66df080337cc"),
                            AddedBy = "ADMIN",
                            AddedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(900),
                            EstablishedYear = "1994",
                            Name = "Cognizant Technology Solutions",
                            Status = 1,
                            UpdatedBy = "ADMIN",
                            UpdatedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(895)
                        },
                        new
                        {
                            Id = new Guid("83bb4320-0d51-4c77-ba50-e30c4b287d4a"),
                            AddedBy = "ADMIN",
                            AddedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(909),
                            EstablishedYear = "1945",
                            Name = "Wipro Ltd",
                            Status = 1,
                            UpdatedBy = "ADMIN",
                            UpdatedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(908)
                        });
                });

            modelBuilder.Entity("WebApi.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JoiningYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c93d8b8e-1dc0-4290-982b-ed83893dca37"),
                            AddedBy = "ADMIN",
                            AddedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1132),
                            CompanyId = new Guid("7cf02d2b-0190-41b9-a8f0-66df080337cc"),
                            Designation = "Senior Software Engineer",
                            EmployeeId = "CTS1",
                            JoiningYear = "2016",
                            Name = "Arulprakash Subramanian",
                            Status = 1,
                            UpdatedBy = "ADMIN",
                            UpdatedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1132)
                        },
                        new
                        {
                            Id = new Guid("31847449-3d22-4997-a08c-58de55c45370"),
                            AddedBy = "ADMIN",
                            AddedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1138),
                            CompanyId = new Guid("7cf02d2b-0190-41b9-a8f0-66df080337cc"),
                            Designation = "Senior Software Engineer",
                            EmployeeId = "CTS2",
                            JoiningYear = "2016",
                            Name = "Saravanan",
                            Status = 1,
                            UpdatedBy = "ADMIN",
                            UpdatedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1137)
                        },
                        new
                        {
                            Id = new Guid("64a85cc8-59ee-4161-aec4-4fdc8e709bab"),
                            AddedBy = "ADMIN",
                            AddedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1142),
                            CompanyId = new Guid("83bb4320-0d51-4c77-ba50-e30c4b287d4a"),
                            Designation = "Manager",
                            EmployeeId = "WIP1",
                            JoiningYear = "2016",
                            Name = "Suresh",
                            Status = 1,
                            UpdatedBy = "ADMIN",
                            UpdatedDate = new DateTime(2022, 9, 14, 14, 28, 48, 577, DateTimeKind.Utc).AddTicks(1141)
                        });
                });

            modelBuilder.Entity("WebApi.Models.Employee", b =>
                {
                    b.HasOne("WebApi.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Company_Employee");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebApi.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
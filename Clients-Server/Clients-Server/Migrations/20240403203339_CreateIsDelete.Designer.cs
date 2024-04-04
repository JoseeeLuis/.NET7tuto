﻿// <auto-generated />
using System;
using Clients_Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clients_Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240403203339_CreateIsDelete")]
    partial class CreateIsDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clients_Server.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Clients_Server.Models.DepartamentType", b =>
                {
                    b.Property<string>("DepartamentTypeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Departament")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartamentTypeCode");

                    b.ToTable("Departaments", (string)null);
                });

            modelBuilder.Entity("Clients_Server.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Clients_Server.Models.SeniorityType", b =>
                {
                    b.Property<string>("SeniorityTypeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Seniority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeniorityTypeCode");

                    b.ToTable("Seniorities", (string)null);
                });

            modelBuilder.Entity("Clients_Server.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("WorkerDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("WorkerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WorkerId");

                    b.HasIndex("AddressId");

                    b.HasIndex("WorkerDetailsId");

                    b.ToTable("Workers", (string)null);
                });

            modelBuilder.Entity("Clients_Server.Models.WorkerDetails", b =>
                {
                    b.Property<int>("WorkerDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerDetailsId"));

                    b.Property<string>("DepartamentTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SeniorityTypeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WorkerDetailsId");

                    b.HasIndex("DepartamentTypeCode");

                    b.HasIndex("SeniorityTypeCode");

                    b.ToTable("WorkersDetails", (string)null);
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.Property<Guid>("ProjectsProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WorkersWorkerId")
                        .HasColumnType("int");

                    b.HasKey("ProjectsProjectId", "WorkersWorkerId");

                    b.HasIndex("WorkersWorkerId");

                    b.ToTable("ProjectWorker");
                });

            modelBuilder.Entity("Clients_Server.Models.Worker", b =>
                {
                    b.HasOne("Clients_Server.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clients_Server.Models.WorkerDetails", "WorkerDetails")
                        .WithMany()
                        .HasForeignKey("WorkerDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("WorkerDetails");
                });

            modelBuilder.Entity("Clients_Server.Models.WorkerDetails", b =>
                {
                    b.HasOne("Clients_Server.Models.DepartamentType", "DepartamentType")
                        .WithMany()
                        .HasForeignKey("DepartamentTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clients_Server.Models.SeniorityType", "SeniorityType")
                        .WithMany()
                        .HasForeignKey("SeniorityTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartamentType");

                    b.Navigation("SeniorityType");
                });

            modelBuilder.Entity("ProjectWorker", b =>
                {
                    b.HasOne("Clients_Server.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clients_Server.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersWorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
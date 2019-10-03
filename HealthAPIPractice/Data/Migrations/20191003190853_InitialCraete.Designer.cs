﻿// <auto-generated />
using System;
using HealthAPIPractice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthAPIPractice.Data.Migrations
{
    [DbContext(typeof(HealthContext))]
    [Migration("20191003190853_InitialCraete")]
    partial class InitialCraete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthAPIPractice.Models.Ailment", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("PatientId");

                    b.ToTable("Ailments");
                });

            modelBuilder.Entity("HealthAPIPractice.Models.Medication", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Doses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("PatientId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("HealthAPIPractice.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HealthAPIPractice.Models.Ailment", b =>
                {
                    b.HasOne("HealthAPIPractice.Models.Patient", null)
                        .WithMany("Ailments")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("HealthAPIPractice.Models.Medication", b =>
                {
                    b.HasOne("HealthAPIPractice.Models.Patient", null)
                        .WithMany("Medications")
                        .HasForeignKey("PatientId");
                });
#pragma warning restore 612, 618
        }
    }
}

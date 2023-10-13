﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Infrustructure.Data;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolProject.Data.Entities.Departement", b =>
                {
                    b.Property<int>("DID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DID"), 1L, 1);

                    b.Property<string>("DNameAr")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DNameEn")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("InsManager")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("DID");

                    b.HasIndex("InsManager");

                    b.ToTable("departements");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartementSubject", b =>
                {
                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<int?>("SubID")
                        .HasColumnType("int");

                    b.HasKey("DID", "SubID");

                    b.HasIndex("SubID");

                    b.ToTable("departementSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("InsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DId")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("InsId");

                    b.HasIndex("DId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.InstructorSubject", b =>
                {
                    b.Property<int>("InsId")
                        .HasColumnType("int");

                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.HasKey("InsId", "SubId");

                    b.HasIndex("SubId");

                    b.ToTable("instructorSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Property<int>("StuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StuId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("StuNameAr")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StuNameEn")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("StuId");

                    b.HasIndex("DID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.Property<int?>("StudID")
                        .HasColumnType("int");

                    b.Property<int?>("SubID")
                        .HasColumnType("int");

                    b.Property<int?>("grade")
                        .HasColumnType("int");

                    b.HasKey("StudID", "SubID");

                    b.HasIndex("SubID");

                    b.ToTable("studentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subject", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubID"), 1L, 1);

                    b.Property<int?>("Period")
                        .HasColumnType("int");

                    b.Property<string>("SubNameAr")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SubNameEn")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubID");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Departement", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Instructor", "Instructor")
                        .WithOne("DepartementManager")
                        .HasForeignKey("SchoolProject.Data.Entities.Departement", "InsManager")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartementSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Departement", "Departement")
                        .WithMany("DepartementSubjects")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("DepartementSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Instructor", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Departement", "Departement")
                        .WithMany("Instructors")
                        .HasForeignKey("DId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SchoolProject.Data.Entities.Instructor", "supervisor")
                        .WithMany("Instructors")
                        .HasForeignKey("SupervisorId");

                    b.Navigation("Departement");

                    b.Navigation("supervisor");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.InstructorSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Instructor", "Instructor")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("InstructorSubjects")
                        .HasForeignKey("SubId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Departement", "Departement")
                        .WithMany("Students")
                        .HasForeignKey("DID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Departement", b =>
                {
                    b.Navigation("DepartementSubjects");

                    b.Navigation("Instructors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Instructor", b =>
                {
                    b.Navigation("DepartementManager")
                        .IsRequired();

                    b.Navigation("InstructorSubjects");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subject", b =>
                {
                    b.Navigation("DepartementSubjects");

                    b.Navigation("InstructorSubjects");

                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}

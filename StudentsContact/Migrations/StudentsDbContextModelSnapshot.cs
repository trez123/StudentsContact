﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentsContact.Models;

#nullable disable

namespace StudentsContact.Migrations
{
    [DbContext(typeof(StudentsDbContext))]
    partial class StudentsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentsContact.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddresLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ParishId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParishId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("StudentsContact.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxStudent")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("StudentsContact.Models.Grades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IndustrialTechnology")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Math")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhysicalEducation")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Physics")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentsContact.Models.Parish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StateParish")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Parish");
                });

            modelBuilder.Entity("StudentsContact.Models.StudentsContacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentsContact.Models.Address", b =>
                {
                    b.HasOne("StudentsContact.Models.Parish", "Parish")
                        .WithMany("Address")
                        .HasForeignKey("ParishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentsContact.Models.StudentsContacts", "StudentsContacts")
                        .WithOne("Address")
                        .HasForeignKey("StudentsContact.Models.Address", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parish");

                    b.Navigation("StudentsContacts");
                });

            modelBuilder.Entity("StudentsContact.Models.Grades", b =>
                {
                    b.HasOne("StudentsContact.Models.StudentsContacts", "StudentsContacts")
                        .WithOne("Grades")
                        .HasForeignKey("StudentsContact.Models.Grades", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentsContacts");
                });

            modelBuilder.Entity("StudentsContact.Models.StudentsContacts", b =>
                {
                    b.HasOne("StudentsContact.Models.Course", "Course")
                        .WithMany("StudentsContacts")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("StudentsContact.Models.Course", b =>
                {
                    b.Navigation("StudentsContacts");
                });

            modelBuilder.Entity("StudentsContact.Models.Parish", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("StudentsContact.Models.StudentsContacts", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityTimeTableModel;

#nullable disable

namespace UNI_timetable.Migrations
{
    [DbContext(typeof(UniversityTimeTableDbContext))]
    [Migration("20230822163524_levelMigration")]
    partial class levelMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UniversityTimeTableModel.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LevelDepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SLOTId")
                        .HasColumnType("int");

                    b.Property<bool>("isItDepartmental")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.Property<int>("no_of_dept_offering")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LevelDepartmentId");

                    b.HasIndex("SLOTId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("UniversityTimeTableModel.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UniversityTimeTableModel.LevelCourse", b =>
                {
                    b.Property<int>("LevelDepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("LevelDepartmentId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("LevelCourses");
                });

            modelBuilder.Entity("UniversityTimeTableModel.LevelDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("TotalNoOfNonDepartmentalCourses")
                        .HasColumnType("int");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("LevelDepartments");
                });

            modelBuilder.Entity("UniversityTimeTableModel.SLOT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("LevelDepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("LevelDepartmentId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LevelDepartmentId");

                    b.HasIndex("LevelDepartmentId1");

                    b.ToTable("slots");
                });

            modelBuilder.Entity("UniversityTimeTableModel.Courses", b =>
                {
                    b.HasOne("UniversityTimeTableModel.LevelDepartment", "dept_level_that_owns_it")
                        .WithMany("delivered")
                        .HasForeignKey("LevelDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimeTableModel.SLOT", "courses")
                        .WithMany("coursesInSlot")
                        .HasForeignKey("SLOTId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("dept_level_that_owns_it");
                });

            modelBuilder.Entity("UniversityTimeTableModel.LevelCourse", b =>
                {
                    b.HasOne("UniversityTimeTableModel.Courses", "course")
                        .WithMany("LevelCourse")
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityTimeTableModel.LevelDepartment", "LevelDepartmental")
                        .WithMany("LevelCourse")
                        .HasForeignKey("LevelDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LevelDepartmental");

                    b.Navigation("course");
                });

            modelBuilder.Entity("UniversityTimeTableModel.LevelDepartment", b =>
                {
                    b.HasOne("UniversityTimeTableModel.Department", "dept")
                        .WithMany("dept_Level")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dept");
                });

            modelBuilder.Entity("UniversityTimeTableModel.SLOT", b =>
                {
                    b.HasOne("UniversityTimeTableModel.LevelDepartment", null)
                        .WithMany("Available")
                        .HasForeignKey("LevelDepartmentId");

                    b.HasOne("UniversityTimeTableModel.LevelDepartment", null)
                        .WithMany("Used")
                        .HasForeignKey("LevelDepartmentId1");
                });

            modelBuilder.Entity("UniversityTimeTableModel.Courses", b =>
                {
                    b.Navigation("LevelCourse");
                });

            modelBuilder.Entity("UniversityTimeTableModel.Department", b =>
                {
                    b.Navigation("dept_Level");
                });

            modelBuilder.Entity("UniversityTimeTableModel.LevelDepartment", b =>
                {
                    b.Navigation("Available");

                    b.Navigation("LevelCourse");

                    b.Navigation("Used");

                    b.Navigation("delivered");
                });

            modelBuilder.Entity("UniversityTimeTableModel.SLOT", b =>
                {
                    b.Navigation("coursesInSlot");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using CourseService.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220207024704_MakeClearer")]
    partial class MakeClearer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndAtHour")
                        .HasColumnType("int");

                    b.Property<int>("EndAtMinute")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("LearningDays")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("StartAtHour")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("StartAtMinute")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Course");
                });

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.Syllabus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Achievements")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("OnlineCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OnlineCourseId");

                    b.ToTable("Syllabi");
                });

            modelBuilder.Entity("CourseService.Domain.SubjectAggregate.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EducationalGradeId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EducationalLevelId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TutorId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TutorId", "Name", "EducationalLevelId", "EducationalGradeId")
                        .IsUnique()
                        .HasFilter("[EducationalGradeId] IS NOT NULL");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.OneOnOneCourse", b =>
                {
                    b.HasBaseType("CourseService.Domain.CourseAggregate.Course");

                    b.HasDiscriminator().HasValue("OneOnOneCourse");
                });

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.OnlineCourse", b =>
                {
                    b.HasBaseType("CourseService.Domain.CourseAggregate.Course");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("MaxNumberOfStudents")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasDiscriminator().HasValue("OnlineCourse");
                });

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.Course", b =>
                {
                    b.OwnsOne("CourseService.Domain.ValueTypes.Money", "TuitionFee", b1 =>
                        {
                            b1.Property<Guid>("CourseId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(17,2)")
                                .HasColumnName("TuitionFeeAmount");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nchar(3)")
                                .HasColumnName("TuitionFeeUnit")
                                .IsFixedLength(true);

                            b1.HasKey("CourseId");

                            b1.ToTable("Courses");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.Navigation("TuitionFee");
                });

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.Syllabus", b =>
                {
                    b.HasOne("CourseService.Domain.CourseAggregate.OnlineCourse", null)
                        .WithMany("Syllabi")
                        .HasForeignKey("OnlineCourseId");
                });

            modelBuilder.Entity("CourseService.Domain.CourseAggregate.OnlineCourse", b =>
                {
                    b.Navigation("Syllabi");
                });
#pragma warning restore 612, 618
        }
    }
}

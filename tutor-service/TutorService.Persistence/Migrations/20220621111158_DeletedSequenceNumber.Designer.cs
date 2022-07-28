﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorService.Persistence;

namespace TutorService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220621111158_DeletedSequenceNumber")]
    partial class DeletedSequenceNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PlaceOfIssue")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademicRankId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("GraduatedUniversity")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TutorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Rental");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Tutor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Certificate", b =>
                {
                    b.HasOne("TutorService.Domain.TutorAggregate.Tutor", null)
                        .WithMany("Certificates")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Degree", b =>
                {
                    b.HasOne("TutorService.Domain.TutorAggregate.Tutor", null)
                        .WithMany("Degrees")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Rental", b =>
                {
                    b.HasOne("TutorService.Domain.TutorAggregate.Tutor", null)
                        .WithMany("Rentals")
                        .HasForeignKey("TutorId");

                    b.OwnsOne("TutorService.Domain.ValueObjects.Money", "Cost", b1 =>
                        {
                            b1.Property<int>("RentalId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Amount")
                                .HasPrecision(10, 2)
                                .HasColumnType("decimal(10,2)")
                                .HasColumnName("CostAmount");

                            b1.Property<string>("Unit")
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)")
                                .HasColumnName("CostUnit");

                            b1.HasKey("RentalId");

                            b1.ToTable("Rental");

                            b1.WithOwner()
                                .HasForeignKey("RentalId");
                        });

                    b.Navigation("Cost");
                });

            modelBuilder.Entity("TutorService.Domain.TutorAggregate.Tutor", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Degrees");

                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}

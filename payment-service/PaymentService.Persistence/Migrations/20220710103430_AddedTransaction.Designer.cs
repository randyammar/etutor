﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentService.Persistence;

#nullable disable

namespace PaymentService.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220710103430_AddedTransaction")]
    partial class AddedTransaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PaymentService.Domain.MethodAggregate.Method", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Cvc")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Expiry")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPreferred")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Methods", (string)null);
                });

            modelBuilder.Entity("PaymentService.Domain.TransactionAggregate.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("PaymentService.Domain.MethodAggregate.Method", b =>
                {
                    b.OwnsOne("PaymentService.Domain.ValueObjects.Tracking", "Tracking", b1 =>
                        {
                            b1.Property<Guid>("MethodId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("CreatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("CreatedAt");

                            b1.Property<DateTimeOffset?>("UpdatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("UpdateAt");

                            b1.HasKey("MethodId");

                            b1.ToTable("Methods");

                            b1.WithOwner()
                                .HasForeignKey("MethodId");
                        });

                    b.Navigation("Tracking")
                        .IsRequired();
                });

            modelBuilder.Entity("PaymentService.Domain.TransactionAggregate.Transaction", b =>
                {
                    b.OwnsOne("PaymentService.Domain.ValueObjects.Tracking", "Tracking", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("CreatedAt")
                                .HasColumnType("datetimeoffset")
                                .HasColumnName("CreatedAt");

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.OwnsOne("PaymentService.Domain.ValueObjects.Money", "Cost", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(17,2)");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)");

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transactions");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.Navigation("Cost")
                        .IsRequired();

                    b.Navigation("Tracking")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

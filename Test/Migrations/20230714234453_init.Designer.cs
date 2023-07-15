﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test.Database;

#nullable disable

namespace Test.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20230714234453_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Test.Models.Address.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gwenborough",
                            CreatedOn = new DateTime(2023, 7, 14, 23, 44, 52, 808, DateTimeKind.Utc).AddTicks(8697),
                            IsDeleted = false,
                            LocationId = 1,
                            Street = "Kulas Light",
                            Suite = "Apt. 556",
                            ZipCode = "92998-3874"
                        });
                });

            modelBuilder.Entity("Test.Models.Address.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Langitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "user",
                            CreatedOn = new DateTime(2023, 7, 14, 23, 44, 52, 808, DateTimeKind.Utc).AddTicks(8480),
                            IsDeleted = false,
                            Langitude = 81.149600000000007,
                            Latitude = -37.315899999999999
                        });
                });

            modelBuilder.Entity("Test.Models.Event.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZoneInfoId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("events");
                });

            modelBuilder.Entity("Test.Models.Invitaion.Invitaion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResponseStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("invitaions");
                });

            modelBuilder.Entity("Test.Models.User.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bs")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CatchPhrase")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bs = "harness real-time e-markets",
                            CatchPhrase = "Multi-layered client-server neural-net",
                            CreatedBy = "user",
                            CreatedOn = new DateTime(2023, 7, 14, 23, 44, 52, 808, DateTimeKind.Utc).AddTicks(8684),
                            IsDeleted = false,
                            Name = "Romaguera-Crona"
                        });
                });

            modelBuilder.Entity("Test.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CompanyId = 1,
                            CreatedBy = "TestUser",
                            CreatedOn = new DateTime(2023, 7, 14, 23, 44, 52, 808, DateTimeKind.Utc).AddTicks(8921),
                            Email = "Sincere@april.biz",
                            IsDeleted = false,
                            Name = "Leanne Graham",
                            UserName = "Bret",
                            WebSite = "hildegard.org",
                            phone = "1-770-736-8031 x56442"
                        });
                });

            modelBuilder.Entity("Test.Models.Address.Address", b =>
                {
                    b.HasOne("Test.Models.Address.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Test.Models.Event.Event", b =>
                {
                    b.HasOne("Test.Models.Address.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Test.Models.User.User", b =>
                {
                    b.HasOne("Test.Models.Address.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test.Models.User.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}

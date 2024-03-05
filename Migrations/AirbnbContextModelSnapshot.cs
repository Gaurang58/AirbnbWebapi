﻿// <auto-generated />
using Airbnb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Airbnb.Migrations
{
    [DbContext(typeof(AirbnbContext))]
    partial class AirbnbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Airbnb.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Airbnb.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Airbnb.Models.OrderConfirmation", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RentalEndDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RentalStartDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomModelId");

                    b.ToTable("OrderConfirmation");
                });

            modelBuilder.Entity("Airbnb.Models.RoomModel", b =>
                {
                    b.Property<int>("RoomModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvailabilityStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomSize")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoomModelId");

                    b.ToTable("RoomModels");
                });

            modelBuilder.Entity("Airbnb.Models.Tariff", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Discounts")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RentalRatePerDay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PriceId");

                    b.HasIndex("RoomModelId");

                    b.ToTable("Pricings");
                });

            modelBuilder.Entity("Airbnb.Models.OrderConfirmation", b =>
                {
                    b.HasOne("Airbnb.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Airbnb.Models.RoomModel", "RoomModel")
                        .WithMany()
                        .HasForeignKey("RoomModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RoomModel");
                });

            modelBuilder.Entity("Airbnb.Models.Tariff", b =>
                {
                    b.HasOne("Airbnb.Models.RoomModel", "RoomModel")
                        .WithMany("Tariffs")
                        .HasForeignKey("RoomModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomModel");
                });

            modelBuilder.Entity("Airbnb.Models.RoomModel", b =>
                {
                    b.Navigation("Tariffs");
                });
#pragma warning restore 612, 618
        }
    }
}

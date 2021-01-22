﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkFinder.Models;

namespace ParkFinder.Migrations
{
    [DbContext(typeof(ParkFinderContext))]
    partial class ParkFinderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParkFinder.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ParkName")
                        .IsRequired();

                    b.Property<string>("ParkType")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Status");

                    b.Property<string>("Website");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");
                });
#pragma warning restore 612, 618
        }
    }
}

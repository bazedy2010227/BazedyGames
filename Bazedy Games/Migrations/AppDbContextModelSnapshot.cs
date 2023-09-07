﻿// <auto-generated />
using Bazedy_Games.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bazedy_Games.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bazedy_Games.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Strategy"
                        });
                });

            modelBuilder.Entity("Bazedy_Games.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "bi bi-playstation",
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "bi bi-xbox",
                            Name = "Xbox"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "bi bi-laptop",
                            Name = "PC"
                        },
                        new
                        {
                            Id = 4,
                            Icon = "bi bi-nintendo-switch",
                            Name = "Nintendo"
                        });
                });

            modelBuilder.Entity("Bazedy_Games.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Bazedy_Games.Models.GameDevice", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("GameDevices");
                });

            modelBuilder.Entity("Bazedy_Games.Models.Game", b =>
                {
                    b.HasOne("Bazedy_Games.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bazedy_Games.Models.GameDevice", b =>
                {
                    b.HasOne("Bazedy_Games.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bazedy_Games.Models.Game", "Game")
                        .WithMany("GameDevices")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Bazedy_Games.Models.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Bazedy_Games.Models.Game", b =>
                {
                    b.Navigation("GameDevices");
                });
#pragma warning restore 612, 618
        }
    }
}

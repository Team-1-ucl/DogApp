﻿// <auto-generated />
using System;
using DogApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DogApp.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DogApp.Data.EntityModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSign")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Open",
                            Description = "",
                            Image = "/images/hojresving",
                            IsSign = true,
                            Name = "højre sving"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Open",
                            Description = "",
                            Image = "/images/venstresving",
                            IsSign = true,
                            Name = "venstre sving"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Open",
                            Description = "",
                            Image = "/images/hojrerundt",
                            IsSign = true,
                            Name = "højre rundt"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Open",
                            Description = "",
                            Image = "/images/venstrerundt",
                            IsSign = true,
                            Name = "venstre rundt"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Open",
                            Description = "",
                            Image = "/images/diagonalthojre",
                            IsSign = true,
                            Name = "diagonalt højre"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description of Extra 1",
                            Image = "hest",
                            IsSign = false,
                            Name = "Extra 1"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Description of Extra 2",
                            Image = "hest",
                            IsSign = false,
                            Name = "Extra 2"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Description of Extra 3",
                            Image = "hest",
                            IsSign = false,
                            Name = "Extra 3"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Description of Extra 4",
                            Image = "hest",
                            IsSign = false,
                            Name = "Extra 4"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Description of Extra 5",
                            Image = "hest",
                            IsSign = false,
                            Name = "Extra 5"
                        });
                });

            modelBuilder.Entity("DogApp.Data.EntityModels.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = " Champion",
                            Height = 100,
                            Name = "Rallybane 1",
                            Width = 200
                        },
                        new
                        {
                            Id = 2,
                            Category = "Open ",
                            Height = 150,
                            Name = "Rallybane 2",
                            Width = 250
                        },
                        new
                        {
                            Id = 3,
                            Category = "Beginder",
                            Height = 120,
                            Name = "Rallybane 3",
                            Width = 180
                        });
                });

            modelBuilder.Entity("DogApp.Data.EntityModels.TrackItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Itemid")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Trackid")
                        .HasColumnType("int");

                    b.Property<float?>("X")
                        .HasColumnType("real");

                    b.Property<float?>("Y")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Itemid");

                    b.HasIndex("Trackid");

                    b.ToTable("TrackItems");
                });

            modelBuilder.Entity("DogApp.Data.EntityModels.TrackItem", b =>
                {
                    b.HasOne("DogApp.Data.EntityModels.Item", null)
                        .WithMany("TrackItems")
                        .HasForeignKey("Itemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogApp.Data.EntityModels.Track", null)
                        .WithMany("TrackItems")
                        .HasForeignKey("Trackid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogApp.Data.EntityModels.Item", b =>
                {
                    b.Navigation("TrackItems");
                });

            modelBuilder.Entity("DogApp.Data.EntityModels.Track", b =>
                {
                    b.Navigation("TrackItems");
                });
#pragma warning restore 612, 618
        }
    }
}

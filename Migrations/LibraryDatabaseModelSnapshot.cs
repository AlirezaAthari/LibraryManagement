﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wpf_start.Models;

namespace wpf_start.Migrations
{
    [DbContext(typeof(LibraryDatabase))]
    partial class LibraryDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("wpf_start.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Deposited")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Part")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("wpf_start.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("wpf_start.Models.Manager", b =>
                {
                    b.HasBaseType("wpf_start.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("wpf_start.Models.Librarian", b =>
                {
                    b.HasBaseType("wpf_start.Models.Manager");

                    b.Property<int>("LibraryPart")
                        .HasColumnType("int");

                    b.Property<string>("Part")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Librarian");
                });

            modelBuilder.Entity("wpf_start.Models.Member", b =>
                {
                    b.HasBaseType("wpf_start.Models.Manager");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("wpf_start.Models.Book", b =>
                {
                    b.HasOne("wpf_start.Models.Member", null)
                        .WithMany("Books")
                        .HasForeignKey("MemberId");
                });

            modelBuilder.Entity("wpf_start.Models.Member", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
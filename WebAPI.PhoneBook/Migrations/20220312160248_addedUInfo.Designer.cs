﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.PhoneBook.Data;

namespace WebAPI.PhoneBook.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220312160248_addedUInfo")]
    partial class addedUInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.PhoneBook.Data.User", b =>
                {
                    b.Property<int>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UUID = 1,
                            Company = "Amazon",
                            Name = "John",
                            Surname = "Doe"
                        },
                        new
                        {
                            UUID = 2,
                            Company = "Amazon",
                            Name = "Ricky",
                            Surname = "More"
                        });
                });

            modelBuilder.Entity("WebAPI.PhoneBook.Data.UserInformation", b =>
                {
                    b.Property<int>("UInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UUID")
                        .HasColumnType("int");

                    b.HasKey("UInfoID");

                    b.ToTable("UserInformations");

                    b.HasData(
                        new
                        {
                            UInfoID = 1,
                            Location = "TURKEY",
                            Mail = "ck@ck.com",
                            Phone = "777888",
                            UUID = 1
                        },
                        new
                        {
                            UInfoID = 2,
                            Location = "USA",
                            Mail = "ck@ck.com",
                            Phone = "777888",
                            UUID = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
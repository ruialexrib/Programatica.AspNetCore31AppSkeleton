﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programatica.AspNetCore31AppSkeleton.Data.Migrations.Context;

namespace Programatica.AspNetCore31AppSkeleton.Data.Migrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201022205642_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Programatica.AspNetCore31AppSkeleton.Data.Models.Dummy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDestroyedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastDestroyedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Dummies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2020, 10, 22, 20, 56, 40, 945, DateTimeKind.Utc).AddTicks(9011),
                            CreatedUser = "system",
                            Description = "Dummy One",
                            IsDestroyed = false,
                            IsSystem = false,
                            SystemId = new Guid("909725a8-1f9e-414a-b4b9-d0a14361052b")
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2020, 10, 22, 20, 56, 40, 945, DateTimeKind.Utc).AddTicks(9132),
                            CreatedUser = "system",
                            Description = "Dummy Two",
                            IsDestroyed = false,
                            IsSystem = false,
                            SystemId = new Guid("5c09a973-49cd-48e3-aa46-b3076cfcf6b7")
                        });
                });

            modelBuilder.Entity("Programatica.AspNetCore31AppSkeleton.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDestroyedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastDestroyedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2020, 10, 22, 20, 56, 40, 945, DateTimeKind.Utc).AddTicks(5637),
                            CreatedUser = "system",
                            IsDestroyed = false,
                            IsSystem = true,
                            LastModifiedDate = new DateTime(2020, 10, 22, 20, 56, 40, 945, DateTimeKind.Utc).AddTicks(5692),
                            LastModifiedUser = "system",
                            Name = "Administrators",
                            SystemId = new Guid("4114d6e5-8af3-42aa-9c89-2199dcbe213b")
                        });
                });

            modelBuilder.Entity("Programatica.AspNetCore31AppSkeleton.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDestroyedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastDestroyedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2020, 10, 22, 20, 56, 40, 940, DateTimeKind.Utc).AddTicks(9045),
                            CreatedUser = "system",
                            IsDestroyed = false,
                            IsSystem = true,
                            LastModifiedDate = new DateTime(2020, 10, 22, 20, 56, 40, 941, DateTimeKind.Utc).AddTicks(2455),
                            LastModifiedUser = "system",
                            Password = "pass",
                            SystemId = new Guid("fd80bb33-e1a4-4c3d-98c5-37f97dc78bfa"),
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Programatica.AspNetCore31AppSkeleton.Data.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDestroyedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastDestroyedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Programatica.Framework.Data.Models.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentFunction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<Guid>("ContentSystemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDestroyedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastDestroyedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Audit");
                });

            modelBuilder.Entity("Programatica.Framework.Data.Models.TrackChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuditId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDestroyed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystem")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDestroyedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastDestroyedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuditId");

                    b.ToTable("TrackChanges");
                });

            modelBuilder.Entity("Programatica.AspNetCore31AppSkeleton.Data.Models.UserRole", b =>
                {
                    b.HasOne("Programatica.AspNetCore31AppSkeleton.Data.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Programatica.AspNetCore31AppSkeleton.Data.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Programatica.Framework.Data.Models.TrackChange", b =>
                {
                    b.HasOne("Programatica.Framework.Data.Models.Audit", "Audit")
                        .WithMany()
                        .HasForeignKey("AuditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Fundamentos_de_Entity_Framework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fundamentos_de_Entity_Framework.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240208000551_initialData")]
    partial class initialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fundamentos_de_Entity_Framework.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("catagory", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("0350254e-bf94-47ae-af12-66f0c349958a"),
                            Name = "Actividades pendientes",
                            Weight = 20
                        },
                        new
                        {
                            CategoryId = new Guid("edb30390-0964-4d2b-88d3-524798688bc0"),
                            Name = "Actividades personales",
                            Weight = 50
                        },
                        new
                        {
                            CategoryId = new Guid("c23a570b-97aa-414d-8f22-93d4ba804805"),
                            Name = "Actividades deportivas",
                            Weight = 10
                        },
                        new
                        {
                            CategoryId = new Guid("a1c0ea94-091e-48b1-bb43-2a7ef79070ce"),
                            Name = "Actividades familiares",
                            Weight = 10
                        });
                });

            modelBuilder.Entity("Fundamentos_de_Entity_Framework.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoryId");

                    b.ToTable("task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("719166a3-46cc-4fb8-a24b-44d810dd2f13"),
                            CategoryId = new Guid("0350254e-bf94-47ae-af12-66f0c349958a"),
                            CreationDate = new DateTime(2024, 2, 7, 19, 5, 51, 161, DateTimeKind.Local).AddTicks(9688),
                            Priority = 1,
                            Title = "Pago servicios"
                        },
                        new
                        {
                            TaskId = new Guid("76377816-924a-4dd7-9b36-73f2f0152e13"),
                            CategoryId = new Guid("edb30390-0964-4d2b-88d3-524798688bc0"),
                            CreationDate = new DateTime(2024, 2, 7, 19, 5, 51, 161, DateTimeKind.Local).AddTicks(9705),
                            Priority = 0,
                            Title = "Terminar de ver la pelicula de Netflix"
                        },
                        new
                        {
                            TaskId = new Guid("f39d1a18-5851-41cf-94ff-f3219056d971"),
                            CategoryId = new Guid("c23a570b-97aa-414d-8f22-93d4ba804805"),
                            CreationDate = new DateTime(2024, 2, 7, 19, 5, 51, 161, DateTimeKind.Local).AddTicks(9709),
                            Priority = 2,
                            Title = "Partido vs papa Karen"
                        });
                });

            modelBuilder.Entity("Fundamentos_de_Entity_Framework.Models.Task", b =>
                {
                    b.HasOne("Fundamentos_de_Entity_Framework.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Fundamentos_de_Entity_Framework.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenBook.Models;

namespace OpenBook.Migrations.CourseLessons
{
    [DbContext(typeof(CourseLessonsContext))]
    [Migration("20201220202711_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("OpenBook.Models.CourseLessons", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("CourseLessons");
                });
#pragma warning restore 612, 618
        }
    }
}

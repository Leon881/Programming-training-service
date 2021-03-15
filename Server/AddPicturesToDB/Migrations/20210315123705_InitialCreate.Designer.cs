﻿// <auto-generated />
using System;
using AddPicturesToDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddPicturesToDB.Migrations
{
    [DbContext(typeof(TrainingServiceDBContext))]
    [Migration("20210315123705_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddPicturesToDB.Models.LessonPicture", b =>
                {
                    b.Property<int>("lessonId")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<byte[]>("picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("lessonId", "position");

                    b.ToTable("LessonsPictures");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using GolfHandicapCalculator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GolfHandicapCalculator.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GolfHandicapCalculator.Models.GolfCourse", b =>
                {
                    b.Property<int>("GolfCourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Rating");

                    b.Property<int>("Slope");

                    b.HasKey("GolfCourseID");

                    b.ToTable("GolfCourses");
                });

            modelBuilder.Entity("GolfHandicapCalculator.Models.Round", b =>
                {
                    b.Property<int>("RoundID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName");

                    b.Property<int>("HoleScore");

                    b.Property<int>("RoundDifferential");

                    b.HasKey("RoundID");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("GolfHandicapCalculator.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MyProperty");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.Property<string>("UserName");

                    b.Property<string>("email");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

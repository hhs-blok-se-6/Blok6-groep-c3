﻿// <auto-generated />
using System;
using KeukenhofProject.Data;
using KeukenhofV2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeukenhofProject.Migrations
{
    [DbContext(typeof(KeukenhofContext))]
    [Migration("20200120002622_added-auto-increment-to-event-table")]
    partial class addedautoincrementtoeventtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KeukenhofProject.Models.Evenementen", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("description");

                b.Property<DateTime>("endTime");

                b.Property<string>("image");

                b.Property<string>("name");

                b.Property<DateTime>("startTime");

                b.Property<string>("type");

                b.HasKey("Id");

                b.ToTable("Evenementen");
            });

            modelBuilder.Entity("KeukenhofProject.Models.EvenementenContent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Content");

                b.Property<string>("Type");

                b.HasKey("Id");

                b.ToTable("EvenementenContent");
            });

            modelBuilder.Entity("KeukenhofProject.Models.EvenementenPagina", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Content");

                b.Property<string>("Links");

                b.Property<string>("Type");

                b.HasKey("Id");

                b.ToTable("EvenementenPagina");
            });

            modelBuilder.Entity("KeukenhofProject.Models.FAQ", b =>
            {
                b.Property<int>("FAQId")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("antwoord");

                b.Property<string>("vraag");

                b.HasKey("FAQId");

                b.ToTable("FAQ");
            });

            modelBuilder.Entity("KeukenhofProject.Models.HomeContent", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Content");

                b.Property<string>("Type");

                b.HasKey("Id");

                b.ToTable("HomeContent");
            });
#pragma warning restore 612, 618
        }
    }
}

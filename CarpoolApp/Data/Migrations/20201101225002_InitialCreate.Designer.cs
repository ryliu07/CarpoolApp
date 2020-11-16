﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CarpoolApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarpoolApp.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20201101225002_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CarpoolApp.Models.CarPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Departure")
                        .HasColumnType("text");

                    b.Property<string>("Destination")
                        .HasColumnType("text");

                    b.Property<List<string>>("Dropoff")
                        .HasColumnType("text[]");

                    b.Property<int>("Luggage")
                        .HasColumnType("integer");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("Occupancy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeBegin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("CarPost");
                });
#pragma warning restore 612, 618
        }
    }
}

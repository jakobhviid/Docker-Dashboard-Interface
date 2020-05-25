﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocketServer.Data;

namespace SocketServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200525090214_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocketServer.Data.Models.Container", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContainerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("SocketServer.Data.Models.RessourceUsageRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPUPercentageUse")
                        .HasColumnType("int");

                    b.Property<Guid>("ContainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DiskInputBytes")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("DiskOutputBytes")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int>("MemoryPercentageUse")
                        .HasColumnType("int");

                    b.Property<decimal>("NetInputBytes")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("NetOutputBytes")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime>("TimeOfRecordInsertion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("ContainerRessourceUsages");
                });

            modelBuilder.Entity("SocketServer.Data.Models.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Servername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("SocketServer.Data.Models.StatusRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ContainerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfRecordInsertion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContainerId");

                    b.ToTable("ContainerUptimes");
                });

            modelBuilder.Entity("SocketServer.Data.Models.Container", b =>
                {
                    b.HasOne("SocketServer.Data.Models.Server", "Server")
                        .WithMany("Container")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocketServer.Data.Models.RessourceUsageRecord", b =>
                {
                    b.HasOne("SocketServer.Data.Models.Container", "Container")
                        .WithMany("RessourceUsageRecords")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocketServer.Data.Models.StatusRecord", b =>
                {
                    b.HasOne("SocketServer.Data.Models.Container", "Container")
                        .WithMany("StatusRecords")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

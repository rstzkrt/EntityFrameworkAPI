﻿// <auto-generated />
using System;
using CodeFirstEFcoreAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirstEFcoreAPI.Migrations
{
    [DbContext(typeof(MainDatabaseContext))]
    partial class MainDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Car", b =>
                {
                    b.Property<int>("IdCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCar");

                    b.ToTable("cars");

                    b.HasData(
                        new
                        {
                            IdCar = 1,
                            ProductionYear = 11,
                            name = "car"
                        },
                        new
                        {
                            IdCar = 2,
                            ProductionYear = 12,
                            name = "car2"
                        });
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Insception", b =>
                {
                    b.Property<int>("IdInsception")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("IdCar")
                        .HasColumnType("int");

                    b.Property<int>("IdMechanic")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsceptionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdInsception");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdMechanic");

                    b.ToTable("insceptions");

                    b.HasData(
                        new
                        {
                            IdInsception = 1,
                            Comment = "comment1",
                            IdCar = 1,
                            IdMechanic = 1,
                            InsceptionDate = new DateTime(2021, 6, 22, 23, 17, 6, 718, DateTimeKind.Local).AddTicks(9786)
                        },
                        new
                        {
                            IdInsception = 2,
                            Comment = "comment2",
                            IdCar = 2,
                            IdMechanic = 2,
                            InsceptionDate = new DateTime(2021, 6, 22, 23, 17, 6, 721, DateTimeKind.Local).AddTicks(1951)
                        });
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Mechanic", b =>
                {
                    b.Property<int>("IdMechanic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdMechanic");

                    b.ToTable("mechanics");

                    b.HasData(
                        new
                        {
                            IdMechanic = 1,
                            FirstName = "Name1",
                            LastName = "LastName1"
                        },
                        new
                        {
                            IdMechanic = 2,
                            FirstName = "Name2",
                            LastName = "LastName2"
                        });
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.ServiceTypeDict", b =>
                {
                    b.Property<int>("IdServiceType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdServiceType");

                    b.ToTable("serviceTypeDicts");

                    b.HasData(
                        new
                        {
                            IdServiceType = 1,
                            Price = 11f,
                            ServiceType = "servicetype1"
                        },
                        new
                        {
                            IdServiceType = 2,
                            Price = 22f,
                            ServiceType = "servicetype2"
                        });
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.ServiceTypeDictInsception", b =>
                {
                    b.Property<int>("IdInsception")
                        .HasColumnType("int");

                    b.Property<int>("IdServiceType")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("IdInsception", "IdServiceType");

                    b.HasIndex("IdServiceType");

                    b.ToTable("serviceTypeDictInsceptions");

                    b.HasData(
                        new
                        {
                            IdInsception = 1,
                            IdServiceType = 1,
                            Comments = "Description1"
                        },
                        new
                        {
                            IdInsception = 2,
                            IdServiceType = 2,
                            Comments = "Description2"
                        });
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Insception", b =>
                {
                    b.HasOne("CodeFirstEFcoreAPI.models.Car", "IdCarNavigation")
                        .WithMany("CarInsceptons")
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstEFcoreAPI.models.Mechanic", "IdMechanicNavigation")
                        .WithMany("MechanicInsceptions")
                        .HasForeignKey("IdMechanic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCarNavigation");

                    b.Navigation("IdMechanicNavigation");
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.ServiceTypeDictInsception", b =>
                {
                    b.HasOne("CodeFirstEFcoreAPI.models.Insception", "IdInsceptionNavigation")
                        .WithMany("ServiceTypeDictInsceptions_Insceptions")
                        .HasForeignKey("IdInsception")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstEFcoreAPI.models.ServiceTypeDict", "IdServiceTypeNavigation")
                        .WithMany("ServiceTypeDictInsceptions_ServiceTypeDict")
                        .HasForeignKey("IdServiceType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdInsceptionNavigation");

                    b.Navigation("IdServiceTypeNavigation");
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Car", b =>
                {
                    b.Navigation("CarInsceptons");
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Insception", b =>
                {
                    b.Navigation("ServiceTypeDictInsceptions_Insceptions");
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.Mechanic", b =>
                {
                    b.Navigation("MechanicInsceptions");
                });

            modelBuilder.Entity("CodeFirstEFcoreAPI.models.ServiceTypeDict", b =>
                {
                    b.Navigation("ServiceTypeDictInsceptions_ServiceTypeDict");
                });
#pragma warning restore 612, 618
        }
    }
}

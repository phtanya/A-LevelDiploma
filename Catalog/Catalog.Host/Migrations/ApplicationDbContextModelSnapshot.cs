﻿// <auto-generated />
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalog.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("pets_food_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("pets_food_type_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("Catalog.Host.Data.Entities.PetsFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "pets_food_hilo");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PetsFoodBrandId")
                        .HasColumnType("integer");

                    b.Property<int>("PetsFoodTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PetsFoodBrandId");

                    b.HasIndex("PetsFoodTypeId");

                    b.ToTable("PetsFood", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.PetsFoodBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "pets_food_hilo");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("PetsFoodBrand", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.PetsFoodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "pets_food_type_hilo");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("PetsFoodType", (string)null);
                });

            modelBuilder.Entity("Catalog.Host.Data.Entities.PetsFood", b =>
                {
                    b.HasOne("Catalog.Host.Data.Entities.PetsFoodBrand", "PetsFoodBrand")
                        .WithMany()
                        .HasForeignKey("PetsFoodBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Host.Data.Entities.PetsFoodType", "PetsFoodType")
                        .WithMany()
                        .HasForeignKey("PetsFoodTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetsFoodBrand");

                    b.Navigation("PetsFoodType");
                });
#pragma warning restore 612, 618
        }
    }
}

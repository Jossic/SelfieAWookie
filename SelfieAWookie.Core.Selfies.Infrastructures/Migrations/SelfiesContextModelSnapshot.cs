﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

#nullable disable

namespace SelfieAWookie.Core.Selfies.Infrastructures.Migrations
{
    [DbContext(typeof(SelfiesContext))]
    partial class SelfiesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Selfie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PictureId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WookieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("WookieId");

                    b.ToTable("Selfie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Wookie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Selfie", b =>
                {
                    b.HasOne("SelfieAWookie.Core.Selfies.Domain.Picture", "Picture")
                        .WithMany("Selfies")
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SelfieAWookie.Core.Selfies.Domain.Wookie", "Wookie")
                        .WithMany("Selfies")
                        .HasForeignKey("WookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picture");

                    b.Navigation("Wookie");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Picture", b =>
                {
                    b.Navigation("Selfies");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Navigation("Selfies");
                });
#pragma warning restore 612, 618
        }
    }
}

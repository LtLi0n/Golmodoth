﻿// <auto-generated />
using System;
using Golmodoth.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Golmodoth.Api.Migrations
{
    [DbContext(typeof(GolmodothContext))]
    partial class GolmodothContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Golmodoth.Shared.Character", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ulong>("Gold");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.Property<ulong>("Silver");

                    b.Property<string>("TotalXp");

                    b.Property<uint>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("Golmodoth.Shared.User", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(64)");

                    b.Property<byte[]>("Passsword_Salt");

                    b.Property<byte[]>("Password_Hash");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Golmodoth.Shared.Character", b =>
                {
                    b.HasOne("Golmodoth.Shared.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

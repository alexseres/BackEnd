﻿// <auto-generated />
using System;
using HearthStone_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HearthStone_Backend.Migrations
{
    [DbContext(typeof(CardDBContext))]
    [Migration("20201102171512_UserNameColumn")]
    partial class UserNameColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HearthStone_Backend.Models.Card", b =>
                {
                    b.Property<string>("CardId")
                        .HasColumnType("text");

                    b.Property<string>("Artist")
                        .HasColumnType("text");

                    b.Property<string>("Attack")
                        .HasColumnType("text");

                    b.Property<string>("CardSet")
                        .HasColumnType("text");

                    b.Property<bool>("Collectable")
                        .HasColumnType("boolean");

                    b.Property<string>("Cost")
                        .HasColumnType("text");

                    b.Property<bool>("Elite")
                        .HasColumnType("boolean");

                    b.Property<string>("Faction")
                        .HasColumnType("text");

                    b.Property<string>("Flavor")
                        .HasColumnType("text");

                    b.Property<string>("Health")
                        .HasColumnType("text");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Race")
                        .HasColumnType("text");

                    b.Property<string>("Rarity")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("img")
                        .HasColumnType("text");

                    b.Property<string>("imgGold")
                        .HasColumnType("text");

                    b.HasKey("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("HearthStone_Backend.Models.CardBack", b =>
                {
                    b.Property<string>("CardBackId")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("Enabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<string>("ImgAnimated")
                        .HasColumnType("text");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SortCategory")
                        .HasColumnType("text");

                    b.Property<string>("SortOrder")
                        .HasColumnType("text");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.HasKey("CardBackId");

                    b.ToTable("CardBacks");
                });

            modelBuilder.Entity("HearthStone_Backend.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

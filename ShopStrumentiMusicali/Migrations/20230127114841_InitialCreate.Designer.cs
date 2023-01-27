﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopStrumentiMusicali.Database;

#nullable disable

namespace ShopStrumentiMusicali.Migrations
{
    [DbContext(typeof(ParamusicContext))]
    [Migration("20230127114841_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopStrumentiMusicali.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.Instrument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.ShopTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstrumentID")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<int>("TransactionFee")
                        .HasColumnType("int");

                    b.Property<short>("TransactionQuantity")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentID");

                    b.ToTable("ShopTransactions");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.UserTransaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("InstrumentID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TransactionDate")
                        .HasColumnType("date");

                    b.Property<short>("TransactionQuantity")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("InstrumentID");

                    b.ToTable("UserTransactions");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.Instrument", b =>
                {
                    b.HasOne("ShopStrumentiMusicali.Models.Category", "Category")
                        .WithMany("Instruments")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.ShopTransaction", b =>
                {
                    b.HasOne("ShopStrumentiMusicali.Models.Instrument", "Instrument")
                        .WithMany("ShopTransactions")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.UserTransaction", b =>
                {
                    b.HasOne("ShopStrumentiMusicali.Models.Instrument", "Instrument")
                        .WithMany("UserTransactions")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.Category", b =>
                {
                    b.Navigation("Instruments");
                });

            modelBuilder.Entity("ShopStrumentiMusicali.Models.Instrument", b =>
                {
                    b.Navigation("ShopTransactions");

                    b.Navigation("UserTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}

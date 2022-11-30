﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcMovie.Data;

#nullable disable

namespace BTLNhom3.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    [Migration("20221129111941_Create_Table_Qlidonhang")]
    partial class CreateTableQlidonhang
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BTLNhom3.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Makhachhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassWord")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Makhachhang");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("BTLNhom3.Models.Quanlydonhang", b =>
                {
                    b.Property<string>("Madonhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Makhachhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Masanpham")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ngaylamnv")
                        .HasColumnType("TEXT");

                    b.HasKey("Madonhang");

                    b.HasIndex("Makhachhang");

                    b.HasIndex("Masanpham");

                    b.ToTable("Quanlydonhang");
                });

            modelBuilder.Entity("BTLNhom3.Models.Quanlykhachhang", b =>
                {
                    b.Property<string>("Makhachhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sodienthoai")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tenkhachhang")
                        .HasColumnType("TEXT");

                    b.HasKey("Makhachhang");

                    b.ToTable("Quanlykhachhang");
                });

            modelBuilder.Entity("BTLNhom3.Models.Quanlyncc", b =>
                {
                    b.Property<string>("Masanncc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Masanpham")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tenncc")
                        .HasColumnType("TEXT");

                    b.Property<string>("diachi")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<int>("sodienthoai")
                        .HasColumnType("INTEGER");

                    b.HasKey("Masanncc");

                    b.HasIndex("Masanpham");

                    b.ToTable("Quanlyncc");
                });

            modelBuilder.Entity("BTLNhom3.Models.Quanlysanpham", b =>
                {
                    b.Property<string>("Masanpham")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tensanpham")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("giatien")
                        .HasColumnType("TEXT");

                    b.Property<string>("mausac")
                        .HasColumnType("TEXT");

                    b.Property<int>("size")
                        .HasColumnType("INTEGER");

                    b.Property<int>("soluong")
                        .HasColumnType("INTEGER");

                    b.HasKey("Masanpham");

                    b.ToTable("Quanlysanpham");
                });

            modelBuilder.Entity("BTLNhom3.Models.Admin", b =>
                {
                    b.HasOne("BTLNhom3.Models.Quanlykhachhang", "Quanlykhachhang")
                        .WithMany()
                        .HasForeignKey("Makhachhang");

                    b.Navigation("Quanlykhachhang");
                });

            modelBuilder.Entity("BTLNhom3.Models.Quanlydonhang", b =>
                {
                    b.HasOne("BTLNhom3.Models.Quanlykhachhang", "Quanlykhachhang")
                        .WithMany()
                        .HasForeignKey("Makhachhang");

                    b.HasOne("BTLNhom3.Models.Quanlysanpham", "Quanlysanpham")
                        .WithMany()
                        .HasForeignKey("Masanpham");

                    b.Navigation("Quanlykhachhang");

                    b.Navigation("Quanlysanpham");
                });

            modelBuilder.Entity("BTLNhom3.Models.Quanlyncc", b =>
                {
                    b.HasOne("BTLNhom3.Models.Quanlysanpham", "Quanlysanpham")
                        .WithMany()
                        .HasForeignKey("Masanpham");

                    b.Navigation("Quanlysanpham");
                });
#pragma warning restore 612, 618
        }
    }
}

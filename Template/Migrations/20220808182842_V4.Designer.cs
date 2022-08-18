﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Template.Migrations
{
    [DbContext(typeof(IspitDbContext))]
    [Migration("20220808182842_V4")]
    partial class V4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Template.Models.Brend", b =>
                {
                    b.Property<int>("BrendID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrendID");

                    b.ToTable("Brend");
                });

            modelBuilder.Entity("Template.Models.Komponenta", b =>
                {
                    b.Property<int>("KomponentaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrendID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipID")
                        .HasColumnType("int");

                    b.HasKey("KomponentaID");

                    b.HasIndex("BrendID");

                    b.HasIndex("TipID");

                    b.ToTable("Komponenta");
                });

            modelBuilder.Entity("Template.Models.Prodavnica", b =>
                {
                    b.Property<int>("ProdavnicaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdavnicaID");

                    b.ToTable("Prodavnica");
                });

            modelBuilder.Entity("Template.Models.Spoj", b =>
                {
                    b.Property<int>("SpojID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int?>("KomponentaID")
                        .HasColumnType("int");

                    b.Property<int?>("ProdavnicaID")
                        .HasColumnType("int");

                    b.Property<int>("Sifra")
                        .HasColumnType("int");

                    b.HasKey("SpojID");

                    b.HasIndex("KomponentaID");

                    b.HasIndex("ProdavnicaID");

                    b.ToTable("Spoj");
                });

            modelBuilder.Entity("Template.Models.Tip", b =>
                {
                    b.Property<int>("TipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("Template.Models.Komponenta", b =>
                {
                    b.HasOne("Template.Models.Brend", "Brend")
                        .WithMany("BrendKomponenta")
                        .HasForeignKey("BrendID");

                    b.HasOne("Template.Models.Tip", "Tip")
                        .WithMany("TipKomponenta")
                        .HasForeignKey("TipID");

                    b.Navigation("Brend");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("Template.Models.Spoj", b =>
                {
                    b.HasOne("Template.Models.Komponenta", "Komponenta")
                        .WithMany("KomponentaProdavnica")
                        .HasForeignKey("KomponentaID");

                    b.HasOne("Template.Models.Prodavnica", "Prodavnica")
                        .WithMany("ProdavnicaKomponenta")
                        .HasForeignKey("ProdavnicaID");

                    b.Navigation("Komponenta");

                    b.Navigation("Prodavnica");
                });

            modelBuilder.Entity("Template.Models.Brend", b =>
                {
                    b.Navigation("BrendKomponenta");
                });

            modelBuilder.Entity("Template.Models.Komponenta", b =>
                {
                    b.Navigation("KomponentaProdavnica");
                });

            modelBuilder.Entity("Template.Models.Prodavnica", b =>
                {
                    b.Navigation("ProdavnicaKomponenta");
                });

            modelBuilder.Entity("Template.Models.Tip", b =>
                {
                    b.Navigation("TipKomponenta");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial2_PA2.Data;

namespace Parcial2_PA2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200312000617_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Parcial2_PA2.Models.LlamadaDetalles", b =>
                {
                    b.Property<int>("LlamadaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LlamadaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Problemas")
                        .HasColumnType("TEXT");

                    b.Property<string>("Solucion")
                        .HasColumnType("TEXT");

                    b.HasKey("LlamadaDetalleId");

                    b.HasIndex("LlamadaId");

                    b.ToTable("LlamadaDetalles");
                });

            modelBuilder.Entity("Parcial2_PA2.Models.Llamadas", b =>
                {
                    b.Property<int>("LlamadaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LlamadaId");

                    b.ToTable("Llamadas");
                });

            modelBuilder.Entity("Parcial2_PA2.Models.LlamadaDetalles", b =>
                {
                    b.HasOne("Parcial2_PA2.Models.Llamadas", null)
                        .WithMany("Detalles")
                        .HasForeignKey("LlamadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
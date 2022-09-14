﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace finalproject.Migrations
{
    [DbContext(typeof(PersonajesContext))]
    [Migration("20220820191830_M4")]
    partial class M4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Condicion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Altura")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FraseFav")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Poder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pronunciacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vestimenta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personajes");
                });

            modelBuilder.Entity("Proceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstadoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonajeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeriesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("GenderId");

                    b.HasIndex("PersonajeId");

                    b.HasIndex("SeriesId");

                    b.ToTable("Proceso");
                });

            modelBuilder.Entity("Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Signos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SignoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SignoId");

                    b.ToTable("Signos");
                });

            modelBuilder.Entity("Proceso", b =>
                {
                    b.HasOne("Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Personaje", "Personaje")
                        .WithMany()
                        .HasForeignKey("PersonajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Serie", "Series")
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Gender");

                    b.Navigation("Personaje");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("Signos", b =>
                {
                    b.HasOne("Personaje", "Signo")
                        .WithMany()
                        .HasForeignKey("SignoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Signo");
                });
#pragma warning restore 612, 618
        }
    }
}
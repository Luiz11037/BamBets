﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apiBambets.Context;

#nullable disable

namespace Bambets.Migrations
{
    [DbContext(typeof(apiBambetsContext))]
    [Migration("20231226122539_identity-jwt_new")]
    partial class identityjwt_new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("apiBambets.Model.Aposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Time_apostado")
                        .HasColumnType("text");

                    b.Property<int>("Valor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Apostas");
                });

            modelBuilder.Entity("apiBambets.Model.Apostador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("JogoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<int>("Palpite")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("JogoId");

                    b.ToTable("Apostadores");
                });

            modelBuilder.Entity("apiBambets.Model.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Time1")
                        .HasColumnType("text");

                    b.Property<string>("Time2")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("apiBambets.Model.Apostador", b =>
                {
                    b.HasOne("apiBambets.Model.Jogo", null)
                        .WithMany("apostadores_jogo")
                        .HasForeignKey("JogoId");
                });

            modelBuilder.Entity("apiBambets.Model.Jogo", b =>
                {
                    b.Navigation("apostadores_jogo");
                });
#pragma warning restore 612, 618
        }
    }
}

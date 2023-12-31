﻿// <auto-generated />
using System;
using CardapioMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CardapioMVC.Migrations
{
    [DbContext(typeof(ApplicationDBContenx))]
    [Migration("20230630143644_atulizarmodel")]
    partial class atulizarmodel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CardapioMVC.Models.ItemPratoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("PratoId")
                        .HasColumnType("int");

                    b.Property<string>("ProdutoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<double>("QuantidadeGramas")
                        .HasColumnType("float");

                    b.HasKey("ProdutoId", "PratoId");

                    b.HasIndex("PratoId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CardapioMVC.Models.Prato_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CustoTotal")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PorcentagemLucro")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("CardapioMVC.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kilos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Prato_ModelId")
                        .HasColumnType("int");

                    b.Property<double?>("Valor")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Prato_ModelId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CardapioMVC.Models.ItemPratoModel", b =>
                {
                    b.HasOne("CardapioMVC.Models.Prato_Model", "Prato")
                        .WithMany("Itens")
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prato");
                });

            modelBuilder.Entity("CardapioMVC.Models.ProdutoModel", b =>
                {
                    b.HasOne("CardapioMVC.Models.Prato_Model", null)
                        .WithMany("Produtos")
                        .HasForeignKey("Prato_ModelId");
                });

            modelBuilder.Entity("CardapioMVC.Models.Prato_Model", b =>
                {
                    b.Navigation("Itens");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}

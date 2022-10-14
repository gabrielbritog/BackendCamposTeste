﻿// <auto-generated />
using System;
using CamposTeste.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CamposTeste.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221014143912_geral")]
    partial class geral
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CamposTeste.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NmCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CamposTeste.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DscProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("VlrUnitario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CamposTeste.Entities.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DthVend")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("QtdVenda")
                        .HasColumnType("int");

                    b.Property<float>("VlrTotalVenda")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}

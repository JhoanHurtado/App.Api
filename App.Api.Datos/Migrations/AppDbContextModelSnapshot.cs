﻿// <auto-generated />
using System;
using App.Api.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Api.Datos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Api.Model.Models.Cliente", b =>
                {
                    b.Property<string>("Identificador")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Identificador");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("App.Api.Model.Models.DetalleFactura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cantidad")
                        .HasColumnType("real");

                    b.Property<int?>("FacturaId")
                        .HasColumnType("int");

                    b.Property<string>("IdCliente")
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("IdFactura")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoId")
                        .HasColumnType("int");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FacturaId");

                    b.HasIndex("IdCliente");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleFacturas");
                });

            modelBuilder.Entity("App.Api.Model.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentificadorCliente")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdentificadorCliente");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("App.Api.Model.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("App.Api.Model.Models.DetalleFactura", b =>
                {
                    b.HasOne("App.Api.Model.Models.Factura", "Factura")
                        .WithMany("DetalleFacturas")
                        .HasForeignKey("FacturaId");

                    b.HasOne("App.Api.Model.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente");

                    b.HasOne("App.Api.Model.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");

                    b.Navigation("Cliente");

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("App.Api.Model.Models.Factura", b =>
                {
                    b.HasOne("App.Api.Model.Models.Cliente", "Cliente")
                        .WithMany("Facturas")
                        .HasForeignKey("IdentificadorCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("App.Api.Model.Models.Cliente", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("App.Api.Model.Models.Factura", b =>
                {
                    b.Navigation("DetalleFacturas");
                });
#pragma warning restore 612, 618
        }
    }
}

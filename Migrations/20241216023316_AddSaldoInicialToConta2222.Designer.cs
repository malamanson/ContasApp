﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContasApp.Migrations
{
    [DbContext(typeof(FinancasContext))]
    [Migration("20241216023316_AddSaldoInicialToConta2222")]
    partial class AddSaldoInicialToConta2222
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("Ganho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ContaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.ToTable("Ganhos");
                });

            modelBuilder.Entity("Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContaId")
                        .HasColumnType("int");

                    b.Property<int?>("ContaId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsEntrada")
                        .HasColumnType("bit");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("ContaId1");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("Ganho", b =>
                {
                    b.HasOne("Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId");

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Transacao", b =>
                {
                    b.HasOne("Conta", null)
                        .WithMany("Transacoes")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId1");

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Conta", b =>
                {
                    b.Navigation("Transacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

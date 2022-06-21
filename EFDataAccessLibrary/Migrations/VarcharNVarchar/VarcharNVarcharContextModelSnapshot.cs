﻿// <auto-generated />
using System;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDataAccessLibrary.Migrations.VarcharNVarchar
{
    [DbContext(typeof(VarcharNVarcharContext))]
    partial class VarcharNVarcharContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFDataAccessLibrary.Models.VarCharNVarChar.NVarcharName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DateTime2(0)");

                    b.Property<string>("FName")
                        .HasColumnType("Nvarchar(50)");

                    b.Property<string>("LName")
                        .HasColumnType("Nvarchar(50)");

                    b.Property<string>("MName")
                        .HasColumnType("Nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_NVarcharId");

                    b.ToTable("NVarcharName");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.VarCharNVarChar.VarcharName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("DateTime2(0)");

                    b.Property<string>("FName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_VarcharId");

                    b.ToTable("VarcharName");
                });
#pragma warning restore 612, 618
        }
    }
}

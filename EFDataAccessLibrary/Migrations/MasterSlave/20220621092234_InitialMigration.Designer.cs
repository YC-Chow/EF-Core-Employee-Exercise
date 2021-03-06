// <auto-generated />
using System;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFDataAccessLibrary.Migrations.MasterSlave
{
    [DbContext(typeof(MasterSlaveContext))]
    [Migration("20220621092234_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFDataAccessLibrary.Models.MasterSlave.Master", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getDate()");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK_MasterId");

                    b.ToTable("Master");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.MasterSlave.Slave", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("MasterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_SlaveId");

                    b.HasIndex("MasterId");

                    b.ToTable("Slave");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.MasterSlave.Slave", b =>
                {
                    b.HasOne("EFDataAccessLibrary.Models.MasterSlave.Master", "Master")
                        .WithMany("SlaveList")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");
                });

            modelBuilder.Entity("EFDataAccessLibrary.Models.MasterSlave.Master", b =>
                {
                    b.Navigation("SlaveList");
                });
#pragma warning restore 612, 618
        }
    }
}

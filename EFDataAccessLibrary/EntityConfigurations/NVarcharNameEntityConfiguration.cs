using EFDataAccessLibrary.Models.VarCharNVarChar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class NVarcharNameEntityConfiguration : IEntityTypeConfiguration<NVarcharName> {
        public void Configure(EntityTypeBuilder<NVarcharName> builder) {

            builder
                .HasKey(a => a.Id)
                .HasName("PK_NVarcharId");

            builder
                .Property(a => a.Id)
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();

            builder
                .Property(a => a.FName)
                .HasColumnType("Nvarchar(50)");

            builder
               .Property(a => a.MName)
               .HasColumnType("Nvarchar(50)");

            builder
               .Property(a => a.LName)
               .HasColumnType("Nvarchar(50)");

            builder
                .Property(a => a.CreatedDate)
                .HasColumnType("DateTime2(0)");
        }
    }
}

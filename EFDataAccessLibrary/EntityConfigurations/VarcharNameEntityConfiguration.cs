using EFDataAccessLibrary.Models.VarCharNVarChar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class VarcharNameEntityConfiguration : IEntityTypeConfiguration<VarcharName> {
        public void Configure(EntityTypeBuilder<VarcharName> builder) {

            builder
                .HasKey(a => a.Id)
                .HasName("PK_VarcharId");

            builder
                .Property(a => a.Id)
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();

            builder
                .Property(a => a.FName)
                .HasColumnType("varchar(50)");

            builder
               .Property(a => a.MName)
               .HasColumnType("varchar(50)");

            builder
               .Property(a => a.LName)
               .HasColumnType("varchar(50)");

            builder
                .Property(a => a.CreatedDate)
                .HasColumnType("DateTime2(0)");
        }
    }
}

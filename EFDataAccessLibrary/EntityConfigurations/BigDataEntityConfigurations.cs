using EFDataAccessLibrary.Models.BigData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class BigDataEntityConfigurations : IEntityTypeConfiguration<BigData> {
        public void Configure(EntityTypeBuilder<BigData> builder) {
            
            builder.Property(p => p.RandomString)
                .HasColumnType("VarChar(max)");

            builder.Property(p => p.RandomString2)
                .HasColumnType("VarChar(max)");

            builder.Property(p => p.RandomInt)
                .HasColumnType("int");

            builder.Property(p => p.RandomInt2)
                .HasColumnType("int");

            builder.Property(p => p.RandomDecimal)
                .HasColumnType("Decimal(38,19)");

            builder.Property(p => p.RandomDecimal2)
                .HasColumnType("Decimal(38,19)");
        }
    }
}

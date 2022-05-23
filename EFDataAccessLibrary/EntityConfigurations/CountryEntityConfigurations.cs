using EFDataAccessLibrary.Models.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class CountryEntityConfigurations : IEntityTypeConfiguration<Country> {
        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.Property(p => p.CountryCode)
                .HasColumnType("VarChar(4)");

            builder.Property(p => p.CountryName)
                .HasColumnType("VarChar(200)")
                .IsRequired();

            builder.Property(p => p.Population)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}

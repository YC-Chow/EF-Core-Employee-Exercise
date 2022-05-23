using EFDataAccessLibrary.Models.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class CitizenEntityConfigurations : IEntityTypeConfiguration<Citizen> {
        public void Configure(EntityTypeBuilder<Citizen> builder) {
            builder.Property(p => p.FName)
                .HasColumnType("VarChar(100)")
                .IsRequired();

            builder.Property(p => p.MName)
                .HasColumnType("VarChar(100)")
                .IsRequired();

            builder.Property(p => p.LName)
                .HasColumnType("VarChar(100)")
                .IsRequired();

            builder.Property(p => p.CountryCode)
                .HasColumnType("VarChar(4)")
                .IsRequired();


        }
    }
}

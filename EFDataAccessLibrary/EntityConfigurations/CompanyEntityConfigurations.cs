using EFDataAccessLibrary.Models.CompanyFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class CompanyEntityConfigurations : IEntityTypeConfiguration<Company> {
        public void Configure(EntityTypeBuilder<Company> builder) {
            builder.Property(p => p.CompanyAddress)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.CompanyName)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.CompanyZipCode)
                .HasColumnType("int");

            builder.Property(p => p.NumberOfEmployees)
                .HasColumnType("int");
        }
    }
}

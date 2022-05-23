using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class EmployeeAddressEntityConfigurations : IEntityTypeConfiguration<EmployeeAddress> {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder) {
            builder.Property(p => p.Address1)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.Address2)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Address3)
                .HasColumnType("varchar(200)");

            builder.Property(p => p.ZipCode)
                .HasColumnType("int");

        }
    }
}

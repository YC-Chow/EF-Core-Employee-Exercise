using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class EmployeeAddressNoIndexEntityConfigurations : IEntityTypeConfiguration<EmployeeAddressNoIndex> {
        public void Configure(EntityTypeBuilder<EmployeeAddressNoIndex> builder) {
            builder
                .HasKey(p => p.Id);

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

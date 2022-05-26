using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class EmployeeEntityConfigurations : IEntityTypeConfiguration<Employee> {
        public void Configure(EntityTypeBuilder<Employee> builder) {
            builder.Property(p => p.FName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.MName)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.LName)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}

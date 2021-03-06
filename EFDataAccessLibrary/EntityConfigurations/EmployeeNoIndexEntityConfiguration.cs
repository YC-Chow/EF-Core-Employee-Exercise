using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class EmployeeNoIndexEntityConfiguration : IEntityTypeConfiguration<EmployeeNoIndex> {
        public void Configure(EntityTypeBuilder<EmployeeNoIndex> builder) {
            builder
                .HasKey(p => p.Id)
                .IsClustered(true);

            builder
                .HasMany<EmployeeAddressNoIndex>(p => p.Addresses)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);

            builder.Property(p => p.FName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.MName)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.LName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .HasColumnType("DateTime2")
                .HasDefaultValueSql("getdate()");
        }
    }
}

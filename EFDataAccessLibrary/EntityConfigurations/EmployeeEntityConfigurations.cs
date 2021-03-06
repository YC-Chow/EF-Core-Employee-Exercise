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
            builder
                .HasKey(p => p.Id)
                .HasName("PK_EmployeeId")
                .IsClustered(true);

            builder
                .HasMany<EmployeeAddress>(p => p.Addresses)
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

            builder.HasIndex(p => p.CreatedDate).HasDatabaseName("IX_CreatedDate");
            builder.HasIndex(p => p.FName).IsClustered(false).HasDatabaseName("IX_FName");

        }
    }
}

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
                .HasIndex(emp => emp.Id)
                .HasDatabaseName("PK_EmployeeId")
                .HasFillFactor(85)
                .IsClustered(true);

            builder.Property(p => p.FName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.MName)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.LName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .HasIndex(emp => emp.Id)
                .HasDatabaseName("IX_Id_FName_LName")
                .HasFillFactor(85)
                .IsClustered(false)
                .IncludeProperties(emp => emp.FName)
                .IncludeProperties(emp => emp.LName);


        }
    }
}

using EFDataAccessLibrary.Models.MasterSlave;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.EntityConfigurations {
    public class SlaveEntityConfiguration : IEntityTypeConfiguration<Slave> {
        public void Configure(EntityTypeBuilder<Slave> builder) {
            builder.HasKey(p => p.Id).HasName("PK_SlaveId");
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier").HasDefaultValueSql("newID()");
            builder.Property(p => p.FirstName).HasColumnType("nvarchar(20)");
            builder.Property(p => p.CreatedDate).HasColumnType("datetime2").HasDefaultValueSql("getdate()");
        }
    }
}

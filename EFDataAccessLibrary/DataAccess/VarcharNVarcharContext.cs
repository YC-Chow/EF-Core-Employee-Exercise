using EFDataAccessLibrary.EntityConfigurations;
using EFDataAccessLibrary.Models.VarCharNVarChar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess {
    public class VarcharNVarcharContext : DbContext {
        public DbSet<VarcharName> VarcharName { get; set; }
        public DbSet<NVarcharName> NVarcharName { get; set; }

        public VarcharNVarcharContext (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new VarcharNameEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NVarcharNameEntityConfiguration());
        }


    }
}

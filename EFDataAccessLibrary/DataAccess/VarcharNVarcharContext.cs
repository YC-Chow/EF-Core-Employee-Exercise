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

        public VarcharNVarcharContext() { }

        public VarcharNVarcharContext (DbContextOptions<VarcharNVarcharContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
            "Data Source=localhost,1433;Initial Catalog = EmployeeTest ;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new VarcharNameEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NVarcharNameEntityConfiguration());
        }


    }
}

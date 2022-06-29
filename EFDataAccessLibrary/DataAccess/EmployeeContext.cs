using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.Models.EmployeeFolder;
using EFDataAccessLibrary.EntityConfigurations;
using EFDataAccessLibrary.Models.CompanyFolder;

namespace EFDataAccessLibrary.DataAccess {
    public class EmployeeContext : DbContext {
        public EmployeeContext() { }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) {}
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }

        public DbSet<EmployeeNoIndex> EmployeeNoIndex { get; set; }

        public DbSet<EmployeeAddressNoIndex> EmployeeAddressNoINdex { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
            "Data Source=localhost,1433;Initial Catalog = EmployeeTest ;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeAddressEntityConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeAddressNoIndexEntityConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeNoIndexEntityConfiguration());

        }
    }
}

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
        public EmployeeContext(DbContextOptions options) : base(options) {}
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
            "Data Source=localhost,1433;Initial Catalog = EmployeeTest ;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeAddressEntityConfigurations());
            modelBuilder.ApplyConfiguration(new CompanyEntityConfigurations());

            modelBuilder.Entity<Employee>()
                .HasKey(p => p.Id)
                .HasName("PK_EmployeeId");

            modelBuilder.Entity<EmployeeAddress>()
                .HasKey(p => p.Id)
                .HasName("PK_AddressId");

            modelBuilder.Entity<Company>()
                .HasKey(Company => Company.Id)
                .HasName("PK_CompanyId");

            modelBuilder.Entity<Employee>()
                .HasMany<EmployeeAddress>(p => p.Addresses)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);

        }
    }
}

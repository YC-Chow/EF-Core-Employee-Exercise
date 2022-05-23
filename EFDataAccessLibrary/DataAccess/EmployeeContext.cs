using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.EntityConfigurations;

namespace EFDataAccessLibrary.DataAccess {
    public /*class*/ interface IEmployeeContext /*: DbContext*/ {
        //public EmployeeContext(DbContextOptions options) : base(options) {}
        DbSet<Employee> Employee { get; /*set;*/ }
        DbSet<EmployeeAddress> EmployeeAddress { get; /*set; */}
        // public DbSet<Employee> Employee { get; set; }
        // public DbSet<EmployeeAddress> EmployeeAddress { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    modelBuilder.ApplyConfiguration(new EmployeeEntityConfigurations());
        //    modelBuilder.ApplyConfiguration(new EmployeeAddressEntityConfigurations());

        //    modelBuilder.Entity<Employee>()
        //        .HasKey(p => p.Id)
        //        .HasName("PK_EmployeeId");

        //    modelBuilder.Entity<EmployeeAddress>()
        //        .HasKey(p => p.Id)
        //        .HasName("PK_AddressId");

        //    modelBuilder.Entity<Employee>()
        //        .HasMany<EmployeeAddress>(p => p.Addresses)
        //        .WithOne(e => e.Employee)
        //        .HasForeignKey(e => e.EmployeeId);

        //}
    }
}

//using EFDataAccessLibrary.EntityConfigurations;
//using EFDataAccessLibrary.Models.EmployeeFolder;
//using EFDataAccessLibrary.Models.BigData;
//using EFDataAccessLibrary.Models.Country;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EFDataAccessLibrary.DataAccess {
//    public class PoolContext : DbContext,ICountryContext, IEmployeeContext, IBigDataContext {

//        public PoolContext(DbContextOptions options) : base(options) { }

//        public DbSet<Employee> Employee { get; set; }
//        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
//        public DbSet<Country> Country { get; set; }
//        public DbSet<Citizen> Citizen { get; set; }
//        public DbSet<BigData> BigData { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder) {

//            modelBuilder.ApplyConfiguration(new EmployeeEntityConfigurations());
//            modelBuilder.ApplyConfiguration(new EmployeeAddressEntityConfigurations());
//            modelBuilder.ApplyConfiguration(new CountryEntityConfigurations());
//            modelBuilder.ApplyConfiguration(new CitizenEntityConfigurations());
//            modelBuilder.ApplyConfiguration(new BigDataEntityConfigurations());

//            modelBuilder.Entity<Employee>()
//                .HasKey(p => p.Id)
//                .HasName("PK_EmployeeId");

//            modelBuilder.Entity<Employee>()
//                .HasIndex(p => p.Id)
//                .HasFillFactor(85);

//            modelBuilder.Entity<EmployeeAddress>()
//                .HasKey(p => p.Id)
//                .HasName("PK_AddressId");

//            modelBuilder.Entity<Employee>()
//                .HasMany<EmployeeAddress>(p => p.Addresses)
//                .WithOne(e => e.Employee)
//                .HasForeignKey(e => e.EmployeeId);

//            modelBuilder.Entity<Country>()
//                .HasKey(p => p.CountryId)
//                .HasName("PK_CountryId");

//            modelBuilder.Entity<Citizen>()
//                .HasKey(p => p.CitizenId)
//                .HasName("PK_CitizenId");

//            modelBuilder.Entity<Country>()
//                .HasMany<Citizen>(p => p.Citizens)
//                .WithOne(p => p.Country)
//                .HasPrincipalKey(p => p.CountryCode)
//                .HasForeignKey(p => p.CountryCode);

//            modelBuilder.Entity<BigData>()
//                .HasKey(p => p.Id)
//                .HasName("PK_BigDataId");
//        }
//    }
//}

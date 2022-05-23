using EFDataAccessLibrary.EntityConfigurations;
using EFDataAccessLibrary.Models.Country;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess {
    public /*class */interface ICountryContext /*: DbContext*/{
        //public CountryContext(DbContextOptions options) : base(options) { }
        /*public*/ DbSet<Country> Country { get; /*set;*/ }
        /*public*/ DbSet<Citizen> Citizen { get; /*set;*/ }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {

        //    modelBuilder.ApplyConfiguration(new CountryEntityConfigurations());
        //    modelBuilder.ApplyConfiguration(new CitizenEntityConfigurations());

        //    modelBuilder.Entity<Country>()
        //        .HasKey(p => p.CountryCode)
        //        .HasName("PK_CountryCode");

        //    modelBuilder.Entity<Citizen>()
        //        .HasKey(p => p.CitizenId)
        //        .HasName("PK_CitizenId");

        //    modelBuilder.Entity<Country>()
        //        .HasMany<Citizen>(p => p.Citizens)
        //        .WithOne(p => p.Country)
        //        .HasForeignKey(p => p.CountryCode);
        //}
    }
}

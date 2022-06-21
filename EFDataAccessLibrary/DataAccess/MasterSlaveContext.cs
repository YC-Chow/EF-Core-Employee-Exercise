using EFDataAccessLibrary.EntityConfigurations;
using EFDataAccessLibrary.Models.MasterSlave;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess {
    public class MasterSlaveContext : DbContext {
        public MasterSlaveContext(DbContextOptions<MasterSlaveContext> options) : base(options) { }
        public DbSet<Master> Master{ get; set; }
        public DbSet<Slave> Slave { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new MasterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SlaveEntityConfiguration());

            modelBuilder.Entity<Master>()
                .HasMany<Slave>(p => p.SlaveList)
                .WithOne(p => p.Master)
                .HasForeignKey(p => p.MasterId);
        }
    }
}

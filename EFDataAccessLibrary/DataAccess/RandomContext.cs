using EFDataAccessLibrary.Models.Random;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess {
    public class RandomContext : DbContext {
        public RandomContext(DbContextOptions<RandomContext> options) : base(options) { }
        public DbSet<RandomModel> RandomModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<RandomModel>().HasKey(p => p.Id);
            modelBuilder.Entity<RandomModel>().ToTable("Random").HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            #region Column
            modelBuilder.Entity<RandomModel>().Property(p => p.Column1).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column2).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column3).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column4).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column5).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column6).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column7).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column8).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column9).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column10).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column11).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column12).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column13).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column14).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column15).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column16).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column17).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column18).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column19).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column20).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column21).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column22).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column23).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column24).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column25).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column26).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column27).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column28).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column29).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column30).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column31).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column32).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column33).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column34).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column35).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column36).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column37).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column38).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column39).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column40).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column41).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column42).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column43).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column44).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column45).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column46).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column47).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column48).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column49).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            modelBuilder.Entity<RandomModel>().Property(p => p.Column50).HasComment(String.Concat(Enumerable.Repeat("a", 1500)));
            #endregion
            
        }
    }
}

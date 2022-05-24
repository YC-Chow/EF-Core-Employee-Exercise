using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    public class PoolingBenchMarks {

        //private readonly PooledDbContextFactory<PoolContext> factory;

        public PoolingBenchMarks() {
            //var options = new DbContextOptionsBuilder<PoolContext>()
            //        .UseSqlServer(
            //                "Data Source=localhost,1433;Initial Catalog = EmployeeTest ;Integrated Security=True;" +
            //                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            //                "ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            //        .Options;

            //factory = new PooledDbContextFactory<PoolContext>(options);
        }

        [Benchmark]
        public void No_Pooling() {
            for (int i = 0; i < 1000; i++) {
                using (var _db = new EmployeeContext()) {
                    var employees = _db.Employee.Where(emp => emp.FName.Equals("Fox")).ToList();
                }
            }
        }
        

        //[Benchmark]
        //public void Pooling() {
        //    for (int i = 0; i < 1000; i++) {
        //        using (var _db = factory.CreateDbContext()) {
        //            var employees = _db.Employee.Where(emp => emp.FName.Equals("Fox")).ToList();
        //        }
        //    }
        //}
    }
}

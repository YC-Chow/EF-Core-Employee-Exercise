using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class DetectChangesBenchmarks {

        //Benchmark for adding entities with and without auto detect changes

        [Benchmark]
        public void WithAutoDetect() {
            using (var _db = new EmployeeContext()) {
                for (int i = 0; i < 10000; i++) {
                    Employee employee = new Employee() { 
                        FName = "A",
                        MName = "B",
                        LName = "C"
                    };
                    _db.Employee.Add(employee);
                }
                _db.SaveChanges();
            }
        }

        [Benchmark]
        public void WithoutAutoDetect() {
            using (var _db = new EmployeeContext()) {
                _db.ChangeTracker.AutoDetectChangesEnabled = false;

                for (int i = 0; i < 10000; i++) {
                    Employee employee = new Employee() {
                        FName = "A",
                        MName = "B",
                        LName = "C"
                    };
                    _db.Employee.Add(employee);
                }
                _db.ChangeTracker.DetectChanges();
                _db.SaveChanges();
            }
        }
    }
}

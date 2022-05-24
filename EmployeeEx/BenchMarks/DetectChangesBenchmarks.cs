using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(10)]
    [MaxIterationCount(20)]
    public class DetectChangesBenchmarks {
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

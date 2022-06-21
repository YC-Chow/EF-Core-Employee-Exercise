using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class OrderByDBBenchmarks {
        [Benchmark]
        public void OrderByDB() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Where(emp => emp.FName.Equals("Fox")).OrderByDescending(emp => emp.Id).ToList();
            }
        }

        [Benchmark]
        public void OrderByApp() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Where(emp => emp.FName.Equals("Fox")).ToList().OrderByDescending(emp => emp.Id);
            }
        }
    }
}

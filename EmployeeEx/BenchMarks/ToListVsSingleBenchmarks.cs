using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class ToListVsSingleBenchmarks {
        [Benchmark]
        public void ToList() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Where(emp => emp.Id == 1).ToList();
            }
        }

        [Benchmark]
        public void Single() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Where(emp => emp.Id == 1).SingleOrDefault();
            }
        }
    }
}

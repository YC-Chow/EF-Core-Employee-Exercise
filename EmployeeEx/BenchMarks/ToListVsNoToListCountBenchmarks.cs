using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class ToListVsNoToListCountBenchmarks {
        [Benchmark]
        public void ToList() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.ToList().Count();
            }
        }

        [Benchmark]
        public void NoToList() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Count();
            }
        }

    }
}

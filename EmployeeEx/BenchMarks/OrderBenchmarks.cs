using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(10)]
    [MaxIterationCount(20)]
    public class OrderBenchmarks {
        [Benchmark]
        public void NoOrderBy() {
            using (var _db = new BlankContext()) {
                var employeeList = _db.Employee
                    .Where(employee => employee.Id < 100000)
                    .ToList();
            }
        }

        [Benchmark]
        public void OrderBy() {
            using (var _db = new BlankContext()) {
                var employeeList = _db.Employee
                .Where(employee => employee.Id < 100000)
                .OrderByDescending(employee => employee.Id)
                .ToList();
            }
        }
    }
}

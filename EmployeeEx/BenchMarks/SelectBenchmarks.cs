using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(20)]
    [MinIterationCount(10)]
    public class SelectBenchmarks {
        [Benchmark]
        public void All_Column() {
            using (var _db = new BlankContext()) {
                var employees = _db.Employee.ToList();
            }
        }

        [Benchmark]
        public void Select_Column() {
            using (var _db = new BlankContext()) {
                var employees = _db.Employee.Select(employee => new Employee() {
                    Id = employee.Id,
                    FName = employee.FName
                })
            .ToList();
            }
        }
    }
}

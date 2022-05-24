using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class OrderBenchmarks {
        [Benchmark]
        public void Sorting_Application_Layer() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                    .Where(employee => employee.Id < 100000)
                    .ToList();

                employeeList.Sort(new EmployeeComparer());
                employeeList.Reverse();
            }
        }

        [Benchmark]
        public void OrderBy() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                .Where(employee => employee.Id < 100000)
                .OrderByDescending(employee => employee.Id)
                .ToList();
            }
        }
    }
}

using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class OrderBenchmarks {

        //Benchmark for having OrderBy in Queries
        //To do sorting in App layer


        [Benchmark]
        public void Sort_In_DB() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                .Where(employee => employee.Id < 150000)
                .OrderByDescending(employee => employee.Id)
                .ToList();
            }
        }

        [Benchmark]
        public void Sort_In_App() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                    .Where(employee => employee.Id < 150000)
                    .ToList();

                employeeList.Sort(new EmployeeComparer());
                employeeList.Reverse();
            }
        }

        
    }
}

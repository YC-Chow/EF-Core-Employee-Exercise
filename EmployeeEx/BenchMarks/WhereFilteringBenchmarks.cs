using BenchmarkDotNet.Attributes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class WhereFilteringBenchmarks {

        [Benchmark]
        public void Where_Is_After_ToList() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee.Take(1000)
                    .ToList()
                    .Where(employee => employee.FName == "Fox");
            }
        }


        [Benchmark]
        public void Where_Is_Before_ToList() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee.Take(1000)
                    .Where(employee => employee.FName == "Fox")
                    .ToList();
            }
        }

        
    }
}

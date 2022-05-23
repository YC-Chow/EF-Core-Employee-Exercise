using BenchmarkDotNet.Attributes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(20)]
    [MinIterationCount(10)]
    public class WhereFilteringBenchmarks {
        [Benchmark]
        public void GetAllEmployeeWhereBeforeToListVer() {
            using (var _db = new BlankContext()) {
                var employees = _db.Employee.Take(1000).Where(employee => employee.FName == "Fox").ToList();
            }
        }

        [Benchmark] 
        public void GetAllEmployeeWhereAfterToListVer() {
            using (var _db = new BlankContext()) {
                var employees = _db.Employee.Take(1000).ToList().Where(employee => employee.FName == "Fox");
            }
        }
    }
}

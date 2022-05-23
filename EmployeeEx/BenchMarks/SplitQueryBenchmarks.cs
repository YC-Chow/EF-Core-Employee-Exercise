using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(20)]
    [MinIterationCount(10)]
    public class SplitQueryBenchmarks {

        [Benchmark]
        public void NoSplit() {
            using (var _db = new BlankContext()) {
                var employees =_db.Employee
                    .Include(employee => employee.Addresses)
                    .AsSingleQuery()
                    .ToList();
            }
        }

        [Benchmark]
        public void Split() {
            using (var _db = new BlankContext()) {
                var employees =_db.Employee
                    .Include(employee => employee.Addresses)
                    .AsSplitQuery()
                    .ToList();
            }
        }
    }
}

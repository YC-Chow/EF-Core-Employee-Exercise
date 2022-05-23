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
    public class ContextLoopingBenchmarks {
       
        [Benchmark]
        public void NoLoopVer() {
            using (var _db = new BlankContext()) {
                var employees = _db.Employee.Take(100000).AsNoTracking().ToList();
            }
        }

        [Benchmark]
        public void LoopVer() { 
            using (var _db = new BlankContext()) {
                List<Employee> employeeList = new List<Employee>();

                for (int i = 0; i < 100000; i++) {
                    var employee = _db.Employee.Where(employeeX => employeeX.Id == 1).AsNoTracking().Single();
                    employeeList.Add(employee);
                }
            }
        }
    }
}

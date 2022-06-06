using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(20)]
    [MinIterationCount(10)]
    public class ContextLoopingBenchmarks {
       
        //Benchmark for putting data retrieval in loops

        [Benchmark]
        public void NoLoopVer() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee.Take(100000).AsNoTracking().ToList();
            }
        }

        [Benchmark]
        public void LoopVer() { 
            using (var _db = new EmployeeContext()) {
                List<Employee> employeeList = new List<Employee>();

                for (int i = 1; i < 100001; i++) {
                    var employee = _db.Employee.Where(employeeX => employeeX.Id == i)
                        .AsNoTracking().Single();
                    employeeList.Add(employee);
                }
            }
        }
    }
}

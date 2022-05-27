using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class SelectBenchmarks {

        //Benchmark for having .Select in query
        //Retrieving only specified columns
        //No Tracking + Select added on Santy request

        [Benchmark]
        public void All_Column() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee
                                .ToList();
            }
        }

        [Benchmark]
        public void Select_Column() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee.Select(employee => new Employee() {
                    Id = employee.Id,
                    FName = employee.FName
                })
            .ToList();
            }
        }

        [Benchmark]
        public void All_Column_No_Tracking() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee
                                .AsNoTracking()
                                .ToList();
            }
        }

        [Benchmark]
        public void Select_Column_No_Tracking() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee.Select(employee => new Employee() {
                    Id = employee.Id,
                    FName = employee.FName
                })
            .AsNoTracking()
            .ToList();
            }
        }
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    

    public class OrderByWithIndexBenchmarks {

      
        [Benchmark]
        public void OrderByCreatedDateWithIndexDB() {
            using (var _db = new EmployeeContext()) {
                _db.Employee
                    .OrderByDescending(p => p.CreatedDate)
                    .Select(p => new Employee() {
                        FName = p.FName,
                        MName = p.MName,
                        LName = p.LName,
                        CreatedDate = p.CreatedDate
                    })
                    .ToList();
            }
        }

        [Benchmark]
        public void OrderByCreatedDateWithIndexApp() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Select(p => new Employee() {
                    FName = p.FName,
                    MName = p.MName,
                    LName = p.LName,
                    CreatedDate = p.CreatedDate
                })
                .ToList()
                .OrderByDescending(p => p.CreatedDate);
            }
        }

        [Benchmark]
        public void OrderByCreatedDateWithIndexWithTakeDB() {
            using (var _db = new EmployeeContext()) {
                _db.Employee
                    .OrderByDescending(p => p.CreatedDate)
                    .Select(p => new Employee() {
                        FName = p.FName,
                        MName = p.MName,
                        LName = p.LName,
                        CreatedDate = p.CreatedDate
                    })
                    .Take(5)
                    .ToList();
            }
        }

        [Benchmark]
        public void OrderByCreatedDateWithIndexWithTakeApp() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Select(p => new Employee() {
                    FName = p.FName,
                    MName = p.MName,
                    LName = p.LName,
                    CreatedDate = p.CreatedDate
                })
                .ToList()
                .OrderByDescending(p => p.CreatedDate)
                .Take(5);
            }
        }

        [Benchmark]
        public void OrderByFNameWithIndexDB() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Select(p => new Employee() {
                    FName = p.FName,
                    MName = p.MName,
                    LName = p.LName,
                    CreatedDate = p.CreatedDate
                })
                .OrderByDescending(p => p.FName)
                .ToList();
            }
        }

        [Benchmark]
        public void OrderByFNameWithIndexApp() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Select(p => new Employee() {
                    FName = p.FName,
                    MName = p.MName,
                    LName = p.LName,
                    CreatedDate = p.CreatedDate
                })
                .ToList()
                .OrderByDescending(p => p.FName);
            }
        }

        [Benchmark]
        public void OrderByFNameWithIndexWithTakeDB() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Select(p => new Employee() {
                    FName = p.FName,
                    MName = p.MName,
                    LName = p.LName,
                    CreatedDate = p.CreatedDate
                })
                .OrderByDescending(p => p.FName)
                .Take(5)
                .ToList();
            }
        }

        [Benchmark]
        public void OrderByFNameWithIndexWithTakeApp() {
            using (var _db = new EmployeeContext()) {
                _db.Employee.Select(p => new Employee() {
                    FName = p.FName,
                    MName = p.MName,
                    LName = p.LName,
                    CreatedDate = p.CreatedDate
                })
                .ToList()
                .OrderByDescending(p => p.FName)
                .Take(5);
            }
        }
    }
}

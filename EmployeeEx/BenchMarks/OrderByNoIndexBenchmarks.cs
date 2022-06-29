using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(150)]
    [MinIterationCount(100)]
    [Config(typeof(Config))]
    
    public class OrderByNoIndexBenchmarks {

        public class Config : ManualConfig {
            public Config() {
                this.SummaryStyle.WithTimeUnit(Perfolizer.Horology.TimeUnit.Millisecond);
            }
        }
        [Benchmark]
        public void OrderByCreatedDateNoIndexDB() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex
                    .OrderByDescending(emp => emp.CreatedDate)
                    .Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .ToList();
            }
        }
        [Benchmark]
        public void OrderByCreatedDateNoIndexApp() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex.Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .ToList()
                .OrderByDescending(emp => emp.CreatedDate);
            }
        }
        [Benchmark]
        public void OrderByCreatedDateNoIndexWithTakeDB() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex
                    .OrderByDescending(emp => emp.CreatedDate)
                    .Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .Take(5)
                .ToList();
            }
        }

        [Benchmark]
        public void OrderByCreatedDateNoIndexWithTakeApp() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex.Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .ToList()
                .OrderByDescending(emp => emp.CreatedDate)
                .Take(5);
            }
        }
        [Benchmark]
        public void OrderByFnameNoIndexDB() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex.Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .OrderByDescending(emp => emp.FName)
                .ToList();
            }
        }

        [Benchmark]
        public void OrderByFnameNoIndexApp() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex.Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .ToList()
                .OrderByDescending(emp => emp.FName);
            }
        }

        [Benchmark]
        public void OrderByFnameNoIndexWithTakeDB() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex.Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .OrderByDescending(emp => emp.FName)
                .Take(5)
                .ToList();
            }
        }

        [Benchmark]
        public void OrderByFnameNoIndexWithTakeApp() {
            using (var _db = new EmployeeContext()) {
                _db.EmployeeNoIndex.Select(emp => new Employee() {
                    FName = emp.FName,
                    MName = emp.MName,
                    LName = emp.LName
                })
                .ToList()
                .OrderByDescending(emp => emp.FName)
                .Take(5);
            }
        }

       
    }
}

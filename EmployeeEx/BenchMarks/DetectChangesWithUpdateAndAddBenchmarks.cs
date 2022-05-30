using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.EmployeeFolder;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class DetectChangesWithUpdateAndAddBenchmarks {

        //Benchmark for updating and adding entities with and without auto detect changes

        [Benchmark]
        public void WithAutoDetect() {
            using (var _db = new EmployeeContext()) {

                var employeeList = _db.Employee.Where(emp => emp.Id >= 204001 && emp.Id <= 214000).ToList();
                foreach (var employee in employeeList) {
                    string currentName;
                    string changeName;
                    if (employee.FName == "A") {
                        currentName = "A";
                        changeName = "B";
                    }
                    else {
                        currentName = "B";
                        changeName = "A";
                    }

                    employee.FName = changeName;
                    employee.MName = changeName;
                    employee.LName = changeName;

                }

                for (int i = 0; i < 10000; i++) {
                    Employee employee = new Employee() { 
                        FName = "A",
                        MName = "B",
                        LName = "C"
                    };
                    _db.Employee.Add(employee);
                }
                _db.SaveChanges();
            }
        }

        [Benchmark]
        public void WithoutAutoDetect() {
            using (var _db = new EmployeeContext()) {
                _db.ChangeTracker.AutoDetectChangesEnabled = false;

                var employeeList = _db.Employee.Where(emp => emp.Id >= 204001 && emp.Id <= 214000).ToList();
                foreach (var employee in employeeList) {
                    string currentName;
                    string changeName;
                    if (employee.FName == "A") {
                        currentName = "A";
                        changeName = "B";
                    }
                    else {
                        currentName = "B";
                        changeName = "A";
                    }

                    employee.FName = changeName;
                    employee.MName = changeName;
                    employee.LName = changeName;

                }

                for (int i = 0; i < 10000; i++) {
                    Employee employee = new Employee() {
                        FName = "A",
                        MName = "B",
                        LName = "C"
                    };
                    _db.Employee.Add(employee);
                }
                _db.ChangeTracker.DetectChanges();
                _db.SaveChanges();
            }
        }
    }
}

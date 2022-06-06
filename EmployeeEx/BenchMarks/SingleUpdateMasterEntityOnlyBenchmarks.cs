using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class SingleUpdateMasterEntityOnlyBenchmarks {
        //Benchmark for updating 1 entity

        [Benchmark]

        public void EFCoreUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {
                //string currentName;
                string changeName;

                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                    //currentName = "A";
                    changeName = "B";
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) {
                    //currentName="B";
                    changeName = "C";
                }
                else {
                    //currentName = "C";
                    changeName = "A";
                }

                _db.Employee
                .Where(employee => employee.Id == 204001)
                .UpdateFromQuery(employee => new Employee() {
                    FName = changeName,
                    MName = changeName,
                    LName = changeName
                });

            }
        }

        [Benchmark]

        public void UsualUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {

                //string currentName;
                string changeName;

                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                    //currentName = "A";
                    changeName = "B";
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) {
                    //currentName = "B";
                    changeName = "C";
                }
                else {
                    //currentName = "C";
                    changeName = "A";
                }

                var employee = _db.Set<Employee>()
                    .Where(emp => emp.Id == 204001).Single();
                employee.FName = changeName;
                employee.MName = changeName;
                employee.LName = changeName;
                _db.SaveChanges();
            }
        }

        [Benchmark]

        public void AttachUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {

                

                string changeName;
                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                    changeName = "B";
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) {
                    changeName = "C";
                }
                else {
                    changeName = "A";
                }

                var employee = new Employee() {
                    Id = 204001,
                    FName = changeName,
                    MName = changeName,
                    LName = changeName
                };
                

                _db.Attach(employee);
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

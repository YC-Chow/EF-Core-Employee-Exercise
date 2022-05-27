using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeEx.BenchMarks
{
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class SingleUpdateBenchmarks
    {
        //Benchmark for updating 1 entity with its child entity

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

                _db.EmployeeAddress
                .Where(add => add.EmployeeId == 204001)
                .UpdateFromQuery(add => new EmployeeAddress() {
                    Address1 = changeName
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
                    .Include(emp => emp.Addresses)
                    .First(employee => employee.Id == 204001);
                employee.FName = changeName;
                employee.MName = changeName;
                employee.LName = changeName;
                employee.Addresses.First().Address1 = changeName;
                _db.SaveChanges();
            }
        }

        [Benchmark]

        public void AttachUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {

                var employee = new Employee();

                string changeName;
                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                    changeName = "B";
                    employee = _db.Employee.Include(emp => emp.Addresses).First(emp => emp.FName == "A");
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) {
                    changeName = "C";
                    employee = _db.Employee.Include(emp => emp.Addresses).First(emp => emp.FName == "B");
                }
                else {
                    changeName = "A";
                    employee = _db.Employee.Include(emp => emp.Addresses).First(emp => emp.FName == "C");
                }

                employee.FName = changeName;
                employee.MName = changeName;
                employee.LName = changeName;
                employee.Addresses.First().Address1 = changeName;

                _db.Attach(employee);
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

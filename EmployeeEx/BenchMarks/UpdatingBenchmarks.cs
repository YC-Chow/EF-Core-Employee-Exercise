using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeEx.BenchMarks
{
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class UpdatingBenchmarks
    {
        //Benchmark for updating multiple entites with child entity

        [Benchmark]

        public void EFCoreUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {
                string currentName;
                string changeName;

                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                   currentName = "A";
                   changeName = "B";
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) { 
                    currentName="B";
                    changeName = "C";
                }
                else {
                   currentName = "C";
                   changeName= "A";
                }

                _db.Employee
                .Where(employee => employee.Id >= 204001 && employee.Id <= 214000)
                .UpdateFromQuery(employee => new Employee() {
                    FName = changeName,
                    MName = changeName,
                    LName = changeName
                });

                _db.EmployeeAddress
                .Where(add => add.EmployeeId >= 204001 && add.EmployeeId <= 214000)
                .UpdateFromQuery(add => new EmployeeAddress() {
                    Address1 = changeName
                }); 


            }
        }

        [Benchmark]

        public void UsualUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {

                string currentName;
                string changeName;

                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                    currentName = "A";
                    changeName = "B";
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) {
                    currentName = "B";
                    changeName = "C";
                }
                else {
                    currentName = "C";
                    changeName = "A";
                }

                var employeeList = _db.Employee
                //.Where(employee => employee.FName.Equals(currentName))
                .Where(employee => employee.FName.Equals(currentName))
                .Include(employee => employee.Addresses)
                .ToList();

                foreach (var employee in employeeList) {
                    employee.FName = changeName;
                    employee.MName = changeName;
                    employee.LName = changeName;
                    employee.Addresses.First().Address1 = changeName;
                }

                _db.SaveChanges();
            }
        }

        [Benchmark]

        public void AttachUpdate() {
            using (EmployeeContext _db = new EmployeeContext()) {
                List<Employee> employee = new List<Employee>();

                string changeName;
                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                    changeName = "B";
                    employee = _db.Employee.Include(emp => emp.Addresses).Where(emp => emp.FName == "A").AsNoTracking().ToList();
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) {
                    changeName = "C";
                    employee = _db.Employee.Include(emp => emp.Addresses).Where(emp => emp.FName == "B").AsNoTracking().ToList();
                }
                else {
                    changeName = "A";
                    employee = _db.Employee.Include(emp => emp.Addresses).Where(emp => emp.FName == "C").AsNoTracking().ToList();
                }

                foreach (var employees in employee) {
                    employees.FName = changeName;
                    employees.MName = changeName;
                    employees.LName = changeName;
                    employees.Addresses.First().Address1 = changeName;
                }

                _db.Attach(employee);
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }


    }
}

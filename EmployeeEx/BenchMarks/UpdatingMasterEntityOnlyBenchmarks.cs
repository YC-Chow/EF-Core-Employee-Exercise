using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeEx.BenchMarks {


    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]

    public class UpdatingMasterEntityOnlyBenchmarks {

        //Benchmark for updating multiple entites

        [Benchmark]

        public void EFCoreUpdate() {
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

                _db.Employee
                .Where(employee => employee.Id >= 204001 && employee.Id <= 214000)
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

                var employeeList = _db.Employee
                .Where(employee => employee.Id >= 204001 && employee.Id <= 214000)
                .ToList();

                foreach (var employee in employeeList) {
                    employee.FName = changeName;
                    employee.MName = changeName;
                    employee.LName = changeName;
                }
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

                for (int i = 204001; i <= 214000; i++) {
                    var employee = new Employee() {
                        Id = i,
                        FName = changeName,
                        MName = changeName,
                        LName = changeName
                    };

                    _db.Attach(employee);
                    _db.Entry(employee).State = EntityState.Modified;
                }
                _db.SaveChanges();
            }
        }
    }
}

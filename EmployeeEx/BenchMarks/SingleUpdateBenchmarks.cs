using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                .Where(employee => employee.Id == 204001)
                .UpdateFromQuery(employee => new Employee() {
                    FName = changeName,MName = changeName,
                    LName = changeName
                });

                _db.EmployeeAddress
                .Where(add => add.EmployeeId == 204001)
                .UpdateFromQuery(add => new EmployeeAddress() {
                    Address1 = changeName,Address2 = changeName
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

                var employee = _db.Set<Employee>()
                    .Include(emp => emp.Addresses)
                    .Where(employee => employee.Id == 204001)
                    .Single();

                employee.FName = changeName;
                employee.MName = changeName;
                employee.LName = changeName;
                foreach (var address in employee.Addresses) {
                    address.Address1 = changeName;
                    address.Address2 = changeName;
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

                Employee employee = new Employee() {
                    Id = 204001,
                    FName = changeName,MName = changeName,LName = changeName,
                    Addresses = new List<EmployeeAddress>()
                };

                int[] addressIds = new int[] { 309061, 319061 };

                foreach (int id in addressIds) {
                    employee.Addresses.Add(new EmployeeAddress() {
                        Id = id, Address1 = changeName,Address2 = changeName
                    });
                }
                _db.Attach(employee);
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                
            }
        }
    }
}

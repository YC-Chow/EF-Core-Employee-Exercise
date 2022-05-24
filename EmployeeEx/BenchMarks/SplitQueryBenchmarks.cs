using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeEx.BenchMarks {
    [MemoryDiagnoser]
    [MaxIterationCount(20)]
    [MinIterationCount(10)]
    public class SplitQueryBenchmarks {

        [Benchmark]
        public void NoSplit() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee
                    .Include(employee => employee.Addresses)
                    .AsSingleQuery()
                    .ToList();
            }
        }

        [Benchmark]
        public void Split() {
            using (var _db = new EmployeeContext()) {
                var employees = _db.Employee
                    .Include(employee => employee.Addresses)
                    .AsSplitQuery()
                    .ToList();
            }
        }

        [Benchmark]
        public void SplitSelect() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                .Join(_db.EmployeeAddress,
                employee => employee.Id,
                address => address.EmployeeId,
                (employee, address) => new {
                    Id = employee.Id,
                    FName = employee.FName,
                    MName = employee.MName,
                    LName = employee.LName,
                    AddressId = address.Id,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    Address3 = address.Address3,
                    ZipCode = address.ZipCode,
                    EmployeeId = address.EmployeeId
                })
                .AsSplitQuery()
                .ToList();
            }
        }

        [Benchmark]
        public void NoSplitSelect() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                .Join(_db.EmployeeAddress,
                employee => employee.Id,
                address => address.EmployeeId,
                (employee, address) => new {
                    Id = employee.Id,
                    FName = employee.FName,
                    MName = employee.MName,
                    LName = employee.LName,
                    AddressId = address.Id,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    Address3 = address.Address3,
                    ZipCode = address.ZipCode,
                    EmployeeId = address.EmployeeId
                })
                .ToList();
            }
        }


    }
}

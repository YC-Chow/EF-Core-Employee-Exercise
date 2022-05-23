﻿using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeEx.BenchMarks
{
    [MinIterationCount(10)]
    [MaxIterationCount(20)]
    [MemoryDiagnoser]
    public class JoinsBenchmarks {

        [Benchmark]
        public void GetEmployeeByZipCodeLeftJoinVer() {
            using (var _db = new BlankContext()) {
                var employeeList = _db.Employee
                .Include(a => a.Addresses)
                .Where(p => p.Addresses.Any(a => a.ZipCode == 401916))
                .ToList();
            }
        }

        [Benchmark]
        public void GetEmployeeByZipCodeInnerJoinVer() {
            using (var _db = new BlankContext()) {
                var employeeList = _db.Employee
                .Join(_db.EmployeeAddress, 
                employee => employee.Id, 
                address => address.EmployeeId,
                (employee, address) => new EmployeeModel() {
                    Id = employee.Id,
                    FName = employee.FName,
                    MName = employee.MName,
                    LName = employee.LName,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    Address3 = address.Address3,
                    ZipCode = address.ZipCode,
                    AddressId = address.Id
                })
                .Where(a => a.ZipCode == 401916)
                .ToList();
            } 
        }
    }
}

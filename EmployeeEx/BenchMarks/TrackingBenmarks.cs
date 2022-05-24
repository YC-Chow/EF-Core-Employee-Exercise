using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeEx.BenchMarks
{
    [MemoryDiagnoser]
    [MinIterationCount(100)]
    [MaxIterationCount(200)]
    public class TrackingBenmarks
    {
        [Benchmark]
        public void With_Tracking() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                .ToList();
            }
        }

        [Benchmark]
        public void No_Tracking() {
            using (var _db = new EmployeeContext()) {
                var employeeList = _db.Employee
                .AsNoTracking()
                .ToList();
            }
        }

        //[Benchmark]
        //public void GetEmployeeByNameTrackingNameVer() {
        //    using (var _db = new EmployeeContext()) {
        //        var employeeList = _db.Employee
        //        .Where(a => a.FName.Equals("AA"))
        //        .ToList();
        //    }
        //}

        //[Benchmark]
        //public void GetEmployeeByNameNoTrackingNameVer() {
        //    using (var _db = new EmployeeContext()) {
        //        var employeeList = _db.Employee
        //        .Where(a => a.FName.Equals("AA"))
        //        .AsNoTracking()
        //        .ToList();
        //    }
        //}
    }
}

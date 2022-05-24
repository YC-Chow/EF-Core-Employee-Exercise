using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeEx.BenchMarks
{
    [MemoryDiagnoser]
    [MaxIterationCount(200)]
    [MinIterationCount(100)]
    public class UpdatingBenchmarks
    {

        //[Benchmark]

        //public void EFCoreUpdateRangeVer() {
        //    using (EmployeeContext _db = new EmployeeContext()) {
        //        _db.Set<Employee>()
        //        .Where(employee => employee.Id > 4000)
        //        .Take(100000)
        //        .UpdateFromQuery(employee => new Employee() {
        //            FName = "AB",
        //            MName = "AB",
        //            LName = "AB"
        //        });
        //    }
        //}

        //[Benchmark]

        //public void UsualUpdateRangeVer() {
        //    using (EmployeeContext _db = new EmployeeContext()) {
        //        var employeeList = _db.Set<Employee>()
        //        .Where(employee => employee.Id > 4000)
        //        .Take(100000)
        //        .ToList();

        //        foreach (var employee in employeeList) {
        //            employee.FName = "AA";
        //            employee.MName = "AA";
        //            employee.LName = "AA";
        //        }

        //        _db.SaveChanges();
        //    }
        //}

        [Benchmark]

        public void EFCoreUpdateNameVer() {
            using (EmployeeContext _db = new EmployeeContext()) {
                //string currentName;
                string changeName;

                if (_db.Employee.Where(employee => employee.FName == "A").Count() > 0) {
                   // currentName = "A";
                    changeName = "B";
                }
                else if (_db.Employee.Where(employee => employee.FName == "B").Count() > 0) { 
                    //currentName="B";
                    changeName = "C";
                }
                else {
                   // currentName = "C";
                    changeName= "A";
                }

                _db.Set<Employee>()
                .Where(employee => employee.Id > 104000 && employee.Id < 204001)
                .Take(100000)
                .UpdateFromQuery(employee => new Employee() {
                    FName = changeName,
                    MName = changeName,
                    LName = changeName
                });

            }
        }

        [Benchmark]

        public void UsualUpdateNameVer() {
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

                var employeeList = _db.Set<Employee>()
                .Where(employee => employee.FName == currentName)
                .Take(100000)
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

                for (int i = 104001; i < 204001; i++) {
                    var employee = new Employee() {
                        Id = i,
                        FName = changeName,
                        MName = changeName,
                        LName = changeName
                    };

                    _db.Attach(employee);
                    _db.Entry(employee).Property(p => p.FName).IsModified = true;
                }
                _db.SaveChanges();
            }
        }


    }
}

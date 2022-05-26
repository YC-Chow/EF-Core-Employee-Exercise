using BenchmarkDotNet.Attributes;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeEx {
    public class Functions {

        public EmployeeContext _db { get; set; }
        public Functions(EmployeeContext _db) {
            this._db = _db;
        }

        //-----------------------------------------------------------------------------------
        //Whole DB related queries
        public void GetAllEmployee() {
            var employees = _db.Employee.ToList();
        }

        public void GetAllEmployeeSelectVer() {
            var employees = _db.Employee.Select(employee => new Employee() {
                Id = employee.Id,
                FName = employee.FName
            })
            .ToList();
        }

        public void GetAllEmployeeWithAddress() {
            var employee = _db.Employee.Include(employee => employee.Addresses).ToList();
        }

        public void GetAllEmployeeWithAddressSplitVer() {
            var employee = _db.Employee.Include(employee => employee.Addresses).AsSplitQuery().ToList();
        }

        public void GetAllEmployeeWhereBeforeToListVer() {
            var employees = _db.Employee.Where(employee => employee.FName == "Fox").ToList();
        }

        public void GetAllEmployeeWhereAfterToListVer() {
            var employees = _db.Employee.ToList().Where(employee => employee.FName == "Fox");

        }

        public void GetFirst100000EmployeeNormalVer() {
            var employees = _db.Employee.Take(100000).ToList();
        }

        public void GetFirst100000EmployeeLoopVer() {
            List<Employee> employeeList = new List<Employee>();

            for (int i = 0; i < 100000; i++) {
                employeeList.Add(_db.Employee.Where(employee => employee.Id == i).Single());
            }
        }

        //-----------------------------------------------------------------------------------
        //Name related queries
        public void ChangeEmployee1001Name(string name) {
            _db.ChangeTracker.AutoDetectChangesEnabled = false;
            var employee = _db.Employee.SingleOrDefault(e => e.Id == 1001);
            employee.FName = name;
           // _db.ChangeTracker.DetectChanges();
            _db.SaveChanges();
        }

        public void ChangeExistingRowWithAttach()
        {
            Employee newEmployee = new Employee()
            {
                Id = 1,
                FName = "Harry",
                MName = "Iz",
                LName = "Gay"
            };

            _db.Employee.Attach(newEmployee);
            _db.Entry(newEmployee).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void GetEmployeeByNameEagerVer(string empName) {
            var employeeList = _db.Employee
                .Select(a => new Employee()
                {
                    FName = a.FName,
                    MName = a.MName,
                    LName = a.LName,
                })
                //.Include(employee => employee.Addresses)
                .Where(employee => employee.FName.Equals(empName))
                .TagWith("This is eager query")
                .ToList();

        }

        public void GetEmployeeByNameExplicitVer(string empName) {
            var employeeList = _db.Employee
                .Where(employee => employee.FName.Equals(empName))
                .ToList();

            foreach (Employee employee in employeeList) {
                _db.Entry(employee).Collection(employees => employees.Addresses).Load();
            }
        }

        public void GetEmployeeByNameTrackingVer(string empName) {
            var employeeList = _db.Employee
                .Where(a => a.FName.Equals(empName))
                .ToList();
        }

        public void GetEmployeeByNameNoTrackingVer(string empName) {
            var employeeList = _db.Employee
                .Where(a => a.FName.Equals(empName))
                .AsNoTracking()
                .ToList();
        }


        //-----------------------------------------------------------------------------------
        //Id related queries
        public void GetEmployeeByIdRangeNoTracking(int min, int max) {
            var employeeList = _db.Employee
                .Where(employee => employee.Id >= min && employee.Id <= max)
                .AsNoTracking()
                .ToList();

        }

        public void GetEmployeeByIdRange(int min, int max) {
            var employeeList = _db.Employee
                .Where(employee => employee.Id >= min && employee.Id <= max)
                .ToList();

        }

        //---------------------------------------------------------------------------------
        //ZipCode related quries 
        public void GetEmployeeByZipCode(int zip) {
            var employeeList = _db.Employee
                .Include(a => a.Addresses)
                .Where(p => p.Addresses.Any(a => a.ZipCode == zip))
                .ToList();
        }

        public void GetEmployeeZipCodeInnerJoinVer(int zip) {
            var employeeList = _db.Employee
                .Join(_db.EmployeeAddress, employee => employee.Id, address => address.EmployeeId,
                (employee, address) => new EmployeeModel() {
                    Id = employee.Id,
                    FName = employee.FName,
                    MName = employee.MName,
                    LName = employee.LName,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    Address3 = address.Address3,
                    ZipCode = address.ZipCode,
                })
                .Where(a => a.ZipCode == zip)
                .ToList();
        }


        public void GetEmployeeByZipCodeV2(int zip) {
            var employeeList = _db.EmployeeAddress
                .Where(address => address.ZipCode == zip)
                .Join(_db.Employee, address => address.EmployeeId, employee => employee.Id,
                (address, employee) => new EmployeeModel() {
                    Id = employee.Id,
                    FName = employee.FName,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    Address3 = address.Address3
                })
                .ToList();

            Debug.WriteLine(employeeList.GetType());

        }
        //----------------------------------------------------------------------------------
        //update Queries

        public void UsualUpdate() {
            var employeeList = _db.Set<Employee>()
                .Where(employee => employee.Id > 4000)
                .ToList();

            for (int i = 0; i < employeeList.Count; i++) {
                employeeList[i].MName = "AA";
                employeeList[i].FName = "AA";
                employeeList[i].LName = "AA";
            }

            _db.SaveChanges();
        }
        public void AttachUpdate() {
            for ( int i = 4001; i < 5001; i++) {
                var employee = new Employee() {
                    Id = i,
                    FName = "AB",
                    MName = "AB",
                    LName = "AB"
                };

                _db.Attach(employee);
                _db.Entry(employee).State = EntityState.Modified;
            }
            _db.SaveChanges();
        }
        public void EFCoreUpdate() {
            _db.Set<Employee>()
                .Where(employee => employee.Id > 4001)
                .UpdateFromQuery(employee => new Employee() {
                    FName = "AC",
                    MName = "AC",
                    LName = "AC"
                });
        }

        private void UpdateWithNoTracking() {
            var employee = _db.Employee
                                .AsNoTracking()
                                .First(emp => emp.FName.Equals("Fox"));

            employee.FName = "UniqueNameOnEarth";
            _db.SaveChanges();

            int count = _db.Employee.Where(emp => emp.FName.Equals("UniqueNameOnEarth")).Count();

            Console.WriteLine("Number of Employee: " + count.ToString());
        }

        //----------------------------------------------------------------------------------
        //Delete Queries

        public void UsualDelete() {
            var employee = _db.Set<Employee>()
                .Where(employee => employee.FName.Equals("A"))
                .ToList();
            _db.RemoveRange(employee);
            _db.SaveChanges();
        }

        public void AttachDelete() {
            var employee = _db.Employee
                .Where(p => p.FName.Equals("A"))
                .Select(p => new Employee() {
                    Id = p.Id
                })
                .ToList();

            _db.AttachRange(employee);
            _db.RemoveRange(employee);
            _db.SaveChanges();
        }

        public void EFCoreDelete() {
            _db.Set<Employee>()
                .Where(employee => employee.FName == "A")
                .DeleteFromQuery();
        }

        //----------------------------------------------------------------------------------
        //misc queries
        public void PrintEmployeeDetails(List<Employee> employeeList) {
            for (int i = 0; i < employeeList.Count; i++) {
                Debug.WriteLine("-----------------------------");
                Debug.WriteLine("Employee " + (i + 1).ToString());
                Debug.WriteLine("");
                Debug.WriteLine(String.Format("Employee ID: {0}", employeeList.ElementAt(i).Id));
                Debug.WriteLine(String.Format("FName: {0}", employeeList.ElementAt(i).FName));
                for (int j = 0; j < employeeList[i].Addresses.Count; j++) {
                    Debug.WriteLine("_____________________________");
                    Debug.WriteLine(String.Format("Address 1: {0}", employeeList[i].Addresses.ElementAt(j).Address1));
                    Debug.WriteLine(String.Format("Address 2: {0}", employeeList[i].Addresses.ElementAt(j).Address2));
                    Debug.WriteLine(String.Format("Address 3: {0}", employeeList[i].Addresses.ElementAt(j).Address3));
                }
                Debug.WriteLine("-----------------------------");
            }
        }
    }
}

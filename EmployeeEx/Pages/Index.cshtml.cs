using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;
using EFDataAccessLibrary.Models.BigData;
using BenchmarkDotNet.Running;
using AutoMapper;
using EmployeeEx.Models;
using EmployeeEx.BenchMarks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EFDataAccessLibrary.Models.EmployeeFolder;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EFDataAccessLibrary.Models.CompanyFolder;

namespace EmployeeEx.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeContext _db;
        private readonly Functions functions;
        private readonly MapperConfiguration config;
        public IndexModel(ILogger<IndexModel> logger, EmployeeContext db) {
            _logger = logger;
            _db = db;
            functions = new Functions(_db);


            //===============================================================================
            /*The config below is for automapper
            AutoMapper configuration can also be seperated out to individual classes*/

            //config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Person, Customer>()
            //            .ForMember(dest => dest.FName, act => act.MapFrom(src => src.FirstName))
            //            .ForMember(dest => dest.MName, act => act.MapFrom(src => src.MiddleName))
            //            .ForMember(dest => dest.LName, act => act.MapFrom(src => src.LastName));        
            //});

                //    cfg.CreateMap<Customer, Person>()
                //            .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FName))
                //            .ForMember(dest => dest.MiddleName, act => act.MapFrom(src => src.MName))
                //            .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LName));
                //});
            //===============================================================================
        }

        public void OnGet() {
            /*
            BigDataContext, BlankContext, CountryContext and PoolContext
            temporarily put off

            Customer and Person classes are used for AutoMapper
             */



            /*
             Most CRUD queries can be found in functions class, 
            which is in the root folder of EmployeeEx

            Name of methods pretty much describe what it does
             */


            /*
             LoadSampleData() will load 1000 employees with addresses
            LoadSampleData() does not have any checks if there is data in database
            There is also a LoadSampleData100000Ver() which  is loads the same json file 100 times
            LoadCompany() not used, Company class got removed

            To run benchmark, BenchmarkRunner.Run<BenchmarkClass>();
             */

            //LoadSampleData();
            //SpamEmployee();

            //functions.ChangeExistingRowWithAttach();
            //functions.GetEmployeeByZipCode(401916);
            //functions.GetEmployeeZipCodeInnerJoinVer(401916);
            //functions.GetEmployeeByName("Hello");
            //functions.GetEmployeeByNameExplicitVer("Drake");
            //functions.ChangeEmployee1001Name("best");
            //functions.GetEmployeeByIdRange(1000, 9000);
            //functions.GetEmployeeByIdRangeNoTracking(1000, 9000);
            //functions.GetAllEmployeeWithAddressSplitVer();

            //functions.UsualDelete();
            //functions.AttachDelete();
            //functions.EFCoreDelete();

            //functions.UsualUpdate();
            //functions.AttachUpdate();
            //functions.EFCoreUpdate();


            //====================================================================
            //========================Benchmark Codes=============================
            //BenchmarkRunner.Run<UpdatingBenchmarks>();
            //BenchmarkRunner.Run<JoinsBenchmarks>();
            //BenchmarkRunner.Run<TrackingBenmarks>();
            //BenchmarkRunner.Run<DeleteBenchmarks>();
            //BenchmarkRunner.Run<SelectBenchmarks>();
            //BenchmarkRunner.Run<DetectChangesBenchmarks>();
            //BenchmarkRunner.Run<WhereFilteringBenchmarks>();
            //BenchmarkRunner.Run<OrderBenchmarks>();
            //BenchmarkRunner.Run<FillFactorBenchmark>();
            //BenchmarkRunner.Run<ContextLoopingBenchmarks>();
            //BenchmarkRunner.Run<SplitQueryBenchmarks>();
            //BenchmarkRunner.Run<PoolingBenchMarks>();
            //BenchmarkRunner.Run<SingleUpdateBenchmarks>();
            //BenchmarkRunner.Run<DetectChangesWithUpdateAndAddBenchmarks>();
            //BenchmarkRunner.Run<SingleUpdateMasterEntityOnlyBenchmarks>();
            //BenchmarkRunner.Run<UpdatingMasterEntityOnlyBenchmarks>();
            //BenchmarkRunner.Run<SingleUpdateMasterEntityOnlyBenchmarks>();
            //BenchmarkRunner.Run<ContextLoopingBenchmarks>();
            //====================================================================
            //AccessChangeTrackerPropValues(); 

        }

        private void SpamEmployeeAddRangeVer() {
            //_db.ChangeTracker.AutoDetectChangesEnabled = false;
            List<Employee> employeeList = new List<Employee>();

            for (int i = 0; i < 1000; i++) {
                Employee employee = new Employee();
                employee.FName = "A";
                employee.MName = "A";
                employee.LName = "A";
                employeeList.Add(employee);
            }
            _db.Employee.AddRange(employeeList);
            _db.SaveChanges();
        }

        private void SpamEmployee() {
            for (int i = 0; i < 1000; i++) {
                Employee employee = new Employee();
                employee.FName = "A";
                employee.MName = "A";
                employee.LName = "A";
                _db.Employee.Add(employee);
            }
            _db.SaveChanges();
        }

        private void SpamEmployeeNoAutoDetect() {

            _db.ChangeTracker.AutoDetectChangesEnabled = false;

            for (int i = 0; i < 90000; i++) {
                Employee employee = new Employee();
                employee.FName = "A";
                employee.MName = "A";
                employee.LName = "A";
                _db.Employee.Add(employee);
            }
            _db.ChangeTracker.DetectChanges();
            _db.SaveChanges();
        }

        private void SpamEmployeeWithReset() {
            //_db.ChangeTracker.AutoDetectChangesEnabled = false;
            List<Employee> employeeList = new List<Employee>();

            //resets the auto increment
            _db.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Employee, RESEED, 204001)");

            for (int i = 0; i < 100000; i++) {
                Employee employee = new Employee();
                employee.FName = "A";
                employee.MName = "A";
                employee.LName = "A";
                employeeList.Add(employee);
            }
            _db.Employee.AddRange(employeeList);
            _db.SaveChanges();
        }

        private void Spam1MilEmployee() {
            //_db.ChangeTracker.AutoDetectChangesEnabled = false;
            List<Employee> employeeList = new List<Employee>();

            for (int i = 0; i < 1000000; i++) {
                Employee employee = new Employee();
                employee.FName = "A";
                employee.MName = "A";
                employee.LName = "A";
                _db.Employee.Add(employee);
            }
            _db.SaveChanges();
        }

        private void LoadSampleDataWOAutoDetect() {
            if (_db.Employee.Count() != 0) {
                _db.ChangeTracker.AutoDetectChangesEnabled = false;
                string file = System.IO.File.ReadAllText("generated.json");
                var employee = JsonSerializer.Deserialize<List<Employee>>(file);
                _db.Employee.AddRange(employee);
                _db.ChangeTracker.DetectChanges();
                _db.SaveChanges();
            }
        }


        private void LoadSampleData() {
            string file = System.IO.File.ReadAllText("generated.json");
            var employee = JsonSerializer.Deserialize<List<Employee>>(file);
            _db.Employee.AddRange(employee);
            _db.SaveChanges();
        }

        private void LoadSampleData100000RowsVer() {
            for (int i = 0; i < 100; i++) {
                LoadSampleData();
            }
        }
        private void LoadSampleDataBulkVer() {
            if (_db.Employee.Count() != 0) {
                string file = System.IO.File.ReadAllText("generated.json");
                var employee = JsonSerializer.Deserialize<List<Employee>>(file);
                _db.BulkInsert(employee);
            }
        }

        //private void LoadCompany() {
        //    if (_db.Company.Count() == 0) {
        //        string file = System.IO.File.ReadAllText("company.json");
        //        var company = JsonSerializer.Deserialize<List<Company>>(file);
        //        _db.BulkInsert(company);
        //    }
        //}
        //private void LoadBigData() {
        //    if (_db.BigData.Count() != 0) {
        //        string file = System.IO.File.ReadAllText("generated2000.json");
        //        var bigData = JsonSerializer.Deserialize<List<BigData>>(file);
        //        _db.BigData.AddRange(bigData);
        //        _db.SaveChanges();
        //    }
        //}

        private void SimpleMappingExercise() {

            Mapper mapper = new Mapper(config);

            Person person = new Person() {
                Id = 1,
                FirstName = "Jimmy",
                MiddleName = "Gameo",
                LastName = "Deadman",
                BankNo = "12134567890123456",
                IsEmployed = false
            };

            Customer customer = mapper.Map<Customer>(person);
            Person anotherPerson = mapper.Map<Person>(customer);
            anotherPerson.PrintDetails();
        }

        private void AccessChangeTrackerPropValues() {
            var employee = _db.Employee.First(emp => emp.FName.Equals("Fox"));
            employee.FName = "Esther";
            _db.ChangeTracker.DetectChanges();
            var modifiedEntries = _db.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (EntityEntry entity in modifiedEntries) {
                foreach (var propName in entity.CurrentValues.Properties) {
                    Console.WriteLine("Before");
                    Console.WriteLine(entity.CurrentValues[propName]);
                    Console.WriteLine("After");
                    Console.WriteLine(entity.OriginalValues[propName]);
                }
            }
        }

        private async Task<List<Employee>> GetEmployeeListAsync() {
            using (var _db = new EmployeeContext()) {
                IQueryable<Employee> query = _db.Employee.Where(emp => emp.FName.Equals("Fox"))/*.Where(emp => emp.Addresses.Any(add => add.Address1.Equals("Florida")))*/;

                Console.WriteLine("Loading");
                query.Include(emp => emp.Addresses).Where(emp => emp.Addresses.Any(add => add.Address1.Equals("Florida"))).Load();

                return await query.ToListAsync();
            }
        }
    }
}

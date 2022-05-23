﻿using Microsoft.AspNetCore.Mvc;
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

namespace EmployeeEx.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly BlankContext _db;
        private readonly Functions functions;
        private readonly MapperConfiguration config;
        public IndexModel(ILogger<IndexModel> logger, BlankContext db) {
            _logger = logger;
            _db = db;
            //functions = new Functions(_db);
            //config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Person, Customer>()
            //            .ForMember(dest => dest.FName, act => act.MapFrom(src => src.FirstName))
            //            .ForMember(dest => dest.MName, act => act.MapFrom(src => src.MiddleName))
            //            .ForMember(dest => dest.LName, act => act.MapFrom(src => src.LastName));

            //    cfg.CreateMap<Customer, Person>()
            //            .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FName))
            //            .ForMember(dest => dest.MiddleName, act => act.MapFrom(src => src.MName))
            //            .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.LName));
            //});
        }

        public void OnGet() {
            //LoadSampleData();
            //LoadSampleData100000RowsVer();
            //LoadSampleDataWOAutoDetect();
            //LoadBigData();
            //SpamEmployee();
            //SpamEmployeeWithReset();
            //SpamEmployeeAddRangeVer();
            //Spam1MilEmployee();
            //SpamEmployeeNoAutoDetect();

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

            //SimpleMappingExercise();

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

            for (int i = 0; i < 100000; i++) {
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
            if (_db.Employee.Count() == 0) {
                string file = System.IO.File.ReadAllText("generated.json");
                var employee = JsonSerializer.Deserialize<List<Employee>>(file);
                _db.Employee.AddRange(employee);
                _db.SaveChanges();
            }
        }

        private void LoadSampleData100000RowsVer() {
            for (int i = 0; i < 100; i++) {
                LoadSampleDataWOAutoDetect();
            }
        }
        private void LoadSampleDataBulkVer() {
            if (_db.Employee.Count() != 0) {
                string file = System.IO.File.ReadAllText("generated.json");
                var employee = JsonSerializer.Deserialize<List<Employee>>(file);
                _db.BulkInsert(employee);
            }
        }

        private void LoadBigData() {
            if (_db.BigData.Count() != 0) {
                string file = System.IO.File.ReadAllText("generated2000.json");
                var bigData = JsonSerializer.Deserialize<List<BigData>>(file);
                _db.BigData.AddRange(bigData);
                _db.SaveChanges();
            }
        }

        private void SimpleMappingExercise() {

            Mapper mapper = new Mapper(config);

            Person person = new Person() {
                Id = 1,
                FirstName = "Jimmy",
                MiddleName = "Gameo",
                LastName = "Lolson",
                BankNo = "12134567890123456",
                IsEmployed = false
            };

            Customer customer = mapper.Map<Customer>(person);
            Person anotherPerson = mapper.Map<Person>(customer);
            anotherPerson.PrintDetails();
        }

    }
}

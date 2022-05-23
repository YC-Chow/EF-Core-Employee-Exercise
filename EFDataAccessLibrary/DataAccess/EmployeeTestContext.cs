using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess {
     public interface IEmployeeTestContext {
        DbSet<Employee> Employee { get; set; }
        DbSet<EmployeeAddress> EmployeeAddress { get; set; }
     }
}

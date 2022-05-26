using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EFDataAccessLibrary.Models.CompanyFolder;

namespace EFDataAccessLibrary.Models.EmployeeFolder {
    public class Employee {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public virtual List<EmployeeAddress> Addresses { get; set; }

    }
}

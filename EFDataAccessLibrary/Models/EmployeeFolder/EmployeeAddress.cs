using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Models.EmployeeFolder {
    public class EmployeeAddress {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int ZipCode { get; set; }
        public int EmployeeId { get; set; }
        public virtual  Employee Employee { get; set; }

    }
}

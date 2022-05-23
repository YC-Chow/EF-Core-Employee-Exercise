using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models {
    public class EmployeeModel {
        public int Id { get; set; }
        public string FName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public int ZipCode { get; set; }
        public int  AddressId { get; set; }
    }
}

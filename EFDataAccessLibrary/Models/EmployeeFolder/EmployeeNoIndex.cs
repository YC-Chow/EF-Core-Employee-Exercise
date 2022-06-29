﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models.EmployeeFolder {
    public class EmployeeNoIndex {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<EmployeeAddressNoIndex> Addresses { get; set; }
    }
}

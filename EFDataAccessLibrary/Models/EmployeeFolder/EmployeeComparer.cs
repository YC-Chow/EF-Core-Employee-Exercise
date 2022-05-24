using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models.EmployeeFolder {
    public class EmployeeComparer : IComparer<Employee> {
        public int Compare(Employee x, Employee y) {
            if (x.Id == y.Id)
                return 0;

            if (x.Id > y.Id)
                return 1;

            if (x.Id < y.Id)
                return -1;

            return x.Id.CompareTo(y.Id);
        }
    }
}

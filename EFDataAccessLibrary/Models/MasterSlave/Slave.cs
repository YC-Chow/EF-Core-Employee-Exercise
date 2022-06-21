using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models.MasterSlave {
    public class Slave {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Master Master { get; set; }
        public Guid MasterId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models.MasterSlave {
    public class Master {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Slave> SlaveList { get; set; } 
    }
}

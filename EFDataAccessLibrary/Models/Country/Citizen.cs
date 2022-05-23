using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models.Country {
    public class Citizen {
        public int CitizenId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDatabaseAccess.Models
{
    public class CarModel
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string RegistrationNumber { get; set; }
        public string VIN_Number { get; set; }
        public DateTime? TermTechnicalResearch { get; set; }
        public DateTime? TechLegalization { get; set; }
        public DateTime? LiftUDT { get; set; }
        public DateTime? OCPolicy { get; set; }
        public DateTime? ACPolicy { get; set; }
    }
}

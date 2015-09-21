using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    class Car
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string VINNumber { get; set; }
        public DateTime TermTechnicalResearch { get; set; }
        public DateTime TachoLegalization { get; set; }
        public DateTime ListUDT { get; set; }
        public DateTime OCPolicy { get; set; }
        public DateTime ACPolicy { get; set; }
    }
}

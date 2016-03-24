using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDatabaseConnector
{
    public partial class Car
    {
        /// <summary>
        /// Indicates the time from now that specified the death line
        /// </summary>
        private double _daysInDeathLine = 14;

        /// <summary>
        /// Indicates is any date (OC policy, AC polisy) crossed over the death line date
        /// </summary>
        public bool CrossedDeathLine
        {
            get
            {
                return
                    LiftUDT.HasValue && DateTime.Now.AddDays(_daysInDeathLine) > LiftUDT.Value ||
                    TechLegalization.HasValue && DateTime.Now.AddDays(_daysInDeathLine) > TechLegalization.Value ||
                    TermTechnicalResearch.HasValue && DateTime.Now.AddDays(_daysInDeathLine) > TermTechnicalResearch.Value ||
                    ACPolicy.HasValue && DateTime.Now.AddDays(_daysInDeathLine) > ACPolicy.Value ||
                    OCPolicy.HasValue && DateTime.Now.AddDays(_daysInDeathLine) > OCPolicy.Value;
            }
        }

        public string OcInsurancesToolTip
        {
            get
            {
                return string.Empty;
            }
        }

        public string AcInsurancesToolTip
        {
            get
            {
                return string.Empty;
            }
        }

    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMSDatabaseConnector
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public Car()
        {
            this.AcInstallments = new HashSet<AcInstallment>();
            this.OcInstallments = new HashSet<OcInstallment>();
        }
    
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string RegistrationNumber { get; set; }
        public string VIN_Number { get; set; }
        public Nullable<System.DateTime> TermTechnicalResearch { get; set; }
        public Nullable<System.DateTime> TechLegalization { get; set; }
        public Nullable<System.DateTime> LiftUDT { get; set; }
        public Nullable<System.DateTime> OCPolicy { get; set; }
        public Nullable<System.DateTime> ACPolicy { get; set; }
    
        public virtual ICollection<AcInstallment> AcInstallments { get; set; }
        public virtual ICollection<OcInstallment> OcInstallments { get; set; }
    }
}

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
    
    public partial class OcInstallment
    {
        public int Id { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }
        public int CarID { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
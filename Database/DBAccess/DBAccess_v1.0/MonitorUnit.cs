//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonitorUnit
    {
        public int Id { get; set; }
        public double Clorine { get; set; }
        public string Name { get; set; }
        public double Ph { get; set; }
        public string SerialNumber { get; set; }
        public double Temperature { get; set; }
        public int PoolId { get; set; }
    
        public virtual Pool Pool { get; set; }
    }
}

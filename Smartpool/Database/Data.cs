//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smartpool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Data
    {
        public int Id { get; set; }
        public string Timestamp { get; set; }
        public int PoolId { get; set; }
    
        public virtual Pool Pool { get; set; }
        public virtual Chlorine Chlorine { get; set; }
        public virtual pH pH { get; set; }
        public virtual Temperature Temperature { get; set; }
        public virtual Humidity Humidity { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirstSmartPool
{
    using System;
    using System.Collections.Generic;
    
    public partial class PoolDimensions
    {
        public int PoolDimensionsId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
    
        public virtual Pool Pool { get; set; }
    }
}

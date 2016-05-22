namespace Smartpool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Temperature
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int DataId { get; set; }
    
        public virtual Data Data { get; set; }
    }
}

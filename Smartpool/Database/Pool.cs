namespace Smartpool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pool
    {
        public Pool()
        {
            this.Data = new HashSet<Data>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
        public virtual ICollection<Data> Data { get; set; }
    }
}

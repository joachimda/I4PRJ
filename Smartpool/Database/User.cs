namespace Smartpool
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Pool = new HashSet<Pool>();
        }
    
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middelname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Pool> Pool { get; set; }
    }
}

using System.Collections.Generic;

namespace SPDatabase
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public RealName Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Pool> Pools { get; set; }
    }
}
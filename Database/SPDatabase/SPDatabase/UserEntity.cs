using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPDatabase
{
    public class UserEntity
    {
        [Key]
        public int UserEntityId { get; set; }

        public RealName Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Pool> Pools { get; set; }
    }
}
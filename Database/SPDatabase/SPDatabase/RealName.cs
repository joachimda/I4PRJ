using System.ComponentModel.DataAnnotations;

namespace SPDatabase
{
    public class RealName
    {
        [Key]
        public int RealNameId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
    }
}
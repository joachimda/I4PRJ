
namespace Smartpool
{
    using System;
    using System.Collections.Generic;
    
    public partial class Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Data()
        {
            this.Chlorine = new HashSet<Chlorine>();
            this.Humidity = new HashSet<Humidity>();
            this.pH = new HashSet<pH>();
            this.Temperature = new HashSet<Temperature>();
        }
    
        public int Id { get; set; }
        public string Timestamp { get; set; }
        public int PoolId { get; set; }
    
        public virtual Pool Pool { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chlorine> Chlorine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Humidity> Humidity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pH> pH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Temperature> Temperature { get; set; }
    }
}

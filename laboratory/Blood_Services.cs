//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace laboratory
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blood_Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blood_Services()
        {
            this.Services = new HashSet<Services>();
        }
    
        public int BService_ID { get; set; }
        public int User_ID { get; set; }
        public int Blood_ID { get; set; }
        public int Code_Service { get; set; }
        public string Result { get; set; }
        public string End_Date { get; set; }
        public string Approved { get; set; }
        public string Status { get; set; }
        public string Analyzer { get; set; }
    
        public virtual Bloods Bloods { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Services> Services { get; set; }
    }
}

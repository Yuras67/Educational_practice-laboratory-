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
    
    public partial class Analyzers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Analyzers()
        {
            this.Completed_services = new HashSet<Completed_services>();
        }
    
        public int Analyzer_ID { get; set; }
        public System.DateTime Date_Of_Order { get; set; }
        public System.DateTime DateTime_Of_Execution { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Completed_services> Completed_services { get; set; }
    }
}

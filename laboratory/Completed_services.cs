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
    
    public partial class Completed_services
    {
        public int C_Service_ID { get; set; }
        public int Service_ID { get; set; }
        public int User_ID { get; set; }
        public int Analyzer_ID { get; set; }
        public System.DateTime Date_Of_Provision { get; set; }
    
        public virtual Analyzers Analyzers { get; set; }
        public virtual Services Services { get; set; }
        public virtual Users Users { get; set; }
    }
}

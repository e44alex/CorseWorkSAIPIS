//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork_SAIPIS.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventsList
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int ExpertId { get; set; }
    
        public virtual Experts Experts { get; set; }
    }
}

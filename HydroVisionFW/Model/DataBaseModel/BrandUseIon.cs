//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HydroVisionFW.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BrandUseIon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BrandUseIon()
        {
            this.ExchangeCapacityAndReagentConsumptionFSD = new HashSet<ExchangeCapacityAndReagentConsumptionFSD>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExchangeCapacityAndReagentConsumptionFSD> ExchangeCapacityAndReagentConsumptionFSD { get; set; }
    }
}

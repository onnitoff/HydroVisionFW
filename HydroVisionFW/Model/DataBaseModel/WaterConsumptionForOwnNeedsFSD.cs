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
    
    public partial class WaterConsumptionForOwnNeedsFSD
    {
        public int Id { get; set; }
        public int IdNameIonFilter { get; set; }
        public int IdBrandUseIon { get; set; }
        public decimal WaterConsumptionForPreparationOfRegenerationSolutionsCation { get; set; }
        public decimal WaterConsumptionForPreparationOfRegenerationSolutionsAnion { get; set; }
        public decimal WaterConsumptionForWashingProductsRegenerationCation { get; set; }
        public decimal WaterConsumptionForWashingProductsRegenerationAnion { get; set; }
        public decimal GeneralWaterConsumptionCation { get; set; }
        public decimal GeneralWaterConsumptionAnion { get; set; }
    
        public virtual BrandUseIon BrandUseIon { get; set; }
        public virtual IonFiltersNames IonFiltersNames { get; set; }
    }
}

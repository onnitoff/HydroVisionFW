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
    
    public partial class Clarifiers
    {
        public int Id { get; set; }
        public int IdBrand { get; set; }
        public int IdForWith { get; set; }
        public int Perfomance { get; set; }
        public int Diameter { get; set; }
        public int Height { get; set; }
    
        public virtual BrandAndPerfomanceClarifiers BrandAndPerfomanceClarifiers { get; set; }
        public virtual ForWithClarifiers ForWithClarifiers { get; set; }
    }
}

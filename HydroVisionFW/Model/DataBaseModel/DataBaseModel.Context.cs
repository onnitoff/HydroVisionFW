﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WaterContext : DbContext
    {
        public WaterContext()
            : base("name=WaterContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApplyingFilter> ApplyingFilter { get; set; }
        public virtual DbSet<Boilers> Boilers { get; set; }
        public virtual DbSet<BrandAndPerfomanceClarifiers> BrandAndPerfomanceClarifiers { get; set; }
        public virtual DbSet<Calciners> Calciners { get; set; }
        public virtual DbSet<Clarifiers> Clarifiers { get; set; }
        public virtual DbSet<CoolingTowers> CoolingTowers { get; set; }
        public virtual DbSet<CoolingWaterFlowOnTurbine> CoolingWaterFlowOnTurbine { get; set; }
        public virtual DbSet<Filters> Filters { get; set; }
        public virtual DbSet<FilterType> FilterType { get; set; }
        public virtual DbSet<ForWithClarifiers> ForWithClarifiers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeOfBoilers> TypeOfBoilers { get; set; }
        public virtual DbSet<FuelOilConsumption> FuelOilConsumption { get; set; }
    }
}

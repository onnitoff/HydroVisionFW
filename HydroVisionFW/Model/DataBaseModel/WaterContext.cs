using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class WaterContext : DbContext
    {
        public WaterContext() : base("name=SQLiteConnection") { }

        public virtual DbSet<Boilers> Boilers { get; set; }
        public virtual DbSet<BrandAndPerfomanceClarifiers> BrandAndPerfomanceClarifiers { get; set; }
        public virtual DbSet<BrandUseIon> BrandUseIon { get; set; }
        public virtual DbSet<Calciners> Calciners { get; set; }
        public virtual DbSet<Clarifiers> Clarifiers { get; set; }
        public virtual DbSet<CoolingWaterFlowOnTurbine> CoolingWaterFlowOnTurbine { get; set; }
        public virtual DbSet<FuelOilConsumption> FuelOilConsumption { get; set; }
        public virtual DbSet<ExchangeCapacityAndReagentConsumption> ExchangeCapacityAndReagentConsumption { get; set; }
        public virtual DbSet<ExchangeCapacityAndReagentConsumptionSimplified> ExchangeCapacityAndReagentConsumptionSimplified { get; set; }
        public virtual DbSet<ExchangeCapacityAndReagentConsumptionFSD> ExchangeCapacityAndReagentConsumptionFSD { get; set; }
        public virtual DbSet<Filters> Filters { get; set; }
        public virtual DbSet<FilterType> FilterType { get; set; }
        public virtual DbSet<OperatingPressure> OperatingPressure { get; set; }
        public virtual DbSet<WaterConsumptionForOwnNeeds> WaterConsumptionForOwnNeeds { get; set; }
        public virtual DbSet<WaterConsumptionForOwnNeedsFSD> WaterConsumptionForOwnNeedsFSD { get; set; }

    }
}

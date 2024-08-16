using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class WaterConsumptionForOwnNeedsFSD
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class WaterConsumptionForOwnNeeds
    {
        public int Id { get; set; }
        public int IdNameIonFilter { get; set; }
        public int IdBrandUseIon { get; set; }
        public decimal WaterConsumptionForPreparationOfRegenerationSolutions { get; set; }
        public decimal WaterConsumptionForWashingProductsRegeneration { get; set; }
        public decimal GeneralWaterConsumption { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model
{
    internal class BrandOfIonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WorkingExchangeCapacity { get; set; }
        public double SpecificConsumptionCation { get; set; }
        public double SpecificConsumptionAnion { get; set; }
        public double GeneralWaterConsumptionCation { get; set; }
        public double GeneralWaterConsumptionAnion { get; set; }
    }
}

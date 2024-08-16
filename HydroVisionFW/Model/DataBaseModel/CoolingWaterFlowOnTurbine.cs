using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class CoolingWaterFlowOnTurbine
    {
        public int Id { get; set; }
        public string TurbineName { get; set; }
        public int WaterConsumption { get; set; }
        public int Perfomance { get; set; }
        public int TurbineType { get; set; }
        public int WaterConsumptionForNetworkHeaters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class ExchangeCapacityAndReagentConsumption
    {
        public int Id { get; set; }
        public int IdIonFiltersNames { get; set; }
        public int IdBrandUseIon { get; set; }
        public int WorkingExchangeCapacityMin { get; set; }
        public Nullable<int> WorkingExchangeCapacityMax { get; set; }
        public int IdNameReagent { get; set; }
        public int SpecificConsumptionMin { get; set; }
        public Nullable<int> SpecificConsumptionMax { get; set; }
    }
}

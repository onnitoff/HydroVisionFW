using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class ExchangeCapacityAndReagentConsumptionFSD
    {
        public int Id { get; set; }
        public int IdIonFiltersNames { get; set; }
        public int IdBrandUseIon { get; set; }
        public int WorkingExchangeCapacity { get; set; }
        public int IdNameReagentFirst { get; set; }
        public int IdNameReagentSecond { get; set; }
        public decimal SpecificConsumptionFirst { get; set; }
        public decimal SpecificConsumptionSecond { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class Filters
    {
        public int Id { get; set; }
        public int IdApplyingFilters { get; set; }
        public Nullable<int> IdFilterTypes { get; set; }
        public string Cipheer { get; set; }
        public Nullable<int> IdOperatingPressure { get; set; }
        public int Diameter { get; set; }
        public Nullable<int> FilterLoadHeight { get; set; }
        public Nullable<int> WaterConsumption { get; set; }
    }
}

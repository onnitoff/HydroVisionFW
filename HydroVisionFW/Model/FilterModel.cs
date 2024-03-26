using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model
{
    internal class FilterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double OperatingPressure { get; set; }
        public int Diameter { get; set; }
        public int IonExchangerLayerHieght { get; set; }
        public int FilterPerfomance { get; set; }
    }
}

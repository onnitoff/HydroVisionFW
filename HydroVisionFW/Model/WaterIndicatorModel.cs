using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionDesign.Model
{
    internal class WaterIndicatorModel
    {
        public string Name { get; set; }
        public double InitialUnit { get; set; }
        public double Eq { get; set; }
        public double FinalUnit { get; set; }
    }
}

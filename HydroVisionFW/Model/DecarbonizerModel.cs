using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model
{
    internal class DecarbonizerModel
    {
        public int Id { get; set; }
        public int Perfomance { get; set; }
        public int Diameter { get; set; }
        public double CrossAreaSections { get; set; }
        public int AirFlow { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Model.DataBaseModel
{
    public class Calciners
    {
        public int Id { get; set; }
        public int Performance { get; set; }
        public int Diameter { get; set; }
        public decimal CrossAreaSections { get; set; }
        public int AirFlow { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.DataStorages
{
    internal class ClarifierStorage
    {
        private static ClarifierStorage instance;
        private ClarifierStorage() { }

        public static ClarifierStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClarifierStorage();
                }
                return instance;
            }
        }

        #region Clarifier
        public double v_ocv { get; set; }
        public double t {  get; set; }
        public int m { get; set; }
        public double G_k { get; set; }
        public double E_k { get; set; }
        public double G_k_tex { get; set; }
        public double C { get; set; }
        public double G_PAA { get; set; }
        public double d_PAA { get; set; }
        public double G_izv { get; set; }
        public double d_izv { get; set; }
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Perfomance { get; set; }
        public int Diameter { get; set; }
        public int Height { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.DataStorages
{
    internal class DecarbonizerStorage
    {
        private static DecarbonizerStorage instance;
        private DecarbonizerStorage() { }

        public static DecarbonizerStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DecarbonizerStorage();
                }
                return instance;
            }
        }

        /// <summary>Переменные Декарбонизатор</summary>
        #region Decarbonizer
        public double C_CO_vx { get; set; }
        public double W_b_oct { get; set; }
        public double W_k_oct { get; set; }
        public double Q_d { get; set; }
        public int m { get; set; }
        public double Q_d_input { get; set; }
        public double b_CO { get; set; }
        public double C_CO_oct { get; set; }
        public double F_dec { get; set; }
        public double K_j { get; set; }
        public double deltaC_CO { get; set; }
        public double F_nac { get; set; }
        public double V_nac { get; set; }
        public double f_kp { get; set; }
        public double f_d { get; set; }
        public double b { get; set; }
        public double d_d { get; set; }
        public double h_nac { get; set; }
        public double Q_vozd { get; set; }



        #endregion
    }
}

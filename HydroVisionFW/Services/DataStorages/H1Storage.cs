using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.DataStorages
{
    internal class H1Storage
    {
        private static H1Storage instance;
        private H1Storage() { }

        public static H1Storage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new H1Storage();
                }
                return instance;
            }
        }

        /// <summary>Переменные H2</summary>
        #region Filter_H2

        public double F { get; set; }
        public double w { get; set; }
        public double f_p { get; set; }
        public double d_p { get; set; }
        public double d_ct { get; set; }
        public double f_ct { get; set; }
        public double t { get; set; }
        public double T_FAA { get; set; }
        public double h { get; set; }
        public int m { get; set; }
        public double n { get; set; }
        public double V_vl { get; set; }
        public double V_vlK { get; set; }
        public double SumV_vl { get; set; }
        public double SumV_vlK { get; set; }

        public double g_cnK { get; set; }
        public double P_iK { get; set; }
        public double G_100pK { get; set; }
        public double bK { get; set; }
        public double e_pK { get; set; }
        public double G_texK { get; set; }
        public double CK { get; set; }
        public double G_cutK { get; set; }

        public double Q_br_input { get; set; }
        public double Q_br { get; set; }


        #region DB

        public int SelectedBrandOfIon { get; set; } = 1;
        public int SelectedSuitableFilter { get; set; } = 0;
        #endregion

        #endregion
    }
}

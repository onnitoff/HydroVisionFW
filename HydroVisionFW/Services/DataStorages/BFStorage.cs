using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace HydroVisionFW.Services.DataStorages
{
    internal class BFStorage
    {
        private static BFStorage instance;
        private BFStorage() { }

        public static BFStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BFStorage();
                }
                return instance;
            }
        }

        /// <summary>Переменные Осветлительные фильтры</summary>
        #region Filter_BF

        public double Q_bf_input { get; set; }
        public double F { get; set; }
        public double w { get; set; }
        public double f_p { get; set; }
        public double d_p { get; set; }
        public double d_ct { get; set; }
        public double f_ct { get; set; }

        public double g_vzr { get; set; }
        public double i { get; set; }
        public double t_vzr { get; set; }

        public double g_otm { get; set; }
        public double t_otm { get; set; }

        public double g_0 { get; set; }

        public double w_m1 { get; set; }
       
        public double h { get; set; }
        public int m { get; set; }
        public double n { get; set; }

        public double SumV_vl { get; set; }

        public double Q_br { get; set; }


        #region DB

        public int SelectedBrandOfIon { get; set; } = 1;
        public int SelectedSuitableFilter { get; set; } = 0;
        #endregion

        #endregion
    }
}

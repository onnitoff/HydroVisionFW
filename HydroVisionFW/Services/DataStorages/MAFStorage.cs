﻿using HydroVisionDesign.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.DataStorages
{
    public class MAFStorage
    {
        private static MAFStorage instance;
        private MAFStorage() { }

        public static MAFStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MAFStorage();
                }
                return instance;
            }
        }

        /// <summary>Переменные ФСД</summary>
        #region Filter_MA

        public double F {  get; set; }
        public double w { get; set; }
        public double f_p { get; set; }
        public double d_p { get; set;}
        public double d_ct { get; set; }
        public double f_ct { get; set; }
        public double t { get;set; }
        public double T_FAA { get; set;}
        public double h { get; set;}
        public int m {  get; set; }
        public double n { get; set; }
        public double V_vl {  get; set; }
        public double V_vlK { get; set;}
        public double SumV_vl { get; set; }
        public double SumV_vlK { get; set; }

        public double g_cnK { get; set; }
        public double P_iK { get; set; }
        public double G_100pK { get; set;}
        public double bK {  get; set; }
        public double e_pK { get; set;}
        public double G_texK {  get; set; }
        public double CK { get; set; }
        public double G_cutK { get; set; }

        public double g_cnA { get; set; }
        public double P_iA { get; set; }
        public double G_100pA { get; set; }
        public double bA { get; set; }
        public double e_pA { get; set; }
        public double G_texA { get; set; }
        public double CA { get; set; }
        public double G_cutA { get; set; }

        public double Q_br { get; set; }


        #region DB

        public int SelectedBrandOfIon { get; set; } = 1;
        public int SelectedSuitableFilter { get; set; } = 0;
        #endregion

        #endregion
    }
}

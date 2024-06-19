using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionDesign.ViewModel
{
    internal class ParametersConstVM : ViewModelBase
    {
        #region Свойства textBox

        private double _K_Al_Fe = DataStorage.Instance.K_Al_Fe;
        /// <summary>Свойство textBox K_Al_Fe</summary>
        public double K_Al_Fe
        {
            get => _K_Al_Fe;
            set => Set(ref _K_Al_Fe, value);
        }

        private double _ResidualHardnessCarbonate = DataStorage.Instance.ResidualHardnessCarbonate;
        /// <summary>Свойство textBox ResidualHardnessCarbonate</summary>
        public double ResidualHardnessCarbonate
        {
            get => _ResidualHardnessCarbonate;
            set => Set(ref _ResidualHardnessCarbonate, value);
        }

        private double _CationOnSecondStageFilter = DataStorage.Instance.CationOnSecondStageFilter;
        /// <summary>Свойство textBox CationOnSecondStageFilter</summary>
        public double CationOnSecondStageFilter
        {
            get => _CationOnSecondStageFilter;
            set => Set(ref _CationOnSecondStageFilter, value);
        }

        private double _t_Filters = DataStorage.Instance.t_Filters;
        /// <summary>Свойство textBox t_Filters</summary>
        public double t_Filters
        {
            get => _t_Filters;
            set => Set(ref _t_Filters, value);
        }

        private double _i_BF = BFStorage.Instance.i;
        /// <summary>Свойство textBox _i_BF</summary>
        public double i_BF
        {
            get => _i_BF;
            set => Set(ref _i_BF, value);
        }

        private double _t_vzr_BF = BFStorage.Instance.t_vzr;
        /// <summary>Свойство textBox t_vzr_BF</summary>
        public double t_vzr_BF
        {
            get => _t_vzr_BF;
            set => Set(ref _t_vzr_BF, value);
        }

        private double _t_otm_BF = BFStorage.Instance.t_otm;
        /// <summary>Свойство textBox t_otm_BF</summary>
        public double t_otm_BF
        {
            get => _t_otm_BF;
            set => Set(ref _t_otm_BF, value);
        }

        private double _n_BF = BFStorage.Instance.n;
        /// <summary>Свойство textBox n_BF</summary>
        public double n_BF
        {
            get => _n_BF;
            set => Set(ref _n_BF, value);
        }


        #endregion
        public ParametersConstVM() { }


       
    }
}

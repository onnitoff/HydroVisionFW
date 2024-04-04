using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Services.Calculations;
using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionDesign.ViewModel
{
    internal class PerfomanceWTPVM : ViewModelBase
    {
        #region Свойство Hidden

        private bool _IsHiddenDirectFlow = false;
        /// <summary>Свойство для открытия и сокрытия элементов xaml DirectFlow</summary>
        public bool IsHiddenDirectFlow
        {
            get => _IsHiddenDirectFlow;
            set => Set(ref _IsHiddenDirectFlow, value);
        }

        private bool _IsHiddenMain = true;
        /// <summary>Свойство для открытия и сокрытия элементов xaml Main</summary>
        public bool IsHiddenMain
        {
            get => _IsHiddenMain;
            set => Set(ref _IsHiddenMain, value);
        }

        private bool _IsHiddenPurging = false;
        /// <summary>Свойство для открытия и сокрытия элементов xaml Purging</summary>
        public bool IsHiddenPurging
        {
            get => _IsHiddenPurging;
            set => Set(ref _IsHiddenPurging, value);
        }

        private bool _IsHiddenFuelOil = false;
        /// <summary>Свойство для открытия и сокрытия элементов xaml FuelOil</summary>
        public bool IsHiddenFuelOil
        {
            get => _IsHiddenFuelOil;
            set => Set(ref _IsHiddenFuelOil, value);
        }

        private bool _IsHiddenExternal = false;
        /// <summary>Свойство для открытия и сокрытия элементов xaml External</summary>
        public bool IsHiddenExternal
        {
            get => _IsHiddenExternal;
            set => Set(ref _IsHiddenExternal, value);
        }

        private bool _IsHiddenPerfomanceWTP = true;
        /// <summary>Свойство для открытия и сокрытия элементов xaml PerfomanceWTP</summary>
        public bool IsHiddenPerfomanceWTP
        {
            get => _IsHiddenPerfomanceWTP;
            set => Set(ref _IsHiddenPerfomanceWTP, value);
        }

        private bool _IsHiddenPerfomanceHeatingNetwork = false;
        /// <summary>Свойство для открытия и сокрытия элементов xaml PerfomanceHeatingNetwork</summary>
        public bool IsHiddenPerfomanceHeatingNetwork
        {
            get => _IsHiddenPerfomanceHeatingNetwork;
            set => Set(ref _IsHiddenPerfomanceHeatingNetwork, value);
        }

        #endregion

        #region Свойство textBox 

        private string _InternalLosses;
        /// <summary>Свойство textBox Внутренние потери</summary>
        public string InternalLosses
        {
            get => _InternalLosses;
            set => Set(ref _InternalLosses, value);
        }

        private string _Stock;
        /// <summary>Свойство textBox Запас</summary>
        public string Stock
        {
            get => _Stock;
            set => Set(ref _Stock, value);
        }

        private string _PerfomanceWTPToFeedMainCycle;
        /// <summary>Свойство textBox Производительность ВПУ для подпитки основного цикла</summary>
        public string PerfomanceWTPToFeedMainCycle
        {
            get => _PerfomanceWTPToFeedMainCycle;
            set => Set(ref _PerfomanceWTPToFeedMainCycle, value);
        }

        private string _PerfomanceWTPToFeedHeatingNetwork;
        /// <summary>Свойство textBox Производительность ВПУ для подпитки тепловых сетей</summary>
        public string PerfomanceWTPToFeedHeatingNetwork
        {
            get => _PerfomanceWTPToFeedHeatingNetwork;
            set => Set(ref _PerfomanceWTPToFeedHeatingNetwork, value);
        }

        private string _BoilerPurging;
        /// <summary>Свойство textBox Потери с продувкой/summary>
        public string BoilerPurging
        {
            get => _BoilerPurging;
            set => Set(ref _BoilerPurging, value);
        }

        private string _FuelOilLosses;
        /// <summary>Свойство textBox Потери на мазутном хозяйстве/summary>
        public string FuelOilLosses
        {
            get => _FuelOilLosses;
            set => Set(ref _FuelOilLosses, value);
        }

        private string _ExternalLosses;
        /// <summary>Свойство textBox Внутренние потери/summary>
        public string ExternalLosses
        {
            get => _ExternalLosses;
            set => Set(ref _ExternalLosses, value);
        }

        #endregion

        public PerfomanceWTPVM() 
        {
            Calculations calculations = new Calculations();
            calculations.RecalculationOfQualityIndicators();
            FillingTextBox();
        }

        /// <summary>Заполнение textBox</summary>
        private void FillingTextBox()
        {
            if (DataStorage.Instance.BoilerPerfomanceFirst != 0 && DataStorage.Instance.BoilerPerfomanceSecond == 0)
                InternalLosses = $"q_внутр = 2% * D * n = 2% * {DataStorage.Instance.BoilerPerfomanceFirst} * {BoilerStorage.Instance.NumberOfBoilersFirst} = {BoilerStorage.Instance.InternalLosses} т/ч";
            if (DataStorage.Instance.BoilerPerfomanceSecond != 0 && DataStorage.Instance.BoilerPerfomanceFirst == 0)
                InternalLosses = $"q_внутр = 2% * D * n = 2% * {DataStorage.Instance.BoilerPerfomanceSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond} = {BoilerStorage.Instance.InternalLosses} т/ч";
            if(DataStorage.Instance.BoilerPerfomanceFirst != 0 && DataStorage.Instance.BoilerPerfomanceSecond != 0)
                InternalLosses = $"q_внутр = 2% * (D1 * n1 + D2 * n2 = 2% * {DataStorage.Instance.BoilerPerfomanceSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond} + " +
                                 $"{DataStorage.Instance.BoilerPerfomanceSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond} = {BoilerStorage.Instance.InternalLosses} т/ч";

            Stock = $"q_зап = {BoilerStorage.Instance.DesaltedWaterSupply} т/ч";

            if (BoilerStorage.Instance.Losses != 0)
            {
                ExternalLosses = $"q_внеш = p% * D_отб * 1.5 = {BoilerStorage.Instance.Losses} * {BoilerStorage.Instance.VacationCouple} * 1.5 = {BoilerStorage.Instance.ExternalLosses} т/ч";
                IsHiddenExternal = true;
            }

            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond != 1)
            {
                BoilerPurging = $"q_прод = k% * D * n = {BoilerStorage.Instance.BlowdownLosses} * {DataStorage.Instance.BoilerPerfomanceFirst} * {BoilerStorage.Instance.NumberOfBoilersFirst} = " +
                                $"{BoilerStorage.Instance.PurgingLosses} т/ч";
                IsHiddenPurging = true;
            }
            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeSecond == 1 && DataStorage.Instance.BoilerTypeFirst != 1)
            {
                BoilerPurging = $"q_прод = k% * D * n = {BoilerStorage.Instance.BlowdownLosses} * {DataStorage.Instance.BoilerPerfomanceSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond} = " +
                                $"{BoilerStorage.Instance.PurgingLosses} т/ч";
                IsHiddenPurging = true;
            }
            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond == 1)
            {
                BoilerPurging = $"q_прод = k% * (D1 * n1 + D2 * n2) = {BoilerStorage.Instance.BlowdownLosses} * ({DataStorage.Instance.BoilerPerfomanceFirst} * {BoilerStorage.Instance.NumberOfBoilersFirst} + " +
                                $"{DataStorage.Instance.BoilerPerfomanceSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond}) = {BoilerStorage.Instance.PurgingLosses} т/ч";
                IsHiddenPurging = true;
            }

            if (BoilerStorage.Instance.FuelOilConsumptionFirst != 0 && BoilerStorage.Instance.FuelOilConsumptionSecond != 0)
            {
                FuelOilLosses = $"q_мх = 0.15 * B1 * n1 + B2 * n2 = 0.15 * {BoilerStorage.Instance.FuelOilConsumptionFirst} * {BoilerStorage.Instance.NumberOfBoilersFirst} + " +
                                $"{BoilerStorage.Instance.FuelOilConsumptionSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond} = {BoilerStorage.Instance.LossesInFuelOilProduction} т/ч";
                IsHiddenFuelOil = true;
            }

            if (BoilerStorage.Instance.NumberOfBoilersSecond == 0)
            {
                if (DataStorage.Instance.TurbineTypeFirst == 1)
                    PerfomanceWTPToFeedMainCycle = $"Q_впу = D * n + q_внутр + q_зап = {DataStorage.Instance.BoilerPerfomanceFirst} * {BoilerStorage.Instance.NumberOfBoilersFirst} + {BoilerStorage.Instance.DesaltedWaterSupply} = {BoilerStorage.Instance.PerfomanceWTP} т/ч";
            }
            if (BoilerStorage.Instance.NumberOfBoilersSecond != 0)
            {
                if (DataStorage.Instance.TurbineTypeFirst == 1 && DataStorage.Instance.TurbineTypeSecond == 1)
                    PerfomanceWTPToFeedMainCycle = $"Q_впу = D1 * n1 + D2 * n2 + q_внутр + q_зап = {DataStorage.Instance.BoilerPerfomanceFirst} * {BoilerStorage.Instance.NumberOfBoilersFirst} +" +
                        $"{DataStorage.Instance.BoilerPerfomanceSecond} * {BoilerStorage.Instance.NumberOfBoilersSecond} + {BoilerStorage.Instance.DesaltedWaterSupply} = {BoilerStorage.Instance.PerfomanceWTP} т/ч";
            }

            if (DataStorage.Instance.TurbineTypeFirst == 2 || DataStorage.Instance.TurbineTypeSecond == 2)
                PerfomanceWTPToFeedMainCycle = $"Q_впу = q_внутр + q_внеш + q_прод + q_мх + q_зап = {BoilerStorage.Instance.InternalLosses} + {BoilerStorage.Instance.ExternalLosses} +" +
                                               $"{BoilerStorage.Instance.PurgingLosses} + {BoilerStorage.Instance.LossesInFuelOilProduction} + {BoilerStorage.Instance.DesaltedWaterSupply} = {BoilerStorage.Instance.PerfomanceWTP} т/ч";

            if (BoilerStorage.Instance.PerfomanceWTPForHeatingSystemFirst != 0 || BoilerStorage.Instance.PerfomanceWTPForHeatingSystemSecond != 0)
            {
                PerfomanceWTPToFeedHeatingNetwork = $"Q_впуУм = 2% * (G_св1 + G_св2) = 2% * ({BoilerStorage.Instance.PerfomanceWTPForHeatingSystemFirst} + {BoilerStorage.Instance.PerfomanceWTPForHeatingSystemSecond}) = {BoilerStorage.Instance.PerfomanceWTPForHeatingSystem} т/ч";
                IsHiddenPerfomanceHeatingNetwork = true;
            }
        }
    }
}

using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Services.Calculations;
using HydroVisionDesign.Services.DataStorages;
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
        /// <summary>Свойство для открытия и сокрытия элементов xaml DirectFlow</summary>
        private bool _IsHiddenDirectFlow = true;

        public bool IsHiddenDirectFlow
        {
            get => _IsHiddenDirectFlow;
            set => Set(ref _IsHiddenDirectFlow, value);
        }
        #endregion

        #region Свойство textBox 
        /// <summary>Свойство textBox Внутренние потери</summary>
        private string _InternalLosses;

        public string InternalLosses
        {
            get => _InternalLosses;
            set => Set(ref _InternalLosses, value);
        }

        /// <summary>Свойство textBox Запас</summary>
        private string _Stock;

        public string Stock
        {
            get => _Stock;
            set => Set(ref _Stock, value);
        }

        /// <summary>Свойство textBox Производительность ВПУ для подпитки основного цикла</summary>
        private string _PerfomanceWTPToFeedMainCycle;

        public string PerfomanceWTPToFeedMainCycle
        {
            get => _PerfomanceWTPToFeedMainCycle;
            set => Set(ref _PerfomanceWTPToFeedMainCycle, value);
        }

        /// <summary>Свойство textBox Производительность ВПУ для подпитки тепловых сетей</summary>
        private string _PerfomanceWTPToFeedHeatingNetwork;

        public string PerfomanceWTPToFeedHeatingNetwork
        {
            get => _PerfomanceWTPToFeedHeatingNetwork;
            set => Set(ref _PerfomanceWTPToFeedHeatingNetwork, value);
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
            InternalLosses = $"q_внутр = 2% * D * n = 2% * {DataStorage.Instance.BoilerPerfomanceFirst} * {DataStorage.Instance.NumberOfBoilersFirst} + " +
                $"{DataStorage.Instance.DesaltedWaterSupply} = {DataStorage.Instance.InternalLosses} т/ч";

            Stock = $"q_зап = {DataStorage.Instance.DesaltedWaterSupply} т/ч";

            PerfomanceWTPToFeedMainCycle = $"q_внутр + q_зап = {DataStorage.Instance.InternalLosses} + {DataStorage.Instance.DesaltedWaterSupply} = {DataStorage.Instance.PerfomanceWTPForIES} т/ч";

            PerfomanceWTPToFeedHeatingNetwork = $"2% * G_св = 2% * {DataStorage.Instance.WaterConsumptionForNetworkHeaters} = {DataStorage.Instance.PerfomanceWTPForHeatingSystem} т/ч";
        }
    }
}

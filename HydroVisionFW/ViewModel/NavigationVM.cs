using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionDesign.Services.Calculations;
using HydroVisionDesign.Services.DataStorages;
using HydroVisionDesign.Services.TestValues;
using HydroVisionFW.Services.Calculations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HydroVisionDesign.ViewModel
{
    internal class NavigationVM : ViewModelBase
    {
        private object _CurrentView;
        /// <summary>Свойство для навигации</summary>
        public object CurrentView
        {
            get => _CurrentView;
            set => Set(ref _CurrentView, value);
        }

        #region Command

        /// <summary>Навигация</summary>
        public ICommand WaterQualityCommand { get; set; }
        private void WaterQuality(object obj) => CurrentView = new WaterQualityIndicatorsVM();

        /// <summary>Навигация</summary>
        public ICommand PerfomanceCommand { get; set; }
        private void Perfomance(object obj) => CurrentView = new PerfomanceWTPVM();

        /// <summary>Навигация</summary>
        public ICommand DesaltingPartCommand { get; set; }
        private void DesaltingPart(object obj) => CurrentView = new DesaltingPartWTPVM();

        /// <summary>Навигация</summary>
        public ICommand CoolingSystemCommand { get; set; }
        private void CoolingSystem(object obj) => CurrentView = new CoolingSystemVM();

        /// <summary>Навигация</summary>
        public ICommand CirculationPumpsCommand { get; set; }
        private void CirculationPumps(object obj) => CurrentView = new CirculationPumpsVM();

        /// <summary>Навигация</summary>
        public ICommand GivenParamCommand { get; set; }
        private void GivenParam(object obj) => CurrentView = new GivenParametersVM();

        /// <summary>Навигация</summary>
        public ICommand ParamConstCommand { get; set; }
        private void ParamConst(object obj) => CurrentView = new ParametersConstVM();

        #endregion

        public NavigationVM()
        {
            Calculations calc = new Calculations();
            calc.RecalculationOfQualityIndicators();
            CalcBoiler calcBoiler = new CalcBoiler();
            WaterQualityCommand = new RelayCommand(WaterQuality);
            PerfomanceCommand = new RelayCommand(Perfomance);
            DesaltingPartCommand = new RelayCommand(DesaltingPart);
            CoolingSystemCommand = new RelayCommand(CoolingSystem);
            CirculationPumpsCommand = new RelayCommand(CirculationPumps);
            GivenParamCommand = new RelayCommand(GivenParam);
            ParamConstCommand = new RelayCommand(ParamConst);

            // Начальное окно
            CurrentView = new GivenParametersVM();
        }
    }
}

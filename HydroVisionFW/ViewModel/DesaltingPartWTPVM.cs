using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionFW.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HydroVisionDesign.ViewModel
{
    internal class DesaltingPartWTPVM : ViewModelBase
    {
        #region Свойство Hidden

        private bool _IsHiddenFAAProperty = false;
        /// <summary>Свойство для открытия и сокрытия элементов xaml DirectFlow</summary>
        public bool IsHiddenFAAProperty
        {
            get => _IsHiddenFAAProperty;
            set => Set(ref _IsHiddenFAAProperty, value);
        }
        #endregion

        #region Свойство textBox 

        private double _FiltrationArea;
        /// <summary>Свойство для Площадь фильтрования</summary>
        public double FiltrationArea
        {
            get => _FiltrationArea;
            set => Set(ref _FiltrationArea, value);
        }

        private double _FiltrationSpeed;
        /// <summary>Свойство для Скорость фильтрования</summary>
        public double FiltrationSpeed
        {
            get => _FiltrationSpeed;
            set => Set(ref _FiltrationSpeed, value);
        }

        private double _WaterConsumptionPerFilter;
        /// <summary>Свойство для Расход воды на фильтр</summary>
        public double WaterConsumptionPerFilter
        {
            get => _WaterConsumptionPerFilter;
            set => Set(ref _WaterConsumptionPerFilter, value);
        }

        private double _FiltrationAreaOfEachFilter;
        /// <summary>Свойство для Площадь фильтрации каждого фильтра</summary>
        public double FiltrationAreaOfEachFilter
        {
            get => _FiltrationAreaOfEachFilter;
            set => Set(ref _FiltrationAreaOfEachFilter, value);
        }

        private double _DesignFilterDiameter;
        /// <summary>Свойство для Расчетный диаметр фильтра</summary>
        public double DesignFilterDiameter
        {
            get => _DesignFilterDiameter;
            set => Set(ref _DesignFilterDiameter, value);
        }

        private double _FilterArea;
        /// <summary>Свойство для Площадь фильтра</summary>
        public double FilterArea
        {
            get => _FilterArea;
            set => Set(ref _FilterArea, value);
        }

        private double _FilterCycleDuration;
        /// <summary>Свойство для продолжительность фильтроцикла</summary>
        public double FilterCycleDuration
        {
            get => _FilterCycleDuration;
            set => Set(ref _FilterCycleDuration, value);
        }

        private double _NumberOfRegenerationsPerDay;
        /// <summary>Свойство для количество регенераций в сутки</summary>
        public double NumberOfRegenerationsPerDay
        {
            get => _NumberOfRegenerationsPerDay;
            set => Set(ref _NumberOfRegenerationsPerDay, value);
        }

        private double _VolumeOfIonExchangeMaterialsInOneFilter;
        /// <summary>Свойство для обьем ионитных материалов в один фильтр</summary>
        public double VolumeOfIonExchangeMaterialsInOneFilter
        {
            get => _VolumeOfIonExchangeMaterialsInOneFilter;
            set => Set(ref _VolumeOfIonExchangeMaterialsInOneFilter, value);
        }

        private double _VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion;
        /// <summary>Свойство для обьем ионитных материалов в один фильтр катионов или анионов</summary>
        public double VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion
        {
            get => _VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion;
            set => Set(ref _VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion, value);
        }

        private double _VolumeOfIonExchangeMaterialsInGroupFilter;
        /// <summary>Свойство для обьем ионитных материалов в группу фильтров</summary>
        public double VolumeOfIonExchangeMaterialsInGroupFilter
        {
            get => _VolumeOfIonExchangeMaterialsInGroupFilter;
            set => Set(ref _VolumeOfIonExchangeMaterialsInGroupFilter, value);
        }

        private double _VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion;
        /// <summary>Свойство для обьем ионитных материалов в группу фильтров катионов или анионов</summary>
        public double VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion
        {
            get => _VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion;
            set => Set(ref _VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion, value);
        }

        private double _WaterConsumptionForOwnNeedsCation;
        /// <summary>Свойство для расход воды на собственные нужды катион</summary>
        public double WaterConsumptionForOwnNeedsCation
        {
            get => _WaterConsumptionForOwnNeedsCation;
            set => Set(ref _WaterConsumptionForOwnNeedsCation, value);
        }

        private double _ConsumptionOfChemicalReagentsCation;
        /// <summary>Свойство для расход хим реагентов катион</summary>
        public double ConsumptionOfChemicalReagentsCation
        {
            get => _ConsumptionOfChemicalReagentsCation;
            set => Set(ref _ConsumptionOfChemicalReagentsCation, value);
        }

        private double _TechnicalProductConsumptionCation;
        /// <summary>Свойство для расход технического продукта катион</summary>
        public double TechnicalProductConsumptionCation
        {
            get => _TechnicalProductConsumptionCation;
            set => Set(ref _TechnicalProductConsumptionCation, value);
        }

        private double _DailyConsumptionOfChemicalReagentCation;
        /// <summary>Свойство для суточный расход хим реагента катион</summary>
        public double DailyConsumptionOfChemicalReagentCation
        {
            get => _DailyConsumptionOfChemicalReagentCation;
            set => Set(ref _DailyConsumptionOfChemicalReagentCation, value);
        }

        private double _WaterConsumptionForOwnNeedsAnion;
        /// <summary>Свойство для расход воды на собственные нужды анион</summary>
        public double WaterConsumptionForOwnNeedsAnion
        {
            get => _WaterConsumptionForOwnNeedsAnion;
            set => Set(ref _WaterConsumptionForOwnNeedsAnion, value);
        }

        private double _ConsumptionOfChemicalReagentsAnion;
        /// <summary>Свойство для расход хим реагентов анион</summary>
        public double ConsumptionOfChemicalReagentsAnion
        {
            get => _ConsumptionOfChemicalReagentsAnion;
            set => Set(ref _ConsumptionOfChemicalReagentsAnion, value);
        }

        private double _TechnicalProductConsumptionAnion;
        /// <summary>Свойство для расход технического продукта анион</summary>
        public double TechnicalProductConsumptionAnion
        {
            get => _TechnicalProductConsumptionAnion;
            set => Set(ref _TechnicalProductConsumptionAnion, value);
        }

        private double _DailyConsumptionOfChemicalReagentAnion;
        /// <summary>Свойство для суточный расход хим реагента анион</summary>
        public double DailyConsumptionOfChemicalReagentAnion
        {
            get => _DailyConsumptionOfChemicalReagentAnion;
            set => Set(ref _DailyConsumptionOfChemicalReagentAnion, value);
        }

        private double _WaterConsumptionForNextGroupOfFilters;
        /// <summary>Свойство для расход воды на следующую группу фильтров</summary>
        public double WaterConsumptionForNextGroupOfFilters
        {
            get => _WaterConsumptionForNextGroupOfFilters;
            set => Set(ref _WaterConsumptionForNextGroupOfFilters, value);
        }

        #endregion



        #region Команды
        #region LeftBtnA1Command
        /// <summary>Нажатие левой кнопки по А1</summary>
        public ICommand LeftBtnA1Command { get; }
        private void OnLeftBtnA1Command(object obj)
        {
            IsHiddenFAAProperty = true;
        }
        #endregion

        #region LeftDoubleBtnA1Command
        /// <summary>Нажатие дабл левой кнопки по А1</summary>
        public ICommand LeftDoubleBtnA1Command { get; }
        private void OnLeftDoubleBtnA1Command(object obj)
        {
            FilterA1Window filterA1 = new FilterA1Window();
            filterA1.Show();
        }
        #endregion

        #region LeftBtnGridCommand
        /// <summary>Нажатие левой кнопки по Grid </summary>
        public ICommand LeftBtnGridCommand { get; }
        private void OnLeftBtnGridCommand(object obj)
        {
            IsHiddenFAAProperty = false;
        }
        #endregion

        #endregion
        public DesaltingPartWTPVM() 
        {
            #region Команды
            LeftBtnA1Command = new RelayCommand(OnLeftBtnA1Command);
            LeftDoubleBtnA1Command = new RelayCommand(OnLeftDoubleBtnA1Command);
            LeftBtnGridCommand = new RelayCommand(OnLeftBtnGridCommand);
            #endregion

        }
    }
}

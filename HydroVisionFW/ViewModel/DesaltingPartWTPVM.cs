using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.Calculations;
using HydroVisionFW.Services.DataStorages;
using HydroVisionFW.View;
using HydroVisionFW.ViewModel;
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

        #region блоки

        private bool _IsHiddenCationProperty = false;
        /// <summary>Свойство для скрытия свойств Катионов/summary>
        public bool IsHiddenCationProperty
        {
            get => _IsHiddenCationProperty;
            set => Set(ref _IsHiddenCationProperty, value);
        }

        private bool _IsHiddenAnionProperty = false;
        /// <summary>Свойство для скрытия свойств Анионов/summary>
        public bool IsHiddenAnionProperty
        {
            get => _IsHiddenAnionProperty;
            set => Set(ref _IsHiddenAnionProperty, value);
        }

        #endregion

        private bool _IsHiddenFilterProperty = false;
        /// <summary>Свойство для скрытия свойств ФСД</summary>
        public bool IsHiddenFilterProperty
        {
            get => _IsHiddenFilterProperty;
            set => Set(ref _IsHiddenFilterProperty, value);
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

        #region LeftBtnAndDoubleA1Command
        /// <summary>Нажатие левой кнопки по А1</summary>
        public ICommand LeftBtnA1Command { get; }
        private void OnLeftBtnA1Command(object obj)
        {
        }

        /// <summary>Нажатие дабл левой кнопки по А1</summary>
        public ICommand LeftDoubleBtnA1Command { get; }
        private void OnLeftDoubleBtnA1Command(object obj)
        {
            DataStorage.Instance.ViewModel = 0;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Show();
        }
        #endregion

        #region LeftBtnAndDoubleMAFCommand
        /// <summary>Нажатие левой кнопки по ФСД</summary>
        public ICommand LeftBtnMAFCommand { get; }
        private void OnLeftBtnMAFCommand(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenCationProperty = true;
            IsHiddenAnionProperty = true;

            FillTextBoxMAF();
        }

        /// <summary>Нажатие дабл левой кнопки по ФСД</summary>
        public ICommand LeftDoubleBtnMAFCommand { get; }
        private void OnLeftDoubleBtnMAFCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 1;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Show();
            mixed.Closed += MAFWindow_Closed;
        }

        #endregion

        #region LeftBtnGridCommand
        /// <summary>Нажатие левой кнопки по Grid </summary>
        public ICommand LeftBtnGridCommand { get; }
        private void OnLeftBtnGridCommand(object obj)
        {
            IsHiddenFilterProperty = false;
        }
        #endregion

        #region LeftBtnAndDoubleA2Command
        /// <summary>Нажатие левой кнопки по A2</summary>
        public ICommand LeftBtnA2Command { get; }
        private void OnLeftBtnA2Command(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = true;

            FillTextBoxA2();

        }

        /// <summary>Нажатие дабл левой кнопки по A2</summary>
        public ICommand LeftDoubleBtnA2Command { get; }
        private void OnLeftDoubleBtnA2Command(object obj)
        {
            DataStorage.Instance.ViewModel = 2;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Show();
            mixed.Closed += A2Window_Closed;
        }

        #endregion

        #region LeftBtnAndDoubleH2Command
        /// <summary>Нажатие левой кнопки по H2</summary>
        public ICommand LeftBtnH2Command { get; }
        private void OnLeftBtnH2Command(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenCationProperty = true;
            IsHiddenAnionProperty = false;

            FillTextBoxH2();

        }

        /// <summary>Нажатие дабл левой кнопки по H2</summary>
        public ICommand LeftDoubleBtnH2Command { get; }
        private void OnLeftDoubleBtnH2Command(object obj)
        {
            DataStorage.Instance.ViewModel = 3;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Show();
            mixed.Closed += H2Window_Closed;
        }

        #endregion

        #endregion


        public DesaltingPartWTPVM() 
        {
            #region Команды
            LeftBtnA1Command = new RelayCommand(OnLeftBtnA1Command);
            LeftDoubleBtnA1Command = new RelayCommand(OnLeftDoubleBtnA1Command);

            LeftBtnMAFCommand = new RelayCommand(OnLeftBtnMAFCommand);
            LeftDoubleBtnMAFCommand = new RelayCommand(OnLeftDoubleBtnMAFCommand);

            LeftBtnGridCommand = new RelayCommand(OnLeftBtnGridCommand);

            LeftBtnA2Command = new RelayCommand(OnLeftBtnA2Command);
            LeftDoubleBtnA2Command = new RelayCommand(OnLeftDoubleBtnA2Command);

            LeftBtnH2Command = new RelayCommand(OnLeftBtnH2Command);
            LeftDoubleBtnH2Command = new RelayCommand(OnLeftDoubleBtnH2Command);

            #endregion

        }



  



        #region MAF
        /// <summary>Вызов метода после закрытия MAFWindow</summary>
        private void MAFWindow_Closed(object sender, EventArgs e)
        {
            CalcMAF calcMAF = new CalcMAF();
            calcMAF.Calculations();
            FillTextBoxMAF();

        }


        /// <summary>Заполнение данными из MAFStorage свойств textBox</summary>
        private void FillTextBoxMAF()
        {
            FiltrationArea = MAFStorage.Instance.F;
            FiltrationSpeed = MAFStorage.Instance.w;
            WaterConsumptionPerFilter = DataStorage.Instance.PerfomanceWTP;
            FiltrationAreaOfEachFilter = MAFStorage.Instance.f_p;
            DesignFilterDiameter = MAFStorage.Instance.d_p;
            FilterArea = MAFStorage.Instance.f_ct;
            FilterCycleDuration = MAFStorage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = MAFStorage.Instance.n;

            VolumeOfIonExchangeMaterialsInOneFilter = MAFStorage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = MAFStorage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = MAFStorage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = MAFStorage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsCation = MAFStorage.Instance.g_cnK;
            ConsumptionOfChemicalReagentsCation = MAFStorage.Instance.G_100pK;
            TechnicalProductConsumptionCation = MAFStorage.Instance.G_texK;
            DailyConsumptionOfChemicalReagentCation = MAFStorage.Instance.G_cutK;

            WaterConsumptionForOwnNeedsAnion = MAFStorage.Instance.g_cnA;
            ConsumptionOfChemicalReagentsAnion = MAFStorage.Instance.G_100pA;
            TechnicalProductConsumptionAnion = MAFStorage.Instance.G_texA;
            DailyConsumptionOfChemicalReagentAnion = MAFStorage.Instance.G_cutA;

            WaterConsumptionForNextGroupOfFilters = MAFStorage.Instance.Q_br;
        }

        #endregion

        #region A2

        /// <summary>Вызов метода после закрытия A2Window</summary>
        private void A2Window_Closed(object sender, EventArgs e)
        {
            CalcA2 calcA2 = new CalcA2();
            calcA2.Calculations();
            FillTextBoxA2();


        }

        /// <summary>Заполнение данными из A2Storage свойств textBox</summary>
        private void FillTextBoxA2()
        {
            FiltrationArea = A2Storage.Instance.F;
            FiltrationSpeed = A2Storage.Instance.w;
            WaterConsumptionPerFilter = MAFStorage.Instance.Q_br;
            FiltrationAreaOfEachFilter = A2Storage.Instance.f_p;
            DesignFilterDiameter = A2Storage.Instance.d_p;
            FilterArea = A2Storage.Instance.f_ct;
            FilterCycleDuration = A2Storage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = A2Storage.Instance.n;
            VolumeOfIonExchangeMaterialsInOneFilter = A2Storage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = A2Storage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = A2Storage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = A2Storage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsAnion = A2Storage.Instance.g_cnA;
            ConsumptionOfChemicalReagentsAnion = A2Storage.Instance.G_100pA;
            TechnicalProductConsumptionAnion = A2Storage.Instance.G_texA;
            DailyConsumptionOfChemicalReagentAnion = A2Storage.Instance.G_cutA;

            WaterConsumptionForNextGroupOfFilters = A2Storage.Instance.Q_br;
        }

        #endregion

        #region H2

        /// <summary>Вызов метода после закрытия H2Window</summary>
        private void H2Window_Closed(object sender, EventArgs e)
        {
            CalcH2 calc = new CalcH2();
            calc.Calculations();
            FillTextBoxH2();


        }

        /// <summary>Заполнение данными из H2Storage свойств textBox</summary>
        private void FillTextBoxH2()
        {
            FiltrationArea = H2Storage.Instance.F;
            FiltrationSpeed = H2Storage.Instance.w;
            WaterConsumptionPerFilter = H2Storage.Instance.Q_br;
            FiltrationAreaOfEachFilter = H2Storage.Instance.f_p;
            DesignFilterDiameter = H2Storage.Instance.d_p;
            FilterArea = H2Storage.Instance.f_ct;
            FilterCycleDuration = H2Storage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = H2Storage.Instance.n;

            VolumeOfIonExchangeMaterialsInOneFilter = H2Storage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = H2Storage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = H2Storage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = H2Storage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsCation = H2Storage.Instance.g_cnK;
            ConsumptionOfChemicalReagentsCation = H2Storage.Instance.G_100pK;
            TechnicalProductConsumptionCation = H2Storage.Instance.G_texK;
            DailyConsumptionOfChemicalReagentCation = H2Storage.Instance.G_cutK;

            WaterConsumptionForNextGroupOfFilters = H2Storage.Instance.Q_br;
        }

        #endregion
    }
}

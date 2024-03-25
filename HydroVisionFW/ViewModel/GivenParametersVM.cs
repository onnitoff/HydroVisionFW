using HydroVisionDesign.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionDesign.Services.DataStorages;
using MathWater;
using HydroVisionDesign.Services.Calculations;
using System.Collections.ObjectModel;
using HydroVisionFW.Model.DataBaseModel;
using HydroVisionFW.Model;
using System.Threading;
using System.Data.Entity;

namespace HydroVisionDesign.ViewModel
{
    internal class GivenParametersVM : ViewModelBase
    {
        #region Показатели воды
        private double _Ca = DataStorage.Instance.Final_Ca;

        /// <summary>Свойство textBox Ca</summary>
        public double Ca
        {
            get => _Ca;
            set => Set(ref _Ca, value);
        }

        //private double _Mg;

        ///// <summary>Свойство textBox Mg</summary>
        //public double Mg
        //{
        //    get => _Mg;
        //    set => Set(ref _Mg, value);
        //}

        private double _Na = DataStorage.Instance.Init_Na;

        /// <summary>Свойство textBox Na</summary>
        public double Na
        {
            get => _Na;
            set => Set(ref _Na, value);
        }

        private double _HCO = DataStorage.Instance.Final_HCO;

        /// <summary>Свойство textBox HCO</summary>
        public double HCO
        {
            get => _HCO;
            set => Set(ref _HCO, value);
        }

        private double _SO = DataStorage.Instance.Init_SO;

        /// <summary>Свойство textBox SO</summary>
        public double SO
        {
            get => _SO;
            set => Set(ref _SO, value);
        }

        private double _Cl = DataStorage.Instance.Init_Cl;

        /// <summary>Свойство textBox Cl</summary>
        public double Cl
        {
            get => _Cl;
            set => Set(ref _Cl, value);
        }

        private double _NO = DataStorage.Instance.Init_NO;

        /// <summary>Свойство textBox NO</summary>
        public double NO
        {
            get => _NO;
            set => Set(ref _NO, value);
        }

        private double _SiO = DataStorage.Instance.Init_SiO;

        /// <summary>Свойство textBox SiO</summary>
        public double SiO
        {
            get => _SiO;
            set => Set(ref _SiO, value);
        }

        private double _Oxidability = DataStorage.Instance.Oxidability;

        /// <summary>Свойство textBox Окисляемость</summary>
        public double Oxidability
        {
            get => _Oxidability;
            set => Set(ref _Oxidability, value);
        }

        private double _DryResidue = DataStorage.Instance.DryResidue;

        /// <summary>Свойство textBox Сухой остаток</summary>
        public double DryResidue
        {
            get => _DryResidue;
            set => Set(ref _DryResidue, value);
        }

        private double _OverallHardness = DataStorage.Instance.OverallHardness;

        /// <summary>Свойство textBox Жесткость общая</summary>
        public double OverallHardness
        {
            get => _OverallHardness;
            set => Set(ref _OverallHardness, value);
        }

        private string _UnitOfMeasurement;

        /// <summary>Свойство единицы измерений</summary>
        public string UnitOfMeasurement
        {
            get => _UnitOfMeasurement;
            set => Set(ref _UnitOfMeasurement, value);
        }

        #endregion

        #region Оборудование

        private double _ElectricPower = DataStorage.Instance.ElectricPower;

        /// <summary>Свойство textBox Электрическая мощность</summary>
        public double ElectricPower
        {
            get => _ElectricPower;
            set => Set(ref _ElectricPower, value);
        }

        private int _NumberOfBoilersFirst = DataStorage.Instance.NumberOfBoilersFirst;

        /// <summary>Свойство textBox Количество котлов</summary>
        public int NumberOfBoilersFirst
        {
            get => _NumberOfBoilersFirst;
            set => Set(ref _NumberOfBoilersFirst, value);
        }

        private int _NumberOfBoilersSecond = DataStorage.Instance.NumberOfBoilersSecond;

        /// <summary>Свойство textBox Количество котлов</summary>
        public int NumberOfBoilersSecond
        {
            get => _NumberOfBoilersSecond;
            set => Set(ref _NumberOfBoilersSecond, value);
        }

        private int _NumberOfTurbinesFirst = DataStorage.Instance.NumberOfTurbinesFirst;

        /// <summary>Свойство textBox Количество турбин</summary>
        public int NumberOfTurbinesFirst
        {
            get => _NumberOfTurbinesFirst;
            set => Set(ref _NumberOfTurbinesFirst, value);
        }

        private int _NumberOfTurbinesSecond = DataStorage.Instance.NumberOfTurbinesSecond;

        /// <summary>Свойство textBox Количество турбин</summary>
        public int NumberOfTurbinesSecond
        {
            get => _NumberOfTurbinesSecond;
            set => Set(ref _NumberOfTurbinesSecond, value);
        }

        private double _VacationCouple = DataStorage.Instance.VacationCouple;

        /// <summary>Свойство textBox Отпуск пара</summary>
        public double VacationCouple
        {
            get => _VacationCouple;
            set => Set(ref _VacationCouple, value);
        }

        private double _Losses = DataStorage.Instance.Losses;

        /// <summary>Свойство textBox Потери</summary>
        public double Losses
        {
            get => _Losses;
            set => Set(ref _Losses, value);
        }

        private double _BlowdownLosses = DataStorage.Instance.BlowdownLosses;

        /// <summary>Свойство textBox Потери с продувкой</summary>
        public double BlowdownLosses
        {
            get => _BlowdownLosses;
            set => Set(ref _BlowdownLosses, value);
        }

        #endregion

        #region Выбор оборудования

        public ObservableCollection<Boilers> BoilerItems { get; set; }
        private Boilers _SelectedBoilerFirstItem;
        public Boilers SelectedBoilerFirstItem
        {
            get => _SelectedBoilerFirstItem;

            set => Set(ref _SelectedBoilerFirstItem, value);
        }

        private Boilers _SelectedBoilerSecondItem;
        public Boilers SelectedBoilerSecondItem
        {
            get => _SelectedBoilerSecondItem;

            set => Set(ref _SelectedBoilerSecondItem, value);
        }

        public ObservableCollection<CoolingWaterFlowOnTurbine> TubineItems { get; set; }
        private CoolingWaterFlowOnTurbine _SelectedTurbineFirstItem;
        public CoolingWaterFlowOnTurbine SelectedTurbineFirstItem
        {
            get => _SelectedTurbineFirstItem;
            set => Set(ref _SelectedTurbineFirstItem, value);
        }

        private CoolingWaterFlowOnTurbine _SelectedTurbineSecondItem;
        public CoolingWaterFlowOnTurbine SelectedTurbineSecondItem
        {
            get => _SelectedTurbineSecondItem;
            set => Set(ref _SelectedTurbineSecondItem, value);
        }

        public ObservableCollection<FuelModel> FuelItems { get; set; }
        private FuelModel _SelectedFuelItem;
        public FuelModel SelectedFuelItem
        {
            get => _SelectedFuelItem;
            set => Set(ref _SelectedFuelItem, value);
        }

        #endregion




        #region Команды
        #region ClearTextBoxCommand
        /// <summary>Кнопка очистки всех textBox</summary>
        public ICommand ClearTextBoxCommand { get; }
        private void OnClearTextBoxCommand(object obj)
        {
            Na = 0;
            SO = 0;
            Cl = 0;
            SiO = 0;
            Oxidability = 0;
            DryResidue = 0;
            OverallHardness = 0;
            Ca = 0;
            HCO = 0;

        }
        #endregion

        #region ApplyCommand
        /// <summary>Кнопка применить параметры</summary>
        public ICommand ApplyCommand { get; }
        private void OnApplyCommand(object obj)
        {
            DataStorage.Instance.Final_Ca = Ca;
            DataStorage.Instance.Init_Na = Na;
            DataStorage.Instance.Final_HCO = HCO;
            DataStorage.Instance.Init_SO = SO;
            DataStorage.Instance.Init_Cl = Cl;
            DataStorage.Instance.Init_NO = NO;
            DataStorage.Instance.Init_SiO = SiO;
            DataStorage.Instance.Oxidability = Oxidability;
            DataStorage.Instance.DryResidue = DryResidue;
            DataStorage.Instance.OverallHardness = OverallHardness;
            Calculations calculations = new Calculations();
            calculations.RecalculationOfQualityIndicators();

            DataStorage.Instance.ElectricPower = ElectricPower;
            DataStorage.Instance.NumberOfBoilersFirst = NumberOfBoilersFirst;
            DataStorage.Instance.NumberOfBoilersSecond = NumberOfBoilersSecond;
            DataStorage.Instance.NumberOfTurbinesFirst = NumberOfTurbinesFirst;
            DataStorage.Instance.NumberOfTurbinesSecond = NumberOfTurbinesSecond;
            DataStorage.Instance.VacationCouple = VacationCouple;
            DataStorage.Instance.Losses = Losses;
            DataStorage.Instance.BlowdownLosses = BlowdownLosses;
            // запись из бд для котла
            DataStorage.Instance.SelectedBoilerFirstItem = SelectedBoilerFirstItem.Id;
            DataStorage.Instance.BoilerTypeFirst = SelectedBoilerFirstItem.Type;
            DataStorage.Instance.BoilerPerfomanceFirst = SelectedBoilerFirstItem.Perfomance;

            DataStorage.Instance.SelectedBoilerSecondItem = SelectedBoilerSecondItem.Id;
            DataStorage.Instance.BoilerTypeSecond = SelectedBoilerSecondItem.Type;
            DataStorage.Instance.BoilerPerfomanceSecond = SelectedBoilerSecondItem.Perfomance;

            // запись из бд для турбины
            DataStorage.Instance.SelectedTurbineFirstItem = SelectedTurbineFirstItem.Id;
            DataStorage.Instance.WaterConsumptionFirst = (int)SelectedTurbineFirstItem.WaterConsumption;
            DataStorage.Instance.TurbinePerfomanceFirst = (int)SelectedTurbineFirstItem.Perfomance;
            DataStorage.Instance.TurbinePerfomanceSecond = (int)SelectedTurbineSecondItem.Perfomance;

            DataStorage.Instance.SelectedTurbineSecondItem = SelectedTurbineSecondItem.Id;
            DataStorage.Instance.WaterConsumptionSecond = (int)SelectedTurbineSecondItem.WaterConsumption;

            // запись для топлива
            DataStorage.Instance.SelectedFuelItem = SelectedFuelItem.Id;
            calculations.CalculationOfWTPPerformance();

            



        }
        #endregion

        #endregion

        public GivenParametersVM() 
        {
            UnitOfMeasurement = "мг/дм3";

            #region Команды
            ClearTextBoxCommand = new RelayCommand(OnClearTextBoxCommand);
            ApplyCommand = new RelayCommand(OnApplyCommand);
            #endregion

            Task.Run(async () => await GetBoilersAsync());
            Task.Run(async () => await GetTurbineAsync());
            GetFuel();
        }

        /// <summary>Обращение к базе данных</summary>
        /// <returns>ObservableCollection коллекция котлов</returns>
        private async Task GetBoilersAsync()
        {
            BoilerItems = new ObservableCollection<Boilers>();
            using (var context = new WaterContext())
            {
                await context.Boilers.ForEachAsync(boiler =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BoilerItems.Add(boiler);

                    });
                });
                if (BoilerItems.Count > 0)
                    SelectedBoilerFirstItem = BoilerItems[DataStorage.Instance.SelectedBoilerFirstItem - 1];
                    SelectedBoilerSecondItem = BoilerItems[DataStorage.Instance.SelectedBoilerSecondItem - 1];
            }
        }

        /// <summary>Обращение к базе данных</summary>
        /// <returns>ObservableCollection коллекция турбин</returns>
        private async Task GetTurbineAsync()
        {
            TubineItems = new ObservableCollection<CoolingWaterFlowOnTurbine>();
            using (var context = new WaterContext())
            {
                await context.CoolingWaterFlowOnTurbine.ForEachAsync(turbine =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        TubineItems.Add(turbine);
                    });
                });
                if (TubineItems.Count > 0)
                    SelectedTurbineFirstItem = TubineItems[DataStorage.Instance.SelectedTurbineFirstItem - 1];
                    SelectedTurbineSecondItem = TubineItems[DataStorage.Instance.SelectedTurbineSecondItem - 1];
            }
        }


        /// <summary>
        /// ObservableCollection коллекция топлива
        /// </summary>
        private void GetFuel()
        {
            FuelItems = new ObservableCollection<FuelModel>();
            FuelItems.Add(new FuelModel { Id = 1, Name = "Газ" });
            FuelItems.Add(new FuelModel { Id = 2, Name = "Мазут" });
            SelectedFuelItem = FuelItems[DataStorage.Instance.SelectedFuelItem - 1];
        }
    }
}

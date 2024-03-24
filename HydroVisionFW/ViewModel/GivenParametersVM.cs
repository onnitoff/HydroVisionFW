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

        private double _BoilerProductivity = DataStorage.Instance.BoilerProductivity;

        /// <summary>Свойство textBox Производительность котла</summary>
        public double BoilerProductivity
        {
            get => _BoilerProductivity;
            set => Set(ref _BoilerProductivity, value);
        }

        private int _NumberOfBoilers = DataStorage.Instance.NumberOfBoilers;

        /// <summary>Свойство textBox Количество котлов</summary>
        public int NumberOfBoilers
        {
            get => _NumberOfBoilers;
            set => Set(ref _NumberOfBoilers, value);
        }

        //private int _TurbineType = DataStorage.Instance.TurbineType; // ПОДУМАТЬ НАД БД

        ///// <summary>Свойство textBox Тип турбины</summary>
        //public int TurbineType
        //{
        //    get => _TurbineType;
        //    set => Set(ref _TurbineType, value);
        //}

        private int _NumberOfTurbines = DataStorage.Instance.NumberOfTurbines;

        /// <summary>Свойство textBox Количество турбин</summary>
        public int NumberOfTurbines
        {
            get => _NumberOfTurbines;
            set => Set(ref _NumberOfTurbines, value);
        }

        //private int _FuelType = DataStorage.Instance.FuelType;

        ///// <summary>Свойство textBox Тип топлива</summary>
        //public int FuelType
        //{
        //    get => _FuelType;
        //    set => Set(ref _FuelType, value);
        //}

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

        private int _BoilerType;

        /// <summary>Свойство comboBox Тип котла</summary>
        public int BoilerType
        {
            get => _BoilerType;
            set => Set(ref _BoilerType, value);
        }

        private int _TurbineType;

        /// <summary>Свойство comboBox Тип турбины</summary>
        public int TurbineType
        {
            get => _TurbineType;
            set => Set(ref _TurbineType, value);
        }

        private int _FuelType;

        /// <summary>Свойство comboBox Тип котла</summary>
        public int FuelType
        {
            get => _FuelType;
            set => Set(ref _FuelType, value);
        }

        #endregion


        #region Коллекции

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public ObservableCollection<Boilers> BoilerItems { get; set; }
        private Boilers _SelectedItem;
        public Boilers SelectredItem
        {
            get => _SelectedItem;

            set { Set(ref _SelectedItem, value);

            }
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
            DataStorage.Instance.BoilerProductivity = BoilerProductivity;
            DataStorage.Instance.NumberOfBoilers = NumberOfBoilers;
            DataStorage.Instance.TurbineType = TurbineType;
            DataStorage.Instance.NumberOfTurbines = NumberOfTurbines;
            DataStorage.Instance.FuelType = FuelType;
            DataStorage.Instance.VacationCouple = VacationCouple;
            DataStorage.Instance.Losses = Losses;
            DataStorage.Instance.BlowdownLosses = BlowdownLosses;
            calculations.CalculationOfWTPPerformance();

            DataStorage.Instance.SelectredItem = SelectredItem.Id;
            DataStorage.Instance.BoilerType = SelectredItem.Type;
            DataStorage.Instance.BoilerProductivity = SelectredItem.Perfomance;


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

            using (var context = new WaterContext())
            {
                BoilerItems = new ObservableCollection<Boilers>();
                var boilers = context.Boilers;
                foreach (var boiler in boilers)
                {
                    BoilerItems.Add(boiler);
                }
                if (BoilerItems.Count > 0)
                    SelectredItem = BoilerItems[DataStorage.Instance.SelectredItem - 1];
            }



        }
    }
}

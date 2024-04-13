using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Model;
using HydroVisionFW.Model.DataBaseModel;
using HydroVisionFW.Services.Calculations;
using HydroVisionFW.Services.DataRepository;
using HydroVisionFW.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace HydroVisionFW.ViewModel
{
    internal class EquipmentWindowVM : ViewModelBase
    {

        #region IsHidden Prop

        private bool _IsHiddenMAScheme = false;
        /// <summary>Свойство для сокрытия схемы ФСД</summary>
        public bool IsHiddenMAScheme
        {
            get => _IsHiddenMAScheme;
            set => Set(ref _IsHiddenMAScheme, value);
        }

        private bool _IsHiddenA2Scheme = false;
        /// <summary>Свойство для сокрытия схемы A2</summary>
        public bool IsHiddenA2Scheme
        {
            get => _IsHiddenA2Scheme;
            set => Set(ref _IsHiddenA2Scheme, value);
        }

        private bool _IsHiddenH2Scheme = false;
        /// <summary>Свойство для сокрытия схемы H2</summary>
        public bool IsHiddenH2Scheme
        {
            get => _IsHiddenH2Scheme;
            set => Set(ref _IsHiddenH2Scheme, value);
        }

        private bool _IsHiddenA1Scheme = false;
        /// <summary>Свойство для сокрытия схемы A1</summary>
        public bool IsHiddenA1Scheme
        {
            get => _IsHiddenA1Scheme;
            set => Set(ref _IsHiddenA1Scheme, value);
        }

        private bool _IsHiddenH1Scheme = false;
        /// <summary>Свойство для сокрытия схемы H1</summary>
        public bool IsHiddenH1Scheme
        {
            get => _IsHiddenH1Scheme;
            set => Set(ref _IsHiddenH1Scheme, value);
        }

        private bool _IsHiddenA2SimplifedScheme = false;
        /// <summary>Свойство для сокрытия схемы A2Simplifed</summary>
        public bool IsHiddenA2SimplifiedScheme
        {
            get => _IsHiddenA2SimplifedScheme;
            set => Set(ref _IsHiddenA2SimplifedScheme, value);
        }

        private bool _IsHiddenNaScheme = false;
        /// <summary>Свойство для сокрытия схемы Na</summary>
        public bool IsHiddenNaScheme
        {
            get => _IsHiddenNaScheme;
            set => Set(ref _IsHiddenNaScheme, value);
        }

        private bool _IsHiddenBFScheme = false;
        /// <summary>Свойство для сокрытия схемы BF</summary>
        public bool IsHiddenBFScheme
        {
            get => _IsHiddenBFScheme;
            set => Set(ref _IsHiddenBFScheme, value);
        }

        private bool _IsHiddenClarifierScheme = false;
        /// <summary>Свойство для сокрытия схемы Clarifier</summary>
        public bool IsHiddenClarifierScheme
        {
            get => _IsHiddenClarifierScheme;
            set => Set(ref _IsHiddenClarifierScheme, value);
        }

        private bool _IsHiddenDecarbonizerScheme = false;
        /// <summary>Свойство для сокрытия схемы Decarbonizer</summary>
        public bool IsHiddenDecarbonizerScheme
        {
            get => _IsHiddenDecarbonizerScheme;
            set => Set(ref _IsHiddenDecarbonizerScheme, value);
        }

        private bool _IsHiddenPropFilter = false;
        /// <summary>Свойство для сокрытия свойств фильтров</summary>
        public bool IsHiddenPropFilter
        {
            get => _IsHiddenPropFilter;
            set => Set(ref _IsHiddenPropFilter, value);
        }

        private bool _IsHiddenPropBF = false;
        /// <summary>Свойство для сокрытия свойств ОФ <summary>
        public bool IsHiddenPropBF
        {
            get => _IsHiddenPropBF;
            set => Set(ref _IsHiddenPropBF, value);
        }

        private bool _IsHiddenPropClarifier = false;
        /// <summary>Свойство для сокрытия свойств Осветлителя <summary>
        public bool IsHiddenPropClarifier
        {
            get => _IsHiddenPropClarifier;
            set => Set(ref _IsHiddenPropClarifier, value);
        }

        private bool _IsHiddenPropDecarbonizer = false;
        /// <summary>Свойство для сокрытия свойств Декарбонизатор <summary>
        public bool IsHiddenPropDecarbonizer
        {
            get => _IsHiddenPropDecarbonizer;
            set => Set(ref _IsHiddenPropDecarbonizer, value);
        }

        #endregion

        #region textBox Prop

        private double _DesignDiameter;
        /// <summary>Свойство для textBox Расчетный диаметр</summary>
        public double DesignDiameter
        {
            get => _DesignDiameter;
            set => Set(ref _DesignDiameter, value);
        }

        private int _FilterCount;
        /// <summary>Свойство для textBox Количество фильтров</summary>
        public int FilterCount
        {
            get => _FilterCount;
            set => Set(ref _FilterCount, value);
        }

        /// <summary>Коллекция для ComboBox Марка ионита</summary>
        public List<BrandOfIonModel> BrandOfIonItems { get; set; }

        private BrandOfIonModel _SelectedBrandOfIon;
        /// <summary>Свойство для Select ComboBox Марка ионита</summary>
        public BrandOfIonModel SelectedBrandOfIon
        {
            get => _SelectedBrandOfIon;
            set => Set(ref _SelectedBrandOfIon, value);
        }

        private double _FiltrationSpeed;
        /// <summary>Свойство для textBox Скорость фильтрации</summary>
        public double FiltrationSpeed
        {
            get => _FiltrationSpeed;
            set => Set(ref _FiltrationSpeed, value);
        }

        /// <summary>Коллекция для ComboBox Фильтр</summary>
        public List<FilterModel> SuitableFilter { get; set; }

        private FilterModel _SelectedSuitableFilter;
        /// <summary>Свойство для Select ComboBox Фильтр</summary>
        public FilterModel SelectedSuitableFilter
        {
            get => _SelectedSuitableFilter;
            set => Set(ref _SelectedSuitableFilter, value);
        }

        /// <summary>Коллекция для ComboBox Осветлитель</summary>
        public List<ClarifierModel> SuitableClarifier { get; set; }

        private ClarifierModel _SelectedSuitableClarifier;
        /// <summary>Свойство для Select ComboBox Осветлитель</summary>
        public ClarifierModel SelectedSuitableClarifier
        {
            get => _SelectedSuitableClarifier;
            set => Set(ref _SelectedSuitableClarifier, value);
        }



        #endregion

        #region Команды

        #region ApplyBtnCommand
        /// <summary>Кнопка нажатия на принять</summary>
        public ICommand ApplyBtnCommand { get; }
        private void OnApplyBtnCommand(object obj)
        {
            switch (DataStorage.Instance.ViewModel)
            {
                case 0:
                    break;

                // открыт ФСД
                case 1:
                    {
                        RecordParamToStorage_MAF();
                    }
                    break;
                // открыт А2
                case 2:
                    {
                        RecordParamToStorage_A2();
                    }
                    break;
                // открыт H2
                case 3:
                    {
                        RecordParamToStorage_H2();
                    }
                    break;
                // открыт A1
                case 4:
                    {
                        RecordParamToStorage_A1();
                    }
                    break;
                // открыт H1
                case 5:
                    {
                        RecordParamToStorage_H1();
                    }
                    break;
                // открыт А2Simplifed
                case 6:
                    {
                        RecordParamToStorage_A2Simplifed();
                    }
                    break;
                // открыт Na
                case 7:
                    {
                        RecordParamToStorage_Na();
                    }
                    break;
                // открыт BF
                case 8:
                    {
                        RecordParamToStorage_BF();
                    }
                    break;
                // открыт Clarifier
                case 9:
                    {
                        RecordParamToStorage_Clarifier();
                    }
                    break;
                // открыт Decarbonizer
                case 10:
                    {
                        RecordParamToStorage_Decarbonizer();
                    }
                    break;
                default:
                    break;
            }

            Window activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            activeWindow?.Close();
        }
        #endregion

        #endregion


        public EquipmentWindowVM()
        {

            #region Команды
            ApplyBtnCommand = new RelayCommand(OnApplyBtnCommand);
            #endregion

            switch (DataStorage.Instance.ViewModel)
            {
                case 0:
                    break;
                // открыт ФСД
                case 1:
                    {
                        IsHiddenMAScheme = true;
                        IsHiddenPropFilter = true;
                        LoadAndCalcProperty_MAF();
                        GetComboBox_MAF();
                    }
                    break;
                // открыт А2
                case 2:
                    {
                        IsHiddenA2Scheme = true;
                        IsHiddenPropFilter = true;
                        LoadProperty_A2();
                        GetComboBox_A2();
                    }
                    break;
                // открыт H2
                case 3:
                    {
                        IsHiddenH2Scheme = true;
                        IsHiddenPropFilter = true;
                        LoadProperty_H2();
                        GetComboBox_H2();
                    }
                    break;
                // открыт A1
                case 4:
                    {
                        IsHiddenA1Scheme = true;
                        IsHiddenPropFilter = true;
                        LoadProperty_A1();
                        GetComboBox_A1();
                    }
                    break;
                // открыт H1
                case 5:
                    {
                        IsHiddenH1Scheme = true;
                        IsHiddenPropFilter = true;
                        LoadProperty_H1();
                        GetComboBox_H1();
                    }
                    break;
                // открыт А2Simplified
                case 6:
                    {
                        IsHiddenA2SimplifiedScheme = true;
                        IsHiddenPropFilter = true;
                        LoadProperty_A2Simplified();
                        GetComboBox_A2Simplified();
                    }
                    break;
                // открыт Na
                case 7:
                    {
                        IsHiddenNaScheme = true;
                        IsHiddenPropFilter = true;
                        LoadProperty_Na();
                        GetComboBox_Na();
                    }
                    break;
                    // открыт BF
                case 8:
                    {
                        IsHiddenBFScheme = true;
                        IsHiddenPropBF = true;
                        LoadProperty_BF();
                        GetComboBox_BF();
                    }
                    break;
                // открыт Clarifier
                case 9:
                    {
                        IsHiddenClarifierScheme = true;
                        IsHiddenPropClarifier = true;
                        LoadProperty_Clarifier();
                        GetComboBox_Clarifier();
                    }
                    break;
                // открыт Decarbonizer
                case 10:
                    {
                        IsHiddenDecarbonizerScheme = true;
                        IsHiddenPropDecarbonizer = true;
                        LoadProperty_Decarbonizer();
                        GetComboBox_Decarbonizer();
                    }
                    break;
                default:
                    MessageBox.Show("Ошибка, перезапустите приложение");
                    break;
            }
        }


        #region MAF
  
        private void LoadAndCalcProperty_MAF()
        {
            CalcMAF calc = new CalcMAF();
            calc.CaclFirstProperty();
            _DesignDiameter = MAFStorage.Instance.f_p;
            _FilterCount = MAFStorage.Instance.m;
            _FiltrationSpeed = MAFStorage.Instance.w;

        }

        private void GetComboBox_MAF()
        {
            DataRepository data = new DataRepository();
            int id = 7;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonMAFAsync();
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[MAFStorage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(id);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[MAFStorage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_MAF()
        {
            MAFStorage.Instance.bK = SelectedBrandOfIon.SpecificConsumptionCation;
            MAFStorage.Instance.P_iK = SelectedBrandOfIon.GeneralWaterConsumptionCation;
            MAFStorage.Instance.e_pK = SelectedBrandOfIon.WorkingExchangeCapacity;
            MAFStorage.Instance.e_pA = SelectedBrandOfIon.WorkingExchangeCapacity;
            MAFStorage.Instance.bA = SelectedBrandOfIon.SpecificConsumptionAnion;
            MAFStorage.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            MAFStorage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            MAFStorage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            MAFStorage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id;
            MAFStorage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 35;

            MAFStorage.Instance.m = FilterCount;
            MAFStorage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region A2

        private void LoadProperty_A2()
        {
            CalcA2 calc = new CalcA2();
            calc.CaclFirstProperty();
            _DesignDiameter = A2Storage.Instance.f_p;
            _FilterCount = A2Storage.Instance.m;
            _FiltrationSpeed = A2Storage.Instance.w;

        }

        private void GetComboBox_A2()
        {
            DataRepository data = new DataRepository();
            int idBrand = 9;
            int idFilter = 5;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync(idBrand);
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[A2Storage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[A2Storage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_A2()
        {
            A2Storage.Instance.e_pA = SelectedBrandOfIon.WorkingExchangeCapacity;
            A2Storage.Instance.bA = SelectedBrandOfIon.SpecificConsumptionCation;
            A2Storage.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            A2Storage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            A2Storage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            A2Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id - 10;
            A2Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 24;

            A2Storage.Instance.m = FilterCount;
            A2Storage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region A2Simplified

        private void LoadProperty_A2Simplified()
        {
            CalcA2Simplified calc = new CalcA2Simplified();
            calc.CaclFirstProperty();
            _DesignDiameter = A2StorageSimplified.Instance.f_p;
            _FilterCount = A2StorageSimplified.Instance.m;
            _FiltrationSpeed = A2StorageSimplified.Instance.w;

        }

        private void GetComboBox_A2Simplified()
        {
            DataRepository data = new DataRepository();
            int idBrand = 8;
            int idFilter = 5;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonA2SimplifiedAsync(idBrand);
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[A2StorageSimplified.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[A2StorageSimplified.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_A2Simplifed()
        {
            A2StorageSimplified.Instance.e_pA = SelectedBrandOfIon.WorkingExchangeCapacity;
            A2StorageSimplified.Instance.bA = SelectedBrandOfIon.SpecificConsumptionCation;
            A2StorageSimplified.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            A2StorageSimplified.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            A2StorageSimplified.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            A2StorageSimplified.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id;
            A2StorageSimplified.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 24;

            A2StorageSimplified.Instance.m = FilterCount;
            A2StorageSimplified.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region H2

        private void LoadProperty_H2()
        {
            CalcH2 calc = new CalcH2();
            calc.CaclFirstProperty();
            _DesignDiameter = H2Storage.Instance.f_p;
            _FilterCount = H2Storage.Instance.m;
            _FiltrationSpeed = H2Storage.Instance.w;

        }

        private void GetComboBox_H2()
        {
            DataRepository data = new DataRepository();
            int idBrand = 5;
            int idFilter = 5;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync(idBrand);
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[H2Storage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[H2Storage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_H2()
        {
            H2Storage.Instance.e_pK = SelectedBrandOfIon.WorkingExchangeCapacity;
            H2Storage.Instance.bK = SelectedBrandOfIon.SpecificConsumptionCation;
            H2Storage.Instance.P_iK = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            H2Storage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            H2Storage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            H2Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id - 6;
            H2Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 24;

            H2Storage.Instance.m = FilterCount;
            H2Storage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region A1

        private void LoadProperty_A1()
        {
            CalcA1 calc = new CalcA1();
            calc.CaclFirstProperty();
            _DesignDiameter = A1Storage.Instance.f_p;
            _FilterCount = A1Storage.Instance.m;
            _FiltrationSpeed = A1Storage.Instance.w;

        }

        private void GetComboBox_A1()
        {
            DataRepository data = new DataRepository();
            int idBrand = 7;
            int idFilter = 4;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync(idBrand);
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[A1Storage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[A1Storage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_A1()
        {
            A1Storage.Instance.e_pA = SelectedBrandOfIon.WorkingExchangeCapacity;
            A1Storage.Instance.bA = SelectedBrandOfIon.SpecificConsumptionCation;
            A1Storage.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            A1Storage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            A1Storage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            A1Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id - 8;
            A1Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 14;

            A1Storage.Instance.m = FilterCount;
            A1Storage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region H1

        private void LoadProperty_H1()
        {
            CalcH1 calc = new CalcH1();
            calc.CaclFirstProperty();
            _DesignDiameter = H1Storage.Instance.f_p;
            _FilterCount = H1Storage.Instance.m;
            _FiltrationSpeed = H1Storage.Instance.w;

        }

        private void GetComboBox_H1()
        {
            DataRepository data = new DataRepository();
            int idBrand = 4;
            int idFilter = 4;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync(idBrand);
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[H1Storage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[H1Storage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_H1()
        {
            H1Storage.Instance.e_pK = SelectedBrandOfIon.WorkingExchangeCapacity;
            H1Storage.Instance.bK = SelectedBrandOfIon.SpecificConsumptionCation;
            H1Storage.Instance.P_iK = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            H1Storage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            H1Storage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            H1Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id - 4;
            H1Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 14;

            H1Storage.Instance.m = FilterCount;
            H1Storage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region Na

        private void LoadProperty_Na()
        {
            CalcNa calc = new CalcNa();
            calc.CaclFirstProperty();
            _DesignDiameter = NaStorage.Instance.f_p;
            _FilterCount = NaStorage.Instance.m;
            _FiltrationSpeed = NaStorage.Instance.w;

        }

        private void GetComboBox_Na()
        {
            DataRepository data = new DataRepository();
            int idBrand = 1;
            int idFilter = 4;

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync(idBrand);
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[NaStorage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[NaStorage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_Na()
        {
            NaStorage.Instance.e_pK = SelectedBrandOfIon.WorkingExchangeCapacity;
            NaStorage.Instance.bK = SelectedBrandOfIon.SpecificConsumptionCation;
            NaStorage.Instance.P_iK = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            NaStorage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            NaStorage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            NaStorage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id;
            NaStorage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 14;

            NaStorage.Instance.m = FilterCount;
            NaStorage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region BF

        private void LoadProperty_BF()
        {
            CalcBF calc = new CalcBF();
            calc.CaclFirstProperty();
            _DesignDiameter = BFStorage.Instance.d_p;
            _FilterCount = BFStorage.Instance.m;
            _FiltrationSpeed = BFStorage.Instance.w;

        }

        private void GetComboBox_BF()
        {
            DataRepository data = new DataRepository();
            int idFilter = 1;

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterBFAsync(idFilter);
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[BFStorage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_BF()
        {
            BFStorage.Instance.d_ct = (double)SelectedSuitableFilter.Diameter / 1000;
            BFStorage.Instance.h = (double)SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            BFStorage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 1;

            BFStorage.Instance.m = FilterCount;
            BFStorage.Instance.w = FiltrationSpeed;
        }

        #endregion

        #region Clarifier

        private void LoadProperty_Clarifier()
        {
            CalcClarifier calc = new CalcClarifier();
            calc.CaclFirstProperty();
            _DesignDiameter = ClarifierStorage.Instance.v_ocv;
            _FilterCount = ClarifierStorage.Instance.m;
        }

        private void GetComboBox_Clarifier()
        {

        }

        private void RecordParamToStorage_Clarifier()
        {
            ClarifierStorage.Instance.m = FilterCount;
        }

        #endregion

        #region Decarbonizer

        private void LoadProperty_Decarbonizer()
        {
            CalcDecarbonizer calc = new CalcDecarbonizer();
            calc.CaclFirstProperty();
        }

        private void GetComboBox_Decarbonizer()
        {
   

        }

        private void RecordParamToStorage_Decarbonizer()
        {
            DecarbonizerStorage.Instance.m = FilterCount;
    }

        #endregion

    }
}

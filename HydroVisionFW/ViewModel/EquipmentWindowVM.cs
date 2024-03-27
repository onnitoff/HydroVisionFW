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

        #endregion


        #region Команды

        #region ApplyBtnCommand
        /// <summary>Кнопка очистки всех textBox</summary>
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
                case 3:
                    {
                        RecordParamToStorage_H2();
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
                        LoadAndCalcProperty_MAF();
                        GetComboBox_MAF();
                    }
                    break;
                // открыт А2
                case 2:
                    {
                        IsHiddenA2Scheme = true;
                        LoadProperty_A2();
                        GetComboBox_A2();
                    }
                    break;
                // открыт H2
                case 3:
                    {
                        IsHiddenH2Scheme = true;
                        LoadProperty_H2();
                        GetComboBox_H2();
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
            MAFStorage.Instance.bK = SelectedBrandOfIon.SpecificConsumptionFirst;
            MAFStorage.Instance.P_iK = SelectedBrandOfIon.GeneralWaterConsumptionCation;
            MAFStorage.Instance.e_pK = SelectedBrandOfIon.WorkingExchangeCapacity;
            MAFStorage.Instance.e_pA = SelectedBrandOfIon.WorkingExchangeCapacity;
            MAFStorage.Instance.bA = SelectedBrandOfIon.SpecificConsumptionSecond;
            MAFStorage.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            MAFStorage.Instance.d_ct = SelectedSuitableFilter.Diameter / 1000;
            MAFStorage.Instance.h = SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            MAFStorage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id;
            MAFStorage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 36;

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
            A2Storage.Instance.bA = SelectedBrandOfIon.SpecificConsumptionFirst;
            A2Storage.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            A2Storage.Instance.d_ct = SelectedSuitableFilter.Diameter / 1000;
            A2Storage.Instance.h = SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            A2Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id - 14;
            A2Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 25;

            A2Storage.Instance.m = FilterCount;
            A2Storage.Instance.w = FiltrationSpeed;
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
            H2Storage.Instance.bK = SelectedBrandOfIon.SpecificConsumptionFirst;
            H2Storage.Instance.P_iK = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            H2Storage.Instance.d_ct = SelectedSuitableFilter.Diameter / 1000;
            H2Storage.Instance.h = SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            H2Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id - 6;
            H2Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 25;

            H2Storage.Instance.m = FilterCount;
            H2Storage.Instance.w = FiltrationSpeed;
        }

        #endregion


    }
}

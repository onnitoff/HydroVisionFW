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
                        LoadProperty_MAF();
                        GetComboBox_MAF();
                        MessageBox.Show("FSD");
                    }
                    break;
                // открыт А2
                case 2:
                    {
                        LoadProperty_A2();
                        GetComboBox_A2();
                        RecordParamToStorage_A2();
                        MessageBox.Show("A2");
                    }
                    break;
                default:
                    MessageBox.Show("Ошибка, перезапустите приложение");
                    break;
            }
        }


        #region MAF
  
        private void LoadProperty_MAF()
        {
            _DesignDiameter = MAFStorage.Instance.f_p;
            _FilterCount = MAFStorage.Instance.m;
            _FiltrationSpeed = MAFStorage.Instance.w;

        }

        private void GetComboBox_MAF()
        {
            DataRepository data = new DataRepository();

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonMAFAsync();
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[MAFStorage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterMAAsync();
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
            _DesignDiameter = A2Storage.Instance.f_p;
            _FilterCount = A2Storage.Instance.m;
            _FiltrationSpeed = A2Storage.Instance.w;

        }

        private void GetComboBox_A2()
        {
            DataRepository data = new DataRepository();

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonMAFAsync();
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[A2Storage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterMAAsync();
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[A2Storage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage_A2()
        {
            A2Storage.Instance.e_pA = SelectedBrandOfIon.WorkingExchangeCapacity;
            A2Storage.Instance.bA = SelectedBrandOfIon.SpecificConsumptionSecond;
            A2Storage.Instance.P_iA = SelectedBrandOfIon.GeneralWaterConsumptionAnion;

            A2Storage.Instance.d_ct = SelectedSuitableFilter.Diameter / 1000;
            A2Storage.Instance.h = SelectedSuitableFilter.IonExchangerLayerHieght / 1000;

            A2Storage.Instance.SelectedBrandOfIon = SelectedBrandOfIon.Id;
            A2Storage.Instance.SelectedSuitableFilter = SelectedSuitableFilter.Id - 36;

            A2Storage.Instance.m = FilterCount;
            A2Storage.Instance.w = FiltrationSpeed;
        }

        #endregion


    }
}

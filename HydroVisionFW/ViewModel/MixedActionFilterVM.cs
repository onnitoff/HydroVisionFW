using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
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
    internal class MixedActionFilterVM : ViewModelBase
    {
        private double _DesignDiameter = MAFStorage.Instance.f_p;
        /// <summary>Свойство для textBox Расчетный диаметр</summary>
        public double DesignDiameter
        {
            get => _DesignDiameter;
            set => Set(ref _DesignDiameter, value);
        }

        private int _FilterCount = MAFStorage.Instance.m;
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

        private double _FiltrationSpeed = MAFStorage.Instance.w;
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
            RecordParamToStorage();

            Window activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            activeWindow?.Close();
        }
        #endregion

        #endregion


        public MixedActionFilterVM()
        {
            #region Команды
            ApplyBtnCommand = new RelayCommand(OnApplyBtnCommand);
            #endregion

            //CalcMAF calcMAF = new CalcMAF();
            //calcMAF.Calculations();

            GetComboBox();
        }


        private void GetComboBox()
        {
            DataRepository data = new DataRepository();

            // обращение к бд марка ионита
            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync();
            }).Wait();
            SelectedBrandOfIon = BrandOfIonItems[MAFStorage.Instance.SelectedBrandOfIon - 1];

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableFilter = await data.GetFilterMAAsync();
            }).Wait();
            SelectedSuitableFilter = SuitableFilter[MAFStorage.Instance.SelectedSuitableFilter];
        }

        private void RecordParamToStorage()
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

            MAFStorage.Instance.CK = 75;
            MAFStorage.Instance.CA = 42;

            MAFStorage.Instance.m = FilterCount;

            MAFStorage.Instance.w = FiltrationSpeed;

        }

        
    }
}

using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionFW.Model;
using HydroVisionFW.Model.DataBaseModel;
using HydroVisionFW.Services.DataRepository;
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

namespace HydroVisionFW.ViewModel
{
    internal class MixedActionFilterVM : ViewModelBase
    {
        private double _DesignDiameter;
        /// <summary>Свойство для textBox Расчетный диаметр</summary>
        public double DesignDiameter
        {
            get => _DesignDiameter;
            set => Set(ref _DesignDiameter, value);
        }

        private double _FilterCount;
        /// <summary>Свойство для textBox Количество фильтров</summary>
        public double FilterCount
        {
            get => _FilterCount;
            set => Set(ref _FilterCount, value);
        }

        /// <summary>Коллекция для ComboBox Марка ионита</summary>
        //public ObservableCollection<ExchangeCapacityAndReagentConsumptionFSD> BrandOfIonItems { get; set; }
        public List<BrandOfIonModel> BrandOfIonItems { get; set; }
        //public IQueryable<BrandOfIonData> BrandOfIonItems {  get; set; }

        /// <summary>Свойство для Select ComboBox Марка ионита</summary>
        private BrandOfIonModel _SelectedBrandOfIon;
        public BrandOfIonModel SelectedBrandOfIon
        {
            get => _SelectedBrandOfIon;
            set => Set(ref _SelectedBrandOfIon, value);
        }

        //private double _BrandOfIon;
        ///// <summary>Свойство для textBox Бренд катиона</summary>
        //public double BrandOfIon
        //{
        //    get => _BrandOfIon;
        //    set => Set(ref _BrandOfIon, value);
        //}

        //private double _BrandOfAnion;
        ///// <summary>Свойство для textBox Бренд аниона</summary>
        //public double BrandOfAnion
        //{
        //    get => _BrandOfAnion;
        //    set => Set(ref _BrandOfAnion, value);
        //}

        private double _FiltrationSpeed;
        /// <summary>Свойство для textBox Скорость фильтрации</summary>
        public double FiltrationSpeed
        {
            get => _FiltrationSpeed;
            set => Set(ref _FiltrationSpeed, value);
        }

        public List<BrandOfIonModel> SuitableFilter { get; set; }

        //private double _SuitableFilter;
        ///// <summary>Свойство для textBox Подходящий фильтр</summary>
        //public double SuitableFilter
        //{
        //    get => _SuitableFilter;
        //    set => Set(ref _SuitableFilter, value);
        //}

        #region Команды

        #region ApplyBtnCommand
        /// <summary>Кнопка очистки всех textBox</summary>
        public ICommand ApplyBtnCommand { get; }
        private void OnApplyBtnCommand(object obj)
        {
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

            DataRepository data = new DataRepository();

            Task.Run(async () =>
            {
                BrandOfIonItems = await data.GetBrandIonAsync();
            }).Wait();
            GetList();


        }


        private void GetList()
        {
            List<BrandOfIonModel> brandOfIonModels = new List<BrandOfIonModel>();
            brandOfIonModels.Add(new BrandOfIonModel
            {
                Id = 1,
                Name = "Name"
            });
            brandOfIonModels.Add(new BrandOfIonModel
            {
                Id = 2,
                Name = "Name2"
            });

            SuitableFilter = brandOfIonModels;
        }
        
    }
}

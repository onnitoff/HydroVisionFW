using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private double _BrandOfCation;
        /// <summary>Свойство для textBox Бренд катиона</summary>
        public double BrandOfCation
        {
            get => _BrandOfCation;
            set => Set(ref _BrandOfCation, value);
        }

        private double _BrandOfAnion;
        /// <summary>Свойство для textBox Бренд аниона</summary>
        public double BrandOfAnion
        {
            get => _BrandOfAnion;
            set => Set(ref _BrandOfAnion, value);
        }

        private double _FiltrationSpeed;
        /// <summary>Свойство для textBox Скорость фильтрации</summary>
        public double FiltrationSpeed
        {
            get => _FiltrationSpeed;
            set => Set(ref _FiltrationSpeed, value);
        }

        private double _SuitableFilter;
        /// <summary>Свойство для textBox Подходящий фильтр</summary>
        public double SuitableFilter
        {
            get => _SuitableFilter;
            set => Set(ref _SuitableFilter, value);
        }

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
        }


    }
}

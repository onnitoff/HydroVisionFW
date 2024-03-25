using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionFW.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HydroVisionDesign.ViewModel
{
    internal class DesaltingPartWTPVM : ViewModelBase
    {
        #region Свойство Hidden
        /// <summary>Свойство для открытия и сокрытия элементов xaml DirectFlow</summary>
        private bool _IsHiddenProperty = false;

        public bool IsHiddenProperty
        {
            get => _IsHiddenProperty;
            set => Set(ref _IsHiddenProperty, value);
        }
        #endregion

        #region Команды
        #region LeftBtnA1Command
        /// <summary>Нажатие левой кнопки по А1</summary>
        public ICommand LeftBtnA1Command { get; }
        private void OnLeftBtnA1Command(object obj)
        {
            IsHiddenProperty = true;
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
            IsHiddenProperty = false;
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

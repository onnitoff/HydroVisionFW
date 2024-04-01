using HydroVisionDesign.Services.DataStorages;
using HydroVisionDesign.Services.TestValues;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HydroVisionFW
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            /// <summary>Определение константых значений</summary>
            DataStorage.Instance.ExcessLime = 0.35;
            DataStorage.Instance.ConcentrationCOBeforeDecarbonizer = 0.136;
            Values values = new Values();
        }
    }
}

using HydroVisionDesign.Services.DataStorages;
using HydroVisionDesign.Services.TestValues;
using HydroVisionFW.Model.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
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

            //CheckDatabaseConnection();
        }

        private void CheckDatabaseConnection()
        {

            try
            {
                using (var context = new WaterContext())
                {

                    // Проверка подключения путем выполнения простого запроса к таблице ExampleEntities
                    var count = context.Boilers.Count();

                    MessageBox.Show("Successfully connected to SQLite database. Entities count: " + count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }
    }
}

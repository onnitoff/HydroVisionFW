using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.DataStorages
{
    internal class BoilerStorage
    {
        private static BoilerStorage instance;
        private BoilerStorage() { }

        public static BoilerStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BoilerStorage();
                }
                return instance;
            }
        }

        /// <summary>Переменные производительности ВПУ</summary>
        #region Perfomance WTP
        public double ElectricPower { get; set; } = 0;
        public int NumberOfBoilersFirst { get; set; } = 0;
        public int NumberOfBoilersSecond { get; set; } = 0;
        public int NumberOfTurbinesFirst { get; set; } = 0;
        public int NumberOfTurbinesSecond { get; set; } = 0;
        public int FuelType { get; set; } = 0;
        public double VacationCouple { get; set; } = 0;
        public double Losses { get; set; } = 0;
        public double BlowdownLosses { get; set; } = 0;
        public double DesaltedWaterSupply { get; set; } = 0;
        public double DesaltedWaterSupplySecond { get; set; } = 0;
        public double WaterConsumptionForNetworkHeaters { get; set; } = 0;

        /// <summary>Для ТЭЦ</summary>
        public double InternalLosses { get; set; } = 0;
        public double ExternalLosses { get; set; } = 0;
        public double PurgingLosses { get; set; } = 0;
        public double LossesInFuelOilProduction { get; set; } = 0;
        public double FuelOilConsumptionFirst { get; set; } = 0;
        public double FuelOilConsumptionSecond { get; set; } = 0;
        public double PerfomanceWTPForTPP { get; set; } = 0;

        /// <summary>Для КЭС</summary>
        public double PerfomanceWTPForIES { get; set; } = 0;

        /// <summary>Для тепловых сетей</summary>


        public double PerfomanceWTPFirst { get; set; } = 0;
        public double PerfomanceWTPSecond { get; set; } = 0;
        public double PerfomanceWTPForHeatingSystemFirst { get; set; } = 0;
        public double PerfomanceWTPForHeatingSystemSecond { get; set; } = 0;

        public double PerfomanceWTP { get; set; } = 0;
        public double PerfomanceWTPForHeatingSystem { get; set; } = 0;

        public double PerfomanceOF { get; set; } = 0;

        #endregion
    }
}

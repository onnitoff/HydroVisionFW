using HydroVisionFW.Model.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionDesign.Services.DataStorages
{
    public class DataStorage
    {
        private static DataStorage instance;
        private DataStorage() { }

        public static DataStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataStorage();
                }
                return instance;
            }
        }

        public int ViewModel { get; set; }

        /// <summary>Переменные показателей качества воды, показателей качества воды по отдельным стадиям обработки</summary>
        #region AnalysisOfWater

        public double Init_Ca { get; set; } = 0;
        public double Init_Mg { get; set; } = 0;
        public double Init_Na { get; set; } = 0;
        public double Init_HCO { get; set; } = 0;
        public double Init_SO { get; set; } = 0;
        public double Init_Cl { get; set; } = 0;
        public double Init_NO { get; set; } = 0;
        public double Init_SiO { get; set; } = 0;
        public double OverallHardness { get; set; } = 0;
        public double DryResidue { get; set; } = 0;
        public double Oxidability { get; set; } = 0;


        public double Final_Ca { get; set; } = 0;
        public double Final_Mg { get; set; } = 0;
        public double Final_Na { get; set; } = 0;
        public double Final_HCO { get; set; } = 0;
        public double Final_SO { get; set; } = 0;
        public double Final_Cl { get; set; } = 0;
        public double Final_NO { get; set; } = 0;
        public double Final_SiO { get; set; } = 0;

        public double TotalCationContent { get; set; } = 0;
        public double TotalAnionContent { get; set; } = 0;
        public double TotalAlkalinity { get; set; } = 0;
        public double NonCarbonateHardness { get; set; } = 0;
        public double SumOfStrongAcidAnions { get; set; } = 0;

        public double K_Al_Fe { get; set; } = 0;
        public double ExcessLime { get; set; } = 0;
        public double ResidualHardnessCarbonate { get; set; } = 0;
        public double ResidualHardnessNoCarbonate { get; set; } = 0;
        public double ResidualAlkalinity { get; set; } = 0;
        public double SilicicAcidConcentration { get; set; } = 0;
        public double ResidualOverallHarndess { get; set; } = 0;
        public double ConcentrationSO { get; set; } = 0;

        public double CationOnFirstStageFilter { get; set; } = 0;
        public double CationOnSecondStageFilter { get; set; } = 0;
        public double ConcentrationCOBeforeDecarbonizer { get; set; } = 0;
        public double AnionOnFirstStageFilter { get; set; } = 0;
        public double AnionOnSecondStageFilter { get; set; } = 0;
        public double AnionOnSecondStageFilterSimplified { get; set; } = 0;
        public double NaCationOnFilter { get; set; } = 0;

        public string DesaltingScheme { get; set; } = String.Empty;


        public bool PresenceOfOnceThroughBoilers { get; set; } = false;
        public bool PresenceOfCentralHeating { get; set; } = false;


        #endregion

        #region Переменные ДБ

        // для котла
        public int BoilerPerfomanceFirst { get; set; } = 0;
        public int BoilerTypeFirst { get; set; } = 0;
        public int BoilerPerfomanceSecond { get; set; } = 0;
        public int BoilerTypeSecond { get; set; } = 0;
        public int SelectedBoilerFirstItem { get; set; } = 1;
        public int SelectedBoilerSecondItem { get; set; } = 1;

        // для турбины
        public int WaterConsumptionFirst { get; set; } = 0;
        public int TurbinePerfomanceFirst {  get; set; } = 0;
        public int TurbinePerfomanceSecond { get; set; } = 0;
        public int SelectedTurbineFirstItem { get; set; } = 1;
        public int WaterConsumptionSecond { get; set; } = 0;
        public int SelectedTurbineSecondItem { get; set; } = 1;

        // для топлива
        public int SelectedFuelItem { get; set; } = 1;

        #endregion

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
        public double DesaltedWaterSupplyFirst {  get; set; } = 0;
        public double DesaltedWaterSupplySecond { get; set; } = 0;
        public double WaterConsumptionForNetworkHeaters { get; set; } = 0;

        /// <summary>Для ТЭЦ</summary>
        public double InternalLosses { get; set; } = 0;
        public double ExternalLosses { get; set; } = 0;
        public double PurgingLosses { get; set; } = 0;
        public double LossesInFuelOilProduction { get; set; } = 0;
        public double FuelOilConsumption {  get; set; } = 0;
        public double PerfomanceWTPForTPP { get; set; } = 0;

        /// <summary>Для КЭС</summary>
        public double PerfomanceWTPForIES { get; set; } = 0;

        /// <summary>Для тепловых сетей</summary>
        public double PerfomanceWTPForHeatingSystem { get; set; } = 0;

        public double PerfomanceWTP { get; set; } = 0;
        public double PerfomanceOF { get; set; } = 0;

        #endregion

        
    }
}

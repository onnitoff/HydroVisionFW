using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HydroVisionFW.Services.Calculations
{
    internal class CalcBoiler
    {
        public void Calculation()
        {
            if (BoilerStorage.Instance.NumberOfBoilersFirst <= 0)
            {
                MessageBox.Show("Введите корректное число");
            }
            if (BoilerStorage.Instance.NumberOfBoilersFirst > 0)
            {
                CalculationOfWTPPerformanceFirst();
            }
            if (BoilerStorage.Instance.NumberOfBoilersSecond > 0 && BoilerStorage.Instance.NumberOfBoilersFirst > 0)
            {

            }
        }

        public void CalculationOfWTPPerformanceFirst()
        {

            WaterTreatmentPlantPerfomance perfomance = new WaterTreatmentPlantPerfomance();
            DesaltedWaterSupplyCalc();

            BoilerStorage.Instance.InternalLosses = perfomance.InternalLosses(
                DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst, DataStorage.Instance.BoilerPerfomanceSecond, BoilerStorage.Instance.NumberOfBoilersSecond);

            if (BoilerStorage.Instance.Losses != 0)
                BoilerStorage.Instance.ExternalLosses = perfomance.ExternalLosses(
                BoilerStorage.Instance.Losses, BoilerStorage.Instance.VacationCouple);

            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond != 1)
                BoilerStorage.Instance.PurgingLosses = perfomance.PurgingLosses(
                BoilerStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst);
            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond == 1)
                BoilerStorage.Instance.PurgingLosses = perfomance.PurgingLosses(
                BoilerStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst, DataStorage.Instance.BoilerPerfomanceSecond, BoilerStorage.Instance.NumberOfBoilersSecond);
            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeSecond == 1 && DataStorage.Instance.BoilerTypeFirst != 1)
                BoilerStorage.Instance.PurgingLosses = perfomance.PurgingLosses(
                BoilerStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceSecond, BoilerStorage.Instance.NumberOfBoilersSecond);

            //to go

            if (BoilerStorage.Instance.FuelOilConsumption != 0)
                BoilerStorage.Instance.LossesInFuelOilProduction = perfomance.LossesInFuelOilProduction(
                    BoilerStorage.Instance.FuelOilConsumption, BoilerStorage.Instance.NumberOfBoilersFirst);

            BoilerStorage.Instance.PerfomanceWTPForIES = perfomance.ProductivityWTPForIES(
                DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst, BoilerStorage.Instance.DesaltedWaterSupplyFirst);

            BoilerStorage.Instance.PerfomanceWTPForTPP = perfomance.ProductivityWTPForTPP(
                BoilerStorage.Instance.InternalLosses, BoilerStorage.Instance.ExternalLosses, BoilerStorage.Instance.PurgingLosses, BoilerStorage.Instance.LossesInFuelOilProduction,
                BoilerStorage.Instance.DesaltedWaterSupplyFirst);

            BoilerStorage.Instance.PerfomanceWTPForHeatingSystem = perfomance.ProductivityWTPForHeatingSystem(
                BoilerStorage.Instance.WaterConsumptionForNetworkHeaters);

            BoilerStorage.Instance.PerfomanceWTP = BoilerStorage.Instance.PerfomanceWTPForTPP;
        }

        private void DesaltedWaterSupplyCalc()
        {
            if (DataStorage.Instance.BoilerTypeFirst == 1)
            {
                BoilerStorage.Instance.DesaltedWaterSupplyFirst = 25;
            }
            
            if(DataStorage.Instance.BoilerTypeSecond == 1)
            {
                BoilerStorage.Instance.DesaltedWaterSupplyFirst = 25;
            }

            if (DataStorage.Instance.BoilerTypeFirst == 2)
            {
                if (DataStorage.Instance.TurbinePerfomanceFirst <= 300)
                {
                    BoilerStorage.Instance.DesaltedWaterSupplyFirst = 25;
                }

                if (DataStorage.Instance.TurbinePerfomanceFirst > 300 && DataStorage.Instance.TurbinePerfomanceFirst <= 500)
                {
                    BoilerStorage.Instance.DesaltedWaterSupplyFirst = 50;
                }

                if (DataStorage.Instance.TurbinePerfomanceFirst > 800)
                {
                    BoilerStorage.Instance.DesaltedWaterSupplyFirst = 75;
                }


                if (DataStorage.Instance.TurbinePerfomanceSecond <= 300)
                {
                    BoilerStorage.Instance.DesaltedWaterSupplySecond = 25;
                }

                if (DataStorage.Instance.TurbinePerfomanceSecond > 300 && DataStorage.Instance.TurbinePerfomanceFirst <= 500)
                {
                    BoilerStorage.Instance.DesaltedWaterSupplySecond = 50;
                }

                if (DataStorage.Instance.TurbinePerfomanceSecond > 800)
                {
                    BoilerStorage.Instance.DesaltedWaterSupplySecond = 75;
                }
            }

        }
    }
}

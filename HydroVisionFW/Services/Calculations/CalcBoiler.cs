using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Model.DataBaseModel;
using HydroVisionFW.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using HydroVisionFW.Services.Calculations;
using HydroVisionFW.Services.DataRepository;
using HydroVisionFW.Model;


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
                
                CalculationOfWTPPerformance();
            }
        }

        public void CalculationOfWTPPerformance()
        {
            DesaltingScheme desalting = new DesaltingScheme();
            desalting.IsDesaltingScheme();
            WaterTreatmentPlantPerfomance perfomance = new WaterTreatmentPlantPerfomance();
            DesaltedWaterSupplyCalc();

            if (DataStorage.Instance.BoilerPerfomanceFirst != 0 && DataStorage.Instance.BoilerPerfomanceSecond == 0)
                BoilerStorage.Instance.InternalLosses = perfomance.InternalLosses(DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst);
            if (DataStorage.Instance.BoilerPerfomanceSecond != 0 && DataStorage.Instance.BoilerPerfomanceFirst == 0)
                BoilerStorage.Instance.InternalLosses = perfomance.InternalLosses(DataStorage.Instance.BoilerPerfomanceSecond, BoilerStorage.Instance.NumberOfBoilersSecond);
            if (DataStorage.Instance.BoilerPerfomanceFirst != 0 && DataStorage.Instance.BoilerPerfomanceSecond != 0)
                BoilerStorage.Instance.InternalLosses = perfomance.InternalLosses(DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst,
                                                        DataStorage.Instance.BoilerPerfomanceSecond, BoilerStorage.Instance.NumberOfBoilersSecond);

            if (BoilerStorage.Instance.Losses != 0)
                BoilerStorage.Instance.ExternalLosses = perfomance.ExternalLosses(BoilerStorage.Instance.Losses, BoilerStorage.Instance.VacationCouple);

            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond != 1)
                BoilerStorage.Instance.PurgingLosses = perfomance.PurgingLosses(BoilerStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceFirst,
                                                       BoilerStorage.Instance.NumberOfBoilersFirst);
            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeSecond == 1 && DataStorage.Instance.BoilerTypeFirst != 1)
                BoilerStorage.Instance.PurgingLosses = perfomance.PurgingLosses(BoilerStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceSecond,
                                                       BoilerStorage.Instance.NumberOfBoilersSecond);
            if (BoilerStorage.Instance.BlowdownLosses != 0 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond == 1)
                BoilerStorage.Instance.PurgingLosses = perfomance.PurgingLosses(BoilerStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceFirst,
                                                       BoilerStorage.Instance.NumberOfBoilersFirst, DataStorage.Instance.BoilerPerfomanceSecond, BoilerStorage.Instance.NumberOfBoilersSecond);


            if (DataStorage.Instance.SelectedFuelType == 2)
            {
                List<FuelModel> fuelOilConsumptions = new List<FuelModel>();

                DataRepository.DataRepository data = new DataRepository.DataRepository();
                //обращение к бд марка ионита
                Task.Run(async () =>
                {
                    fuelOilConsumptions = await data.GetFuelOilAsync();
                }).Wait();

                foreach (var item in fuelOilConsumptions)
                {
                    if (item.Perfomance <= DataStorage.Instance.BoilerPerfomanceFirst)
                    {
                        BoilerStorage.Instance.FuelOilConsumptionFirst = item.OilConsumption;
                    }
                    else
                    {
                        BoilerStorage.Instance.FuelOilConsumptionFirst = item.OilConsumption;
                    }

                    if (item.Perfomance <= DataStorage.Instance.BoilerPerfomanceSecond)
                    {
                        BoilerStorage.Instance.FuelOilConsumptionSecond = item.OilConsumption;
                    }
                    else
                    {
                        BoilerStorage.Instance.FuelOilConsumptionSecond = item.OilConsumption;
                    }
                }

                if (BoilerStorage.Instance.FuelOilConsumptionFirst != 0 && BoilerStorage.Instance.FuelOilConsumptionSecond != 0)
                    BoilerStorage.Instance.LossesInFuelOilProduction = perfomance.LossesInFuelOilProduction(BoilerStorage.Instance.FuelOilConsumptionFirst, BoilerStorage.Instance.NumberOfBoilersFirst,
                                                                       BoilerStorage.Instance.FuelOilConsumptionSecond, BoilerStorage.Instance.NumberOfBoilersSecond);
            }
            

            if (BoilerStorage.Instance.NumberOfBoilersSecond == 0)
            {
                if (DataStorage.Instance.TurbineTypeFirst == 1)
                    BoilerStorage.Instance.PerfomanceWTP = perfomance.ProductivityWTPForIES(DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst, BoilerStorage.Instance.DesaltedWaterSupply);
            }
            if (BoilerStorage.Instance.NumberOfBoilersSecond != 0)
            {
                if (DataStorage.Instance.TurbineTypeFirst == 1 && DataStorage.Instance.TurbineTypeSecond == 1)
                    BoilerStorage.Instance.PerfomanceWTP = perfomance.ProductivityWTPForIES(DataStorage.Instance.BoilerPerfomanceFirst, BoilerStorage.Instance.NumberOfBoilersFirst, DataStorage.Instance.BoilerPerfomanceSecond, 
                                                           BoilerStorage.Instance.NumberOfBoilersSecond, BoilerStorage.Instance.DesaltedWaterSupply);
            }

            if (DataStorage.Instance.TurbineTypeFirst == 2 || DataStorage.Instance.TurbineTypeSecond == 2)
                    BoilerStorage.Instance.PerfomanceWTP = perfomance.ProductivityWTPForTPP(BoilerStorage.Instance.InternalLosses, BoilerStorage.Instance.ExternalLosses,
                                                           BoilerStorage.Instance.PurgingLosses, BoilerStorage.Instance.LossesInFuelOilProduction, BoilerStorage.Instance.DesaltedWaterSupply);


            if (DataStorage.Instance.WaterConsumptionForNetworkHeatersFirst > 0)
                BoilerStorage.Instance.PerfomanceWTPForHeatingSystemFirst = perfomance.ProductivityWTPForHeatingSystem(DataStorage.Instance.WaterConsumptionForNetworkHeatersFirst, BoilerStorage.Instance.NumberOfTurbinesFirst);
            else BoilerStorage.Instance.PerfomanceWTPForHeatingSystemFirst = 0;
            if (DataStorage.Instance.WaterConsumptionForNetworkHeatersSecond > 0)
                BoilerStorage.Instance.PerfomanceWTPForHeatingSystemSecond = perfomance.ProductivityWTPForHeatingSystem(DataStorage.Instance.WaterConsumptionForNetworkHeatersSecond, BoilerStorage.Instance.NumberOfTurbinesSecond);
            else BoilerStorage.Instance.PerfomanceWTPForHeatingSystemSecond = 0;

            BoilerStorage.Instance.PerfomanceWTPForHeatingSystem = BoilerStorage.Instance.PerfomanceWTPForHeatingSystemFirst + BoilerStorage.Instance.PerfomanceWTPForHeatingSystemSecond;

        }

        private void DesaltedWaterSupplyCalc()
        {
            if (DataStorage.Instance.BoilerTypeFirst == 1)
            {
                BoilerStorage.Instance.DesaltedWaterSupply = 25;
            }
            
            if(DataStorage.Instance.BoilerTypeSecond == 1 && BoilerStorage.Instance.NumberOfBoilersSecond > 0)
            {
                BoilerStorage.Instance.DesaltedWaterSupply = 25;
            }

            if (DataStorage.Instance.BoilerTypeFirst == 2)
            {
                if (DataStorage.Instance.TurbinePerfomanceFirst <= 300)
                {
                    BoilerStorage.Instance.DesaltedWaterSupply = 25;
                }

                if (DataStorage.Instance.TurbinePerfomanceFirst > 300 && DataStorage.Instance.TurbinePerfomanceFirst <= 500)
                {
                    BoilerStorage.Instance.DesaltedWaterSupply = 50;
                }

                if (DataStorage.Instance.TurbinePerfomanceFirst > 800)
                {
                    BoilerStorage.Instance.DesaltedWaterSupply = 75;
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

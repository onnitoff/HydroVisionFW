using HydroVisionDesign.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HydroVisionDesign.Services.Calculations
{
    public class Calculations
    {
        public Calculations()
        {

        }
        /// <summary>Метод перерасчета показателей качества воды</summary>
        public void RecalculationOfQualityIndicators()
        {
            DataStorage.Instance.Final_Mg = DataStorage.Instance.OverallHardness - DataStorage.Instance.Final_Ca;

            AnalysisOfWaterQualityIndicators analysisOfWater = new AnalysisOfWaterQualityIndicators();

            DataStorage.Instance.Init_Ca = analysisOfWater.RecalculationOfQualityIndicatorsSecond("Ca",
                DataStorage.Instance.Final_Ca);
            DataStorage.Instance.Init_Mg = analysisOfWater.RecalculationOfQualityIndicatorsSecond("Mg",
                DataStorage.Instance.Final_Mg);
            DataStorage.Instance.Final_Na = analysisOfWater.RecalculationOfQualityIndicators("Na",
                DataStorage.Instance.Init_Na);
            DataStorage.Instance.Init_HCO = analysisOfWater.RecalculationOfQualityIndicatorsSecond("HCO",
                DataStorage.Instance.Final_HCO);
            DataStorage.Instance.Final_SO = analysisOfWater.RecalculationOfQualityIndicators("SO",
                DataStorage.Instance.Init_SO);
            DataStorage.Instance.Final_Cl = analysisOfWater.RecalculationOfQualityIndicators("Cl",
                DataStorage.Instance.Init_Cl);
            DataStorage.Instance.Final_NO = analysisOfWater.RecalculationOfQualityIndicators("NO",
                DataStorage.Instance.Init_NO);
            DataStorage.Instance.Final_SiO = analysisOfWater.RecalculationOfQualityIndicators("SiO",
                DataStorage.Instance.Init_SiO);
        }

        public void CalculationOfOtherQualityIndicators()
        {
            AnalysisOfWaterQualityIndicators analysisOfWater = new AnalysisOfWaterQualityIndicators();

            DataStorage.Instance.TotalCationContent = analysisOfWater.TotalCationContent(
            DataStorage.Instance.Final_Ca, DataStorage.Instance.Final_Mg, DataStorage.Instance.Final_Na);
            DataStorage.Instance.TotalAnionContent = analysisOfWater.TotalAnionContent(
                DataStorage.Instance.Final_HCO, DataStorage.Instance.Final_SO, DataStorage.Instance.Final_Cl, DataStorage.Instance.Final_SiO);
            DataStorage.Instance.TotalAlkalinity = DataStorage.Instance.Final_HCO;
            DataStorage.Instance.NonCarbonateHardness = analysisOfWater.TotalAlkalinityOfSurfaceWaters(DataStorage.Instance.OverallHardness, DataStorage.Instance.TotalAlkalinity);
            DataStorage.Instance.SumOfStrongAcidAnions = analysisOfWater.TotalStrongAcidAnionsContent(DataStorage.Instance.Final_NO, DataStorage.Instance.Final_Cl,
                DataStorage.Instance.Final_SO);

            RecalculationOfChangesInWaterQualityIndicators recalculationOfWaterIndicators = new RecalculationOfChangesInWaterQualityIndicators();
            if (DataStorage.Instance.TotalAlkalinity < 2) // для Al
            {
                DataStorage.Instance.K_Al_Fe = 0.5;
                DataStorage.Instance.ResidualHardnessCarbonate = recalculationOfWaterIndicators.ResidualHardnessCarbonateAl(
                    DataStorage.Instance.TotalAlkalinity, DataStorage.Instance.K_Al_Fe);
                DataStorage.Instance.ResidualHardnessNoCarbonate = recalculationOfWaterIndicators.ResidualHardnessNoCarbonateAl(
                    DataStorage.Instance.NonCarbonateHardness, DataStorage.Instance.K_Al_Fe);
                DataStorage.Instance.ResidualOverallHarndess = DataStorage.Instance.OverallHardness;
                DataStorage.Instance.ResidualAlkalinity = recalculationOfWaterIndicators.ResidualAlkalinityAl(
                    DataStorage.Instance.TotalAlkalinity, DataStorage.Instance.K_Al_Fe);
                DataStorage.Instance.SilicicAcidConcentration = recalculationOfWaterIndicators.SilicicAcidConcentrationAl(
                    DataStorage.Instance.Final_SiO);
                DataStorage.Instance.ConcentrationSO = DataStorage.Instance.Final_SO;
            }
            else // для Fe
            {
                DataStorage.Instance.K_Al_Fe = 0.35;
                DataStorage.Instance.ResidualHardnessCarbonate = recalculationOfWaterIndicators.ResidualHardnessCarbonateFe(0.7);
                DataStorage.Instance.ResidualHardnessNoCarbonate = recalculationOfWaterIndicators.ResidualHardnessNoCarbonateFe(
                    DataStorage.Instance.NonCarbonateHardness, DataStorage.Instance.K_Al_Fe);
                DataStorage.Instance.ResidualOverallHarndess = recalculationOfWaterIndicators.ResidualOverallHardnessFe(
                    DataStorage.Instance.ResidualHardnessCarbonate, DataStorage.Instance.ResidualHardnessNoCarbonate);
                DataStorage.Instance.ResidualAlkalinity = recalculationOfWaterIndicators.ResidualAlkalinityFe(
                    DataStorage.Instance.ResidualHardnessCarbonate, DataStorage.Instance.ExcessLime);
                DataStorage.Instance.SilicicAcidConcentration = recalculationOfWaterIndicators.SilicicAcidConcentrationFe(
                    DataStorage.Instance.Final_SiO);
                DataStorage.Instance.ConcentrationSO = recalculationOfWaterIndicators.ConcentrationSO4Fe(
                    DataStorage.Instance.Final_SO, DataStorage.Instance.K_Al_Fe);
            }

            DataStorage.Instance.CationOnFirstStageFilter = recalculationOfWaterIndicators.CationOnFirstStageFilters(
                   DataStorage.Instance.OverallHardness, DataStorage.Instance.Final_Na);
            DataStorage.Instance.CationOnSecondStageFilter = recalculationOfWaterIndicators.CationOnSecondStageFilters(0.3);

            if (DataStorage.Instance.SumOfStrongAcidAnions < 2 && DataStorage.Instance.PresenceOfOnceThroughBoilers != true) // упрощенная схема
            {
                DataStorage.Instance.DesaltingScheme = "simplified";
                DataStorage.Instance.AnionOnSecondStageFilterSimplified = recalculationOfWaterIndicators.AnionOnSimplifiedSecondStageFilters(
                    DataStorage.Instance.ConcentrationSO, DataStorage.Instance.Final_Cl, DataStorage.Instance.Final_NO, DataStorage.Instance.K_Al_Fe,
                    DataStorage.Instance.SilicicAcidConcentration, DataStorage.Instance.ConcentrationCOBeforeDecarbonizer);
            }
            else if (DataStorage.Instance.SumOfStrongAcidAnions < 5) // двухступенчатая схема
            {
                if (DataStorage.Instance.PresenceOfOnceThroughBoilers != false)
                    DataStorage.Instance.DesaltingScheme = "three-stage";
                else
                    DataStorage.Instance.DesaltingScheme = "two-stage";

                DataStorage.Instance.AnionOnFirstStageFilter = recalculationOfWaterIndicators.AnionOnFirstStageFilters(
                    DataStorage.Instance.ConcentrationSO, DataStorage.Instance.Final_Cl, DataStorage.Instance.Final_NO, DataStorage.Instance.K_Al_Fe);
                DataStorage.Instance.AnionOnSecondStageFilter = recalculationOfWaterIndicators.AnionOnSecondStageFilters(
                    DataStorage.Instance.SilicicAcidConcentration, DataStorage.Instance.ConcentrationCOBeforeDecarbonizer);
            }

            DataStorage.Instance.NaCationOnFilter = recalculationOfWaterIndicators.NaCationFilters(
                DataStorage.Instance.OverallHardness);
        }

        public void CalculationOfWTPPerformance()
        {
            WaterTreatmentPlantPerfomance perfomance = new WaterTreatmentPlantPerfomance();

            DataStorage.Instance.InternalLosses = perfomance.InternalLosses(
                DataStorage.Instance.BoilerPerfomanceFirst, DataStorage.Instance.NumberOfBoilersFirst);

            if (DataStorage.Instance.Losses != 0)
                DataStorage.Instance.ExternalLosses = perfomance.ExternalLosses(
                DataStorage.Instance.Losses, DataStorage.Instance.VacationCouple);

            if(DataStorage.Instance.BlowdownLosses != 0)
                DataStorage.Instance.PurgingLosses = perfomance.PurgingLosses(
                DataStorage.Instance.BlowdownLosses, DataStorage.Instance.BoilerPerfomanceFirst, DataStorage.Instance.NumberOfBoilersFirst);
            
            if(DataStorage.Instance.FuelOilConsumption != 0)
            DataStorage.Instance.LossesInFuelOilProduction = perfomance.LossesInFuelOilProduction(
                DataStorage.Instance.FuelOilConsumption, DataStorage.Instance.NumberOfBoilersFirst);

            DataStorage.Instance.PerfomanceWTPForIES = perfomance.ProductivityWTPForIES(
                DataStorage.Instance.BoilerPerfomanceFirst, DataStorage.Instance.NumberOfBoilersFirst, DataStorage.Instance.DesaltedWaterSupply);

            DataStorage.Instance.PerfomanceWTPForTPP = perfomance.ProductivityWTPForTPP(
                DataStorage.Instance.InternalLosses, DataStorage.Instance.ExternalLosses, DataStorage.Instance.PurgingLosses, DataStorage.Instance.LossesInFuelOilProduction,
                DataStorage.Instance.DesaltedWaterSupply);

            DataStorage.Instance.PerfomanceWTPForHeatingSystem = perfomance.ProductivityWTPForHeatingSystem(
                DataStorage.Instance.WaterConsumptionForNetworkHeaters);
        }

        private void DesaltedWaterSupplyCalc()
        {
            if (DataStorage.Instance.BoilerTypeFirst == 1)
            {
                DataStorage.Instance.DesaltedWaterSupply = 25;
            }

            if (DataStorage.Instance.BoilerTypeFirst == 2)
            {
                if(DataStorage.Instance.)
            }

        }
    }
}

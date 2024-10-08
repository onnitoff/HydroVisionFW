﻿using HydroVisionDesign.Services.DataStorages;
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
                DataStorage.Instance.K_Al_Fe = DataStorage.Instance.K_Al;
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
                DataStorage.Instance.K_Al_Fe = DataStorage.Instance.K_Fe;
                DataStorage.Instance.ResidualHardnessCarbonate = recalculationOfWaterIndicators.ResidualHardnessCarbonateFe(DataStorage.Instance.ResidualHardnessCarbonate);
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
                   DataStorage.Instance.ResidualOverallHarndess, DataStorage.Instance.Final_Na);
            DataStorage.Instance.CationOnSecondStageFilter = recalculationOfWaterIndicators.CationOnSecondStageFilters(DataStorage.Instance.CationOnSecondStageFilter);

            if (DataStorage.Instance.SumOfStrongAcidAnions < 2 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond == 1) // упрощенная схема
            {
                DataStorage.Instance.AnionOnSecondStageFilterSimplified = recalculationOfWaterIndicators.AnionOnSimplifiedSecondStageFilters(
                    DataStorage.Instance.Final_SO, DataStorage.Instance.Final_Cl, DataStorage.Instance.Final_NO, DataStorage.Instance.K_Al_Fe,
                    DataStorage.Instance.SilicicAcidConcentration, DataStorage.Instance.ConcentrationCOBeforeDecarbonizer);
            }
            else if (DataStorage.Instance.SumOfStrongAcidAnions < 5) // двухступенчатая схема
            {
                DataStorage.Instance.AnionOnFirstStageFilter = recalculationOfWaterIndicators.AnionOnFirstStageFilters(
                    DataStorage.Instance.Final_SO, DataStorage.Instance.Final_Cl, DataStorage.Instance.Final_NO, DataStorage.Instance.K_Al_Fe);
                DataStorage.Instance.AnionOnSecondStageFilter = recalculationOfWaterIndicators.AnionOnSecondStageFilters(
                    DataStorage.Instance.SilicicAcidConcentration, DataStorage.Instance.ConcentrationCOBeforeDecarbonizer);
            }

            DataStorage.Instance.NaCationOnFilter = recalculationOfWaterIndicators.NaCationFilters(
                DataStorage.Instance.ResidualOverallHarndess);
        }

        
    }
}

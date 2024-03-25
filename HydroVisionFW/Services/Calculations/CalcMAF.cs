using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.Calculations
{
    internal class CalcMAF
    {
        public CalcMAF() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            MAFStorage.Instance.F = filters.FiltrationArea(
                DataStorage.Instance.PerfomanceWTP, MAFStorage.Instance.w);

            MAFStorage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(MAFStorage.Instance.F, MAFStorage.Instance.m);
            MAFStorage.Instance.d_p = filters.FilterDiameter(MAFStorage.Instance.f_p);
            MAFStorage.Instance.f_ct = filters.FilterArea(MAFStorage.Instance.d_ct);
            MAFStorage.Instance.T_FAA = filters.FilterCycleDurationForThreeStage(MAFStorage.Instance.f_ct, MAFStorage.Instance.m, MAFStorage.Instance.h, DataStorage.Instance.PerfomanceWTP);
            MAFStorage.Instance.n = filters.NumberOfRegenerationsPerDay(MAFStorage.Instance.T_FAA, t);
            MAFStorage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(MAFStorage.Instance.f_ct, MAFStorage.Instance.h);
            MAFStorage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(MAFStorage.Instance.V_vl);
            MAFStorage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(MAFStorage.Instance.f_ct, MAFStorage.Instance.h, MAFStorage.Instance.m);
            MAFStorage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(MAFStorage.Instance.SumV_vl);
            
            MAFStorage.Instance.g_cnK = filters.WaterConsumptionForOwnNeeds(MAFStorage.Instance.SumV_vlK, MAFStorage.Instance.P_iK, MAFStorage.Instance.n);
            MAFStorage.Instance.G_100pK = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(MAFStorage.Instance.bK, MAFStorage.Instance.V_vl, MAFStorage.Instance.e_pK);
            MAFStorage.Instance.G_texK = filters.SpecificConsumptionOfChemicals(MAFStorage.Instance.G_100pK, MAFStorage.Instance.CK);
            MAFStorage.Instance.G_cutK = filters.SpecificConsumptionOfChemicalsPerDay(MAFStorage.Instance.G_texK, MAFStorage.Instance.n, MAFStorage.Instance.m);

            MAFStorage.Instance.g_cnA = filters.WaterConsumptionForOwnNeeds(MAFStorage.Instance.SumV_vlK, MAFStorage.Instance.P_iA, MAFStorage.Instance.n);
            MAFStorage.Instance.G_100pA = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(MAFStorage.Instance.bA, MAFStorage.Instance.V_vl, MAFStorage.Instance.e_pA);
            MAFStorage.Instance.G_texA = filters.SpecificConsumptionOfChemicals(MAFStorage.Instance.G_100pA, MAFStorage.Instance.CA);
            MAFStorage.Instance.G_cutA = filters.SpecificConsumptionOfChemicalsPerDay(MAFStorage.Instance.G_texA, MAFStorage.Instance.n, MAFStorage.Instance.m);






        }
    }
}

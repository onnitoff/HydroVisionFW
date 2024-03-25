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
    internal class CalcFAA
    {
        public CalcFAA() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            FAAStorage.Instance.F = filters.FiltrationArea(
                DataStorage.Instance.PerfomanceWTP, FAAStorage.Instance.w);

            FAAStorage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(FAAStorage.Instance.F, FAAStorage.Instance.m);
            FAAStorage.Instance.d_p = filters.FilterDiameter(FAAStorage.Instance.f_p);
            FAAStorage.Instance.f_ct = filters.FilterArea(FAAStorage.Instance.d_ct);
            FAAStorage.Instance.T_FAA = filters.FilterCycleDurationForThreeStage(FAAStorage.Instance.f_ct, FAAStorage.Instance.m, FAAStorage.Instance.h, DataStorage.Instance.PerfomanceWTP);
            FAAStorage.Instance.n = filters.NumberOfRegenerationsPerDay(FAAStorage.Instance.T_FAA, t);
            FAAStorage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(FAAStorage.Instance.f_ct, FAAStorage.Instance.h);
            FAAStorage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(FAAStorage.Instance.V_vl);
            FAAStorage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(FAAStorage.Instance.f_ct, FAAStorage.Instance.h, FAAStorage.Instance.m);
            FAAStorage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(FAAStorage.Instance.SumV_vl);
            FAAStorage.Instance.g_cnK = filters.WaterConsumptionForOwnNeeds(FAAStorage.Instance.SumV_vlK, FAAStorage.Instance.P_iK, FAAStorage.Instance.n);
            FAAStorage.Instance.G_100pK = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(FAAStorage.Instance.bK, FAAStorage.Instance.V_vl, FAAStorage.Instance.e_pK);




        }
    }
}

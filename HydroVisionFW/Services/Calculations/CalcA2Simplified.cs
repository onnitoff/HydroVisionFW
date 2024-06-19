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
    internal class CalcA2Simplified
    {
        public CalcA2Simplified() { }


        public void Calculations()
        {
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();

            A2StorageSimplified.Instance.f_ct = filters.FilterArea(A2StorageSimplified.Instance.d_ct);
            A2StorageSimplified.Instance.T_FAA = filters.FilterCycleDurationForSimpleAndTwoStage(A2StorageSimplified.Instance.f_ct, A2StorageSimplified.Instance.h, A2StorageSimplified.Instance.e_pA, A2StorageSimplified.Instance.m, A2StorageSimplified.Instance.Q_br_input, DataStorage.Instance.AnionOnSecondStageFilter);
            A2StorageSimplified.Instance.n = filters.NumberOfRegenerationsPerDay(A2StorageSimplified.Instance.T_FAA, DataStorage.Instance.t_Filters);
            A2StorageSimplified.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(A2StorageSimplified.Instance.f_ct, A2StorageSimplified.Instance.h);
            //A2Storage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(A2Storage.Instance.V_vl);
            A2StorageSimplified.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(A2StorageSimplified.Instance.f_ct, A2StorageSimplified.Instance.h, A2StorageSimplified.Instance.m);
            //A2Storage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(A2Storage.Instance.SumV_vl);

            A2StorageSimplified.Instance.g_cnA = filters.WaterConsumptionForOwnNeeds(A2StorageSimplified.Instance.SumV_vl, A2StorageSimplified.Instance.P_iA, A2StorageSimplified.Instance.n);
            A2StorageSimplified.Instance.G_100pA = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(A2StorageSimplified.Instance.bA, A2StorageSimplified.Instance.V_vl, A2StorageSimplified.Instance.e_pA);
            A2StorageSimplified.Instance.G_texA = filters.SpecificConsumptionOfChemicals(A2StorageSimplified.Instance.G_100pA, A2StorageSimplified.Instance.CA);
            A2StorageSimplified.Instance.G_cutA = filters.SpecificConsumptionOfChemicalsPerDay(A2StorageSimplified.Instance.G_texA, A2StorageSimplified.Instance.n, A2StorageSimplified.Instance.m);
            A2StorageSimplified.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(A2StorageSimplified.Instance.Q_br_input, A2StorageSimplified.Instance.g_cnA);
        }

        public void CaclFirstProperty()
        {
            A2StorageSimplified.Instance.Q_br_input = BoilerStorage.Instance.PerfomanceWTP;

            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            A2StorageSimplified.Instance.F = filters.FiltrationArea(A2StorageSimplified.Instance.Q_br_input, A2StorageSimplified.Instance.w);
            A2StorageSimplified.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(A2StorageSimplified.Instance.F, A2StorageSimplified.Instance.m);
            A2StorageSimplified.Instance.d_p = filters.FilterDiameter(A2StorageSimplified.Instance.f_p);
        }
    }
}

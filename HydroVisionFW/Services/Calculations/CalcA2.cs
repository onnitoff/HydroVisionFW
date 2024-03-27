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
    internal class CalcA2
    {
        public CalcA2() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();


            A2Storage.Instance.F = filters.FiltrationArea(MAFStorage.Instance.Q_br, A2Storage.Instance.w);

            A2Storage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(A2Storage.Instance.F, A2Storage.Instance.m);
            A2Storage.Instance.d_p = filters.FilterDiameter(A2Storage.Instance.f_p);
            A2Storage.Instance.f_ct = filters.FilterArea(A2Storage.Instance.d_ct);
            A2Storage.Instance.T_FAA = filters.FilterCycleDurationForThreeStage(A2Storage.Instance.f_ct, A2Storage.Instance.m, A2Storage.Instance.h, MAFStorage.Instance.Q_br);
            A2Storage.Instance.n = filters.NumberOfRegenerationsPerDay(A2Storage.Instance.T_FAA, t);
            A2Storage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(A2Storage.Instance.f_ct, A2Storage.Instance.h);
            A2Storage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(A2Storage.Instance.V_vl);
            A2Storage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(A2Storage.Instance.f_ct, A2Storage.Instance.h, A2Storage.Instance.m);
            A2Storage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(A2Storage.Instance.SumV_vl);

            A2Storage.Instance.g_cnA = filters.WaterConsumptionForOwnNeeds(A2Storage.Instance.SumV_vlK, A2Storage.Instance.P_iA, A2Storage.Instance.n);
            A2Storage.Instance.G_100pA = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(A2Storage.Instance.bA, A2Storage.Instance.V_vl, A2Storage.Instance.e_pA);
            A2Storage.Instance.G_texA = filters.SpecificConsumptionOfChemicals(A2Storage.Instance.G_100pA, A2Storage.Instance.CA);
            A2Storage.Instance.G_cutA = filters.SpecificConsumptionOfChemicalsPerDay(A2Storage.Instance.G_texA, A2Storage.Instance.n, A2Storage.Instance.m);
            A2Storage.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(MAFStorage.Instance.Q_br, A2Storage.Instance.g_cnA);
        }
    }
}

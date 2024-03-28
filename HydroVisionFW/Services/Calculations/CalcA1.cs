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
    internal class CalcA1
    {
        public CalcA1() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();


            A1Storage.Instance.f_ct = filters.FilterArea(A1Storage.Instance.d_ct);
            A1Storage.Instance.T_FAA = filters.FilterCycleDurationForSimpleAndTwoStage(A1Storage.Instance.f_ct, A1Storage.Instance.h, A1Storage.Instance.e_pA, A1Storage.Instance.m, A1Storage.Instance.Q_br_input, DataStorage.Instance.AnionOnFirstStageFilter);
            A1Storage.Instance.n = filters.NumberOfRegenerationsPerDay(A1Storage.Instance.T_FAA, t);
            A1Storage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(A1Storage.Instance.f_ct, A1Storage.Instance.h);
            //A1Storage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(A1Storage.Instance.V_vl);
            A1Storage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(A1Storage.Instance.f_ct, A1Storage.Instance.h, A1Storage.Instance.m);
            //A1Storage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(A1Storage.Instance.SumV_vl);

            A1Storage.Instance.g_cnA = filters.WaterConsumptionForOwnNeeds(A1Storage.Instance.SumV_vl, A1Storage.Instance.P_iA, A1Storage.Instance.n);
            A1Storage.Instance.G_100pA = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(A1Storage.Instance.bA, A1Storage.Instance.V_vl, A1Storage.Instance.e_pA);
            A1Storage.Instance.G_texA = filters.SpecificConsumptionOfChemicals(A1Storage.Instance.G_100pA, A1Storage.Instance.CA);
            A1Storage.Instance.G_cutA = filters.SpecificConsumptionOfChemicalsPerDay(A1Storage.Instance.G_texA, A1Storage.Instance.n, A1Storage.Instance.m);
            A1Storage.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(A1Storage.Instance.Q_br_input, A1Storage.Instance.g_cnA);
        }

        public void CaclFirstProperty()
        {
            A1Storage.Instance.Q_br_input = H2Storage.Instance.Q_br;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            A1Storage.Instance.F = filters.FiltrationArea(A1Storage.Instance.Q_br_input, A1Storage.Instance.w);
            A1Storage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(A1Storage.Instance.F, A1Storage.Instance.m);
            A1Storage.Instance.d_p = filters.FilterDiameter(A1Storage.Instance.f_p);
        }
    }
}

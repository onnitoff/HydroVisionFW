using HydroVisionFW.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.Calculations
{
    internal class CalcH1
    {
        public CalcH1() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();

            H1Storage.Instance.f_ct = filters.FilterArea(H1Storage.Instance.d_ct);
            H1Storage.Instance.T_FAA = filters.FilterCycleDurationForThreeStage(H1Storage.Instance.f_ct, H1Storage.Instance.m, H1Storage.Instance.h, A1Storage.Instance.Q_br);
            H1Storage.Instance.n = filters.NumberOfRegenerationsPerDay(H1Storage.Instance.T_FAA, t);
            H1Storage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(H1Storage.Instance.f_ct, H1Storage.Instance.h);
            H1Storage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(H1Storage.Instance.V_vl);
            H1Storage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(H1Storage.Instance.f_ct, H1Storage.Instance.h, H1Storage.Instance.m);
            H1Storage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(H1Storage.Instance.SumV_vl);

            H1Storage.Instance.g_cnK = filters.WaterConsumptionForOwnNeeds(H1Storage.Instance.SumV_vlK, H1Storage.Instance.P_iK, H1Storage.Instance.n);
            H1Storage.Instance.G_100pK = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(H1Storage.Instance.bK, H1Storage.Instance.V_vl, H1Storage.Instance.e_pK);
            H1Storage.Instance.G_texK = filters.SpecificConsumptionOfChemicals(H1Storage.Instance.G_100pK, H1Storage.Instance.CK);
            H1Storage.Instance.G_cutK = filters.SpecificConsumptionOfChemicalsPerDay(H1Storage.Instance.G_texK, H1Storage.Instance.n, H1Storage.Instance.m);
            H1Storage.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(A1Storage.Instance.Q_br, H1Storage.Instance.g_cnK);

        }

        public void CaclFirstProperty()
        {
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            H1Storage.Instance.F = filters.FiltrationArea(A1Storage.Instance.Q_br, H1Storage.Instance.w);
            H1Storage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(H1Storage.Instance.F, H1Storage.Instance.m);
            H1Storage.Instance.d_p = filters.FilterDiameter(H1Storage.Instance.f_p);
        }
    }
}

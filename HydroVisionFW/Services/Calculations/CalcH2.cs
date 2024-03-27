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
    internal class CalcH2
    {
        public CalcH2() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();

            H2Storage.Instance.f_ct = filters.FilterArea(H2Storage.Instance.d_ct);
            H2Storage.Instance.T_FAA = filters.FilterCycleDurationForThreeStage(H2Storage.Instance.f_ct, H2Storage.Instance.m, H2Storage.Instance.h, A2Storage.Instance.Q_br);
            H2Storage.Instance.n = filters.NumberOfRegenerationsPerDay(H2Storage.Instance.T_FAA, t);
            H2Storage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(H2Storage.Instance.f_ct, H2Storage.Instance.h);
            //H2Storage.Instance.V_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilterCationAndAnion(H2Storage.Instance.V_vl);
            H2Storage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(H2Storage.Instance.f_ct, H2Storage.Instance.h, H2Storage.Instance.m);
            //H2Storage.Instance.SumV_vlK = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFiltersCationAndAnion(H2Storage.Instance.SumV_vl);

            H2Storage.Instance.g_cnK = filters.WaterConsumptionForOwnNeeds(H2Storage.Instance.SumV_vl, H2Storage.Instance.P_iK, H2Storage.Instance.n);
            H2Storage.Instance.G_100pK = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(H2Storage.Instance.bK, H2Storage.Instance.V_vl, H2Storage.Instance.e_pK);
            H2Storage.Instance.G_texK = filters.SpecificConsumptionOfChemicals(H2Storage.Instance.G_100pK, H2Storage.Instance.CK);
            H2Storage.Instance.G_cutK = filters.SpecificConsumptionOfChemicalsPerDay(H2Storage.Instance.G_texK, H2Storage.Instance.n, H2Storage.Instance.m);
            H2Storage.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(A2Storage.Instance.Q_br, H2Storage.Instance.g_cnK);

        }

        public void CaclFirstProperty()
        {
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            H2Storage.Instance.F = filters.FiltrationArea(A2Storage.Instance.Q_br, H2Storage.Instance.w);
            H2Storage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(H2Storage.Instance.F, H2Storage.Instance.m);
            H2Storage.Instance.d_p = filters.FilterDiameter(H2Storage.Instance.f_p);
        }
    }
}

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
    internal class CalcNa
    {
        public CalcNa() { }

        public void Calculations()
        {
            const double t = 3.5;
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();

            NaStorage.Instance.f_ct = filters.FilterArea(NaStorage.Instance.d_ct);
            NaStorage.Instance.T_FAA = filters.FilterCycleDurationForSimpleAndTwoStage(NaStorage.Instance.f_ct, NaStorage.Instance.h, NaStorage.Instance.e_pK, NaStorage.Instance.m, BoilerStorage.Instance.PerfomanceWTPForHeatingSystem, DataStorage.Instance.NaCationOnFilter);
            NaStorage.Instance.n = filters.NumberOfRegenerationsPerDay(NaStorage.Instance.T_FAA, t);
            NaStorage.Instance.V_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInOneFilter(NaStorage.Instance.f_ct, NaStorage.Instance.h);
            NaStorage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(NaStorage.Instance.f_ct, NaStorage.Instance.h, NaStorage.Instance.m);

            NaStorage.Instance.g_cnK = filters.WaterConsumptionForOwnNeeds(NaStorage.Instance.SumV_vl, NaStorage.Instance.P_iK, NaStorage.Instance.n);
            NaStorage.Instance.G_100pK = filters.ConsumptionOfChemicalReagentsForRegenerationOfOneFilter(NaStorage.Instance.bK, NaStorage.Instance.V_vl, NaStorage.Instance.e_pK);
            NaStorage.Instance.G_texK = filters.SpecificConsumptionOfChemicals(NaStorage.Instance.G_100pK, NaStorage.Instance.CK);
            NaStorage.Instance.G_cutK = filters.SpecificConsumptionOfChemicalsPerDay(NaStorage.Instance.G_texK, NaStorage.Instance.n, NaStorage.Instance.m);
            NaStorage.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(BoilerStorage.Instance.PerfomanceWTPForHeatingSystem, NaStorage.Instance.g_cnK);

            BoilerStorage.Instance.PerfomanceOF = NaStorage.Instance.Q_br + H1Storage.Instance.Q_br;
        }

        public void CaclFirstProperty()
        {
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            NaStorage.Instance.F = filters.FiltrationArea(BoilerStorage.Instance.PerfomanceWTPForHeatingSystem, NaStorage.Instance.w);
            NaStorage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(NaStorage.Instance.F, NaStorage.Instance.m);
            NaStorage.Instance.d_p = filters.FilterDiameter(NaStorage.Instance.f_p);
        }
    }
}

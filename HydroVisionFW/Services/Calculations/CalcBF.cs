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
    internal class CalcBF
    {
        public CalcBF() { }

        public void Calculations()
        {
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();

            BFStorage.Instance.f_ct = filters.FilterArea(BFStorage.Instance.d_ct);
            BFStorage.Instance.g_vzr = filters.WaterConsumptionForLooseningWashing(BFStorage.Instance.i, BFStorage.Instance.f_ct, BFStorage.Instance.t_vzr);
            BFStorage.Instance.g_otm = filters.WaterConsumptionForCleaningTheClarificationFilter(BFStorage.Instance.f_ct, BFStorage.Instance.w, BFStorage.Instance.t_otm);
            BFStorage.Instance.g_0 = filters.HourlyWaterConsumptionForWashingTheClarificationFilter(BFStorage.Instance.g_vzr, BFStorage.Instance.g_otm, BFStorage.Instance.m, BFStorage.Instance.n);
            BFStorage.Instance.Q_br = filters.WaterConsumptionForTheNextGroupOfFilters(BFStorage.Instance.Q_bf_input, BFStorage.Instance.g_0);
            BFStorage.Instance.w_m1 = filters.ActualFiltrationRate(BFStorage.Instance.Q_br, BFStorage.Instance.m, BFStorage.Instance.f_ct);

            BFStorage.Instance.SumV_vl = filters.VolumeOfIonExchangeMaterialsInWetStateInGroupFilters(BFStorage.Instance.f_ct, BFStorage.Instance.h, BFStorage.Instance.m);
        }

        public void CaclFirstProperty()
        {
            CalculationOfIonExchangeFilters filters = new CalculationOfIonExchangeFilters();
            BFStorage.Instance.Q_bf_input = filters.PerfomanceBrighteningFilters(H1Storage.Instance.Q_br, NaStorage.Instance.Q_br);
            BFStorage.Instance.F = filters.FiltrationArea(BFStorage.Instance.Q_bf_input, BFStorage.Instance.w);
            BFStorage.Instance.f_p = filters.RequiredFiltrationAreaOfEachFilter(BFStorage.Instance.F, BFStorage.Instance.m);
            BFStorage.Instance.d_p = filters.FilterDiameter(BFStorage.Instance.f_p);
        }
    }

}

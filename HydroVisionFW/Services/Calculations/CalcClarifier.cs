using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Model.DataBaseModel;
using HydroVisionFW.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.Calculations
{
    internal class CalcClarifier
    {
        public CalcClarifier() { }

        public void Calculations()
        {
            CalculationOfClarifiers clarifiers = new CalculationOfClarifiers();

            ClarifierStorage.Instance.G_k = clarifiers.RequiredAmountOfReagentsForCoagulation(BFStorage.Instance.Q_br, ClarifierStorage.Instance.E_k, DataStorage.Instance.K_Al_Fe);
            ClarifierStorage.Instance.G_k_tex = clarifiers.ConsumptionOfTechnicalCoagulantPerDay(ClarifierStorage.Instance.G_k, ClarifierStorage.Instance.C);
            ClarifierStorage.Instance.G_PAA = clarifiers.ConsumptionOfPolyacrylamidePerDay(BFStorage.Instance.Q_br, ClarifierStorage.Instance.d_PAA);
            ClarifierStorage.Instance.d_izv = clarifiers.DoseOfLime(DataStorage.Instance.OverallHardness, DataStorage.Instance.Final_Mg, DataStorage.Instance.K_Al_Fe, DataStorage.Instance.ExcessLime);
            ClarifierStorage.Instance.G_izv = clarifiers.ConsumptionLime(BFStorage.Instance.Q_br, ClarifierStorage.Instance.d_izv);
        }

        public void CaclFirstProperty()
        {
            CalculationOfClarifiers clarifiers = new CalculationOfClarifiers();
            ClarifierStorage.Instance.v_ocv = clarifiers.CapacityOfEachOfTwoClarifiers(BFStorage.Instance.Q_br, ClarifierStorage.Instance.t, ClarifierStorage.Instance.m);
        }
    }
}

using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Model;
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

        /// <summary>Коллекция для ComboBox Осветлитель</summary>
        public List<ClarifierModel> SuitableClarifier { get; set; }

        public void Calculations()
        {
            CalculationOfClarifiers clarifiers = new CalculationOfClarifiers();

            ClarifierStorage.Instance.G_k = clarifiers.RequiredAmountOfReagentsForCoagulation(BFStorage.Instance.Q_br, ClarifierStorage.Instance.E_k, DataStorage.Instance.K_Al_Fe);
            ClarifierStorage.Instance.G_k_tex = clarifiers.ConsumptionOfTechnicalCoagulantPerDay(ClarifierStorage.Instance.G_k, ClarifierStorage.Instance.C);
            ClarifierStorage.Instance.G_PAA = clarifiers.ConsumptionOfPolyacrylamidePerDay(BFStorage.Instance.Q_br, ClarifierStorage.Instance.d_PAA);
            ClarifierStorage.Instance.d_izv = clarifiers.DoseOfLime(DataStorage.Instance.OverallHardness, DataStorage.Instance.Final_Mg, DataStorage.Instance.K_Al_Fe, DataStorage.Instance.ExcessLime);
            ClarifierStorage.Instance.G_izv = clarifiers.ConsumptionLime(BFStorage.Instance.Q_br, ClarifierStorage.Instance.d_izv);

            DataRepository.DataRepository data = new DataRepository.DataRepository();
            int idClarifier = 1;

            // обращение к бд фильтры
            Task.Run(async () =>
            {
                SuitableClarifier = await data.GetClarifierAsync(idClarifier);
            }).Wait();

            foreach (var item in SuitableClarifier)
            {
                if (item.Volume > ClarifierStorage.Instance.v_ocv)
                {
                    ClarifierStorage.Instance.Name = item.Name;
                    ClarifierStorage.Instance.Perfomance = item.Perfomance;
                    ClarifierStorage.Instance.Volume = item.Volume;
                    ClarifierStorage.Instance.Diameter = item.Diameter;
                    ClarifierStorage.Instance.Height = item.Height;
                    return;
                }
            }

        }

        public void CaclFirstProperty()
        {
            CalculationOfClarifiers clarifiers = new CalculationOfClarifiers();
            ClarifierStorage.Instance.v_ocv = clarifiers.CapacityOfEachOfTwoClarifiers(BFStorage.Instance.Q_br, ClarifierStorage.Instance.t, ClarifierStorage.Instance.m);
        }
    }
}

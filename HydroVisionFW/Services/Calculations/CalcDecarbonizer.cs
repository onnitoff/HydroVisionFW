using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Model;
using HydroVisionFW.Services.DataRepository;
using HydroVisionFW.Services.DataStorages;
using MathWater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.Calculations
{
    internal class CalcDecarbonizer
    {
        public CalcDecarbonizer() { }
        /// <summary>Коллекция для вывода Декарбонизторов</summary>
        public List<DecarbonizerModel> SuitableDecarbonizer { get; set; }

        private DecarbonizerModel _SelectedSuitableDecarbonizer;
        /// <summary>Свойство для Select Декарбонизатор</summary>
        public DecarbonizerModel SelectedSuitableDecarbonizer { get; set; }

        public void Calculations()
        {
            DecarbonizerCalculation decarbonizer = new DecarbonizerCalculation();
            DecarbonizerStorage.Instance.W_b_oct = decarbonizer.CarbonateAlkalinity(DataStorage.Instance.ExcessLime);
            DecarbonizerStorage.Instance.W_k_oct = decarbonizer.BicarbonateAlkalinity(DataStorage.Instance.ResidualHardnessCarbonate, DataStorage.Instance.ExcessLime);
            DecarbonizerStorage.Instance.C_CO_vx = decarbonizer.ConcentrationCO2BeforeTheDecarbonizer(DecarbonizerStorage.Instance.W_b_oct, DecarbonizerStorage.Instance.W_k_oct);

            if (DataStorage.Instance.DesaltingScheme == "simplified")
                DecarbonizerStorage.Instance.Q_d_input = A2StorageSimplified.Instance.Q_br;
            else
                DecarbonizerStorage.Instance.Q_d_input = H2Storage.Instance.Q_br;

            DecarbonizerStorage.Instance.Q_d = decarbonizer.CalculatedCapacityInCalciner(DecarbonizerStorage.Instance.Q_d_input, DecarbonizerStorage.Instance.m);
            DecarbonizerStorage.Instance.b_CO = decarbonizer.AmountOfCO2RemovedInTheDecarbonizer(DecarbonizerStorage.Instance.Q_d, DecarbonizerStorage.Instance.C_CO_vx, DecarbonizerStorage.Instance.C_CO_oct);
            DecarbonizerStorage.Instance.F_dec = decarbonizer.DesorptionArea(DecarbonizerStorage.Instance.b_CO, DecarbonizerStorage.Instance.K_j, DecarbonizerStorage.Instance.deltaC_CO);
            DecarbonizerStorage.Instance.F_nac = decarbonizer.RequiredNozzleSurfaceArea(DecarbonizerStorage.Instance.F_dec);
            DecarbonizerStorage.Instance.V_nac = decarbonizer.NozzleVolume(DecarbonizerStorage.Instance.F_nac, DecarbonizerStorage.Instance.f_kp);
            DecarbonizerStorage.Instance.f_d = decarbonizer.CalcinerCrossSectionalArea(DecarbonizerStorage.Instance.Q_d, DecarbonizerStorage.Instance.b);
            DecarbonizerStorage.Instance.d_d = decarbonizer.CalcinerDiameter(DecarbonizerStorage.Instance.f_d);
            DecarbonizerStorage.Instance.h_nac = decarbonizer.RaschigRingAttachmentHeight(DecarbonizerStorage.Instance.V_nac, DecarbonizerStorage.Instance.f_d);
            DecarbonizerStorage.Instance.Q_vozd = decarbonizer.AirConsumptionForWaterDecarbonization(DecarbonizerStorage.Instance.Q_d);


            DataRepository.DataRepository data = new DataRepository.DataRepository();
            // обращение к бд декарбонизаторы
            Task.Run(async () =>
            {
                SuitableDecarbonizer = await data.GetDecarbonizerAsync();
            }).Wait();

            foreach (var item in SuitableDecarbonizer)
            {
                if (item.Diameter > DecarbonizerStorage.Instance.d_d)
                {
                    DecarbonizerStorage.Instance.Perfomance = item.Perfomance;
                    DecarbonizerStorage.Instance.Diameter = item.Diameter;
                    DecarbonizerStorage.Instance.CrossAreaSections = item.CrossAreaSections;
                    DecarbonizerStorage.Instance.AirFlow = item.AirFlow;
                }
            }




        }

        public void CaclFirstProperty()
        {
            
        }
    }
}

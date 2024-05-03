using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionDesign.Services.TestValues
{
    internal class Values
    {
        public Values() 
        {
            #region Default
            //WaterQuality
            DataStorage.Instance.Final_Ca = 2.22;
            DataStorage.Instance.Init_Na = 12;
            DataStorage.Instance.Final_HCO = 1.7;
            DataStorage.Instance.Init_SO = 71.3;
            DataStorage.Instance.Init_Cl = 10;
            DataStorage.Instance.Init_NO = 0;
            DataStorage.Instance.Init_SiO = 6.3;
            DataStorage.Instance.OverallHardness = 3.08;
            DataStorage.Instance.DryResidue = 244;
            DataStorage.Instance.Oxidability = 13.2;

            //PerfomanceWTP
            BoilerStorage.Instance.ElectricPower = 1000;
            //DataStorage.Instance.BoilerProductivity = 1000;
            BoilerStorage.Instance.NumberOfBoilersFirst = 4;
            //DataStorage.Instance.TurbineType = 8;
            BoilerStorage.Instance.NumberOfTurbinesFirst = 4;
            //DataStorage.Instance.FuelType = 1;
            BoilerStorage.Instance.VacationCouple = 0;
            BoilerStorage.Instance.Losses = 0;
            BoilerStorage.Instance.BlowdownLosses = 0;


            //MAF
            MAFStorage.Instance.m = 3;
            MAFStorage.Instance.w = 50;

            MAFStorage.Instance.CK = 75;
            MAFStorage.Instance.CA = 42;


            //A2
            A2Storage.Instance.m = 3;
            A2Storage.Instance.w = 20;

            A2Storage.Instance.CA = 42;


            //H2
            H2Storage.Instance.m = 3;
            H2Storage.Instance.w = 40;

            H2Storage.Instance.CK = 75;


            //A1
            A1Storage.Instance.m = 3;
            A1Storage.Instance.w = 20;

            A1Storage.Instance.CA = 42;


            //H1
            H1Storage.Instance.m = 3;
            H1Storage.Instance.w = 30;

            H1Storage.Instance.CK = 75;

            //Na
            NaStorage.Instance.m = 3;
            NaStorage.Instance.w = 30;

            NaStorage.Instance.CK = 95;

            //A2Simplified
            A2StorageSimplified.Instance.m = 3;
            A2StorageSimplified.Instance.w = 20;

            A2StorageSimplified.Instance.CA = 42;

            //BF
            BFStorage.Instance.m = 12;
            BFStorage.Instance.w = 10;

            //Clarifier
            ClarifierStorage.Instance.m = 2;
            ClarifierStorage.Instance.t = 1;
            ClarifierStorage.Instance.E_k = 57.02;
            ClarifierStorage.Instance.C = 88.5;
            ClarifierStorage.Instance.d_PAA = 1;

            //Decarbonizer
            DecarbonizerStorage.Instance.m = 2;
            DecarbonizerStorage.Instance.C_CO_oct = 6;
            DecarbonizerStorage.Instance.K_j = 0.5;
            DecarbonizerStorage.Instance.deltaC_CO = 0.015;
            DecarbonizerStorage.Instance.f_kp = 206;
            DecarbonizerStorage.Instance.b = 60;

            #endregion



            #region My
            //WaterQuality
            DataStorage.Instance.Final_Ca = 4.6;
            DataStorage.Instance.Init_Na = 69;
            DataStorage.Instance.Final_HCO = 7.1;
            DataStorage.Instance.Init_SO = 125.5;
            DataStorage.Instance.Init_Cl = 49.2;
            DataStorage.Instance.Init_NO = 0;
            DataStorage.Instance.Init_SiO = 0;
            DataStorage.Instance.OverallHardness = 8.1;
            DataStorage.Instance.DryResidue = 708;
            DataStorage.Instance.Oxidability = 15.2;

            //PerfomanceWTP
            BoilerStorage.Instance.ElectricPower = 1500;
            //DataStorage.Instance.BoilerProductivity = 1000;
            BoilerStorage.Instance.NumberOfBoilersFirst = 3;
            //DataStorage.Instance.TurbineType = 8;
            BoilerStorage.Instance.NumberOfTurbinesFirst = 3;
            //DataStorage.Instance.FuelType = 1;
            BoilerStorage.Instance.VacationCouple = 0;
            BoilerStorage.Instance.Losses = 0;
            BoilerStorage.Instance.BlowdownLosses = 0.5;


            //MAF
            MAFStorage.Instance.m = 3;
            MAFStorage.Instance.w = 50;

            MAFStorage.Instance.CK = 75;
            MAFStorage.Instance.CA = 42;


            //A2
            A2Storage.Instance.m = 3;
            A2Storage.Instance.w = 20;

            A2Storage.Instance.CA = 42;


            //H2
            H2Storage.Instance.m = 3;
            H2Storage.Instance.w = 30;

            H2Storage.Instance.CK = 75;


            //A1
            A1Storage.Instance.m = 3;
            A1Storage.Instance.w = 20;

            A1Storage.Instance.CA = 42;


            //H1
            H1Storage.Instance.m = 3;
            H1Storage.Instance.w = 30;

            H1Storage.Instance.CK = 75;

            //Na
            NaStorage.Instance.m = 3;
            NaStorage.Instance.w = 30;

            NaStorage.Instance.CK = 95;

            //A2Simplified
            A2StorageSimplified.Instance.m = 3;
            A2StorageSimplified.Instance.w = 20;

            A2StorageSimplified.Instance.CA = 42;

            //BF
            BFStorage.Instance.m = 6;
            BFStorage.Instance.w = 10;

            //Clarifier
            ClarifierStorage.Instance.m = 2;
            ClarifierStorage.Instance.t = 1;
            ClarifierStorage.Instance.E_k =75.16;
            ClarifierStorage.Instance.C = 50;
            ClarifierStorage.Instance.d_PAA = 0.8;

            //Decarbonizer
            DecarbonizerStorage.Instance.m = 1;
            DecarbonizerStorage.Instance.C_CO_oct = 6;
            DecarbonizerStorage.Instance.K_j = 0.5;
            DecarbonizerStorage.Instance.deltaC_CO = 0.015;
            DecarbonizerStorage.Instance.f_kp = 206;
            DecarbonizerStorage.Instance.b = 60;

            #endregion


            #region Начальные параметры констант
            DataStorage.Instance.K_Al = 0.5;
            DataStorage.Instance.K_Fe = 0.45;
            DataStorage.Instance.ResidualHardnessCarbonate = 0.7;
            DataStorage.Instance.CationOnSecondStageFilter = 0.3;
            DataStorage.Instance.t_Filters = 3.5;

            BFStorage.Instance.i = 12;
            BFStorage.Instance.t_vzr = 8;
            BFStorage.Instance.t_otm = 10;
            BFStorage.Instance.n = 2;


            #endregion



        }
    }
}

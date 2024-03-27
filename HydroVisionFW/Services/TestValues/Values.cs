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
            DataStorage.Instance.PresenceOfOnceThroughBoilers = true ;
            DataStorage.Instance.PresenceOfCentralHeating = true ;

            //PerfomanceWTP
            DataStorage.Instance.ElectricPower = 1000;
            //DataStorage.Instance.BoilerProductivity = 1000;
            DataStorage.Instance.NumberOfBoilersFirst = 4;
            //DataStorage.Instance.TurbineType = 8;
            DataStorage.Instance.NumberOfTurbinesFirst = 4;
            //DataStorage.Instance.FuelType = 1;
            DataStorage.Instance.VacationCouple = 0;
            DataStorage.Instance.Losses = 0;
            DataStorage.Instance.BlowdownLosses = 0;


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


        }
    }
}

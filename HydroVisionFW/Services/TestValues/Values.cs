using HydroVisionDesign.Services.DataStorages;
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
            DataStorage.Instance.NumberOfBoilers = 4;
            //DataStorage.Instance.TurbineType = 8;
            DataStorage.Instance.NumberOfTurbines = 4;
            //DataStorage.Instance.FuelType = 1;
            DataStorage.Instance.VacationCouple = 0;
            DataStorage.Instance.Losses = 0;
            DataStorage.Instance.BlowdownLosses = 0;

        }
    }
}

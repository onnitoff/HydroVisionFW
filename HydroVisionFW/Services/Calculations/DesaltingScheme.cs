using HydroVisionDesign.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroVisionFW.Services.Calculations
{
    internal class DesaltingScheme
    {
        public void IsDesaltingScheme()
        {
            if (DataStorage.Instance.SumOfStrongAcidAnions < 2 && DataStorage.Instance.BoilerTypeFirst == 1 && DataStorage.Instance.BoilerTypeSecond == 1) // упрощенная схема
            {
                DataStorage.Instance.DesaltingScheme = "simplified";
            }
            else if (DataStorage.Instance.SumOfStrongAcidAnions < 5) // двухступенчатая схема
            {
                if (DataStorage.Instance.BoilerTypeFirst == 2 || DataStorage.Instance.BoilerTypeSecond == 2)
                    DataStorage.Instance.DesaltingScheme = "three-stage";
                else
                    DataStorage.Instance.DesaltingScheme = "two-stage";
            }
        }
    }
}

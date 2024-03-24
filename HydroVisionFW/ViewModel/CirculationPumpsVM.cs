using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HydroVisionDesign.ViewModel
{
    class CirculationPumpsVM : ViewModelBase
    {
        private readonly WaterIndicatorModel _waterIndicator;

        public CirculationPumpsVM()
		{
			_waterIndicator = new WaterIndicatorModel();
		}

	}
}

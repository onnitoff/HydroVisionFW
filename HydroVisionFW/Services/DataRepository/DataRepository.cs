using HydroVisionFW.Model.DataBaseModel;
using HydroVisionFW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HydroVisionFW.Services.DataRepository
{
    internal class DataRepository
    {
        public async Task<List<BrandOfIonModel>> GetBrandIonAsync()
        {
            using (var context = new WaterContext())
            {
                return await (from first in context.ExchangeCapacityAndReagentConsumptionFSD
                              join second in context.BrandUseIon on first.IdBrandUseIon equals second.Id
                              select new BrandOfIonModel
                              {
                                  Id = first.Id,
                                  Name = second.Name,
                                  SpecificConsumptionFirst = (double)first.SpecificConsumptionFirst,
                                  SpecificConsumptionSecond = (double)first.SpecificConsumptionSecond
                              }).ToListAsync();

            }
        }

        //public async Task<double> GetSpecificConsumptionOfChemicalReagents(int id)
        //{
        //    using (var context = new WaterContext())
        //    {
        //        return await context.ExchangeCapacityAndReagentConsumptionFSD
        //            .Where(x => x.Id == id)
        //            .Select(x => (double)x.SpecificConsumptionFirst)
        //            .FirstOrDefaultAsync();
        //    }
        //}

        public async Task<List<FilterModel>> GetFilterMAAsync()
        {
            using (var context = new WaterContext())
            {
                return await (from first in context.Filters
                              join second in context.FilterType on first.IdFilterTypes equals second.Id
                              join third in context.OperatingPressure on first.IdOperatingPressure equals third.Id
                              where second.Id == 7 
                              select new FilterModel
                              {
                                  Id = first.Id,
                                  Name = first.Cipheer,
                                  OperatingPressure = (double)third.OperatingPressure1,
                                  Diameter = first.Diameter,
                                  IonExchangerLayerHieght = (int)first.IonExchangerLayerHieght,
                                  FilterPerfomance = (int)first.FilterPerfomance,
                              }).ToListAsync();

            }
        }
    }
}

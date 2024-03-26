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
                                  Name = second.Name
                              }).ToListAsync();

            }
        }
    }
}

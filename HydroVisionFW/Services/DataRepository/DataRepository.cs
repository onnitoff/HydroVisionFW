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
        /// <summary>обращение к бд и вытягивание список фильтров</summary>
        /// <returns>List FilterModel</returns>
        public async Task<List<FilterModel>> GetFilterAsync(int id)
        {
            using (var context = new WaterContext())
            {
                return await (from first in context.Filters
                              join second in context.FilterType on first.IdFilterTypes equals second.Id
                              join third in context.OperatingPressure on first.IdOperatingPressure equals third.Id
                              where second.Id == id
                              select new FilterModel
                              {
                                  Id = first.Id,
                                  Name = first.Cipheer,
                                  OperatingPressure = (double)third.OperatingPressure1,
                                  Diameter = first.Diameter,
                                  IonExchangerLayerHieght = (int)first.IonExchangerLayerHieght,
                                  FilterPerfomance = (int)first.FilterPerfomance
                              }).ToListAsync();

            }
        }

        #region MAF
        /// <summary>обращение к бд и вытягивание брендов ионитов ФСД</summary>
        /// <returns>List BrandOfIonModel</returns>
        public async Task<List<BrandOfIonModel>> GetBrandIonMAFAsync()
        {
            using (var context = new WaterContext())
            {
                return await (from first in context.ExchangeCapacityAndReagentConsumptionFSD
                              join second in context.BrandUseIon on first.IdBrandUseIon equals second.Id
                              join third in context.WaterConsumptionForOwnNeedsFSD on first.Id equals third.Id
                              select new BrandOfIonModel
                              {
                                  Id = first.Id,
                                  Name = second.Name,
                                  WorkingExchangeCapacity = first.WorkingExchangeCapacity,
                                  SpecificConsumptionFirst = (double)first.SpecificConsumptionFirst,
                                  SpecificConsumptionSecond = (double)first.SpecificConsumptionSecond,
                                  GeneralWaterConsumptionCation = (double)third.GeneralWaterConsumptionCation,
                                  GeneralWaterConsumptionAnion = (double)third.GeneralWaterConsumptionAnion
                              }).ToListAsync();
            }
        }

        

        #endregion

        #region A2

        /// <summary>обращение к бд и вытягивание брендов ионитов А2</summary>
        /// <returns>List BrandOfIonModel</returns>
        public async Task<List<BrandOfIonModel>> GetBrandIonAsync(int id)
        {
            using (var context = new WaterContext())
            {
                return await (from first in context.ExchangeCapacityAndReagentConsumption
                              join second in context.BrandUseIon on first.IdBrandUseIon equals second.Id
                              join third in context.WaterConsumptionForOwnNeeds on first.IdBrandUseIon equals third.IdBrandUseIon
                              where first.IdIonFiltersNames == id
                              select new BrandOfIonModel
                              {
                                  Id = first.Id,
                                  Name = second.Name,
                                  WorkingExchangeCapacity = first.WorkingExchangeCapacityMin,
                                  SpecificConsumptionFirst = first.SpecificConsumptionMin,
                                  GeneralWaterConsumptionAnion = (double)third.GeneralWaterConsumption
                              }).ToListAsync();
            }
        }

        /// <summary>обращение к бд и вытягивание список фильтров A</summary>
        /// <returns>List FilterModel</returns>
        public async Task<List<FilterModel>> GetFilterAAsync(int id)
        {
            using (var context = new WaterContext())
            {
                return await (from first in context.Filters
                              join second in context.FilterType on first.IdFilterTypes equals second.Id
                              join third in context.OperatingPressure on first.IdOperatingPressure equals third.Id
                              where second.Id == id
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
        #endregion

    }
}

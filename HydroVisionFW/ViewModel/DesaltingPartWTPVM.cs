using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Infrastructure.Commands;
using HydroVisionDesign.Services.DataStorages;
using HydroVisionFW.Services.Calculations;
using HydroVisionFW.Services.DataStorages;
using HydroVisionFW.View;
using HydroVisionFW.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HydroVisionDesign.ViewModel
{
    internal class DesaltingPartWTPVM : ViewModelBase
    {
        #region Свойство Hidden

        private bool _IsHiddenMain = false;
        /// <summary>Свойство для скрытия главного Grid</summary>
        public bool IsHiddenMain
        {
            get => _IsHiddenMain;
            set => Set(ref _IsHiddenMain, value);
        }

        #region блоки

        private bool _IsHiddenCationProperty = false;
        /// <summary>Свойство для скрытия свойств Катионов/summary>
        public bool IsHiddenCationProperty
        {
            get => _IsHiddenCationProperty;
            set => Set(ref _IsHiddenCationProperty, value);
        }

        private bool _IsHiddenAnionProperty = false;
        /// <summary>Свойство для скрытия свойств Анионов/summary>
        public bool IsHiddenAnionProperty
        {
            get => _IsHiddenAnionProperty;
            set => Set(ref _IsHiddenAnionProperty, value);
        }

        private bool _IsHiddenFilterProperty = false;
        /// <summary>Свойство для скрытия свойств фильтра</summary>
        public bool IsHiddenFilterProperty
        {
            get => _IsHiddenFilterProperty;
            set => Set(ref _IsHiddenFilterProperty, value);
        }

        private bool _IsHiddenVolumeOfIonForMAFProperty = false;
        /// <summary>Свойство для скрытия свойств ФСД</summary>
        public bool IsHiddenVolumeOfIonForMAFProperty
        {
            get => _IsHiddenVolumeOfIonForMAFProperty;
            set => Set(ref _IsHiddenVolumeOfIonForMAFProperty, value);
        }

        private bool _IsHiddenVolumeOfIonForIonFilterProperty = false;
        /// <summary>Свойство для скрытия свойств ионитных фильтров</summary>
        public bool IsHiddenVolumeOfIonForIonFilterProperty
        {
            get => _IsHiddenVolumeOfIonForIonFilterProperty;
            set => Set(ref _IsHiddenVolumeOfIonForIonFilterProperty, value);
        }

        private bool _IsHiddenWaterFlowToTheNextStage = false;
        /// <summary>Свойство для скрытия свойства расхода воды на след ступень</summary>
        public bool IsHiddenWaterFlowToTheNextStage
        {
            get => _IsHiddenWaterFlowToTheNextStage;
            set => Set(ref _IsHiddenWaterFlowToTheNextStage, value);
        }

        private bool _IsHiddenClarificationFilterProp = false;
        /// <summary>Свойство для скрытия свойства ОФ</summary>
        public bool IsHiddenClarificationFilterProp
        {
            get => _IsHiddenClarificationFilterProp;
            set => Set(ref _IsHiddenClarificationFilterProp, value);
        }

        private bool _IsHiddenClarifierProp = false;
        /// <summary>Свойство для скрытия свойства Осветлителя</summary>
        public bool IsHiddenClarifierProp
        {
            get => _IsHiddenClarifierProp;
            set => Set(ref _IsHiddenClarifierProp, value);
        }

        private bool _IsHiddenDecarbonizerProp = false;
        /// <summary>Свойство для скрытия свойства Декарбонизатора</summary>
        public bool IsHiddenDecarbonizerProp
        {
            get => _IsHiddenDecarbonizerProp;
            set => Set(ref _IsHiddenDecarbonizerProp, value);
        }

        #endregion

        #region иконки оборудования

        private bool _IsHiddenH1Image = false;
        /// <summary>Свойство для скрытия иконки Н1/summary>
        public bool IsHiddenH1Image
        {
            get => _IsHiddenH1Image;
            set => Set(ref _IsHiddenH1Image, value);
        }

        private bool _IsHiddenA1Image = false;
        /// <summary>Свойство для скрытия иконки A1/summary>
        public bool IsHiddenA1Image
        {
            get => _IsHiddenA1Image;
            set => Set(ref _IsHiddenA1Image, value);
        }

        private bool _IsHiddenH2Image = false;
        /// <summary>Свойство для скрытия иконки Н2/summary>
        public bool IsHiddenH2Image
        {
            get => _IsHiddenH2Image;
            set => Set(ref _IsHiddenH2Image, value);
        }

        private bool _IsHiddenA2Image = false;
        /// <summary>Свойство для скрытия иконки A2/summary>
        public bool IsHiddenA2Image
        {
            get => _IsHiddenA2Image;
            set => Set(ref _IsHiddenA2Image, value);
        }

        private bool _IsHiddenMAImage = false;
        /// <summary>Свойство для скрытия иконки ФСД/summary>
        public bool IsHiddenMAImage
        {
            get => _IsHiddenMAImage;
            set => Set(ref _IsHiddenMAImage, value);
        }

        private bool _IsHiddenA2SimplifiedImage = false;
        /// <summary>Свойство для скрытия иконки A2Simplified/summary>
        public bool IsHiddenA2SimplifiedImage
        {
            get => _IsHiddenA2SimplifiedImage;
            set => Set(ref _IsHiddenA2SimplifiedImage, value);
        }

        private bool _IsHiddenNaImage = false;
        /// <summary>Свойство для скрытия иконки Na/summary>
        public bool IsHiddenNaImage
        {
            get => _IsHiddenNaImage;
            set => Set(ref _IsHiddenNaImage, value);
        }

        #endregion

        #region тип схемы

        private bool _IsHiddenThreeStage = false;
        /// <summary>Свойство для скрытия трехступенчатой схемы/summary>
        public bool IsHiddenThreeStage
        {
            get => _IsHiddenThreeStage;
            set => Set(ref _IsHiddenThreeStage, value);
        }

        private bool _IsHiddenTwoStage = false;
        /// <summary>Свойство для скрытия двухступенчатой схемы/summary>
        public bool IsHiddenTwoStage
        {
            get => _IsHiddenTwoStage;
            set => Set(ref _IsHiddenTwoStage, value);
        }

        private bool _IsHiddenSimplified = false;
        /// <summary>Свойство для скрытия упрощенной схемы/summary>
        public bool IsHiddenSimplified
        {
            get => _IsHiddenSimplified;
            set => Set(ref _IsHiddenSimplified, value);
        }

        private bool _IsHiddenNa = false;
        /// <summary>Свойство для скрытия Na схемы/summary>
        public bool IsHiddenNa
        {
            get => _IsHiddenNa;
            set => Set(ref _IsHiddenNa, value);
        }



        #endregion

        #endregion

        #region Свойство textBox 

        private double _FiltrationArea;
        /// <summary>Свойство для Площадь фильтрования</summary>
        public double FiltrationArea
        {
            get => _FiltrationArea;
            set => Set(ref _FiltrationArea, value);
        }

        private double _FiltrationSpeed;
        /// <summary>Свойство для Скорость фильтрования</summary>
        public double FiltrationSpeed
        {
            get => _FiltrationSpeed;
            set => Set(ref _FiltrationSpeed, value);
        }

        private double _WaterConsumptionPerFilter;
        /// <summary>Свойство для Расход воды на фильтр</summary>
        public double WaterConsumptionPerFilter
        {
            get => _WaterConsumptionPerFilter;
            set => Set(ref _WaterConsumptionPerFilter, value);
        }

        private double _FiltrationAreaOfEachFilter;
        /// <summary>Свойство для Площадь фильтрации каждого фильтра</summary>
        public double FiltrationAreaOfEachFilter
        {
            get => _FiltrationAreaOfEachFilter;
            set => Set(ref _FiltrationAreaOfEachFilter, value);
        }

        private double _DesignFilterDiameter;
        /// <summary>Свойство для Расчетный диаметр фильтра</summary>
        public double DesignFilterDiameter
        {
            get => _DesignFilterDiameter;
            set => Set(ref _DesignFilterDiameter, value);
        }

        private double _FilterArea;
        /// <summary>Свойство для Площадь фильтра</summary>
        public double FilterArea
        {
            get => _FilterArea;
            set => Set(ref _FilterArea, value);
        }

        private double _FilterCycleDuration;
        /// <summary>Свойство для продолжительность фильтроцикла</summary>
        public double FilterCycleDuration
        {
            get => _FilterCycleDuration;
            set => Set(ref _FilterCycleDuration, value);
        }

        private double _NumberOfRegenerationsPerDay;
        /// <summary>Свойство для количество регенераций в сутки</summary>
        public double NumberOfRegenerationsPerDay
        {
            get => _NumberOfRegenerationsPerDay;
            set => Set(ref _NumberOfRegenerationsPerDay, value);
        }

        private double _VolumeOfIonExchangeMaterialsInOneFilter;
        /// <summary>Свойство для обьем ионитных материалов в один фильтр</summary>
        public double VolumeOfIonExchangeMaterialsInOneFilter
        {
            get => _VolumeOfIonExchangeMaterialsInOneFilter;
            set => Set(ref _VolumeOfIonExchangeMaterialsInOneFilter, value);
        }

        private double _VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion;
        /// <summary>Свойство для обьем ионитных материалов в один фильтр катионов или анионов</summary>
        public double VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion
        {
            get => _VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion;
            set => Set(ref _VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion, value);
        }

        private double _VolumeOfIonExchangeMaterialsInGroupFilter;
        /// <summary>Свойство для обьем ионитных материалов в группу фильтров</summary>
        public double VolumeOfIonExchangeMaterialsInGroupFilter
        {
            get => _VolumeOfIonExchangeMaterialsInGroupFilter;
            set => Set(ref _VolumeOfIonExchangeMaterialsInGroupFilter, value);
        }

        private double _VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion;
        /// <summary>Свойство для обьем ионитных материалов в группу фильтров катионов или анионов</summary>
        public double VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion
        {
            get => _VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion;
            set => Set(ref _VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion, value);
        }

        private double _WaterConsumptionForOwnNeedsCation;
        /// <summary>Свойство для расход воды на собственные нужды катион</summary>
        public double WaterConsumptionForOwnNeedsCation
        {
            get => _WaterConsumptionForOwnNeedsCation;
            set => Set(ref _WaterConsumptionForOwnNeedsCation, value);
        }

        private double _ConsumptionOfChemicalReagentsCation;
        /// <summary>Свойство для расход хим реагентов катион</summary>
        public double ConsumptionOfChemicalReagentsCation
        {
            get => _ConsumptionOfChemicalReagentsCation;
            set => Set(ref _ConsumptionOfChemicalReagentsCation, value);
        }

        private double _TechnicalProductConsumptionCation;
        /// <summary>Свойство для расход технического продукта катион</summary>
        public double TechnicalProductConsumptionCation
        {
            get => _TechnicalProductConsumptionCation;
            set => Set(ref _TechnicalProductConsumptionCation, value);
        }

        private double _DailyConsumptionOfChemicalReagentCation;
        /// <summary>Свойство для суточный расход хим реагента катион</summary>
        public double DailyConsumptionOfChemicalReagentCation
        {
            get => _DailyConsumptionOfChemicalReagentCation;
            set => Set(ref _DailyConsumptionOfChemicalReagentCation, value);
        }

        private double _WaterConsumptionForOwnNeedsAnion;
        /// <summary>Свойство для расход воды на собственные нужды анион</summary>
        public double WaterConsumptionForOwnNeedsAnion
        {
            get => _WaterConsumptionForOwnNeedsAnion;
            set => Set(ref _WaterConsumptionForOwnNeedsAnion, value);
        }

        private double _ConsumptionOfChemicalReagentsAnion;
        /// <summary>Свойство для расход хим реагентов анион</summary>
        public double ConsumptionOfChemicalReagentsAnion
        {
            get => _ConsumptionOfChemicalReagentsAnion;
            set => Set(ref _ConsumptionOfChemicalReagentsAnion, value);
        }

        private double _TechnicalProductConsumptionAnion;
        /// <summary>Свойство для расход технического продукта анион</summary>
        public double TechnicalProductConsumptionAnion
        {
            get => _TechnicalProductConsumptionAnion;
            set => Set(ref _TechnicalProductConsumptionAnion, value);
        }

        private double _DailyConsumptionOfChemicalReagentAnion;
        /// <summary>Свойство для суточный расход хим реагента анион</summary>
        public double DailyConsumptionOfChemicalReagentAnion
        {
            get => _DailyConsumptionOfChemicalReagentAnion;
            set => Set(ref _DailyConsumptionOfChemicalReagentAnion, value);
        }

        private double _WaterConsumptionForNextGroupOfFilters;
        /// <summary>Свойство для расход воды на следующую группу фильтров</summary>
        public double WaterConsumptionForNextGroupOfFilters
        {
            get => _WaterConsumptionForNextGroupOfFilters;
            set => Set(ref _WaterConsumptionForNextGroupOfFilters, value);
        }

        private double _WaterConsumptionForLooseningWashes;
        /// <summary>Свойство для Расход воды на взрых промывку</summary>
        public double WaterConsumptionForLooseningWashes
        {
            get => _WaterConsumptionForLooseningWashes;
            set => Set(ref _WaterConsumptionForLooseningWashes, value);
        }

        private double _WaterConsumptionForWashingBF;
        /// <summary>Свойство для Расход воды на отмывку ОФ</summary>
        public double WaterConsumptionForWashingBF
        {
            get => _WaterConsumptionForWashingBF;
            set => Set(ref _WaterConsumptionForWashingBF, value);
        }

        private double _HourlyWaterConsumptionForRinsing;
        /// <summary>Свойство для Часовой расход воды на промывку</summary>
        public double HourlyWaterConsumptionForRinsing
        {
            get => _HourlyWaterConsumptionForRinsing;
            set => Set(ref _HourlyWaterConsumptionForRinsing, value);
        }

        private double _ActualFiltrationSpeed;
        /// <summary>Свойство для Действительная скорость фильтров</summary>
        public double ActualFiltrationSpeed
        {
            get => _ActualFiltrationSpeed;
            set => Set(ref _ActualFiltrationSpeed, value);
        }

        private double _CapacityOfEachClarifier;
        /// <summary>Свойство для Емкость каждого из осветлителей</summary>
        public double CapacityOfEachClarifier
        {
            get => _CapacityOfEachClarifier;
            set => Set(ref _CapacityOfEachClarifier, value);
        }

        private double _CoagulantConsumption;
        /// <summary>Свойство для Расход коагулянта</summary>
        public double CoagulantConsumption
        {
            get => _CoagulantConsumption;
            set => Set(ref _CoagulantConsumption, value);
        }

        private double _AnhydrousCoagulantEquivalent;
        /// <summary>Свойство для Эквивалент безводного коагулянта</summary>
        public double AnhydrousCoagulantEquivalent
        {
            get => _AnhydrousCoagulantEquivalent;
            set => Set(ref _AnhydrousCoagulantEquivalent, value);
        }

        private double _CoagulantDose;
        /// <summary>Свойство для Доза коагулянта</summary>
        public double CoagulantDose
        {
            get => _CoagulantDose;
            set => Set(ref _CoagulantDose, value);
        }

        private double _ConsumptionOfTechnicalCoagulantPerDay;
        /// <summary>Свойство для Расход тех коагулянта в сутки</summary>
        public double ConsumptionOfTechnicalCoagulantPerDay
        {
            get => _ConsumptionOfTechnicalCoagulantPerDay;
            set => Set(ref _ConsumptionOfTechnicalCoagulantPerDay, value);
        }

        private double _CoagulantPercentage;
        /// <summary>Свойство для Процентное содержание коагулянта</summary>
        public double CoagulantPercentage
        {
            get => _CoagulantPercentage;
            set => Set(ref _CoagulantPercentage, value);
        }

        private double _PolyacrylamideConsumptionPerDay;
        /// <summary>Свойство для Расход ПАА в сутки</summary>
        public double PolyacrylamideConsumptionPerDay
        {
            get => _PolyacrylamideConsumptionPerDay;
            set => Set(ref _PolyacrylamideConsumptionPerDay, value);
        }

        private double _LimeConsumption;
        /// <summary>Свойство для Расход извести</summary>
        public double LimeConsumption
        {
            get => _LimeConsumption;
            set => Set(ref _LimeConsumption, value);
        }

        private double _ProportionOfLime;
        /// <summary>Свойство для Доля извести</summary>
        public double ProportionOfLime
        {
            get => _ProportionOfLime;
            set => Set(ref _ProportionOfLime, value);
        }

        private string _ClarifierBrand;
        /// <summary>Свойство для Бренд</summary>
        public string ClarifierBrand
        {
            get => _ClarifierBrand;
            set => Set(ref _ClarifierBrand, value);
        }

        private double _ClarifierPerformance;
        /// <summary>Свойство для Производительность</summary>
        public double ClarifierPerformance
        {
            get => _ClarifierPerformance;
            set => Set(ref _ClarifierPerformance, value);
        }

        private double _GeometricVolumeOfClarifier;
        /// <summary>Свойство для Обьем</summary>
        public double GeometricVolumeOfClarifier
        {
            get => _GeometricVolumeOfClarifier;
            set => Set(ref _GeometricVolumeOfClarifier, value);
        }

        private double _ClarifierDiameter;
        /// <summary>Свойство для Диаметр</summary>
        public double ClarifierDiameter
        {
            get => _ClarifierDiameter;
            set => Set(ref _ClarifierDiameter, value);
        }

        private double _ClarifierHeight;
        /// <summary>Свойство для Высота</summary>
        public double ClarifierHeight
        {
            get => _ClarifierHeight;
            set => Set(ref _ClarifierHeight, value);
        }

        private double _ConcentrationCO2BeforeTheDecarbonizer;
        /// <summary>Свойство для Концентрация СО2 перед Д</summary>
        public double ConcentrationCO2BeforeTheDecarbonizer
        {
            get => _ConcentrationCO2BeforeTheDecarbonizer;
            set => Set(ref _ConcentrationCO2BeforeTheDecarbonizer, value);
        }

        private double _ResidualBicarbonateAlkalinity;
        /// <summary>Свойство для Бикарбонатная щелочность ост</summary>
        public double ResidualBicarbonateAlkalinity
        {
            get => _ResidualBicarbonateAlkalinity;
            set => Set(ref _ResidualBicarbonateAlkalinity, value);
        }

        private double _ResidualCarbonateAlkalinity;
        /// <summary>Свойство для Карбонатная щелочность ост</summary>
        public double ResidualCarbonateAlkalinity
        {
            get => _ResidualCarbonateAlkalinity;
            set => Set(ref _ResidualCarbonateAlkalinity, value);
        }

        private double _CalculatedCapacityInCalciner;
        /// <summary>Свойство для Расчетная производительность в Д</summary>
        public double CalculatedCapacityInCalciner
        {
            get => _CalculatedCapacityInCalciner;
            set => Set(ref _CalculatedCapacityInCalciner, value);
        }

        private double _AmountOfCO2RemovedInTheDecarbonizer;
        /// <summary>Свойство для Количество CO2 удаленного в Д</summary>
        public double AmountOfCO2RemovedInTheDecarbonizer
        {
            get => _AmountOfCO2RemovedInTheDecarbonizer;
            set => Set(ref _AmountOfCO2RemovedInTheDecarbonizer, value);
        }

        private double _DesorptionArea;
        /// <summary>Свойство для Площадь десорбции</summary>
        public double DesorptionArea
        {
            get => _DesorptionArea;
            set => Set(ref _DesorptionArea, value);
        }

        private double _NozzleArea;
        /// <summary>Свойство для Площадь насадки</summary>
        public double NozzleArea
        {
            get => _NozzleArea;
            set => Set(ref _NozzleArea, value);
        }

        private double _NozzleVolume;
        /// <summary>Свойство для Обьем насадки</summary>
        public double NozzleVolume
        {
            get => _NozzleVolume;
            set => Set(ref _NozzleVolume, value);
        }

        private double _CrossSectionalArea;
        /// <summary>Свойство для Площадь поперечного сечения Д</summary>
        public double CrossSectionalArea
        {
            get => _CrossSectionalArea;
            set => Set(ref _CrossSectionalArea, value);
        }

        private double _CalcinerDiameter;
        /// <summary>Свойство для Диаметр декарбонизатора</summary>
        public double CalcinerDiameter
        {
            get => _CalcinerDiameter;
            set => Set(ref _CalcinerDiameter, value);
        }

        private double _RaschigRingAttachmentHeight;
        /// <summary>Свойство для Высота насадки колец Рашига</summary>
        public double RaschigRingAttachmentHeight
        {
            get => _RaschigRingAttachmentHeight;
            set => Set(ref _RaschigRingAttachmentHeight, value);
        }

        private double _AirConsumptionForWaterDecarbonization;
        /// <summary>Свойство для Расход воздуха на Д</summary>
        public double AirConsumptionForWaterDecarbonization
        {
            get => _AirConsumptionForWaterDecarbonization;
            set => Set(ref _AirConsumptionForWaterDecarbonization, value);
        }

        private double _DecarbonizerPerfomance;
        /// <summary>Свойство для Производительность Д по таблице</summary>
        public double DecarbonizerPerfomance
        {
            get => _DecarbonizerPerfomance;
            set => Set(ref _DecarbonizerPerfomance, value);
        }

        private double _DecarbonizerDiameter;
        /// <summary>Свойство для Диаметер Д по таблице</summary>
        public double DecarbonizerDiameter
        {
            get => _DecarbonizerDiameter;
            set => Set(ref _DecarbonizerDiameter, value);
        }

        private double _DecarbonizerCrossAreaSection;
        /// <summary>Свойство для Площадь поперечного сечения Д по таблице</summary>
        public double DecarbonizerCrossAreaSection
        {
            get => _DecarbonizerCrossAreaSection;
            set => Set(ref _DecarbonizerCrossAreaSection, value);
        }

        private double _DecarbonizerAirFlow;
        /// <summary>Свойство для Расход воздуха Д по таблице</summary>
        public double DecarbonizerAirFlow
        {
            get => _DecarbonizerAirFlow;
            set => Set(ref _DecarbonizerAirFlow, value);
        }

        #endregion

        #region Команды

        #region LeftBtnAndDoubleMAFCommand
        /// <summary>Нажатие левой кнопки по ФСД</summary>
        public ICommand LeftBtnMAFCommand { get; }
        private void OnLeftBtnMAFCommand(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = true;
            IsHiddenVolumeOfIonForIonFilterProperty = false;
            IsHiddenCationProperty = true;
            IsHiddenAnionProperty = true;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxMAF();
        }

        /// <summary>Нажатие дабл левой кнопки по ФСД</summary>
        public ICommand LeftDoubleBtnMAFCommand { get; }
        private void OnLeftDoubleBtnMAFCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 1;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += MAFWindow_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #region LeftBtnGridCommand
        /// <summary>Нажатие левой кнопки по Grid </summary>
        public ICommand LeftBtnGridCommand { get; }
        private void OnLeftBtnGridCommand(object obj)
        {
            IsHiddenFilterProperty = false;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = false;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = false;
        }
        #endregion

        #region LeftBtnAndDoubleA2Command

        /// <summary>Нажатие левой кнопки по A2</summary>
        public ICommand LeftBtnA2Command { get; }
        private void OnLeftBtnA2Command(object obj)
        { 
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = true;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = true;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxA2();
        }

        /// <summary>Нажатие дабл левой кнопки по A2</summary>
        public ICommand LeftDoubleBtnA2Command { get; }
        private void OnLeftDoubleBtnA2Command(object obj)
        {
            DataStorage.Instance.ViewModel = 2;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += A2Window_Closed;
            mixed.ShowDialog();
        }
        #endregion

        #region LeftBtnAndDoubleA2SimplifiedCommand

        /// <summary>Нажатие левой кнопки по A2упр</summary>
        public ICommand LeftBtnA2SimplifiedCommand { get; }
        private void OnLeftBtnA2SimplifiedCommand(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = true;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = true;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxA2Simplified();
        }

        /// <summary>Нажатие дабл левой кнопки по A2упр</summary>
        public ICommand LeftDoubleBtnA2SimplifiedCommand { get; }
        private void OnLeftDoubleBtnA2SimplifiedCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 6;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += A2SimplifiedWindow_Closed;
            mixed.ShowDialog();
        }
        #endregion

        #region LeftBtnAndDoubleH2Command

        /// <summary>Нажатие левой кнопки по H2</summary>
        public ICommand LeftBtnH2Command { get; }
        private void OnLeftBtnH2Command(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = true;
            IsHiddenCationProperty = true;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxH2();
        }

        /// <summary>Нажатие дабл левой кнопки по H2</summary>
        public ICommand LeftDoubleBtnH2Command { get; }
        private void OnLeftDoubleBtnH2Command(object obj)
        {
            DataStorage.Instance.ViewModel = 3;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += H2Window_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #region LeftBtnAndDoubleA1Command
        /// <summary>Нажатие левой кнопки по А1</summary>
        public ICommand LeftBtnA1Command { get; }
        private void OnLeftBtnA1Command(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = true;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = true;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxA1();
        }

        /// <summary>Нажатие дабл левой кнопки по А1</summary>
        public ICommand LeftDoubleBtnA1Command { get; }
        private void OnLeftDoubleBtnA1Command(object obj)
        {
            DataStorage.Instance.ViewModel = 4;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += A1Window_Closed;
            mixed.ShowDialog();
        }
        #endregion

        #region LeftBtnAndDoubleH1Command

        /// <summary>Нажатие левой кнопки по H1</summary>
        public ICommand LeftBtnH1Command { get; }
        private void OnLeftBtnH1Command(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = true;
            IsHiddenCationProperty = true;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxH1();
        }

        /// <summary>Нажатие дабл левой кнопки по H2</summary>
        public ICommand LeftDoubleBtnH1Command { get; }
        private void OnLeftDoubleBtnH1Command(object obj)
        {
            DataStorage.Instance.ViewModel = 5;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += H1Window_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #region LeftBtnAndDoubleNaCommand

        /// <summary>Нажатие левой кнопки по Na</summary>
        public ICommand LeftBtnNaCommand { get; }
        private void OnLeftBtnNaCommand(object obj)
        {
            IsHiddenFilterProperty = true;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = true;
            IsHiddenCationProperty = true;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxNa();
        }

        /// <summary>Нажатие дабл левой кнопки по Na</summary>
        public ICommand LeftDoubleBtnNaCommand { get; }
        private void OnLeftDoubleBtnNaCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 7;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += NaWindow_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #region LeftBtnAndDoubleBFCommand

        /// <summary>Нажатие левой кнопки по BF</summary>
        public ICommand LeftBtnBFCommand { get; }
        private void OnLeftBtnBFCommand(object obj)
        {
            IsHiddenFilterProperty = false;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = false;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = true;
            IsHiddenWaterFlowToTheNextStage = true;

            FillTextBoxBF();
        }

        /// <summary>Нажатие дабл левой кнопки по BF</summary>
        public ICommand LeftDoubleBtnBFCommand { get; }
        private void OnLeftDoubleBtnBFCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 8;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += BFWindow_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #region LeftBtnAndDoubleClarifierCommand

        /// <summary>Нажатие левой кнопки по Clarifier</summary>
        public ICommand LeftBtnClarifierCommand { get; }
        private void OnLeftBtnClarifierCommand(object obj)
        {
            IsHiddenFilterProperty = false;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = false;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = true;
            IsHiddenDecarbonizerProp = false;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = false;
            FillTextBoxClarifier();
        }

        /// <summary>Нажатие дабл левой кнопки по Clarifier</summary>
        public ICommand LeftDoubleBtnClarifierCommand { get; }
        private void OnLeftDoubleBtnClarifierCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 9;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += ClarifierWindow_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #region LeftBtnAndDoubleDecarbonizerCommand

        /// <summary>Нажатие левой кнопки по Decarbonizer</summary>
        public ICommand LeftBtnDecarbonizerCommand { get; }
        private void OnLeftBtnDecarbonizerCommand(object obj)
        {
            IsHiddenFilterProperty = false;
            IsHiddenVolumeOfIonForMAFProperty = false;
            IsHiddenVolumeOfIonForIonFilterProperty = false;
            IsHiddenCationProperty = false;
            IsHiddenAnionProperty = false;
            IsHiddenClarifierProp = false;
            IsHiddenDecarbonizerProp = true;
            IsHiddenClarificationFilterProp = false;
            IsHiddenWaterFlowToTheNextStage = false;

            FillTextBoxDecarbonizer();

        }

        /// <summary>Нажатие дабл левой кнопки по Decarbonizer</summary>
        public ICommand LeftDoubleBtnDecarbonizerCommand { get; }
        private void OnLeftDoubleBtnDecarbonizerCommand(object obj)
        {
            DataStorage.Instance.ViewModel = 10;
            EquipmentWindow mixed = new EquipmentWindow();
            mixed.Closed += DecarbonizerWindow_Closed;
            mixed.ShowDialog();
        }

        #endregion

        #endregion

        public DesaltingPartWTPVM()
        {
            #region Команды

            LeftBtnMAFCommand = new RelayCommand(OnLeftBtnMAFCommand);
            LeftDoubleBtnMAFCommand = new RelayCommand(OnLeftDoubleBtnMAFCommand);

            LeftBtnGridCommand = new RelayCommand(OnLeftBtnGridCommand);

            LeftBtnA2Command = new RelayCommand(OnLeftBtnA2Command);
            LeftDoubleBtnA2Command = new RelayCommand(OnLeftDoubleBtnA2Command);

            LeftBtnA2SimplifiedCommand = new RelayCommand(OnLeftBtnA2SimplifiedCommand);
            LeftDoubleBtnA2SimplifiedCommand = new RelayCommand(OnLeftDoubleBtnA2SimplifiedCommand);

            LeftBtnH2Command = new RelayCommand(OnLeftBtnH2Command);
            LeftDoubleBtnH2Command = new RelayCommand(OnLeftDoubleBtnH2Command);

            LeftBtnA1Command = new RelayCommand(OnLeftBtnA1Command);
            LeftDoubleBtnA1Command = new RelayCommand(OnLeftDoubleBtnA1Command);

            LeftBtnH1Command = new RelayCommand(OnLeftBtnH1Command);
            LeftDoubleBtnH1Command = new RelayCommand(OnLeftDoubleBtnH1Command);

            LeftBtnNaCommand = new RelayCommand(OnLeftBtnNaCommand);
            LeftDoubleBtnNaCommand = new RelayCommand(OnLeftDoubleBtnNaCommand);

            LeftBtnBFCommand = new RelayCommand(OnLeftBtnBFCommand);
            LeftDoubleBtnBFCommand = new RelayCommand(OnLeftDoubleBtnBFCommand);

            LeftBtnClarifierCommand = new RelayCommand(OnLeftBtnClarifierCommand);
            LeftDoubleBtnClarifierCommand = new RelayCommand(OnLeftDoubleBtnClarifierCommand);

            LeftBtnDecarbonizerCommand = new RelayCommand(OnLeftBtnDecarbonizerCommand);
            LeftDoubleBtnDecarbonizerCommand = new RelayCommand(OnLeftDoubleBtnDecarbonizerCommand);

            #endregion

            if (DataStorage.Instance.DesaltingScheme == "three-stage")
            {
                IsHiddenMain = true;
                IsHiddenThreeStage = true;
            }

            if (DataStorage.Instance.DesaltingScheme == "two-stage")
            {
                IsHiddenMain = true;
                IsHiddenTwoStage = true;
            }

            if (DataStorage.Instance.DesaltingScheme == "simplified")
            {
                IsHiddenMain = true;
                IsHiddenSimplified = true;
            }

            if (BoilerStorage.Instance.PerfomanceWTPForHeatingSystem == 0)
            {
                IsHiddenNa = false;
            }
            else 
            { 
                IsHiddenNa = true; 
            }
        }

        #region MAF
        /// <summary>Вызов метода после закрытия MAFWindow</summary>
        private void MAFWindow_Closed(object sender, EventArgs e)
        {
            CalcMAF calcMAF = new CalcMAF();
            calcMAF.Calculations();
            FillTextBoxMAF();

        }


        /// <summary>Заполнение данными из MAFStorage свойств textBox</summary>
        private void FillTextBoxMAF()
        {
            FiltrationArea = MAFStorage.Instance.F;
            FiltrationSpeed = MAFStorage.Instance.w;
            WaterConsumptionPerFilter = BoilerStorage.Instance.PerfomanceWTP;
            FiltrationAreaOfEachFilter = MAFStorage.Instance.f_p;
            DesignFilterDiameter = MAFStorage.Instance.d_p;
            FilterArea = MAFStorage.Instance.f_ct;
            FilterCycleDuration = MAFStorage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = MAFStorage.Instance.n;

            VolumeOfIonExchangeMaterialsInOneFilter = MAFStorage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = MAFStorage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = MAFStorage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = MAFStorage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsCation = MAFStorage.Instance.g_cnK;
            ConsumptionOfChemicalReagentsCation = MAFStorage.Instance.G_100pK;
            TechnicalProductConsumptionCation = MAFStorage.Instance.G_texK;
            DailyConsumptionOfChemicalReagentCation = MAFStorage.Instance.G_cutK;

            WaterConsumptionForOwnNeedsAnion = MAFStorage.Instance.g_cnA;
            ConsumptionOfChemicalReagentsAnion = MAFStorage.Instance.G_100pA;
            TechnicalProductConsumptionAnion = MAFStorage.Instance.G_texA;
            DailyConsumptionOfChemicalReagentAnion = MAFStorage.Instance.G_cutA;

            WaterConsumptionForNextGroupOfFilters = MAFStorage.Instance.Q_br;
        }

        #endregion

        #region A2

        /// <summary>Вызов метода после закрытия A2Window</summary>
        private void A2Window_Closed(object sender, EventArgs e)
        {
            CalcA2 calcA2 = new CalcA2();
            calcA2.Calculations();
            FillTextBoxA2();
        }

        /// <summary>Заполнение данными из A2Storage свойств textBox</summary>
        private void FillTextBoxA2()
        {
            FiltrationArea = A2Storage.Instance.F;
            FiltrationSpeed = A2Storage.Instance.w;
            WaterConsumptionPerFilter = A2Storage.Instance.Q_br_input;
            FiltrationAreaOfEachFilter = A2Storage.Instance.f_p;
            DesignFilterDiameter = A2Storage.Instance.d_p;
            FilterArea = A2Storage.Instance.f_ct;
            FilterCycleDuration = A2Storage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = A2Storage.Instance.n;
            VolumeOfIonExchangeMaterialsInOneFilter = A2Storage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = A2Storage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = A2Storage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = A2Storage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsAnion = A2Storage.Instance.g_cnA;
            ConsumptionOfChemicalReagentsAnion = A2Storage.Instance.G_100pA;
            TechnicalProductConsumptionAnion = A2Storage.Instance.G_texA;
            DailyConsumptionOfChemicalReagentAnion = A2Storage.Instance.G_cutA;

            WaterConsumptionForNextGroupOfFilters = A2Storage.Instance.Q_br;
        }

        #endregion

        #region A2Simplified

        /// <summary>Вызов метода после закрытия A2SimplifiedWindow</summary>
        private void A2SimplifiedWindow_Closed(object sender, EventArgs e)
        {
            CalcA2Simplified calc = new CalcA2Simplified();
            calc.Calculations();
            FillTextBoxA2Simplified();


        }

        /// <summary>Заполнение данными из A2StorageSimplified свойств textBox</summary>
        private void FillTextBoxA2Simplified()
        {
            FiltrationArea = A2StorageSimplified.Instance.F;
            FiltrationSpeed = A2StorageSimplified.Instance.w;
            WaterConsumptionPerFilter = A2StorageSimplified.Instance.Q_br_input;
            FiltrationAreaOfEachFilter = A2StorageSimplified.Instance.f_p;
            DesignFilterDiameter = A2StorageSimplified.Instance.d_p;
            FilterArea = A2StorageSimplified.Instance.f_ct;
            FilterCycleDuration = A2StorageSimplified.Instance.T_FAA;
            NumberOfRegenerationsPerDay = A2StorageSimplified.Instance.n;
            VolumeOfIonExchangeMaterialsInOneFilter = A2StorageSimplified.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = A2StorageSimplified.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = A2StorageSimplified.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = A2StorageSimplified.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsAnion = A2StorageSimplified.Instance.g_cnA;
            ConsumptionOfChemicalReagentsAnion = A2StorageSimplified.Instance.G_100pA;
            TechnicalProductConsumptionAnion = A2StorageSimplified.Instance.G_texA;
            DailyConsumptionOfChemicalReagentAnion = A2StorageSimplified.Instance.G_cutA;

            WaterConsumptionForNextGroupOfFilters = A2StorageSimplified.Instance.Q_br;
        }

        #endregion

        #region H2

        /// <summary>Вызов метода после закрытия H2Window</summary>
        private void H2Window_Closed(object sender, EventArgs e)
        {
            CalcH2 calc = new CalcH2();
            calc.Calculations();
            FillTextBoxH2();
        }

        /// <summary>Заполнение данными из H2Storage свойств textBox</summary>
        private void FillTextBoxH2()
        {
            FiltrationArea = H2Storage.Instance.F;
            FiltrationSpeed = H2Storage.Instance.w;
            WaterConsumptionPerFilter = H2Storage.Instance.Q_br_input;
            FiltrationAreaOfEachFilter = H2Storage.Instance.f_p;
            DesignFilterDiameter = H2Storage.Instance.d_p;
            FilterArea = H2Storage.Instance.f_ct;
            FilterCycleDuration = H2Storage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = H2Storage.Instance.n;

            VolumeOfIonExchangeMaterialsInOneFilter = H2Storage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = H2Storage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = H2Storage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = H2Storage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsCation = H2Storage.Instance.g_cnK;
            ConsumptionOfChemicalReagentsCation = H2Storage.Instance.G_100pK;
            TechnicalProductConsumptionCation = H2Storage.Instance.G_texK;
            DailyConsumptionOfChemicalReagentCation = H2Storage.Instance.G_cutK;

            WaterConsumptionForNextGroupOfFilters = H2Storage.Instance.Q_br;
        }

        #endregion

        #region A1

        /// <summary>Вызов метода после закрытия A1Window</summary>
        private void A1Window_Closed(object sender, EventArgs e)
        {
            CalcA1 calc = new CalcA1();
            calc.Calculations();
            FillTextBoxA1();
        }

        /// <summary>Заполнение данными из A1Storage свойств textBox</summary>
        private void FillTextBoxA1()
        {
            FiltrationArea = A1Storage.Instance.F;
            FiltrationSpeed = A1Storage.Instance.w;
            WaterConsumptionPerFilter = A1Storage.Instance.Q_br_input;
            FiltrationAreaOfEachFilter = A1Storage.Instance.f_p;
            DesignFilterDiameter = A1Storage.Instance.d_p;
            FilterArea = A1Storage.Instance.f_ct;
            FilterCycleDuration = A1Storage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = A1Storage.Instance.n;
            VolumeOfIonExchangeMaterialsInOneFilter = A1Storage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInOneFilterCationOrAnion = A1Storage.Instance.V_vlK;
            VolumeOfIonExchangeMaterialsInGroupFilter = A1Storage.Instance.SumV_vl;
            VolumeOfIonExchangeMaterialsInGroupFilterCationOrAnion = A1Storage.Instance.SumV_vlK;

            WaterConsumptionForOwnNeedsAnion = A1Storage.Instance.g_cnA;
            ConsumptionOfChemicalReagentsAnion = A1Storage.Instance.G_100pA;
            TechnicalProductConsumptionAnion = A1Storage.Instance.G_texA;
            DailyConsumptionOfChemicalReagentAnion = A1Storage.Instance.G_cutA;

            WaterConsumptionForNextGroupOfFilters = A1Storage.Instance.Q_br;
        }

        #endregion

        #region H1

        /// <summary>Вызов метода после закрытия H1Window</summary>
        private void H1Window_Closed(object sender, EventArgs e)
        {
            CalcH1 calc = new CalcH1();
            calc.Calculations();
            FillTextBoxH1();
        }

        /// <summary>Заполнение данными из H1Storage свойств textBox</summary>
        private void FillTextBoxH1()
        {
            FiltrationArea = H1Storage.Instance.F;
            FiltrationSpeed = H1Storage.Instance.w;
            WaterConsumptionPerFilter = H1Storage.Instance.Q_br_input;
            FiltrationAreaOfEachFilter = H1Storage.Instance.f_p;
            DesignFilterDiameter = H1Storage.Instance.d_p;
            FilterArea = H1Storage.Instance.f_ct;
            FilterCycleDuration = H1Storage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = H1Storage.Instance.n;

            VolumeOfIonExchangeMaterialsInOneFilter = H1Storage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInGroupFilter = H1Storage.Instance.SumV_vl;

            WaterConsumptionForOwnNeedsCation = H1Storage.Instance.g_cnK;
            ConsumptionOfChemicalReagentsCation = H1Storage.Instance.G_100pK;
            TechnicalProductConsumptionCation = H1Storage.Instance.G_texK;
            DailyConsumptionOfChemicalReagentCation = H1Storage.Instance.G_cutK;

            WaterConsumptionForNextGroupOfFilters = H1Storage.Instance.Q_br;
        }

        #endregion

        #region Na

        /// <summary>Вызов метода после закрытия NaWindow</summary>
        private void NaWindow_Closed(object sender, EventArgs e)
        {
            CalcNa calc = new CalcNa();
            calc.Calculations();
            FillTextBoxNa();
        }

        /// <summary>Заполнение данными из NaStorage свойств textBox</summary>
        private void FillTextBoxNa()
        {
            FiltrationArea = NaStorage.Instance.F;
            FiltrationSpeed = NaStorage.Instance.w;
            WaterConsumptionPerFilter = BoilerStorage.Instance.PerfomanceWTPForHeatingSystem;
            FiltrationAreaOfEachFilter = NaStorage.Instance.f_p;
            DesignFilterDiameter = NaStorage.Instance.d_p;
            FilterArea = NaStorage.Instance.f_ct;
            FilterCycleDuration = NaStorage.Instance.T_FAA;
            NumberOfRegenerationsPerDay = NaStorage.Instance.n;

            VolumeOfIonExchangeMaterialsInOneFilter = NaStorage.Instance.V_vl;
            VolumeOfIonExchangeMaterialsInGroupFilter = NaStorage.Instance.SumV_vl;

            WaterConsumptionForOwnNeedsCation = NaStorage.Instance.g_cnK;
            ConsumptionOfChemicalReagentsCation = NaStorage.Instance.G_100pK;
            TechnicalProductConsumptionCation = NaStorage.Instance.G_texK;
            DailyConsumptionOfChemicalReagentCation = NaStorage.Instance.G_cutK;

            WaterConsumptionForNextGroupOfFilters = NaStorage.Instance.Q_br;
        }

        #endregion

        #region BF

        /// <summary>Вызов метода после закрытия BFWindow</summary>
        private void BFWindow_Closed(object sender, EventArgs e)
        {
            CalcBF calc = new CalcBF();
            calc.Calculations();
            if (BFStorage.Instance.w_m1 > BFStorage.Instance.w)
            {
                MessageBox.Show($"Действительная скорость фильтрования w = {BFStorage.Instance.w_m1} м/ч, что больше чем теоритическая скорость w_0 = {BFStorage.Instance.w} м/ч \n Добавьте еще как минимум 1 фильтр!");
            }
            FillTextBoxBF();
        }

        /// <summary>Заполнение данными из BFStorage свойств textBox</summary>
        private void FillTextBoxBF()
        {
            FiltrationArea = BFStorage.Instance.F;
            FiltrationSpeed = BFStorage.Instance.w;
            WaterConsumptionPerFilter = BFStorage.Instance.Q_bf_input;
            FiltrationAreaOfEachFilter = BFStorage.Instance.f_p;
            DesignFilterDiameter = BFStorage.Instance.d_p;
            FilterArea = BFStorage.Instance.f_ct;

            WaterConsumptionForLooseningWashes = BFStorage.Instance.g_vzr;
            WaterConsumptionForWashingBF = BFStorage.Instance.g_otm;
            HourlyWaterConsumptionForRinsing = BFStorage.Instance.g_0;
            ActualFiltrationSpeed = BFStorage.Instance.w_m1;

            WaterConsumptionForNextGroupOfFilters = BFStorage.Instance.Q_br;
        }

        #endregion

        #region Clarifier

        /// <summary>Вызов метода после закрытия ClarifierWindow</summary>
        private void ClarifierWindow_Closed(object sender, EventArgs e)
        {
            CalcClarifier calc = new CalcClarifier();
            calc.Calculations();
            FillTextBoxClarifier();
        }

        /// <summary>Заполнение данными из ClarifierStorage свойств textBox</summary>
        private void FillTextBoxClarifier()
        {
            CapacityOfEachClarifier = ClarifierStorage.Instance.v_ocv;
            WaterConsumptionPerFilter = BFStorage.Instance.Q_br;
            CoagulantConsumption = ClarifierStorage.Instance.G_k;
            AnhydrousCoagulantEquivalent = ClarifierStorage.Instance.E_k;
            CoagulantDose = DataStorage.Instance.K_Al_Fe;
            ConsumptionOfTechnicalCoagulantPerDay = ClarifierStorage.Instance.G_k_tex;
            CoagulantPercentage = ClarifierStorage.Instance.C;
            PolyacrylamideConsumptionPerDay = ClarifierStorage.Instance.G_PAA;
            LimeConsumption = ClarifierStorage.Instance.G_izv;
            ProportionOfLime = ClarifierStorage.Instance.d_izv;
            ClarifierBrand = ClarifierStorage.Instance.Name;
            ClarifierPerformance = ClarifierStorage.Instance.Perfomance;
            GeometricVolumeOfClarifier = ClarifierStorage.Instance.Volume;
            ClarifierDiameter = ClarifierStorage.Instance.Diameter;
            ClarifierHeight = ClarifierStorage.Instance.Height;
        }

        #endregion

        #region Decarbonizer

        /// <summary>Вызов метода после закрытия DecarbonizerWindow</summary>
        private void DecarbonizerWindow_Closed(object sender, EventArgs e)
        {
            CalcDecarbonizer calc = new CalcDecarbonizer();
            calc.Calculations();
            FillTextBoxDecarbonizer();
        }

        /// <summary>Заполнение данными из DecarbonizerStorage свойств textBox</summary>
        private void FillTextBoxDecarbonizer()
        {
            ConcentrationCO2BeforeTheDecarbonizer = DecarbonizerStorage.Instance.C_CO_vx;
            ResidualBicarbonateAlkalinity = DecarbonizerStorage.Instance.W_b_oct;
            ResidualCarbonateAlkalinity = DecarbonizerStorage.Instance.W_k_oct;
            CalculatedCapacityInCalciner = DecarbonizerStorage.Instance.Q_d;
            AmountOfCO2RemovedInTheDecarbonizer = DecarbonizerStorage.Instance.b_CO;
            DesorptionArea = DecarbonizerStorage.Instance.F_dec;
            NozzleArea = DecarbonizerStorage.Instance.F_nac;
            NozzleVolume = DecarbonizerStorage.Instance.V_nac;
            CrossSectionalArea = DecarbonizerStorage.Instance.f_d;
            CalcinerDiameter = DecarbonizerStorage.Instance.d_d;
            RaschigRingAttachmentHeight = DecarbonizerStorage.Instance.h_nac;
            AirConsumptionForWaterDecarbonization = DecarbonizerStorage.Instance.Q_vozd;
            DecarbonizerPerfomance = DecarbonizerStorage.Instance.Perfomance;
            DecarbonizerDiameter = DecarbonizerStorage.Instance.Diameter;
            DecarbonizerCrossAreaSection = DecarbonizerStorage.Instance.CrossAreaSections;
            DecarbonizerAirFlow = DecarbonizerStorage.Instance.AirFlow;
        }

        #endregion
    }
}

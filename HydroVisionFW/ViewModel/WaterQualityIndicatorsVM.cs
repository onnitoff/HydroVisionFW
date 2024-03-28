using HydroVisionDesign.Infrastructure.Base;
using HydroVisionDesign.Model;
using HydroVisionDesign.Services.Calculations;
using HydroVisionDesign.Services.DataStorages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HydroVisionDesign.ViewModel
{
    internal class WaterQualityIndicatorsVM : ViewModelBase
    {
        #region Свойство Hidden
        /// <summary>Свойство для открытия и сокрытия элементов xaml Al</summary>
        private bool _IsHiddenAl = true;

        public bool IsHiddenAl
        {
            get => _IsHiddenAl;
            set => Set(ref _IsHiddenAl, value);
        }

        /// <summary>Свойство для открытия и сокрытия элементов xaml Fe</summary>
        private bool _IsHiddenFe = false;

        public bool IsHiddenFe
        {
            get => _IsHiddenFe;
            set => Set(ref _IsHiddenFe, value);
        }

        /// <summary>Свойство для открытия и сокрытия элементов xaml Упрощенная схема</summary>
        private bool _IsHiddenSimplified = false;

        public bool IsHiddenSimplified
        {
            get => _IsHiddenSimplified;
            set => Set(ref _IsHiddenSimplified, value);
        }

        /// <summary>Свойство для открытия и сокрытия элементов xaml Двухступенчатая схема</summary>
        private bool _IsHiddenTwoStage = false;

        public bool IsHiddenTwoStage
        {
            get => _IsHiddenTwoStage;
            set => Set(ref _IsHiddenTwoStage, value);
        }

        /// <summary>Свойство для открытия и сокрытия элементов xaml Трехступенчатая схема</summary>
        private bool _IsHiddenThreeStage = true;

        public bool IsHiddenThreeStage
        {
            get => _IsHiddenThreeStage;
            set => Set(ref _IsHiddenThreeStage, value);
        }

        /// <summary>Свойство для открытия и сокрытия элементов xaml Трехступенчатая схема</summary>
        private bool _IsHiddenCentralHeating = true;

        public bool IsHiddenCentralHeating
        {
            get => _IsHiddenCentralHeating;
            set => Set(ref _IsHiddenCentralHeating, value);
        }

#endregion

        public ObservableCollection<WaterIndicatorModel> WaterIndicators { get; set; }

        #region Общие показатели воды

        private string _TotalCationContent;

        /// <summary>Суммарное содержание катионов</summary>
        public string TotalCationContent
        {
            get => _TotalCationContent;
            set => Set(ref _TotalCationContent, value);
        }

        private string _TotalAnionContent;

        /// <summary>Суммарное содержание анионов</summary>
        public string TotalAnionContent
        {
            get => _TotalAnionContent;
            set => Set(ref _TotalAnionContent, value);
        }

        private string _TotalAlkalinity;

        /// <summary>Общая щелочность</summary>
        public string TotalAlkalinity
        {
            get => _TotalAlkalinity;
            set => Set(ref _TotalAlkalinity, value);
        }

        private string _NonCarbonateHardness;

        /// <summary>Некарбонатная жесткость</summary>
        public string NonCarbonateHardness
        {
            get => _NonCarbonateHardness;
            set => Set(ref _NonCarbonateHardness, value);
        }

        private string _SumOfStrongAcidAnions;

        /// <summary>Сумма анионов сильных кислот</summary>
        public string SumOfStrongAcidAnions
        {
            get => _SumOfStrongAcidAnions;
            set => Set(ref _SumOfStrongAcidAnions, value);
        }

        private string _ResidualHardnessCarbonate;

        /// <summary>Жесткость карбонатная остаточная</summary>
        public string ResidualHardnessCarbonate
        {
            get => _ResidualHardnessCarbonate;
            set => Set(ref _ResidualHardnessCarbonate, value);
        }

        private string _ResidualHardnessNoCarbonate;

        /// <summary>Жесткость некарбонатная остаточная</summary>
        public string ResidualHardnessNoCarbonate
        {
            get => _ResidualHardnessNoCarbonate;
            set => Set(ref _ResidualHardnessNoCarbonate, value);
        }

        private string _ResidualAlkalinity;

        /// <summary>Щелочность остаточная</summary>
        public string ResidualAlkalinity
        {
            get => _ResidualAlkalinity;
            set => Set(ref _ResidualAlkalinity, value);
        }

        private string _SilicicAcidConcentration;

        /// <summary>Концентрация кремниевой кислоты</summary>
        public string SilicicAcidConcentration
        {
            get => _SilicicAcidConcentration;
            set => Set(ref _SilicicAcidConcentration, value);
        }

        private string _ResidualOverallHarndess;

        /// <summary>Общая жесткость остаточная</summary>
        public string ResidualOverallHarndess
        {
            get => _ResidualOverallHarndess;
            set => Set(ref _ResidualOverallHarndess, value);
        }

        private string _ConcentrationSO;

        /// <summary>Концентрация SO</summary>
        public string ConcentrationSO
        {
            get => _ConcentrationSO;
            set => Set(ref _ConcentrationSO, value);
        }

        private string _CationOnFirstStageFilter;

        /// <summary>Uн1</summary>
        public string CationOnFirstStageFilter
        {
            get => _CationOnFirstStageFilter;
            set => Set(ref _CationOnFirstStageFilter, value);
        }

        private string _CationOnSecondStageFilter;

        /// <summary>Uн2</summary>
        public string CationOnSecondStageFilter
        {
            get => _CationOnSecondStageFilter;
            set => Set(ref _CationOnSecondStageFilter, value);
        }

        private string _ConcentrationCOBeforeDecarbonizer;

        /// <summary>СО2 остаточное после декарбонизатора</summary>
        public string ConcentrationCOBeforeDecarbonizer
        {
            get => _ConcentrationCOBeforeDecarbonizer;
            set => Set(ref _ConcentrationCOBeforeDecarbonizer, value);
        }

        private string _AnionOnFirstStageFilter;

        /// <summary>Uа1</summary>
        public string AnionOnFirstStageFilter
        {
            get => _AnionOnFirstStageFilter;
            set => Set(ref _AnionOnFirstStageFilter, value);
        }

        private string _AnionOnSecondStageFilter;

        /// <summary>Uа2</summary>
        public string AnionOnSecondStageFilter
        {
            get => _AnionOnSecondStageFilter;
            set => Set(ref _AnionOnSecondStageFilter, value);
        }

        private string _AnionOnSecondStageFilterSimplified;

        /// <summary>Uа2упр</summary>
        public string AnionOnSecondStageFilterSimplified
        {
            get => _AnionOnSecondStageFilterSimplified;
            set => Set(ref _AnionOnSecondStageFilterSimplified, value);
        }

        private string _NaCationOnFilter;

        /// <summary>U_Na</summary>
        public string NaCationOnFilter
        {
            get => _NaCationOnFilter;
            set => Set(ref _NaCationOnFilter, value);
        }


        #endregion

        #region Команды



        #endregion

        public WaterQualityIndicatorsVM() 
        {
            #region Команды


            #endregion

            Calculations calculations = new Calculations();
            calculations.CalculationOfOtherQualityIndicators();
            FillingDataGrid();
            FillingTextBox();
        }

        /// <summary>Заполнение DataGrid</summary>
        private void FillingDataGrid()
        { 
            WaterIndicators = new ObservableCollection<WaterIndicatorModel>();
            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "Ca",
                InitialUnit = double.Parse(DataStorage.Instance.Init_Ca.ToString("0.000")),
                Eq = 20,
                FinalUnit = double.Parse(DataStorage.Instance.Final_Ca.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "Mg",
                InitialUnit = double.Parse(DataStorage.Instance.Init_Mg.ToString("0.000")),
                Eq = 12,
                FinalUnit = double.Parse(DataStorage.Instance.Final_Mg.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "Na",
                InitialUnit = double.Parse(DataStorage.Instance.Init_Na.ToString("0.000")),
                Eq = 23,
                FinalUnit = double.Parse(DataStorage.Instance.Final_Na.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "HCO",
                InitialUnit = double.Parse(DataStorage.Instance.Init_HCO.ToString("0.000")),
                Eq = 61,
                FinalUnit = double.Parse(DataStorage.Instance.Final_HCO.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "SO",
                InitialUnit = double.Parse(DataStorage.Instance.Init_SO.ToString("0.000")),
                Eq = 48,
                FinalUnit = double.Parse(DataStorage.Instance.Final_SO.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "Cl",
                InitialUnit = double.Parse(DataStorage.Instance.Init_Cl.ToString("0.000")),
                Eq = 35.5,
                FinalUnit = double.Parse(DataStorage.Instance.Final_Cl.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "NO",
                InitialUnit = double.Parse(DataStorage.Instance.Init_NO.ToString("0.000")),
                Eq = 0,
                FinalUnit = double.Parse(DataStorage.Instance.Final_NO.ToString("0.000"))
            });

            WaterIndicators.Add(new WaterIndicatorModel
            {
                Name = "SiO",
                InitialUnit = double.Parse(DataStorage.Instance.Init_SiO.ToString("0.000")),
                Eq = 38,
                FinalUnit = double.Parse(DataStorage.Instance.Final_SiO.ToString("0.000"))
            });
        }

        /// <summary>Заполнение TextBox</summary>
        private void FillingTextBox()
        {
            TotalCationContent = $"ΣКат = Ca + Mg + Na = " +
                $"{DataStorage.Instance.Final_Ca.ToString("0.000")} + " +
                $"{DataStorage.Instance.Final_Mg.ToString("0.000")} + " +
                $"{DataStorage.Instance.Final_Na.ToString("0.000")} = " +
                $"{DataStorage.Instance.TotalCationContent.ToString("0.000")} мг-экв/дм3";

            TotalAnionContent = $"ΣАн = HCO + SO + Cl + SiO = " +
                $"{DataStorage.Instance.Final_HCO.ToString("0.000")} + " +
                $"{DataStorage.Instance.Final_SO.ToString("0.000")} + " +
                $"{DataStorage.Instance.Final_Cl.ToString("0.000")} + " +
                $"{DataStorage.Instance.Final_SiO.ToString("0.000")} = " +
                $"{DataStorage.Instance.TotalAnionContent.ToString("0.000")} мг-экв/дм3";

            TotalAlkalinity = $"Щo = Жк = HCO = {DataStorage.Instance.Final_HCO.ToString("0.000")} мг-экв/дм3";

            NonCarbonateHardness = $"Жнк = Жо - Жк = {DataStorage.Instance.OverallHardness.ToString("0.000")} - " +
                $"{DataStorage.Instance.Final_HCO.ToString("0.000")} = {DataStorage.Instance.NonCarbonateHardness.ToString("0.000")} мг-экв/дм3";

            SumOfStrongAcidAnions = $"ΣАск = N0 + Cl + SO = {DataStorage.Instance.Final_NO.ToString("0.000")} + " +
                $"{DataStorage.Instance.Final_Cl.ToString("0.000")} + {DataStorage.Instance.Final_SO.ToString("0.000")} = " +
                $"{DataStorage.Instance.SumOfStrongAcidAnions.ToString("0.000")} мг-экв/дм3";

            if (DataStorage.Instance.TotalAlkalinity < 2) // для Al
            {
                IsHiddenFe = false;
                IsHiddenAl = true;
                ResidualHardnessCarbonate = $"Жк_ост = Жк_исх - К_Al = {DataStorage.Instance.TotalAlkalinity.ToString("0.000")} - " +
                    $"{DataStorage.Instance.K_Al_Fe.ToString("0.000")} = {DataStorage.Instance.ResidualHardnessCarbonate.ToString("0.000")} мг-экв/дм3";

                ResidualHardnessNoCarbonate = $"Жнк_ост = Жнк_исж + К_Al = {DataStorage.Instance.NonCarbonateHardness.ToString("0.000")} + " +
                    $"{DataStorage.Instance.K_Al_Fe.ToString("0.000")} = {DataStorage.Instance.ResidualHardnessNoCarbonate.ToString("0.000")} мг-экв/дм3";

                ResidualOverallHarndess = $"Жо_ост = Жо = {DataStorage.Instance.ResidualOverallHarndess.ToString("0.000")} мг-экв/дм3";

                ResidualAlkalinity = $"Щост = Що - К_Al = {DataStorage.Instance.TotalAlkalinity.ToString("0.000")} - " +
                    $"{DataStorage.Instance.K_Al_Fe.ToString("0.000")} = {DataStorage.Instance.ResidualAlkalinity.ToString("0.000")} мг-экв/дм3";

                SilicicAcidConcentration = $"SiOост = 0,75 * SiOост = 0,75 * {DataStorage.Instance.Final_SiO.ToString("0.000")} = {DataStorage.Instance.SilicicAcidConcentration.ToString("0.000")} мг-экв/дм3";
            }
            else // для Fe
            {
                IsHiddenFe = true;
                IsHiddenAl = false;
                ResidualHardnessCarbonate = $"Жк_ост = {DataStorage.Instance.ResidualHardnessCarbonate.ToString("0.000")} мг-экв/дм3";
                
                ResidualHardnessNoCarbonate = $"Жнк_ост = Жнк_исх + К_Fe = {DataStorage.Instance.NonCarbonateHardness.ToString("0.000")} + " +
                    $"{DataStorage.Instance.K_Al_Fe.ToString("0.000")} = {DataStorage.Instance.ResidualHardnessNoCarbonate.ToString("0.000")} мг-экв/дм3";

                ResidualOverallHarndess = $"Жо_ост = Жк_ост + Жнк_ост = {DataStorage.Instance.ResidualHardnessCarbonate.ToString("0.000")} + " +
                    $"{DataStorage.Instance.ResidualHardnessNoCarbonate.ToString("0.000")} = {DataStorage.Instance.ResidualOverallHarndess.ToString("0.000")} мг-экв/дм3";

                ConcentrationSO = $"SOост = S0 + K_Fe = {DataStorage.Instance.Final_SO.ToString("0.000")} + " +
                    $"{DataStorage.Instance.K_Al_Fe.ToString("0.000")} = {DataStorage.Instance.ConcentrationSO.ToString("0.000")} мг-экв/дм3";

                ResidualAlkalinity = $"Щост = Жк_ост + а_изв = {DataStorage.Instance.ResidualHardnessCarbonate.ToString("0.000")} + " +
                    $"{DataStorage.Instance.ExcessLime.ToString("0.000")} = {DataStorage.Instance.ResidualAlkalinity.ToString("0.000")} мг-экв/дм3";

                SilicicAcidConcentration = $"SiOост = 0,6 * SiOост = 0,6 * {DataStorage.Instance.Final_SiO.ToString("0.000")} = {DataStorage.Instance.SilicicAcidConcentration.ToString("0.000")} мг-экв/дм3";
            }

            CationOnFirstStageFilter = $"ΣUн1 = Жо_ост + 2,15 * Na = {DataStorage.Instance.ResidualOverallHarndess.ToString("0.000")} + 2,15 * " +
               $"{DataStorage.Instance.Final_Na.ToString("0.000")} = {DataStorage.Instance.CationOnFirstStageFilter.ToString("0.000")} мг-экв/дм3";

            CationOnSecondStageFilter = $"ΣUн2 = {DataStorage.Instance.CationOnSecondStageFilter.ToString("0.000")} мг-экв/дм3";

            ConcentrationCOBeforeDecarbonizer = $"CO2ост = 6 / 44 =  {DataStorage.Instance.ConcentrationCOBeforeDecarbonizer.ToString("0.000")} мг-экв/дм3";

            switch (DataStorage.Instance.DesaltingScheme)
            {
                case "simplified":
                    IsHiddenSimplified = true;
                    IsHiddenTwoStage = false;
                    AnionOnSecondStageFilterSimplified = $"ΣUа2_упр = SO + Cl + NO + K_Al(Fe) + SiO + CO = {DataStorage.Instance.ConcentrationSO.ToString("0.000")} + " +
                        $"{DataStorage.Instance.Final_Cl.ToString("0.000")} + {DataStorage.Instance.Final_NO.ToString("0.000")} + " +
                        $"{DataStorage.Instance.K_Al_Fe.ToString("0.000")} + {DataStorage.Instance.SilicicAcidConcentration.ToString("0.000")} +" +
                        $"{DataStorage.Instance.ConcentrationCOBeforeDecarbonizer.ToString("0.000")} = {DataStorage.Instance.AnionOnFirstStageFilter.ToString("0.000")} мг-экв/дм3";
                    break;

                case "two-stage":
                case "three-stage":
                    IsHiddenTwoStage = true;
                    IsHiddenSimplified = false;
                    AnionOnFirstStageFilter = $"ΣUа1 = SO + Cl + NO + K_Al = {DataStorage.Instance.Final_SO.ToString("0.000")} + " +
                        $"{DataStorage.Instance.Final_Cl.ToString("0.000")} + {DataStorage.Instance.Final_NO} + " +
                        $"{DataStorage.Instance.K_Al_Fe} = {DataStorage.Instance.AnionOnFirstStageFilter.ToString("0.000")} мг-экв/дм3";

                    AnionOnSecondStageFilter = $"ΣUа2 = SiOост + СО2ост = {DataStorage.Instance.SilicicAcidConcentration.ToString("0.000")} + " +
                        $"{DataStorage.Instance.ConcentrationCOBeforeDecarbonizer.ToString("0.000")} = {DataStorage.Instance.AnionOnSecondStageFilter.ToString("0.000")} мг-экв/дм3";
                    break;
            }

            if (true)
            {
                IsHiddenCentralHeating = true;
                NaCationOnFilter = $"ΣU_Na = Жо_ост = {DataStorage.Instance.NaCationOnFilter.ToString("0.000")} мг-экв/дм3";
            }
            else
                IsHiddenCentralHeating = false;








        }
    }
}

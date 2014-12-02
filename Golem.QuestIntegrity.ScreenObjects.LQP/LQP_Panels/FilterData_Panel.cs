using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;
using System.Collections.Generic;


namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class FilterData_Panel : BasePanel<FilterData_Panel>
    {
        // Menu option to select Filter Data panel
        private string _panelPath;
        private PurpleButton filterDataMenuButton;
        #region Variable Declaration

        #region Range Variables
        //"Apply to" section
        //This radio button makes use of some kind of fancy drop down -- 
        //TODO: Figure out how to see elements in the fancy drop down
        private PurpleRadioButton SelectedFeatures_RadioButton;
        
        private PurpleRadioButton CustomRange_RadioButton;
        //only available if SelectedData Radio button is checked
        private LQP_DevX_SimpleDD SelectionMethod;
        private LQP_DevX_TextBox FilterDataPosition;
        private LQP_DevX_TextBox FilterDataLength;
        private LQP_DevX_TextBox FilterDataCircPosition;
        private LQP_DevX_TextBox FilterDataExtent;
        private LQP_DevX_SimpleDD FilterDataSensor;
        //only available if SelectedData Radio button is checked

        private PurpleRadioButton Joint_RadioButton;
        private LQP_DevX_SimpleDD JointSelection;
        private PurpleRadioButton Range_RadioButton;
        private LQP_DevX_SimpleDD StartRange;
        private LQP_DevX_SimpleDD EndRange;
        private PurpleRadioButton AllData_RadioButton;
        private PurpleCheckBox JointByJoint_CheckBox;

        //Preset Filters
        private LQP_DevX_SimpleDD presetFilter;
        private PurpleButton presetFilter_Save;
        private PurpleButton presetFilter_Delete;
        #endregion

        #region Criteria Variables

        private PurpleButton criteriaTab;  //This is the tab button that will be added SU10032014 
        //Constraint to
        private PurpleCheckBox CTWallThickNaN_CheckBox;
        private PurpleCheckBox CTWallThickLess_CheckBox;
        private LQP_DevX_TextBox CTWallThickLess_Text;
        private PurpleCheckBox CTWallThickGreat_CheckBox;
        private LQP_DevX_TextBox CTWallThickGreat_Text;
        private PurpleCheckBox CTWallThickGreatT_CheckBox;
        private LQP_DevX_TextBox CTWallThickGreatT_Text;
        private PurpleCheckBox CTInsideRadNaN_CheckBox;
        private PurpleCheckBox CTInsideRadLess_CheckBox;
        private LQP_DevX_TextBox CTInsideRadLess_Text;
        private PurpleCheckBox CTInsideRadGreat_CheckBox;
        private LQP_DevX_TextBox CTInsideRadGreat_Text;
        private PurpleCheckBox CTDecenterRadNaN_CheckBox;
        private PurpleCheckBox CTDecenterRadLess_CheckBox;
        private LQP_DevX_TextBox CTDecenterRadLess_Text;
        private PurpleCheckBox CTDecenterRadGreat_CheckBox;
        private LQP_DevX_TextBox CTDecenterRadGreat_Text;
        private PurpleCheckBox CTGrade_CheckBox;
        private LQP_DevX_TextBox CTGrade_Text;
        private PurpleCheckBox CTGradeUnless_CheckBox;
        private LQP_DevX_TextBox CTGradeUnless_Text;
        private LQP_DevX_SimpleDD CTGradeUnless_DropDown;
        //TODO: identify the items from the drop down
        #endregion

        #region Replacement Variables

        private PurpleButton replacementTab; //This is the tab button that will be added soon su10032014
        //Replacement Values section
        private LQP_DevX_SimpleDD RP_DropDown;

            //Phil's filter
        //TODO: check to verify these purple paths are working properly
        private PurpleRadioButton RPSizeNarrow_RadioButton;
        private PurpleRadioButton RPSizeWide_RadioButton;
        private PurpleTextBox RPWindowSize_Text;
        private PurpleTextBox RPThresTolerance_Text;
        private PurpleTextBox RPGradeThres_Text;
        
            //Local window
        private PurpleDropDown RP_LW_Averaging_DropDown;
        private PurpleRadioButton RPUnits_RadioButton;
        private PurpleRadioButton RPSensors_RadioButton;
        private PurpleTextBox RPWindowSizeAxial_Text;
        private PurpleTextBox RPWindowSizeCirc_Text;
        private PurpleTextBox RPWindowSizeSlices_Text;
        private PurpleTextBox RPWindowSizeSensors_Text;
        
            //Global value
        private PurpleDropDown RP_GV_AveragingMethodDropDown;
        
            //Specified value
        private PurpleTextBox RPReplacThickness_Text;
        private PurpleTextBox RPReplacInsideRadius_Text;
        private PurpleTextBox RPReplacDescentRadius_Text;
        private PurpleCheckBox RPUseNaN_CheckBox;
        private PurpleTextBox RPReplacDeltaWT_Text;

            //Percentage
        private PurpleTextBox RPWallThickness_Text;
        private PurpleTextBox RPInsideRadius_Text;
        private PurpleTextBox RPDecentRadius_Text;
        
            //Infer WT from IR 
        private PurpleCheckBox RPReplaceAll_CheckBox;
        #endregion

        #region Panel Wide Button variables
        //Panel wide buttons
        private PurpleButton ApplyFilter_Button;
        private PurpleButton Cancel_Button;
        private PurpleButton UndoLast_Button;
        private PurpleButton History_Button;
        #endregion

        #region new Controls 3.2
        private PurpleDropDown featureSelector;
        private PurpleCheckBox excludeAnomolies;
        private PurpleRadioButton phils_outside_useNaN;
        private PurpleRadioButton phils_outside_median;
        private PurpleRadioButton phils_inside_leave;
        private PurpleRadioButton phils_inside_median;
        #endregion

        #region Public Variables
        public Point TestingPoint1, TestingPoint2;
        public Dictionary<string, TableRow> Point1DataBefore, Point2DataBefore;
        public Dictionary<string, TableRow> Point1DataAfter, Point2DataAfter;
        public string ApplyFilterValue;
        public static string replaceWallThickness;
        public static string replaceInsideRadius;
        public static string replaceDecenteredRadius;
        public static string replaceByPercentValue;
        public string replacementValue;
        #endregion

        #endregion
        //Constructor
        public FilterData_Panel()
        {
            _panelPath = "/LifeQuest™ Pipeline/panelContainer1/Filter Data/!BLANK!/Filter Data/";
            //Range SubPanel
            #region Range SubPanel
            //Custom Range Region - Used when Custom Range is selected
            #region CustomRange
            CustomRange_RadioButton = new PurpleRadioButton("SelectedData Radio Button", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadioApplyToSelected");
            //only available if SelectedData Radio button is checked
            SelectionMethod = new LQP_DevX_SimpleDD("SelectionMethod DropDown", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CboPositionSelectionMethod");
            FilterDataPosition = new LQP_DevX_TextBox("FilterDataPosition", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_Position");
            FilterDataLength = new LQP_DevX_TextBox("FilterDataLength", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_Length");
            FilterDataCircPosition = new LQP_DevX_TextBox("FilterDataCircPosition", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CircumferentialPosition");
            FilterDataExtent = new LQP_DevX_TextBox("FilterDataExtent", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CircumferentialExtent");
            FilterDataSensor = new LQP_DevX_SimpleDD("FilterDataSensor", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CboSensorIndex");
            #endregion

            SelectedFeatures_RadioButton = new PurpleRadioButton("SelectedFeatures RadioButton", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadioApplyToFilteredFeatureList");
            featureSelector = new PurpleDropDown("Feature Selector", _panelPath + "/FilterData_ProcessDataLayoutControl/FilterData_FeatureSelector");
            
            Joint_RadioButton = new PurpleRadioButton("Joint Radio Button", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadioApplyToJoint");
            JointSelection = new LQP_DevX_SimpleDD("Joint Selection Drop Down", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CboJointList");

            Range_RadioButton = new PurpleRadioButton("Range Radio Button", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadioApplyToRange");
            StartRange = new LQP_DevX_SimpleDD("Start Range Drop Down", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CboJointStart");
            EndRange = new LQP_DevX_SimpleDD("End Range Drop Down", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CboJointEnd");

            AllData_RadioButton = new PurpleRadioButton("Select All Data Radio Button", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadioApplyToAll");
            JointByJoint_CheckBox = new PurpleCheckBox("Joint By Joint Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ProcessJointByJoint");
            excludeAnomolies = new PurpleCheckBox("Exclude Anomolies Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ProcessDoesNotIncludeAnomalies");
            #endregion
            //Criteria Tab TODO determine how to change tabs - no tab button is visible in PurpleUI
            #region Criteria Tab
            //TODO need locator for this tab
            criteriaTab = new PurpleButton("Filter Data Criteria", _panelPath + "NEED LOCATOR");
            //Preset Filter
            presetFilter = new LQP_DevX_SimpleDD("Preset Filter", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_QuickFilters");
            presetFilter_Save = new PurpleButton("presetFilter Save Button", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_SaveFilter");
            presetFilter_Delete = new PurpleButton("presetFilter Delete Button", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_DeleteFilter");
        
            //Constraint to
            CTWallThickNaN_CheckBox = new PurpleCheckBox("Constrain To Wall Thickness NaN Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterNaNsWT");
            CTWallThickLess_CheckBox = new PurpleCheckBox("Constrain To Wall Thickness Less Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMinimumThickness");
            CTWallThickLess_Text = new LQP_DevX_TextBox("Constrain To Wall Thickness Less TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ThicknessMinimum");
            CTWallThickGreat_CheckBox = new PurpleCheckBox("Constrain To Wall Thickness Great Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMaximumThickness");
            CTWallThickGreat_Text = new LQP_DevX_TextBox("Constrain To Wall Thickness Great TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ThicknessMaximum");
            CTWallThickGreatT_CheckBox = new PurpleCheckBox("Constrain To Wall Thickness Great T Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterThicknessGreaterTNominal");
            CTWallThickGreatT_Text = new LQP_DevX_TextBox("Constrain To Wall Thickness Great T TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ThicknessTNominal");
            CTInsideRadNaN_CheckBox = new PurpleCheckBox("Constrain To Inside Radius NaN Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterNaNsRadius");
            CTInsideRadLess_CheckBox = new PurpleCheckBox("Constrain To Inside Radius Less Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMinimumRadius");
            CTInsideRadLess_Text = new LQP_DevX_TextBox("Constrain To Inside Radius Less TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadiusMinimum");
            CTInsideRadGreat_CheckBox = new PurpleCheckBox("Constrain To Inside Radius Great Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMaximumRadius");
            CTInsideRadGreat_Text = new LQP_DevX_TextBox("Constrain To Inside Radius Great TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_RadiusMaximum");
            CTDecenterRadNaN_CheckBox = new PurpleCheckBox("Constrain To Decentered Radius NaN Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterNaNsDRadius");
            CTDecenterRadLess_CheckBox = new PurpleCheckBox("Constrain To Decentered Radius Less Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMinimumDRadius");
            CTDecenterRadLess_Text = new LQP_DevX_TextBox("Constrain To Decentered Radius Less TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_DradiusMinimum");
            CTDecenterRadGreat_CheckBox = new PurpleCheckBox("Constrain To Decentered Radius Great Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMaximumDRadius");
            CTDecenterRadGreat_Text = new LQP_DevX_TextBox("Constrain To Decentered Radius Great TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_DradiusMaximum");
            CTGrade_CheckBox = new PurpleCheckBox("Constrain To Grade Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_ChkFilterMinimumQualityFactor");
            CTGrade_Text = new LQP_DevX_TextBox("Constrain To Grade TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_QFactorMinimum");
            CTGradeUnless_CheckBox = new PurpleCheckBox("Constrain To Grade unless Checkbox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_GradeConsideration");
            CTGradeUnless_Text = new LQP_DevX_TextBox("Constrain To Grade Unless TextBox", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_QFactorTThreshold");
            CTGradeUnless_DropDown = new LQP_DevX_SimpleDD("Constrain To Grade Unless DropDown", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_QFactorTThresholdBasis");
            //TODO: identify the items from the drop down
            #endregion
            //Replacement Tab
            #region Replacement Tab
            replacementTab = new PurpleButton("Replacement Tab", _panelPath + "FilterData_ProcessDataLayoutControl/Root/filterParametersGroup/FilterData_ProcessDataLayoutControl/Replacement");
            //Replacement Values section
            RP_DropDown = new LQP_DevX_SimpleDD("Replacement values", _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_CboFilterType");

            //Phil's filter
            //TODO: check to verify these purple paths are working properly
            string paramPath = _panelPath + "FilterData_ProcessDataLayoutControl/FilterData_FilterParameters/!BLANK!/";
            RPSizeNarrow_RadioButton = new PurpleRadioButton("Replacement values Size Narrow", paramPath + "/Size:{1}/PhilsFilterInputs_PhilNarrow");
            RPSizeWide_RadioButton = new PurpleRadioButton("Replacement values Size Wide", paramPath + "/Size:{1}/PhilsFilterInputs_PhilWide");
            RPWindowSize_Text = new PurpleTextBox("Replacement values Window Size", paramPath + "/Window Size:");
            RPThresTolerance_Text = new PurpleTextBox("Replacement values Threshold Tolerance", paramPath + "/Threshold tolerance (+/-):");
            RPGradeThres_Text = new PurpleTextBox("Replacement values Grade Threshold", paramPath + "/Grade threshold ( > ):");
            phils_outside_useNaN = new PurpleRadioButton("Phils Outside Use Nan", paramPath + "/Replacement Values{1}/PhilsFilterInputs_OutsideUseNaN");
            phils_outside_median = new PurpleRadioButton("Phils Outside median", paramPath + "/Replacement Values{1}/PhilsFilterInputs_OutsideUseMedian");
            phils_inside_leave = new PurpleRadioButton("Phils Inside Leave", paramPath + "/Outside Threshold:{1}/PhilsFilterInputs_InsideUseValue");
            phils_inside_median = new PurpleRadioButton("Phils Inside Median", paramPath + "/Outside Threshold:{1}/PhilsFilterInputs_InsideUseMedian");
        
            //Local window
            RP_LW_Averaging_DropDown = new PurpleDropDown("Replacement values LW Averaging Method", paramPath + "/FilterInputBase_AveragingMethod");
            RPUnits_RadioButton = new PurpleRadioButton("Replacement values Units", paramPath + "/DansFilterInputs_UseUnits");
            RPSensors_RadioButton = new PurpleRadioButton("Replacement values Sensors", paramPath + "/DansFilterInputs_UseSensors");
            RPWindowSizeAxial_Text = new PurpleTextBox("Replacement values Window Size Axial", paramPath + "/Window Size (axial)");
            RPWindowSizeCirc_Text = new PurpleTextBox("Replacement values Window Size Circ", paramPath + "/Window Size (circ.)");
            RPWindowSizeSlices_Text = new PurpleTextBox("Replacement values Window Size Slices", paramPath + "/Window Size (slices)");
            RPWindowSizeSensors_Text = new PurpleTextBox("Replacement values Window Size Sensors", paramPath + "/Window Size (sensors)");
        
                //Global value
            RP_GV_AveragingMethodDropDown = new PurpleDropDown("Replacement values GV Averaging Method", paramPath + "/FilterInputBase_AveragingMethod");
        
                //Specified value
            RPReplacThickness_Text = new PurpleTextBox("Replacement values Replacement Thickness", paramPath + "/Replacement Thickness");
            RPReplacInsideRadius_Text = new PurpleTextBox("Replacement values Replacement Inside Radius", paramPath + "/Replacement Inside Radius");
            RPReplacDescentRadius_Text = new PurpleTextBox("Replacement values Replacement Descentered Radius", paramPath + "/Replacement Decentered Radius");
            RPUseNaN_CheckBox = new PurpleCheckBox("Replacement values Use NaN",  paramPath + "/UserSpecifiedInputs_WTNaN");
            RPReplacDeltaWT_Text = new PurpleTextBox("Replacement values Replacement Delta WT", paramPath + "/Replacement Delta WT");

                //Percentage
            RPWallThickness_Text = new PurpleTextBox("Replacement values Wall Thickness", paramPath + "/Wall Thickness Modifier");
            RPInsideRadius_Text = new PurpleTextBox("Replacement values Inside Radius", paramPath + "/Inside Radius Modifier");
            RPDecentRadius_Text = new PurpleTextBox("Replacement values Decentered Radius", paramPath + "/ Decentered Radius Modifier");
        
                //Infer WT from IR 
            RPReplaceAll_CheckBox = new PurpleCheckBox("Replacement values Replace All WT", paramPath + "/InferWTFromIRInputs_ReplaceAllNansCheckbox");
            #endregion
            //Panel wide buttons
            #region PanelWide Buttons
            ApplyFilter_Button = new PurpleButton("Apply Filter Button", _panelPath + "FilterData_ActionButtonPanel/FilterData_ApplyButton");
            Cancel_Button = new PurpleButton("Cancel Filter Button", _panelPath + "FilterData_ActionButtonPanel/FilterData_CancelButton");
            UndoLast_Button = new PurpleButton("Undo Last Filter Button", _panelPath + "FilterData_ActionButtonPanel/FilterData_UndoLast");
            History_Button = new PurpleButton("History Button", _panelPath + "FilterData_ActionButtonPanel/FilterData_HistoryButton");
            #endregion

        }

        //Form Standard controls
        #region TestControls - used to test interactivity of panel
        public FilterData_Panel TestApplyToControls()
        {
            AllData_RadioButton.Click();
            JointByJoint_CheckBox.Click();
            Range_RadioButton.Click();
            StartRange.SelectItem("GW30");
            EndRange.SelectItem("GW1100");
            Joint_RadioButton.Click();
            JointSelection.SelectItem("FL140 - FL150");
            CustomRange_RadioButton.Click();
            SelectionMethod.SelectItem("Slice Index");
            int startIndex = MainScreen.dataInspector.SliceInx - 100;
            int length = 150;
            FilterDataPosition.Text = startIndex.ToString();
            FilterDataLength.Text = length.ToString();
            FilterDataCircPosition.Text = "4.0";
            FilterDataExtent.Text = "180";
            SelectedFeatures_RadioButton.Click();
            CustomRange_RadioButton.Click();
            return new FilterData_Panel();
        }

        public FilterData_Panel TestConstrainToControls()
        {
            CTWallThickGreat_CheckBox.Click();
            CTWallThickNaN_CheckBox.Click();
            CTWallThickLess_CheckBox.Click();
            CTWallThickGreat_CheckBox.Click();
            CTWallThickGreatT_CheckBox.Click();
            CTInsideRadNaN_CheckBox.Click();
            CTInsideRadLess_CheckBox.Click();
            CTInsideRadGreat_CheckBox.Click();
            CTDecenterRadNaN_CheckBox.Click();
            CTDecenterRadLess_CheckBox.Click();
            CTDecenterRadGreat_CheckBox.Click();
            CTGrade_CheckBox.Click();
            CTGradeUnless_CheckBox.Click();
            CTWallThickLess_Text.Text = "1.234";
            CTWallThickGreat_Text.Text = "1.234";
            CTWallThickGreatT_Text.Text = "1.234";
            CTInsideRadLess_Text.Text = "1.234";
            CTInsideRadGreat_Text.Text = "1.234";
            CTDecenterRadLess_Text.Text = "1.234";
            CTDecenterRadGreat_Text.Text = "1.234";
            CTGrade_Text.Text = "1.234";
            CTGradeUnless_Text.Text = "1.234";
            CTGradeUnless_DropDown.SelectItem("of Joint T(median)");
            return new FilterData_Panel();
        }

        public FilterData_Panel TestReplacementValuesControls()
        {
            replacementTab.Click();
            RP_DropDown.SelectItem("Infer WT from IR");
            
            RP_DropDown.SelectItem("Phil's Filter");
            // Later, it doesn't work //RPSizeWide_RadioButton.Click();
            // Later, it doesn't work //RPSizeNarrow_RadioButton.Click();
            // Later, it doesn't work //RPThresTolerance_Text.Text = "0.07";
            RPGradeThres_Text.Text = "7";

            RP_DropDown.SelectItem("Local Window");
            RP_LW_Averaging_DropDown.SelectItem("Median");
            RPUnits_RadioButton.Click();
            RPWindowSizeAxial_Text.Text = "1.2";
            RPWindowSizeCirc_Text.Text = "2.1";
            RPSensors_RadioButton.Click();
            RPWindowSizeSlices_Text.Text = "123";
            RPWindowSizeSensors_Text.Text = "321";
            
            RP_DropDown.SelectItem("Global Value");
            RP_GV_AveragingMethodDropDown.SelectItem("Mean");
            
            RP_DropDown.SelectItem("Specified Value");
            RPReplacThickness_Text.Text = "1.2";
            RPReplacInsideRadius_Text.Text = "2.3";
            RPReplacDescentRadius_Text.Text = "3.4";
            RPUseNaN_CheckBox.Click();
            RPReplacDeltaWT_Text.Text = "1.23";
            RP_DropDown.SelectItem("Percentage");
            RPWallThickness_Text.Text = "20";
            RPInsideRadius_Text.Text = "40";
            RPDecentRadius_Text.Text = "60";
            
            RP_DropDown.SelectItem("Infer WT from IR");
            RPReplaceAll_CheckBox.Click();

            return new FilterData_Panel();
        }
        
        public MainScreen TestQuickFilter()
        {
            CustomRange_RadioButton.Click();
            SelectionMethod.SelectItem("Slice Index");
            int startIndex = MainScreen.dataInspector.SliceInx - 100;
            int length = 150;
            FilterDataPosition.Text = startIndex.ToString();
            FilterDataLength.Text = length.ToString();
            presetFilter.SelectItem("Blank data (turn to NaN)");
            ApplyFilter();
            return new MainScreen();
        }
        
        public FilterData_Panel TestJoint()
        {
            Joint_RadioButton.Click();
            JointSelection.SelectItem("GW100 - GW110");
            CTWallThickGreat_Text.Text = "0.100";
            ApplyFilter();
            return this;
        }
        #endregion

        #region Range Controls
        public FilterData_Panel SwitchToJoint(int jointRange) {
            Joint_RadioButton.Click();
            JointSelection.EnterPartialText("GW" + jointRange);
            
            return this;
        }
        
        public FilterData_Panel SwitchToRange(int start, int end)
        {
            Range_RadioButton.Click();
            StartRange.SelectItem("GW" + start);
            EndRange.SelectItem("GW" + end);
            if (JointByJoint_CheckBox.IsElementToggledOn())
            {
                JointByJoint_CheckBox.Click();
            }
            return this;
        }
        #endregion

        #region Criteria Controls
        /// <summary>
        /// Sets all the Criteria elemnts to off
        /// </summary>
        /// <returns></returns>
        public FilterData_Panel Criteria_ResetAllControls()
        {
            if (CTWallThickNaN_CheckBox.IsElementToggledOn())
            {
                CTWallThickNaN_CheckBox.Click();
            }
            if (CTWallThickLess_CheckBox.IsElementToggledOn())
            {
                CTWallThickLess_CheckBox.Click();
            }
            if (CTWallThickGreat_CheckBox.IsElementToggledOn())
            {
                CTWallThickGreat_CheckBox.Click();
            }
            if (CTWallThickGreatT_CheckBox.IsElementToggledOn())
            {
                CTWallThickGreatT_CheckBox.Click();
            }
            if (CTInsideRadNaN_CheckBox.IsElementToggledOn())
            {
                CTInsideRadNaN_CheckBox.Click();
            }
            if (CTInsideRadLess_CheckBox.IsElementToggledOn())
            {
                CTInsideRadLess_CheckBox.Click();
            }
            if (CTInsideRadGreat_CheckBox.IsElementToggledOn())
            {
                CTInsideRadGreat_CheckBox.Click();
            }
            if (CTDecenterRadNaN_CheckBox.IsElementToggledOn())
            {
                CTDecenterRadNaN_CheckBox.Click();
            }
            if (CTDecenterRadLess_CheckBox.IsElementToggledOn())
            {
                CTDecenterRadLess_CheckBox.Click();
            }
            if (CTDecenterRadGreat_CheckBox.IsElementToggledOn())
            {
                CTDecenterRadGreat_CheckBox.Click();
            }
            if (CTGrade_CheckBox.IsElementToggledOn())
            {
                CTGrade_CheckBox.Click();
            }
            return this;
        }
        /// <summary>
        /// Sets the state of the Thickness NaNs checkbox
        /// </summary>
        /// <param name="enabled">Checked or Unchecked</param>
        /// <returns></returns>
        public FilterData_Panel Criteria_ThicknessNaNs(bool enabled)
        {
            CTWallThickNaN_CheckBox.Checked = enabled;
            return this;
        }
        /// <summary>
        /// Sets the Wall Thickness Less Than value to the data provided
        /// </summary>
        /// <param name="enabled">Sets the checkbox state</param>
        /// <param name="filterText">sets the corresponding textbox value</param>
        /// <returns></returns>
        public FilterData_Panel Criteria_ThicknessLT(bool enabled, string filterText)
        {
            CTWallThickLess_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTWallThickLess_Text.Text = filterText;
            }
            
            return this;

        }
        /// <summary>
        /// Set the Wall Thickness value to Filter
        /// </summary>
        /// <param name="enabled">Set the value of the Thickness GT Checkbox</param>
        /// <param name="filterText">Sets the value of the corresponding textbox</param>
        /// <returns></returns>
        public FilterData_Panel Criteria_ThicknessGT(bool enabled, string filterText)
        {
               CTWallThickGreat_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTWallThickGreat_Text.Text = filterText;
            }
            return this;
        }
        /// <summary>
        /// Sets the Thickness GT T(nom.) checkbox and textbox values
        /// </summary>
        /// <param name="enabled">State of the Thickness GT T(nom.) Checkbox</param>
        /// <param name="filterText">Sets the value of the textbox</param>
        /// <returns></returns>
        public FilterData_Panel Criteria_ThicknessGTnom(bool enabled, string filterText)
        {
            CTWallThickGreatT_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTWallThickGreatT_Text.Text = filterText;
            }
            return this;
        }
        /// <summary>
        /// Sets the value of the Radius NaNs checkbox
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public FilterData_Panel Criteria_RadiusNaNs(bool enabled)
        {
            CTInsideRadNaN_CheckBox.Checked = enabled;
            return this;
        }

        public FilterData_Panel Criteria_RadiusLT(bool enabled, string filterText)
        {
            CTInsideRadLess_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTInsideRadLess_Text.Text = filterText;
            }
            return this;
        }

        public FilterData_Panel Criteria_RadiusGT(bool enabled, string filterText)
        {
            CTInsideRadGreat_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTInsideRadGreat_Text.Text = filterText;
            }
            return this;
        }

        public FilterData_Panel Criteria_DRadiusNaNs(bool enabled)
        {
            CTDecenterRadNaN_CheckBox.Checked = enabled;
            return this;
        }

        public FilterData_Panel Criteria_DRadiusLT(bool enabled, string filterText)
        {
            CTDecenterRadLess_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTDecenterRadLess_Text.Text = filterText;
            }
            return this;
        }

        public FilterData_Panel Criteria_DRadiusGT(bool enabled, string filterText)
        {
            CTDecenterRadGreat_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTDecenterRadGreat_Text.Text = filterText;
            }
            return this;
        }

        public FilterData_Panel Criteria_Grade(bool enabled, string filterText, bool UnlessWTVal, string val,
            string dd_val)
        {
            CTGrade_CheckBox.Checked = enabled;
            if (enabled)
            {
                CTGrade_Text.Text = filterText;
                CTGradeUnless_CheckBox.Checked = UnlessWTVal;
                if (UnlessWTVal)
                {
                    CTGradeUnless_Text.Text = val;
                    CTGradeUnless_DropDown.EnterText(dd_val);
                }
            }
            return this;
        }


        #endregion

        #region Replacement Values Controls

        public FilterData_Panel Replacement_Phils(bool narrow, string thresholdTolerance, string gradeThreshold, bool outsideNan, bool insideLeave)
        {
            return this;
        }

        public FilterData_Panel Replacement_Local(string AveragingMethod, bool units, string axial_windowSize,
            string circ_windowSize, string slice_windowSize, string sensors_windowSize)
        {
            return this;
        }

        public FilterData_Panel Replacement_Global(string AveragingMethod)
        {
            return this;
        }

        public FilterData_Panel Replacement_Specified(bool useNaN, string replacementThickness, string replacementIR,
            string replacementDR, string replacementDelta)
        {
            return this;
        }

        public FilterData_Panel Replacement_Percentage(int wallThicknessMod, int IRMod, int decenteredRadMod)
        {
            return this;
        }

        public FilterData_Panel Replacement_InferWTfromIR()
        {
            return this;
        }

        #endregion

        #region PanelWide Controls
        public FilterData_Panel ApplyFilter(bool waitForConfirmation = false,int sleepTime=60000)
        {
            ApplyFilter_Button.Click();
            //Thread.Sleep(500);
            ConfirmFilterAction_Dialog confirmation = new ConfirmFilterAction_Dialog();
            
            if (waitForConfirmation && confirmation.VerifyWindowPresent())
            {
                confirmation.ClickYes();
            }
            FilterData_Processing_Popup.WaitForFilterDataProcess();
            
            return this;
        }

        public FilterData_Panel CancelFilter()
        {
            Cancel_Button.Click();
            return this;
        }

        public FilterData_Panel HistoryFilter()
        {
            History_Button.Click();
            return this;
        }
        public FilterData_Panel UndoLastFilter()
        {
            UndoLast_Button.Click();
            Thread.Sleep(500);
            return this;
        }
        public FilterData_Panel ConfirmFilterAction(bool yes)
        {
            ConfirmFilterAction_Dialog confirm = new ConfirmFilterAction_Dialog();
            if (yes)
            {
                confirm.ClickYes();
            }
            else
            {
                confirm.ClickNo();
            }
            return this;
        }
        #endregion

        #region Junk we're trying to get rid of
        

        public FilterData_Panel GetValuesBeforeFilter(string filterType)
        {
            bool dbug = true;
            Dictionary<string, TableRow> testPoint1Data, testPoint2Data;
            Pipe2D_Panel pipePanel = new Pipe2D_Panel();
            PurplePanel panel2D = pipePanel.pipe2D_GraphicsPanel;
            DataInspector_Panel dataInspector = new DataInspector_Panel();
            Rect panelBounds = panel2D.Bounds;
            // Select an arbitrary point from the 2D panel
            Point testPoint1 = pipePanel.FindPoint(panelBounds, dataInspector, filterType, false);
            testPoint1Data = new Dictionary<string, TableRow>(pipePanel.foundPointData);
            if (dbug)
            {
                Console.WriteLine("Point 1 - pos X: " + testPoint1.X + " - pos Y: " + testPoint1.Y);
                Console.WriteLine("Point 1 data: " + filterType + ": " + testPoint1Data[filterType].Value);
            }
            float testPoint1Value = float.Parse(testPoint1Data[filterType].Value);
            string evalValueFilter;
            testPoint2Data = new Dictionary<string, TableRow>();
            float evalValueFilterNew = 0f;
            Point testPoint2 = new Point(0, 0);
            float testPoint2Value = 0f;
            float evalValueFilterDiff = 0f;
            bool loopControl = true;
            // We look for a second Point which evalValueFilter is at least +/- 0.002 in  
            while (loopControl)
            {
                testPoint2 = pipePanel.FindPoint(panelBounds, dataInspector, filterType, false);
                if (dbug) Console.WriteLine("Evaluating point 2 - pos X: " + testPoint2.X + " - pos Y: " + testPoint2.Y);
                testPoint2Data = new Dictionary<string, TableRow>(pipePanel.foundPointData);
                testPoint2Value = float.Parse(testPoint2Data[filterType].Value);
                evalValueFilterDiff = Math.Abs((testPoint1Value - testPoint2Value)/2);
                if (evalValueFilterDiff > 0.002)
                {
                    loopControl = false;
                    if (dbug)
                    {
                        Console.WriteLine("Point 2 valid");
                        Console.WriteLine("Point 2 data: " + filterType + ": " + testPoint2Data[filterType].Value);
                    }
                }
                else
                {
                    if (dbug) Console.WriteLine("Point 2 not valid");
                }
            }

            Point1DataBefore = testPoint1Data;
            Point2DataBefore = testPoint2Data;
            TestingPoint1 = testPoint1;
            TestingPoint2 = testPoint2;
            if (testPoint1Value > testPoint2Value)
            {
                evalValueFilterNew = testPoint2Value + evalValueFilterDiff;
            }
            else
            {
                evalValueFilterNew = testPoint1Value + evalValueFilterDiff;
            }
            ApplyFilterValue = evalValueFilterNew.ToString("0.000", CultureInfo.InvariantCulture);
            return this;
        }
        
        public FilterData_Panel GetValuesAfterFilter()
        {
            bool dbug = true;
            Dictionary<string, TableRow> testPoint1Data, testPoint2Data;
            Pipe2D_Panel pipePanel = new Pipe2D_Panel();
            PurplePanel panel2D = pipePanel.pipe2D_GraphicsPanel;
            DataInspector_Panel dataInspector = new DataInspector_Panel();

            pipePanel.ClickIntoXY(TestingPoint1);
            dataInspector.CalculateDataInspectorDictionary();
            Point1DataAfter = new Dictionary<string, TableRow>(dataInspector.GetDataInspectorDictionary());
            if (dbug) Console.WriteLine("Point 1 - pos X: " + TestingPoint1.X + " - pos Y: " + TestingPoint1.Y);
            pipePanel.ClickIntoXY(TestingPoint2);
            dataInspector.CalculateDataInspectorDictionary();
            Point2DataAfter = new Dictionary<string, TableRow>(dataInspector.GetDataInspectorDictionary());
            if (dbug) Console.WriteLine("Point 2 - pos X: " + TestingPoint2.X + " - pos Y: " + TestingPoint2.Y);
            return this;
        }

        public FilterData_Panel CompareValues(string filterType, bool greater)
        {
            bool dbug = true;
            string testPoint1ValueBefore = Point1DataBefore[filterType].Value;
            string testPoint2ValueBefore = Point2DataBefore[filterType].Value;
            string testPoint1ValueAfter = Point1DataAfter[filterType].Value;
            string testPoint2ValueAfter = Point2DataAfter[filterType].Value;


            if (dbug) Console.WriteLine("Point 1 before: " + testPoint1ValueBefore + " - After: " + testPoint1ValueAfter);
            if (dbug) Console.WriteLine("Point 2 before: " + testPoint2ValueBefore + " - After: " + testPoint2ValueAfter);

            if (dbug) Console.WriteLine("Filter value: " + ApplyFilterValue);
            if (dbug) Console.WriteLine("Replacement value: " + replacementValue);
            if (greater)
            {
                if (dbug) Console.WriteLine("Greater");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + replacementValue + ");");
                    Assert.AreEqual(testPoint1ValueAfter, replacementValue);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
            }
            else
            {
                if (dbug) Console.WriteLine("Less than");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + replacementValue + ");");
                    Assert.AreEqual(testPoint1ValueAfter, replacementValue);
                }
            }
            if (greater)
            {
                if (dbug) Console.WriteLine("Greater");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + replacementValue + ");");
                    Assert.AreEqual(testPoint2ValueAfter, replacementValue);
                }
            }
            else
            {
                if (dbug) Console.WriteLine("Less than");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + replacementValue + ");");
                    Assert.AreEqual(testPoint2ValueAfter, replacementValue);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
            }

            return this;
        }

        public FilterData_Panel CompareValuesPercentage(string filterType, bool greater)
        {
            bool dbug = true;
            string formatString = "###,##0.00";
            string testPoint1ValueBefore = float.Parse(Point1DataBefore[filterType].Value).ToString(formatString);
            string testPoint2ValueBefore = float.Parse(Point2DataBefore[filterType].Value).ToString(formatString);
            string testPoint1ValueAfter = float.Parse(Point1DataAfter[filterType].Value).ToString(formatString);
            string testPoint2ValueAfter = float.Parse(Point2DataAfter[filterType].Value).ToString(formatString);
            float replacementPercentage = float.Parse(replacementValue);
            float multiplyBy = replacementPercentage / 100;
            string compareTo = "";
            if (dbug) Console.WriteLine("Point 1 before: " + testPoint1ValueBefore + " - After: " + testPoint1ValueAfter);
            if (dbug) Console.WriteLine("Point 2 before: " + testPoint2ValueBefore + " - After: " + testPoint2ValueAfter);

            if (dbug) Console.WriteLine("Filter value: " + ApplyFilterValue);
            if (dbug) Console.WriteLine("Replacement value: " + replacementValue + "%");
            if (greater)
            {
                if (dbug) Console.WriteLine("Greater");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    compareTo = (float.Parse(Point1DataBefore[filterType].Value) * multiplyBy).ToString(formatString, CultureInfo.InvariantCulture);
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + compareTo + ");");
                    Assert.AreEqual(testPoint1ValueAfter, compareTo);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
            }
            else
            {
                if (dbug) Console.WriteLine("Less than");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
                else
                {
                    compareTo = (float.Parse(Point1DataBefore[filterType].Value) * multiplyBy).ToString(formatString, CultureInfo.InvariantCulture);
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + compareTo + ");");
                    Assert.AreEqual(testPoint1ValueAfter, compareTo);
                }
            }
            if (greater)
            {
                if (dbug) Console.WriteLine("Greater");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
                else
                {
                    compareTo = (float.Parse(Point2DataBefore[filterType].Value) * multiplyBy).ToString(formatString, CultureInfo.InvariantCulture);
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + compareTo + ");");
                    Assert.AreEqual(testPoint2ValueAfter, compareTo);
                }
            }
            else
            {
                if (dbug) Console.WriteLine("Less than");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    compareTo = (float.Parse(Point2DataBefore[filterType].Value) * multiplyBy).ToString(formatString, CultureInfo.InvariantCulture);
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + compareTo + ");");
                    Assert.AreEqual(testPoint2ValueAfter, compareTo);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
            }

            return this;
        }


        public FilterData_Panel CompareUndoneOrCancelledValues(string filterType, bool greater)
        {
            bool dbug = true;
            
            string testPoint1ValueBefore = Point1DataBefore[filterType].Value;
            string testPoint2ValueBefore = Point2DataBefore[filterType].Value;
            string testPoint1ValueAfter = Point1DataAfter[filterType].Value;
            string testPoint2ValueAfter = Point2DataAfter[filterType].Value;
            
            if (dbug) Console.WriteLine("Point 1 before: " + testPoint1ValueBefore + " - After: " + testPoint1ValueAfter);
            if (dbug) Console.WriteLine("Point 2 before: " + testPoint2ValueBefore + " - After: " + testPoint2ValueAfter);

            if (dbug) Console.WriteLine("Filter value: " + ApplyFilterValue);
            if (dbug) Console.WriteLine("Replacement value: " + replacementValue);
            if (greater)
            {
                if (dbug) Console.WriteLine("Greater");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
            }
            else
            {
                if (dbug) Console.WriteLine("Less than");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint1ValueAfter + "," + testPoint1ValueBefore + ");");
                    Assert.AreEqual(testPoint1ValueAfter, testPoint1ValueBefore);
                }
            }
            if (greater)
            {
                if (dbug) Console.WriteLine("Greater");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
            }
            else
            {
                if (dbug) Console.WriteLine("Less than");
                if (float.Parse(testPoint1ValueBefore) > float.Parse(testPoint2ValueBefore))
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore > testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
                else
                {
                    if (dbug) Console.WriteLine("testPoint1ValueBefore < testPoint2ValueBefore");
                    if (dbug) Console.WriteLine("Assert.AreEqual(" + testPoint2ValueAfter + "," + testPoint2ValueBefore + ");");
                    Assert.AreEqual(testPoint2ValueAfter, testPoint2ValueBefore);
                }
            }

            return this;
        }
        #endregion

        #region Parent methods
        //Interface Methods
        public override FilterData_Panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }
        #endregion
    }
}

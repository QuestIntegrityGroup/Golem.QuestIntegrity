using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs
{
    public class SummaryChartOptions_Dialog : BaseScreenObject
    {
        
        //Sub Panels
        private PurpleButton XAxis_Panel = new PurpleButton("General Panel", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis");
        private PurpleButton General_Panel = new PurpleButton("X-Axis Panel", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General");
        
        //General Panel's oblects
        private PurpleRadioButton YAxisScale_Automatic_Radio = new PurpleRadioButton("Y-Axis Scale - Automatic Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_ScaleAutomatic");
        private PurpleRadioButton YAxisScale_Nominal_Radio = new PurpleRadioButton("Y-Axis Scale - Nominal Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_ScaleNominal");
        private PurpleRadioButton YAxisScale_MatchColor_Radio = new PurpleRadioButton("Y-Axis Scale - Match Color Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_ScaleMatchColor");
        private PurpleRadioButton YAxisScale_SpecificRange_Radio = new PurpleRadioButton("Y-Axis Scale - Specific Range Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_ScaleRange");
        private PurpleTextBox YAxisScale_SRMin_Textbox = new PurpleTextBox("Y-Axis Scale - Range Min TextBox", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_RangeMin");
        private PurpleTextBox YAxisScale_SRMax_Textbox = new PurpleTextBox("Y-Axis Scale - Range Max TextBox", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_RangeMax");
        private PurpleCheckBox DisplayShowNominal_Checkbox = new PurpleCheckBox("Display - Show Nominal", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_ShowNominal");
        private PurpleCheckBox DisplayShowNominalLabels_Checkbox = new PurpleCheckBox("Display - Show Nominal Labels", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_ShowNominalLabels");
        private PurpleCheckBox DisplayUseToolTips_Checkbox = new PurpleCheckBox("Display - Use Tool Tips", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/General/ChartOptions_General/ChartOptions_UseToolTips");
        //XAxis Panel's objects
        private PurpleRadioButton XAxisScale_Position_Radio = new PurpleRadioButton("X-Axis Scale - Position Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_XScalePosition");
        private PurpleRadioButton XAxisScale_SliceIndex_Radio = new PurpleRadioButton("X-Axis Scale - Slice Index Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_XScaleSliceIndex");
        private PurpleRadioButton XAxisScale_Time_Radio = new PurpleRadioButton("X-Axis Scale - Time Radio Button", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_XScaleTime");
        private PurpleTextBox XAxisScale_SliceAtTime_Textbox = new PurpleTextBox("X-Axis Scale - Slice At Time 0 Text 2", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_XScaleStartSlice/ChartOptions_XScaleStartSlice");

        private PurpleTextBox XAxisScale_XGradients_DropDown = new PurpleTextBox("X-Axis Scale - X Gradients drop Down", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_CboXGradients/ChartOptions_CboXGradients");
        private PurpleCheckBox XAxisScale_ApproxPositions_Checkbox = new PurpleCheckBox("X-Axis Scale - Approximate Positions CheckBox", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_ChkApproximatePositions");
        private PurpleTextBox XAxisScale_NoOfBins_Textbox = new PurpleTextBox("X-Axis Scale - Number Of Bins Spinner", "/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Options/X Axis/ChartOptions_TabXAxis/ChartOptions_CboNumberOfBins/ChartOptions_CboNumberOfBins");
        
        //General Buttons
        private PurpleButton Apply_Button = new PurpleButton("Apply Button","/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Apply");
        private PurpleButton Ok_Button = new PurpleButton("OK Button","/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_OK");
        private PurpleButton Cancel_Button = new PurpleButton("Cancel Button","/LifeQuest™ Pipeline/Summary Chart Options/ChartOptions_Cancel");

        public void Test()
        {
            YAxisScale_Nominal_Radio.Click();
            YAxisScale_Automatic_Radio.Click();
            YAxisScale_MatchColor_Radio.Click();
            YAxisScale_SpecificRange_Radio.Click();
            YAxisScale_SRMin_Textbox.Text = "10";
            YAxisScale_SRMax_Textbox.Text = "90";
            DisplayShowNominalLabels_Checkbox.Click();
            DisplayShowNominal_Checkbox.Click();
            DisplayUseToolTips_Checkbox.Click();

            XAxis_Panel.Click();
            XAxisScale_SliceIndex_Radio.Click();
            XAxisScale_Position_Radio.Click();
            XAxisScale_Time_Radio.Click();
            XAxisScale_SliceAtTime_Textbox.Text = "20";
            XAxisScale_ApproxPositions_Checkbox.Click();
            XAxisScale_XGradients_DropDown.Text="SliceIndex";
            XAxisScale_NoOfBins_Textbox.Text="20";
            General_Panel.Click();
            Cancel_Button.Click();
        }

        //interface methods
        public MainScreen GoToMain()
        {
            return new MainScreen();
        }
    }
}

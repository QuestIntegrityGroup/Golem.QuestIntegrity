using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;
using ProtoTest.Golem.WebDriver.Elements.Types;
using PurpleLib;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class SummaryCharts_Panel : BasePanel<SummaryCharts_Panel>
    {
        private static SummaryCharts_Panel thisPanel;
        
        private static string _ProjectName = "";
        private static string _PanelPath = "";

        private PurpleDropDown Data_DropDown ;
        private PurpleDropDown Measure_DropDown ;
        private PurpleCheckBox ShowPoints_Checkbox ;
        private PurpleCheckBox ShowLines_Checkbox ;
        private PurpleButton Options_Button ;
        private PurpleElementBase GraphicPanel;
        private PurpleButton SummaryChart_MenuItem = new PurpleButton("Menu item", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuView/Main_ViewSummaryPlot");
        
        public static SummaryCharts_Panel GetInstance()
        {
            if (thisPanel == null)
            {
                thisPanel = new SummaryCharts_Panel();   
            }
            return thisPanel;
        }

        public static SummaryCharts_Panel GetInstance(string projectName)
        {
            _ProjectName = projectName;
            _PanelPath = "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Summary Charts]";
            if (thisPanel == null)
            
            {
                thisPanel = new SummaryCharts_Panel();
            }
            return thisPanel;
        }

        /*
        public static void SetUpPanel(string ProjectName)
        {
            _ProjectName = ProjectName;
            _PanelPath = "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Summary Charts]/LifeQuestBaseView_ViewBar";
        }
        */

        private SummaryCharts_Panel()
        {
            Data_DropDown = new PurpleDropDown("Data Drop Down", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_ScalarDataComboBox");
            Measure_DropDown = new PurpleDropDown("Measure Drop Down", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_MeasureComboBox");
            ShowPoints_Checkbox = new PurpleCheckBox("Show Points Checkbox", _PanelPath + "/LifeQuestBaseView_ViewBar/Show points");
            ShowLines_Checkbox = new PurpleCheckBox("ShowLines Checkbox", _PanelPath + "/LifeQuestBaseView_ViewBar/Show lines");
            Options_Button = new PurpleButton("Options Button", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_OptionsButton");
            GraphicPanel = new PurpleElementBase("Summary Chart Graphic Panel", _PanelPath + "/ChartPane_ChartControl");
        }

        public SummaryCharts_Panel OpenSummaryCharts()
        {
            SummaryChart_MenuItem.Invoke();
            return this;
        }

        /// <summary>
        /// Change the data drop down
        /// Valid options are: "Velocity", "Flaws by location", "Flaws by orientation", "Dents by location", "Dents by orientation"
        /// "RSF results by location", "MAOPr results by location", "Tmm by location", "Tmed v. Tnom by Joint", "Joint Summary", "Data Grade"
        /// "Joint Length by Odometer", "Data Quality"
        /// </summary>
        /// <param name="dataType">The name of the element in the drop down</param>
        /// <returns>MainScreen</returns>
        public MainScreen ChangeData(string dataType)
        {
            Data_DropDown.SelectItem(dataType);
            return new MainScreen();
        }

        /// <summary>
        /// Change the measure drop down
        /// Valid options are:
        /// FOR DataQuality: "Thickness Data Quality", "Thickness Quality with AGMs", "Radius Data Quality", "Radius Quality with AGMs"
        /// </summary>
        /// <param name="measureType">The name of the element in the drop down</param>
        /// <returns>MainScreen</returns>
        public MainScreen ChangeMeasure(string measureType)
        {
            Measure_DropDown.SelectItem(measureType);
            return new MainScreen();
        }

        /// <summary>
        /// This function is for testing purposes
        /// </summary>
        public void Test()
        {
            Data_DropDown.SelectItemByPosition(3);
            Measure_DropDown.SelectItemByPosition(3);
            ShowPoints_Checkbox.Click();
            ShowLines_Checkbox.Click();
            Options_Button.Click();
            SummaryChartOptions_Dialog dialog1 = new SummaryChartOptions_Dialog();
            dialog1.Test();
        }

        /// <summary>
        /// Returns the Graphic panel of the summary chart panel
        /// </summary>
        /// <returns>PurpleElementBase</returns>
        public PurpleElementBase GetGraphicPanel()
        {
            return GraphicPanel;
        }

        //interface methods
        public override SummaryCharts_Panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }
    }
}

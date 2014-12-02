using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_ProgramOptions
{
    public class ProgramOptions_Dialog : BaseScreenObject
    {
        
        

        private PurpleButton General = new PurpleButton("GeneralItem", "/LifeQuest™ Pipeline/Program Options/ProgramOptions_ConfigGroupTree/General");
        private PurpleButton Visualization = new PurpleButton("VisualizationItem", "/LifeQuest™ Pipeline/Program Options/ProgramOptions_ConfigGroupTree/Visualization");
        private PurpleButton Calculations = new PurpleButton("CalculationsItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/Calculations");
        private PurpleButton Performance = new PurpleButton("PerformanceItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/Performance");
        private PurpleButton ChartOptions = new PurpleButton("ChartOptionsItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/Chart Options");
        private PurpleButton FileLocations = new PurpleButton("FileLocationsItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/File Locations");
        private PurpleButton UserDefinedFields = new PurpleButton("UserDefinedFieldsItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/User-Defined Fields");
        private PurpleButton AnalystOptions = new PurpleButton("AnalystOptionsItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/Analyst Options");
        private PurpleButton FeatureAutoLabeling = new PurpleButton("FeatureAutoLabelingItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/Feature Auto Labeling");
        private PurpleButton ImportSettings = new PurpleButton("ImportSettingsItem", "/LifeQuest™ Pipeline/Program Options/!BLANK!{1}/Import Settings");

        public static GeneralPage generalpage;
        

        public ProgramOptions_Dialog()
        {

        }
        
        public GeneralPage chooseGeneralItem()
        {
            General.Click();

            return new GeneralPage();
        }

        public void chooseVisualizationItem()
        {
            Visualization.Click();
        }

        public void chooseCalculationsItem()
        {
            Calculations.Click();
        }

        public void choosePerformanceItem()
        {
            Performance.Click();
        }

        public void chooseChartOptionsItem()
        {
            ChartOptions.Click();
        }

        public void chooseFileLocationsItem()
        {
            FileLocations.Click();
        }

        public void chooseUserDefinedFieldsItem()
        {
            UserDefinedFields.Click();
        }

        public void chooseAnalystOptionsItem()
        {
            AnalystOptions.Click();
        }

        public void chooseFeatureAutoLabelingItem()
        {
            FeatureAutoLabeling.Click();
        }

        public void chooseImportSettingsItem()
        {
            ImportSettings.Click();
        }

        //public void chooseOK()
        //{
        //    OKButton.Click();
        //}

        //public void chooseCancel()
        //{
        //    CancelButton.Click();
        //}

    }
}

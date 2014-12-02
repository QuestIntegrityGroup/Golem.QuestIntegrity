using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_ProgramOptions
{
    public class GeneralPage :BaseScreenObject
    {
        private PurpleButton GlobalMetric = new PurpleButton("MetricRadioButton", "/LifeQuest™ Pipeline/Program Options/ProgramOptions_BorderPanel/ProgramOptions_TabPanel/!BLANK!/GeneralTab_UnitSystemPanel/GeneralTab_MetricRadioButton");
        private PurpleButton GlobalImperial = new PurpleButton("ImperialRadioButton", "/LifeQuest™ Pipeline/Program Options/ProgramOptions_BorderPanel/ProgramOptions_TabPanel/!BLANK!/GeneralTab_UnitSystemPanel/GeneralTab_ImperialRadioButton");
        private PurpleButton OKButton = new PurpleButton("OKButtton", "/LifeQuest™ Pipeline/Program Options/ProgramOptions_OK");
        private PurpleButton CancelButton = new PurpleButton("CancelButton", "/LifeQuest™ Pipeline/Program Options/Cancel");

        public static ProgramOptions_Dialog programOptions_Dialog;
        public static MainScreen mainScreen;
        public static FeatureSpreadsheet_Panel featureSpreadsheet_Panel;

        public GeneralPage()
        {

        }

        public MainScreen updateUnitSystem(string FeatureLengthUnit)
        {
            if (FeatureLengthUnit == Constants.METRIC)
            {
                GlobalMetric.Click();
                OKButton.Click();
                Constants.UnitSystem = Constants.METRIC;
            }
            else
            {
                GlobalImperial.Click();
                OKButton.Click();
                Constants.UnitSystem = Constants.IMPERIAL;
            }

            return new MainScreen();
        }
    }
}

using System;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using NUnit.Framework;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class Navigation_Panel : BasePanel<Navigation_Panel>
    {
        private static string _ProjectName;
        private string _PanelPath;

        private static string centerPositionBefore;
        private static string viewWidthBefore;
        private static string centerPositionAfter;
        private static string viewWidthAfter;


        //TODO: There are a lot of labels that can be read on this panel that may effect the outcome of paticular tests.  They should be added to this panel.
        //TODO: this controls haven't been tested yet
        private PurpleElementBase NavigationPanel_Panel = new PurpleElementBase("Navigation Panel", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm");
        private PurpleSpinner CenterPosition_Spinner=new PurpleSpinner("Center Position Spinner" ,"/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/The XtraLayoutControl/Navigation_ViewSectionStartSelector");
        private PurpleTextBox CenterPosition_TextBox = new PurpleTextBox("Center Position Textbox", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/The XtraLayoutControl/Navigation_ViewSectionStartSelector/Navigation_ViewSectionStartSelector");
        private PurpleSpinner ViewWidth_Spinner = new PurpleSpinner("View Width Spinner", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/The XtraLayoutControl/Navigation_ViewSectionWidthSelector");
        private PurpleTextBox ViewWidth_TextBox = new PurpleTextBox("View Width Textbox", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/The XtraLayoutControl/Navigation_ViewSectionWidthSelector/Navigation_ViewSectionWidthSelector");
        private PurpleDropDown ReferenceBy_DropDown = new PurpleDropDown("Reference By DropDown","/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/The XtraLayoutControl/Navigation_ViewSectionSelectionMethod");
        private PurpleDropDown NavigateBy_DropDown = new PurpleDropDown("Navigate By DropDown", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_NavigationFeatureType");
        // define something for ViewWidthInits
        private PurpleButton MoveFirst_Button  = new PurpleButton("Move First Button","/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_NavigateFirst");
        private PurpleButton MoveForward_Button = new PurpleButton("Move Forward Button", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_NavigateNext");
        private PurpleButton MoveBackward_Button = new PurpleButton("Move Backward Button ", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_NavigatePrevious");
        private PurpleButton MoveLast_Button = new PurpleButton("Move Last Button", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_NavigateLast");

        private PurpleButton Find_Button = new PurpleButton("Find Button", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_FindByLabel");
        private PurpleTextBox Find_TextBox = new PurpleTextBox("Find TextBox", "/LifeQuest™ Pipeline/Navigation/!BLANK!/LifeQuestBaseForm/Navigation_SearchStringInput");
        
        // define something for navigationbar 
        

        public static void setProjectName(string ProjectName)
        {
            _ProjectName = ProjectName;
        }

        public Navigation_Panel()
        {
            _PanelPath = _ProjectName + "";

        }

        public MainScreen GoToBeginingofPipe()
        {
            MoveFirst_Button.Invoke();
            return new MainScreen();
        }

        public void Test()
        {
            CenterPosition_Spinner.Increment();
            ViewWidth_Spinner.Increment();
            ReferenceBy_DropDown.SelectItemByPosition(1);
            NavigateBy_DropDown.SelectItemByPosition(3);
            Find_TextBox.Text = "FL2500";
            MoveFirst_Button.Click();
            MoveForward_Button.Click();
            MoveLast_Button.Click();
            MoveBackward_Button.Click();
            Find_Button.Click();
        }
        
        public void ShowChilds()
        {
           

        }

        /// <summary>
        /// Reads Center Position and View Width values before changes, and stores them in local variables
        /// </summary>
        public MainScreen ReadNavigationValuesBefore()
        {
            centerPositionBefore = CenterPosition_TextBox.Text;
            viewWidthBefore = ViewWidth_TextBox.Text;
            return new MainScreen();
        }

        /// <summary>
        /// Reads Center Position and View Width values after changes, and stores them in local variables
        /// </summary>
        public MainScreen ReadNavigationValuesAfter()
        {
            centerPositionAfter = CenterPosition_TextBox.Text;
            viewWidthAfter = ViewWidth_TextBox.Text;
            return new MainScreen();
        }

        public void CompareUnits(string systemFrom)
        {
            bool toImperial = true;
            if (systemFrom.Equals(Constants.IMPERIAL))
            {
                //To imperial=true means that BEFORE stores values in metric and AFTER in imperial
                toImperial = false;
            }

            if (systemFrom.Equals(Constants.METRIC))
            {
                //To imperial=true means that BEFORE stores values in metric and AFTER in imperial
                toImperial = true;
            }
            if (toImperial)
            {
                Assert.AreEqual(
                    Math.Round(Double.Parse(viewWidthBefore), 1, MidpointRounding.AwayFromZero).ToString("0,000.0"),
                    Math.Round(UnitConversions.Length.FeetToMeters(Double.Parse(viewWidthAfter)), 1,
                        MidpointRounding.AwayFromZero).ToString("0,000.0"));

                Assert.AreEqual(
                    Math.Round(Double.Parse(centerPositionBefore), 1, MidpointRounding.AwayFromZero).ToString("0,000.0"),
                    Math.Round(UnitConversions.Length.FeetToMeters(Double.Parse(centerPositionAfter)), 1,
                        MidpointRounding.AwayFromZero).ToString("0,000.0"));

            }
            else
            {
                Assert.AreEqual(
                        Math.Round(Double.Parse(viewWidthBefore), 1, MidpointRounding.AwayFromZero).ToString("0,000.0"),
                        Math.Round(UnitConversions.Length.MetersToFeet(Double.Parse(viewWidthAfter)), 1,
                            MidpointRounding.AwayFromZero).ToString("0,000.0"));

                Assert.AreEqual(
                        Math.Round(Double.Parse(centerPositionBefore), 1, MidpointRounding.AwayFromZero).ToString("0,000.0"),
                        Math.Round(UnitConversions.Length.MetersToFeet(Double.Parse(centerPositionAfter)), 1,
                            MidpointRounding.AwayFromZero).ToString("0,000.0"));

            }
        }
        //interface method
        public override Navigation_Panel MenuSelection(PurpleButton button)
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

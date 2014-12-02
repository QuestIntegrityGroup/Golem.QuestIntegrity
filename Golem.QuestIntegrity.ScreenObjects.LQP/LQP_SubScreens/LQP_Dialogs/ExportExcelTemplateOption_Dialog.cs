using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs
{
    public class ExportExcelTemplateOption_Dialog : BaseScreenObject
    {
        private PurpleButton YesButton = new PurpleButton("Yes button", "/LifeQuest™ Pipeline/Template Option/Template Option/Yes");
        private PurpleButton NoButton = new PurpleButton("No button", "/LifeQuest™ Pipeline/Template Option/Template Option/No");

        public MainScreen ClickYes()
        {
            YesButton.Click();
            return new MainScreen();
        }

        public MainScreen ClickNo()
        {
            NoButton.Click();
            return new MainScreen();
        }
    }
}

using System.Threading;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs
{
    public class ExportExcelWarning_Dialog : BaseScreenObject
    {
        private PurpleButton YesButton = new PurpleButton("Yes button", "/LifeQuest™ Pipeline/Warning/Warning/Yes");
        private PurpleButton NoButton = new PurpleButton("No button", "/LifeQuest™ Pipeline/Warning/Warning/No");

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

        public bool VerifyWindowPresent()
        {
            Thread.Sleep(500);
            if (YesButton.Present())
            {
                return true;
            }
            return false;
        }
    }
}

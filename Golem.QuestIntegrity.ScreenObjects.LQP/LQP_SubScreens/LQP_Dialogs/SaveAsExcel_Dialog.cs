using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs
{
    public class SaveAsExcel_Dialog : BaseScreenObject
    {
        private PurpleButton Save_Button = new PurpleButton("Save button", "/LifeQuest™ Pipeline/Save As Excel File/Save");
        private PurpleButton Cancel_Button = new PurpleButton("Cancel button", "/LifeQuest™ Pipeline/Warning/Warning/No");
        private PurpleTextBox FileName_Textbox = new PurpleTextBox("File Name TextBox", "/LifeQuest™ Pipeline/Save As Excel File/!BLANK!/Explorer Pane/Details Pane/File name:{1}/File name:");

        public MainScreen SaveFile(string name)
        {
            FileName_Textbox.Text = name;
            Save_Button.Click();
            return new MainScreen();
        }
    }
}

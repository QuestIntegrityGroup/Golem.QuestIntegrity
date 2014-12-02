using System;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs
{
    public class OpenFile_Dialog : BaseScreenObject
    {
        //private WhiteButton OpenButton = new WhiteButton(SearchCriteria.ByText("Open"), OpenFileWindow);
        private PurpleButton OpenButton = new PurpleButton("OpenFileButton", "/LifeQuest™ Pipeline/Open/Open");
        //private WhiteButton CancelButton = new WhiteButton(SearchCriteria.ByText("Cancel"), OpenFileWindow);
        private PurpleButton CancelButton = new PurpleButton("CancelButton", "/LifeQuest™ Pipeline/Open/Cancel");
        //private WhiteComboBox FileName = new WhiteComboBox(SearchCriteria.ByText("File name:"), OpenFileWindow);
        private PurpleTextBox FileName = new PurpleTextBox("FileName", "/LifeQuest™ Pipeline/Open/File name:{1}/File name:/File name:");



        public void OpenaFile(String filepathtoOpen)
        {
            FileName.Text = filepathtoOpen;
            OpenButton.Click();
        }

        public void Cancel()
        {
            CancelButton.Click();
        }
    }
}
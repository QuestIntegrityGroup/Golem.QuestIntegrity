using ProtoTest.Golem.Purple;


namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality
{
    public class SimpleDialogHandler : BaseScreenObject
    {
        /* This class is meant to be used to handle errors and dialog messages from LQP that can be dismissed without affecting
         * the operation of a test case.  These messages may or may not be error messages.
         */
        //private Window dialogBox;
        //private List<Window> availableWindows;
        private string dialogTitle;
        private string dialogResponse;

        public SimpleDialogHandler(string title, bool auto = false)
        {
            //dialogTitle = title;
            //if (auto)
            //{
            //    AknowledgeDialog();
            //}
        }

        public SimpleDialogHandler(string title, string response, bool auto = false)
        {
            //dialogTitle = title;
            //dialogResponse = response;
            //if (auto)
            //{
            //    AknowledgeDialog();
            //}
        }

        public void AknowledgeDialog()
        {
            //if (closeWindow())
            //{
            //    DiagnosticLog.WriteLine("DialogBox Titled: " + dialogTitle + " handled and closed.");
            //}
            //else
            //{
            //    DiagnosticLog.WriteLine("DialogBox Titled: " + dialogTitle + " was not found or Handled.");
            //}
        }

        private bool closeWindow()
        {
            //This function checks all the available windows currently running for the dialog box with the matching title
            //if the matching title is found it attempts to close the window.
            //bool exists = false;
            //availableWindows = PurpleTestBase.app.GetWindows();
            //for (int x = 0; x < availableWindows.Count; x++)
            //{
            //    if (availableWindows[x].Title == dialogTitle)
            //    {
            //        exists = true;
            //        dialogBox = availableWindows[x];
            //    }
            //}
            //if (exists)
            //{
            //    if (dialogResponse != null)
            //    {
            //        Button responseButton = dialogBox.Get<Button>(SearchCriteria.ByText(dialogResponse));
            //        responseButton.Click();
            //    }
            //    else
            //    {
            //        dialogBox.Close();    
            //    }
            //}

            return true;
        }
    }
}

using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using ProtoTest.Golem.Purple;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_DataTools
{
    public class DataTools_Remove : BaseScreenObject
    {
        //private static WhitePanel CrossSectionPanel = new WhitePanel(SearchCriteria.ByAutomationId("CrossSectionViewPane"));
        //private WhiteCheckBox allDataCheckBox = new WhiteCheckBox(SearchCriteria.ByText("InspectionRangeSelector_SelectAllData"), dataToolsWindow);
        //private WhiteTextBox startPositionTextBox = new WhiteTextBox(SearchCriteria.ByText("InspectionRangeSelector_DataStartPosition"), dataToolsWindow);
        //private WhiteTextBox endPositionTextBox = new WhiteTextBox(SearchCriteria.ByText("InspectionRangeSelector_DataEndPosition"), dataToolsWindow);
        //private WhiteTextBox startSliceIndexTextBox = new WhiteTextBox(SearchCriteria.ByText("InspectionRangeSelector_DataStartIndex"), dataToolsWindow);
        //private WhiteTextBox endSliceIndexTextBox = new WhiteTextBox(SearchCriteria.ByText("InspectionRangeSelector_DataEndIndex"), dataToolsWindow);
        //private WhiteTextBox distancePositionTextBox = new WhiteTextBox(SearchCriteria.ByText("InspectionRangeSelector_DataDistance"), dataToolsWindow);
        //private WhiteTextBox distanceSliceIndexTextBox = new WhiteTextBox(SearchCriteria.ByText("InspectionRangeSelector_DataDistanceSlices"), dataToolsWindow);
        ////These 2 buttons are present on every tab from the Data Tools Window
        //private WhiteButton runToolButton = new WhiteButton(SearchCriteria.ByText("DataTools_RunToolTask"), dataToolsWindow);
        //private WhiteButton closeButton = new WhiteButton(SearchCriteria.ByText("DataTools_CloseForm"), dataToolsWindow);

        private string InitialEndPosition;
        private string InitialEndSliceIndex;
        private string InitialStartPosition;
        private string InitialStartSliceIndex;

        private void getAllData()
        {
            ////Assuming everytime open the DataTools_Remove window, all data is un-checked
            //allDataCheckBox.Click();

            //InitialStartPosition = startPositionTextBox.Text;
            //InitialEndPosition = endPositionTextBox.Text;
            //InitialStartSliceIndex = startSliceIndexTextBox.Text;
            //InitialEndSliceIndex = endSliceIndexTextBox.Text;

            //allDataCheckBox.Click();
        }

        public void ShortenPipe(double startPositionValue = 0, double endPositionValue = 0)
        {
            getAllData();

            //startPositionTextBox.Text = startPositionValue.ToString();
            //endPositionTextBox.Text = endPositionValue.ToString();
            //runToolButton.Click();

            var MakeBackup = new SimpleDialogHandler("Make Backup of Project?", "Yes", true);
            var RemoveData = new SimpleDialogHandler("Remove Data", true);
            var DataRemoval = new SimpleDialogHandler("Data Removal", true);
            var FeaturesRequireUpdating = new SimpleDialogHandler("Features Require Updating", "Yes", true);
            RemoveData.AknowledgeDialog();
            DataRemoval.AknowledgeDialog();


            VerifyPipeLength();
        }

        private void VerifyPipeLength()
        {
            
            //OpenUpRemoveData.OpenMenuItem();
            HandleFirstErrors();
            //allDataCheckBox.Click();
            //int endpos = int.Parse(InitialEndPosition);
            //int newendpos = int.Parse(endPositionTextBox.Text);
            //Assert.LessThan(newendpos, endpos);
        }

        private void DataToolMessageBoxHandler(string WindowTitle)
        {
            //var MessageBox = dataToolsWindow.MessageBox(WindowTitle);
            //MessageBox.Close();
        }

        private void HandleFirstErrors()
        {
            DataToolMessageBoxHandler("Scaling Data Error");
            DataToolMessageBoxHandler("Scaling Data Error");
        }
    }
}
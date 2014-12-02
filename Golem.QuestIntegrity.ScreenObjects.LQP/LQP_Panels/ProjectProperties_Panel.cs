using System;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class ProjectProperties_Panel : BasePanel<ProjectProperties_Panel>
    {
        
        ////Components List
        //private static WhitePanel ProjectProperties_Pane = new WhitePanel(SearchCriteria.ByAutomationId("ProjectProperties")); 
        //private static WhitePanel Information_Panel = new WhitePanel(SearchCriteria.ByAutomationId("groupBox1"), ProjectProperties_Pane);
        ////Information panel items
        //public WhiteTextBox ProjectName_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("projectName"), Information_Panel); 
        //public WhiteTextBox ClientName_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("clientName"), Information_Panel);
        //public WhiteTextBox Description_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("description"), Information_Panel);
        //public WhiteTextBox Analyst_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("analyst"), Information_Panel);
        //public WhiteTextBox Engineer_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("engineer"), Information_Panel); 
        //public WhiteTextBox ApprovedBy_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("approvedBy"), Information_Panel);
        //public WhiteTextBox ProjectNumber_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("projectNumber"), Information_Panel);
        //public WhiteTextBox InspectionDate_tb = new WhiteTextBox(SearchCriteria.ByAutomationId("inspectionDate"), Information_Panel);
        //public WhiteComboBox ProjectStage_cb = new WhiteComboBox(SearchCriteria.ByAutomationId("projectStatus"), Information_Panel);
        //public WhiteLabel Filename_lbl = new WhiteLabel(SearchCriteria.ByAutomationId("fileName"), Information_Panel); 

        ////Attributes List
        //private static WhitePanel Attributes_Panel = new WhitePanel(SearchCriteria.ByAutomationId("groupBox2"), ProjectProperties_Pane);
        //public WhiteListItem DateCreated_li = new WhiteListItem(SearchCriteria.ByText("Date Created"), Attributes_Panel);
        //public WhiteListItem ProjectSize_li = new WhiteListItem(SearchCriteria.ByText("Project Size"), Attributes_Panel);
        //public WhiteListItem InspectionFiles = new WhiteListItem(SearchCriteria.ByText("Inspection Files"), Attributes_Panel); 
        //public WhiteListItem DataFile_li = new WhiteListItem(SearchCriteria.ByText("Data File"), Attributes_Panel);
        
        public ProjectProperties_Panel()
        {
            
        }

        //TODO: Create functions to read/write to each property

        public void EnterSomeText(String approvedby, String projectName, String clientName)
        {   
            //ApprovedBy_tb.Text = approvedby;
            //ProjectName_tb.Text = projectName;
            //ClientName_tb.Text = clientName;
        }

        //interface methods
        public override ProjectProperties_Panel MenuSelection(PurpleButton button)
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

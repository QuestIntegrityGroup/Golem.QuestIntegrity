using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class CrossSection_panel : BasePanel<CrossSection_panel>
    {
        
        //private static WhitePanel CrossSectionPanel = new WhitePanel(SearchCriteria.ByAutomationId("CrossSectionViewPane"));
        //public WhiteCheckBox Nominal_ckb = new WhiteCheckBox(SearchCriteria.ByAutomationId("displayOptions1"), CrossSectionPanel);
        //public WhiteCheckBox OuterWall_ckb = new WhiteCheckBox(SearchCriteria.ByAutomationId("displayOptions2"), CrossSectionPanel);
        //public WhiteCheckBox Points_ckb = new WhiteCheckBox(SearchCriteria.ByAutomationId("displayOptions3"), CrossSectionPanel);
        //public WhiteSpinner Exaggeration = new WhiteSpinner(SearchCriteria.ByAutomationId("spinner"), CrossSectionPanel);

        public override CrossSection_panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }

        public CrossSection_panel()
        {
           
        }


        
    }
}

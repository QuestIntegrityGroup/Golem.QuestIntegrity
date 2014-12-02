using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using ProtoTest.Golem.Purple.PurpleElements;
using ProtoTest.Golem.WebDriver.Elements.Types;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements
{
    internal class LQP_PurplePanel : PurplePanel
    {

        private string PanelPath;

        private string SelectedRow;

        public LQP_PurplePanel(string name, string locatorPath) : base(name, locatorPath)
        {

        }

        public void ClickOnRow(int position)
        {
            AutomationElement panel = PurpleElement;
            string ppath = PurplePath;
            AutomationElementCollection aec = panel.FindAll(TreeScope.Children, Condition.TrueCondition);
            AutomationElement clickOn = aec[position - 1];
            string path = aLocator.FindPurplePath(clickOn);

            PurpleButton pb = new PurpleButton("row button", path);
            pb.Click();
            PurpleTextBox ptb = new PurpleTextBox("row text", path);
            SelectedRow = ptb.Text;
        }

        public string GetSelectedRow()
        {
            return SelectedRow;
        }

       
    
    }
}


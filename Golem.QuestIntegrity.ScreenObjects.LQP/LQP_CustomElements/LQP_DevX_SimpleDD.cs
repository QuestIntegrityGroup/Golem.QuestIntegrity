using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements
{
    /// <summary>
    /// This Class is used for the DevExpress controls - because they're unique snowflakes
    /// </summary>
    public class LQP_DevX_SimpleDD : PurpleDropDown
    {
        public LQP_DevX_SimpleDD(string name, string locatorPath) : base(name, locatorPath)
        {
        }

        public void EnterText(string val)
        {
            if (!PurpleElement.Current.IsOffscreen)
            {
                _UIAElement.SetFocus();
                SendKeys.SendWait(val);
            }
        }

        public void EnterPartialText(string val)
        {
            if (!PurpleElement.Current.IsOffscreen)
            {
                _UIAElement.SetFocus();
                SendKeys.SendWait(val);
                List<AutomationElement> childlist = aLocator.GetChildren(_UIAElement);
                PurpleButton closeDD = new PurpleButton(ElementName + "Open-CloseBtn", childlist[1]);
                closeDD.Click();
            }
        }

        public new void SelectItem(string val)
        {
            EnterPartialText(val);
        }
    }
}

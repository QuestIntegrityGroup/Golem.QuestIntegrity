using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements
{
    /// <summary>
    /// The LQP_DevX_TextBox is based on the FilterData Panel - Criteria Section Textboxes - 3.2 - 10/13/2014
    /// </summary>
    public class LQP_DevX_TextBox : PurpleTextBox
    {
        //Children of the DevX_TextBox are the things that we can actually interact with
        //This object is based off the textboxes in the FilterData Panel - Criteria Section
        //If the TextBox is editable - there will be two children - The first child will have Text Pattern available
        //If the textbox is uneditable - there will be one child - The second child will have value pattern available
        private List<AutomationElement> childElements; 
        #region Constructors
        public LQP_DevX_TextBox(string name, string locatorPath) : base(name, locatorPath)
        {
            
        }

        public LQP_DevX_TextBox(string name, AutomationElement element) : base(name, element)
        {
            
        }
        #endregion

        public string Text
        {
            get
            {
                childElements = aLocator.GetChildren(PurpleElement);
                string value = "NOT FOUND!";
                if (PurpleElement != null)
                {
                    value = GetText();
                }
                return value;
            }
            set
            {
                childElements = aLocator.GetChildren(PurpleElement);
                if (PurpleElement != null)
                {
                    EnterText(value);
                }
            }
        }

        private string GetText()
        {
            string textValue = "THERE IS NO TEXT";
            if (_UIAElement.Current.IsPassword)
            {
                PurpleTestBase.LogEvent(string.Format("Field is {0} is a Password field, cannot get value", ElementName));
                textValue = "PASSWORD FIELD CANNOT BE READ";
            }
            object basePattern;
            if (childElements.First().TryGetCurrentPattern(ValuePattern.Pattern, out basePattern))
            {
                ValuePattern valuePattern = (BasePattern)basePattern as ValuePattern;
                if (valuePattern != null)
                {
                    textValue = valuePattern.Current.Value;
                }
                
            }
            return textValue;
        }

        private void EnterText(string value)
        {
            object basePattern;
            if (childElements.First().TryGetCurrentPattern(TextPattern.Pattern, out basePattern))
            {
                TextPattern textPattern = (BasePattern) basePattern as TextPattern;
                if (textPattern != null)
                {
                    //textPattern.DocumentRange.Select();
                }
                PurpleTextBox actualTextBox = new PurpleTextBox(ElementName, childElements.First());
                actualTextBox.Text = value;
                //SendKeys.SendWait(value);
            }
            else
            {
                PurpleTestBase.LogEvent(string.Format("DevX_TextBox {0} is not accepting new Text in it's current state", ElementName));
            }
        }


    }
}

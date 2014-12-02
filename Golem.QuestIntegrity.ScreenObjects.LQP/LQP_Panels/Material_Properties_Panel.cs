using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WindowsInput;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using NUnit.Framework;
using ProtoTest.Golem.Purple.PurpleElements;
using System.Windows.Automation;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class Material_Properties_Panel : BasePanel<Material_Properties_Panel>
    {
        /*  This panel is used for assigning material properties.  These affect calculations regarding Nominal thickness and other values
         * 
         * */
        private string _panelPath = "/LifeQuest™ Pipeline/panelContainer1/Material Properties/!BLANK!/Material Properties";
        private string PurplePanelPath;
        private LQP_PurplePanel panel;
        private string rowSelectedBefore;
        private string rowSelectedAfter;
        private string LocationStartPosBefore;
        private string LocationEndPosBefore;
        private string LocationStartPosAfter;
        private string LocationEndPosAfter;
        private string SmysBefore;
        private string SmtsBefore;
        private string SmysAfter;
        private string SmtsAfter;

        private PurpleTextBox LocationStartPosition_TextBox;
        private PurpleTextBox LocationEndPosition_TextBox;
        private PurpleTextBox Smys_TextBox;
        private PurpleTextBox Smts_TextBox;
        private PurpleCheckBox UseDefaultMaterialP_checkBox;


        public Material_Properties_Panel()
        {
            PurplePanelPath = _panelPath + "/InputBaseForm_LayoutControl/InputBaseForm_DataGrid";
            panel = new LQP_PurplePanel("Grid Panel", PurplePanelPath+"/Data Panel");
            LocationStartPosition_TextBox = new PurpleTextBox("Location Start Position TextBox", _panelPath + "/InputBaseForm_LayoutControl/InputBaseForm_DetailsScrollablePanel/InputBaseForm_GwSelector/StartEndFeatureSelector_LocationGroupBox/PipingSizeInput_StartPosition");
            LocationEndPosition_TextBox = new PurpleTextBox("Location End Position TextBox", _panelPath + "/InputBaseForm_LayoutControl/InputBaseForm_DetailsScrollablePanel/InputBaseForm_GwSelector/StartEndFeatureSelector_LocationGroupBox/PipingSizeInput_EndPosition");
            Smys_TextBox = new PurpleTextBox("Syms TextBox", _panelPath + "/InputBaseForm_LayoutControl/InputBaseForm_DetailsScrollablePanel/InputBaseForm_DetailsGroupControl/MaterialPropertiesInput_Smys");
            Smts_TextBox = new PurpleTextBox("Smts TextBox", _panelPath + "/InputBaseForm_LayoutControl/InputBaseForm_DetailsScrollablePanel/InputBaseForm_DetailsGroupControl/MaterialPropertiesInput_Smts");
            UseDefaultMaterialP_checkBox = new PurpleCheckBox("Use Default Material Properties CheckBox", _panelPath + "/InputBaseForm_LayoutControl/InputBaseForm_DetailsScrollablePanel/InputBaseForm_DetailsGroupControl/MaterialPropertiesInput_UseDefaultMaterialProperties");
        }

        

       /// <summary>
        /// Selects a row in the materials grid
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Material_Properties_Panel ClickOnRow(int pos)
        {
            panel.ClickOnRow(pos);
            return this;
        }

        /// <summary>
        /// Returns the current row selected before the change
        /// </summary>
        /// <returns></returns>
        public Material_Properties_Panel ReadMaterialValuesBefore()
        {
            rowSelectedBefore = panel.GetSelectedRow();
            LocationStartPosBefore = LocationStartPosition_TextBox.Text;
            LocationEndPosBefore = LocationEndPosition_TextBox.Text;
            bool selected = false;
            if (UseDefaultMaterialP_checkBox.IsElementToggledOn())
            {
                UseDefaultMaterialP_checkBox.Click();
                selected = true;
            }
            SmtsBefore = Smts_TextBox.Text;
            SmysBefore = Smys_TextBox.Text;
            if (selected)
            {
                UseDefaultMaterialP_checkBox.Click();
            }
            return this;
        }

        /// <summary>
        /// Returns the current row selected before the change
        /// </summary>
        /// <returns></returns>
        public Material_Properties_Panel ReadMaterialValuesAfter()
        {
            rowSelectedAfter = panel.GetSelectedRow();
            LocationStartPosAfter = LocationStartPosition_TextBox.Text;
            LocationEndPosAfter = LocationEndPosition_TextBox.Text;

            bool selected = false;
            if (UseDefaultMaterialP_checkBox.IsElementToggledOn())
            {
                UseDefaultMaterialP_checkBox.Click();
                selected = true;
            }
            SmtsAfter = Smts_TextBox.Text;
            SmysAfter = Smys_TextBox.Text;
            if (selected)
            {
                UseDefaultMaterialP_checkBox.Click();
            }
            return this;
        }

        /// <summary>
        /// This function compares the values from the grid and the detailed section to check if the values were properly converted
        /// when the units changes from imperial to metric
        /// </summary>
        /// <returns></returns>
        public Material_Properties_Panel CompareValuesAfterUnitChange(string systemFrom)
        {
            //TODO: This needs to be re-evalutated --Why are we converting doubles into strings for comparisons?  
            //Adapt values to the grid's values format and calculate conversions for comparison
            string LocationEndPosConverted;
            string LocationStartPosConverted;
            string SmysConverted = "NaN";
            string SmtsConverted = "NaN";
            string imperialFormat = "#,##0";
            string metricFormat = "#,##0.0";
            LocationEndPosBefore = Math.Round(Double.Parse(LocationEndPosBefore), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
            LocationEndPosAfter = Math.Round(Double.Parse(LocationEndPosAfter), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
            LocationStartPosBefore = Math.Round(Double.Parse(LocationStartPosBefore), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
            LocationStartPosAfter = Math.Round(Double.Parse(LocationStartPosAfter), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
            if (systemFrom.Equals(Constants.METRIC))
            {
                SmtsBefore = Math.Round(Double.Parse(SmtsBefore), 1, MidpointRounding.AwayFromZero).ToString(metricFormat);
                SmysBefore = Math.Round(Double.Parse(SmysBefore), 1, MidpointRounding.AwayFromZero).ToString(metricFormat);
                SmtsAfter = Math.Round(Double.Parse(SmtsAfter), 1, MidpointRounding.AwayFromZero).ToString(imperialFormat);
                SmysAfter = Math.Round(Double.Parse(SmysAfter), 1, MidpointRounding.AwayFromZero).ToString(imperialFormat);

                LocationEndPosConverted = Math.Round(UnitConversions.Length.MetersToFeet(Double.Parse(LocationEndPosBefore)), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
                LocationStartPosConverted = Math.Round(UnitConversions.Length.MetersToFeet(Double.Parse(LocationStartPosBefore)), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
                if (!SmysBefore.Equals("NaN"))
                {
                    SmysConverted = Math.Round(UnitConversions.Pressure.MPaIntoPSI(Double.Parse(SmysBefore)), 1, MidpointRounding.AwayFromZero).ToString(metricFormat);
                }
                if (!SmtsBefore.Equals("NaN"))
                {
                    SmtsConverted = Math.Round(UnitConversions.Pressure.MPaIntoPSI(Double.Parse(SmtsBefore)), 1, MidpointRounding.AwayFromZero).ToString(metricFormat);
                }
            }
            else
            {
                SmtsBefore = Math.Round(Double.Parse(SmtsBefore), 1, MidpointRounding.AwayFromZero).ToString(imperialFormat);
                SmysBefore = Math.Round(Double.Parse(SmysBefore), 1, MidpointRounding.AwayFromZero).ToString(imperialFormat);
                SmtsAfter = Math.Round(Double.Parse(SmtsAfter), 1, MidpointRounding.AwayFromZero).ToString(metricFormat);
                SmysAfter = Math.Round(Double.Parse(SmysAfter), 1, MidpointRounding.AwayFromZero).ToString(metricFormat);
                LocationEndPosConverted = Math.Round(UnitConversions.Length.FeetToMeters(Double.Parse(LocationEndPosBefore)), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
                LocationStartPosConverted = Math.Round(UnitConversions.Length.FeetToMeters(Double.Parse(LocationStartPosBefore)), 1, MidpointRounding.AwayFromZero).ToString("#,##0.0");
                if (!SmysBefore.Equals("NaN"))
                {
                    SmysConverted = Math.Round(UnitConversions.Pressure.PSIintoMegaPa(Double.Parse(SmysBefore)), 1, MidpointRounding.AwayFromZero).ToString(imperialFormat);
                }
                if (!SmtsBefore.Equals("NaN"))
                {
                    SmtsConverted = Math.Round(UnitConversions.Pressure.PSIintoMegaPa(Double.Parse(SmtsBefore)), 1, MidpointRounding.AwayFromZero).ToString(imperialFormat);
                }
            }

            //Expand rows
            string[] valuesBefore = rowSelectedBefore.Split(';');
            string[] valuesAfter = rowSelectedAfter.Split(';');
            int count = 0;
            foreach (string value in valuesBefore)
            {
                //Look for start position
                if (value.Equals(LocationStartPosBefore))
                {
                    Assert.AreEqual(Double.Parse(LocationStartPosConverted), Double.Parse(valuesAfter[count]));
                }
                //Look for end position
                if (value.Equals(LocationEndPosBefore))
                {
                    Assert.AreEqual(Double.Parse(LocationEndPosConverted), Double.Parse(valuesAfter[count]));
                }
                //Look for smys
                if (!SmysBefore.Equals("NaN") && value.Equals(SmysBefore))
                {
                    Assert.AreEqual(Double.Parse(SmysConverted), Double.Parse(valuesAfter[count]));
                }
                //Look for smts
                if (!SmtsBefore.Equals("NaN") && value.Equals(SmtsBefore))
                {
                    Assert.AreEqual(Double.Parse(SmtsConverted), Double.Parse(valuesAfter[count]));
                }

                count++;
            }


            return this;
        }
        //interface methods
        public override Material_Properties_Panel MenuSelection(PurpleButton button)
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

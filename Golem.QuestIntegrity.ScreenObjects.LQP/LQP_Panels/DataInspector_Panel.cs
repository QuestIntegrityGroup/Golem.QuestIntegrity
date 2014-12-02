using System;
using System.Collections.Generic;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using NUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class DataInspector_Panel : BasePanel<DataInspector_Panel>
    {
        /*  This class represents the Data Inspector Panel in its default state.
         *  Data can be extracted from this panel by selecting the the desired row and extracting the information
         */
        public double AxialPosition;
        private int SliceIndex;
        private string PercentLoss;
        private string CurrentUnitSystem;
        private double WallThickness;
        private double InsideRadius;
        private double NominalThickness;
        private double OutsideRadius;

        public Dictionary<string, TableRow> DataInspectorDict = new Dictionary<string,TableRow>();

        private string _panelPath;

        public int SliceInx{ get { return SliceIndex; }}
        private static List<DataInspectorValueContainer> InitialDIValues = new List<DataInspectorValueContainer>();
        private static List<DataInspectorValueContainer> ActualConvertedDIValues = new List<DataInspectorValueContainer>();
        private static List<DataInspectorValueContainer> ExpectedConvertedDIValues = new List<DataInspectorValueContainer>();
        private PurpleTable DataInspectorValues;
        private PurpleButton DataInspector_SearchButton;


        //TODO: need to add any logic specific to this panel and add any missing elements

        public DataInspector_Panel()
        {
            //This path is valid for the build releases
            //_panelPath = "/LifeQuest™ Pipeline/panelContainer2/Data Inspector/!BLANK!/Data Inspector/toolStripContainer1";
            //This path is valid for Michael's releases
            _panelPath = "/LifeQuest™ Pipeline/panelContainer2/Data Inspector/!BLANK!/Data Inspector/toolStripContainer1";
            DataInspectorValues = new PurpleTable("DataInspectorTable_DefaultView", _panelPath+"/!BLANK!/DataInspector_ViewSplit/ForceGrade:/DataInspector_ResultsListView");
            DataInspector_SearchButton = new PurpleButton("DataInspectorSearchButton", _panelPath + "/!BLANK!{1}/toolStrip1/DataInspector_ToggleSearchPanel");
    
        }

        public override DataInspector_Panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }

        public DataInspector_Search_Panel OpenSearchPanel()
        {
            DataInspector_SearchButton.Invoke();
            return new DataInspector_Search_Panel();
        }
        #region read values functions

        /// <summary>
        /// This function should replace all the individual retreieve data functions
        /// </summary>
        /// <returns>DataInspectorValueContainer</returns>
        public DataInspectorValueContainer GetDataValue(DIRow row)
        {
            DataInspectorValueContainer rowData = new DataInspectorValueContainer(DataInspectorValues.GetValue((int) row, 0),
                DataInspectorValues.GetValue((int) row, 1),
                DataInspectorValues.GetValue((int) row, 2));

            return rowData;
        }
         
        

        public double SelectAxialPosition_DefaultLayout()
        {
            //Data list headings are no counted in the array
            string text = DataInspectorValues.GetValue(0, 1);
            //now we need to remove any commas
            AxialPosition = double.Parse(text);
            return AxialPosition;
        }

        public MainScreen SelectSliceIndex_DefaultLayout()
        {
            string sliceIndex = DataInspectorValues.GetValue(7, 1);
            sliceIndex = sliceIndex.Replace(",", "");
            SliceIndex = int.Parse(sliceIndex);
            return new MainScreen();;
        }

        public MainScreen SelectPercentLoss_DefaultLayout()
        {
            PercentLoss = DataInspectorValues.GetValue(20, 1);
            return new MainScreen();
        }

        public void SelectOutsideRadius()
        {
            string outsideRad = DataInspectorValues.GetValue(17, 1);
            OutsideRadius = double.Parse(outsideRad);
        }

        public double SelectAxialPosition_FeatureDrawLayout()
        {
            //string value = dataListBox.Rows[1].Cells[1].Text;
            //AxialPosition = double.Parse(value);
            return AxialPosition;
        }
        #endregion

        public MainScreen VerifyPercentLoss(string Expected)
        {
            SelectPercentLoss_DefaultLayout();
            Assert.AreEqual(PercentLoss, Expected);
            return new MainScreen();
        }

        public List<double> InitialUnitValues()
        {
            SetInitialValues();
            //build the list just caring about the unit values
            List<double> initialValues = new List<double>();
            if (InitialDIValues.Count > 0)
            {
                for (int i = 0; i < InitialDIValues.Count; i++)
                {
                    initialValues.Add(InitialDIValues[i].Value);
                }
            }
            return initialValues;
        }

        public List<double> ConvertedValues()
        {
            if (InitialDIValues.Count > 0)
            {
                SetExpectedValues();
            }
            List<double> expectedValues = new List<double>();
            if (ExpectedConvertedDIValues.Count > 0)
            {
                for (int i = 0; i < ExpectedConvertedDIValues.Count; i++)
                {
                    expectedValues.Add(ExpectedConvertedDIValues[i].Value);
                }
            }
            return expectedValues;
        }

        //these functions are used to test unit conversion in data inspector
        public MainScreen SetInitialValues()
        {
            //we only want to retrieve that values for data items that can will be converted from one system to another
            if (InitialDIValues != null)
            {
                InitialDIValues.Clear();
                for (int i = 0; i < DataInspectorValues.RowCount; i++)
                {
                    //First check to make sure the unit is something we can convert -- we don't care about blanks or %
                    DataInspectorValueContainer checkUnit = new DataInspectorValueContainer(DataInspectorValues.GetValue(i, 0), DataInspectorValues.GetValue(i, 1), DataInspectorValues.GetValue(i, 2));
                    if (!checkUnit.Unit.Equals("") && !checkUnit.Unit.Equals("%"))
                    {
                        checkUnit.Index = i;
                        InitialDIValues.Add(checkUnit);
                    }
                }
            }
            else
            {
                InitialDIValues = new List<DataInspectorValueContainer>();
                SetInitialValues();
            }
            SetExpectedValues();
            return  new MainScreen();
        }

        public MainScreen SetActualValues()
        {
            //we only want to retrieve that values for data items that can will be converted from one system to another
            if (ActualConvertedDIValues != null)
            {
                ActualConvertedDIValues.Clear();
                for (int i = 0; i < DataInspectorValues.RowCount; i++)
                {
                    //First check to make sure the unit is something we can convert -- we don't care about blanks or %
                    DataInspectorValueContainer checkUnit = new DataInspectorValueContainer(DataInspectorValues.GetValue(i, 0), DataInspectorValues.GetValue(i, 1), DataInspectorValues.GetValue(i, 2));
                    if (!checkUnit.Unit.Equals("") && !checkUnit.Unit.Equals("%"))
                    {
                        checkUnit.Index = i;
                        ActualConvertedDIValues.Add(checkUnit);
                    }
                }
            }
            else
            {
                ActualConvertedDIValues = new List<DataInspectorValueContainer>();
                SetActualValues();
            }
            
            return new MainScreen();
        }

        private void SetExpectedValues()
        {
            if (InitialDIValues.Count > 0)
            {
                ExpectedConvertedDIValues.Clear();
                if (Constants.UnitSystem.Equals(Constants.METRIC))
                {
                    //convert over to imperial
                    for (int i = 0; i < InitialDIValues.Count; i++)
                    {
                        DataInspectorValueContainer convertedValue = InitialDIValues[i];
                        if (convertedValue.Unit.Equals(UnitConversions.Milimeters))
                        {
                            double mm = UnitConversions.Length.MMToInches(convertedValue.Value);
                            convertedValue.Value = mm;
                        }
                        if (convertedValue.Unit.Equals(UnitConversions.Meters))
                        {
                            double feet = UnitConversions.Length.MetersToFeet(convertedValue.Value);
                            convertedValue.Value = feet;
                        }
                        if (convertedValue.Unit.Equals(UnitConversions.MeterPerSecond))
                        {
                            double fps = UnitConversions.Velocity.MetersPSintoFeetPS(convertedValue.Value);
                            convertedValue.Value = fps;
                        }
                        if (convertedValue.Unit.Equals(UnitConversions.KPa))
                        {
                            double psi = UnitConversions.Pressure.KPaIntoPSI(convertedValue.Value);
                            convertedValue.Value = psi;
                        }
                        ExpectedConvertedDIValues.Add(convertedValue);
                    }
                }

                if (Constants.UnitSystem.Equals(Constants.IMPERIAL))
                {
                    //convert to metric
                    for (int i = 0; i < InitialDIValues.Count; i++)
                    {
                        DataInspectorValueContainer convertedValue = InitialDIValues[i];
                        if (convertedValue.Unit.Equals(UnitConversions.Inches))
                        {
                            double mm = UnitConversions.Length.InchesToMM(convertedValue.Value);
                            convertedValue.Value = mm;
                        }
                        if ((convertedValue.Unit.Equals(UnitConversions.Feet)) || (convertedValue.Unit.Equals(UnitConversions.Ft)))
                        {
                            double meters = UnitConversions.Length.FeetToMeters(convertedValue.Value);
                            convertedValue.Value = meters;
                        }
                        if (convertedValue.Unit.Equals(UnitConversions.FeetPerSecond))
                        {
                            double mps = UnitConversions.Velocity.FeetPSintoMetersPS(convertedValue.Value);
                            convertedValue.Value = mps;
                        }
                        if (convertedValue.Unit.Equals(UnitConversions.PSI))
                        {
                            double kpa = UnitConversions.Pressure.PSIintoKPA(convertedValue.Value);
                            convertedValue.Value = kpa;
                        }
                        ExpectedConvertedDIValues.Add(convertedValue);
                    }
                }
                if (Constants.UnitSystem.Equals("BLANK"))
                {
                    TestBase.Log("Unit system not initially set -- test might fail");
                }
            }
        }

        public MainScreen VerifyUnitConversions()
        {
            //make sure that the Expected and actual results list is populated
            if (ExpectedConvertedDIValues.Count > 0 && ActualConvertedDIValues.Count > 0)
            {
                Assert.AreEqual(ExpectedConvertedDIValues.Count, ActualConvertedDIValues.Count, "Verify the Expected Values list and Actual Values lists are the same size.");
                for (int i = 0; i < ExpectedConvertedDIValues.Count; i++)
                {
                    TestBase.Log(string.Format("Verify that {0} is converted properly into {1}", ExpectedConvertedDIValues[i].Name, Constants.UnitSystem));
                    decimal expected = (decimal) ExpectedConvertedDIValues[i].Value;
                    expected = Math.Round(expected, 2);
                    decimal actual = (decimal) ActualConvertedDIValues[i].Value;
                    actual = Math.Round(actual, 2);
                    Assert.AreEqual(decimal.Round(expected, 1), decimal.Round(actual, 1));
                }
            }

            return new MainScreen();
        }

        

        public Dictionary<string, TableRow> GetDataInspectorDictionary()
        {
            return DataInspectorDict;
        }

        public void CalculateDataInspectorDictionary()
        {
            DataInspectorDict = new Dictionary<string, TableRow>();
            int loopLimit = DataInspectorValues.RowCount;
            DataInspectorValues.EvaluatePattern();
            for (int count = 0; count < loopLimit; count++)
            {

                DataInspectorDict.Add(DataInspectorValues.GetValueNew(count, 0), new TableRow(DataInspectorValues.GetValueNew(count, 1), DataInspectorValues.GetValueNew(count, 2)));
            }
            /*
            To retrieve this information use:
            DataInspectorDict["Axial Position"]
            DataInspectorDict["Tool Velocity"]
            DataInspectorDict["Circ. Position (corrected)"]
            DataInspectorDict["Top Sensor Angle"]
            DataInspectorDict["Circ. Position (raw)"]
            DataInspectorDict["Pitch"]
            DataInspectorDict["Sensor Index"]
            DataInspectorDict["Slice Index"]
            DataInspectorDict["Orig. Slice Index"]
            DataInspectorDict["Data Point ID"]
            DataInspectorDict["Log Time"]
            DataInspectorDict["AGM Time"]
            DataInspectorDict["AGM Date"]
            DataInspectorDict["Wall Thickness"]
            DataInspectorDict["Inside Radius"]
            DataInspectorDict["Decentered Radius"]
            DataInspectorDict["Grade"]
            DataInspectorDict["RSF"]
            DataInspectorDict["RSF profile length"]
            DataInspectorDict["MAOPr"]
            DataInspectorDict["Outside Radius"]
            DataInspectorDict["Nominal Thickness"]
            DataInspectorDict["Nominal Inside Radius"]
            DataInspectorDict["Percent Loss"]
            DataInspectorDict["Absolute Loss"]
            DataInspectorDict["Percent Inside Loss"]
            DataInspectorDict["Inside Metal Loss"]
            DataInspectorDict["Dent Depth Percent"]
            DataInspectorDict["Absolute Dent Depth"]
            */
        }
       

    }
}

using System;
using System.Collections.Generic;
using NUnit.Framework;
using ProtoTest.Golem.Purple.PurpleElements;


namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class DataInspector_Search_Panel : BasePanel<DataInspector_Search_Panel>
    {
        private const string GeneralLocator =
            "/LifeQuest™ Pipeline/panelContainer2/Data Inspector/!BLANK!/Data Inspector/toolStripContainer1/!BLANK!/DataInspector_ViewSplit";
        private PurpleButton clearButton = new PurpleButton("ClearButton", "/LifeQuest™ Pipeline/panelContainer2/Data Inspector/!BLANK!/Data Inspector/toolStripContainer1/!BLANK!{1}/toolStrip1/DataInspector_ClearSelection");

        //Search Panel Toolstrip buttons
        private PurpleButton Recycle = new PurpleButton("RecycleButton", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_SynchronizeItem");
        private PurpleButton MoveFirst = new PurpleButton("MoveFirst", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_MoveFirst");
        private PurpleButton MoveNext = new PurpleButton("MoveNext", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_MoveNext");
        private PurpleButton MovePrevious = new PurpleButton("MovePrevious", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_MovePrevious");
        private PurpleButton MoveLast = new PurpleButton("MoveLast", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_MoveLast");
        private PurpleButton SaveTmm = new PurpleButton("SaveTmm", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_SaveTmmPoint");
        private PurpleButton NextJoint = new PurpleButton("NextJoint", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_NextItem");
        private PurpleButton PreviousJoint = new PurpleButton("PreviousJoint", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_PreviousItem");
        private PurpleTextBox SearchStatusLabel = new PurpleTextBox("SearchStatusLabel", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_SearchStatusLabel");
        private PurpleButton LockButton = new PurpleButton("LockButton", GeneralLocator + "/!BLANK!/DataInspector_DataMoveToolStrip/DataInspector_LockToggle");

        //This screen is opened through the regular data inspector 
        private PurpleDropDown selectionDown = new PurpleDropDown("SelectionDropDown", GeneralLocator + "/!BLANK!/DataInspector_CboSelection");
        private PurpleDropDown AvailableJoints = new PurpleDropDown("JointsDD", GeneralLocator + "/!BLANK!/DataInspector_CboSelectionList");
        private PurpleDropDown ThicknessDD = new PurpleDropDown("ThicknessDD", GeneralLocator + "/!BLANK!/DataInspector_CboNextThicknessOption");
        private PurpleTextBox ThicknessValue = new PurpleTextBox("ThicknessVal", GeneralLocator + "/!BLANK!/DataInspector_NextThicknessValue");
        private PurpleDropDown RadiusDD = new PurpleDropDown("RadiusDD", GeneralLocator + "/!BLANK!/DataInspector_CboNextRadiusOption");
        private PurpleTextBox RadiusValue = new PurpleTextBox("RadiusVal", GeneralLocator + "/!BLANK!/DataInspector_NextRadiusValue");
        private PurpleDropDown AdjPointsDD = new PurpleDropDown("AdjustmentPointsDD", GeneralLocator + "/!BLANK!/DataInspector_CboNextUseAdjacentPoints");
        private PurpleDropDown GradeDD = new PurpleDropDown("GradeDD", GeneralLocator + "/!BLANK!/DataInspector_CboNextQualityFactorOption");
        private PurpleTextBox GradeValue = new PurpleTextBox("GradeValue", GeneralLocator + "/!BLANK!/DataInspector_NextQualityFactorValue/DataInspector_NextQualityFactorValue");
        private PurpleDropDown ForceGrade = new PurpleDropDown("ForceGradeDD", GeneralLocator + "/!BLANK!/DataInspector_CboForceNextQualityFactorOption");
        private PurpleCheckBox ForceGrade_NaNsCB = new PurpleCheckBox("UseNaNs_Cb", GeneralLocator + "/!BLANK!/DataInspector_IncludeNans");
        private PurpleTextBox ForceGradeValue = new PurpleTextBox("ForceGradeVal", GeneralLocator + "/!BLANK!/DataInspector_NextForceQualityFactorValue/DataInspector_NextForceQualityFactorValue");
        
        //DataInspector Positions
        private PurpleTable DataInspectorValues = new PurpleTable("DataInspectorTable_SearchView", GeneralLocator + "/ForceGrade:/DataInspector_ResultsListView");
        private PurpleTable DataInspector_Position_DataPoint = new PurpleTable("DataPointID", GeneralLocator + "/ForceGrade:/DataInspector_ResultsListView/Position/Data Point ID");
        
        public DataInspector_Search_Panel()
        {
           
        }

        public DataInspector_Search_Panel InitiateTmmPickingUI()
        {
            SetAllDD_ValueNotUsed();
            Recycle.Click();
            return this;
        }

        private DataInspector_Search_Panel SetAllDD_ValueNotUsed()
        {
            string valueNotUsed = "Value not used";
            ThicknessDD.SelectItem(valueNotUsed);
            RadiusDD.SelectItem(valueNotUsed);
            AdjPointsDD.SelectItem("Not Used");
            GradeDD.SelectItem(valueNotUsed);
            
            return this;
        }

        public DataInspector_Search_Panel VerifyMoveButtons()
        {
            
            MoveFirst.Click();
            //Make sure that these things are being updated
            Assert.AreNotEqual(" ", SearchStatusLabel.Text);
            Assert.AreNotEqual(" ", DataInspectorValues.GetValue(9, 1)); //Data Point ID
            Assert.AreEqual(false, MovePrevious.IsEnabled());

            string CurrentDataPoint = DataInspectorValues.GetValue(9, 1);

            MoveNext.Click();
            MoveNext.Click();
            Assert.AreNotEqual(CurrentDataPoint, DataInspectorValues.GetValue(9, 1));
            CurrentDataPoint = DataInspectorValues.GetValue(9, 1);

            MovePrevious.Click();
            Assert.AreNotEqual(CurrentDataPoint, DataInspectorValues.GetValue(9, 1));
            CurrentDataPoint = DataInspectorValues.GetValue(9, 1);

            MoveLast.Click();
            Assert.AreNotEqual(CurrentDataPoint, DataInspectorValues.GetValue(9, 1));
            Assert.AreEqual(false, MoveNext.IsEnabled());

            return this;
        }

        public DataInspector_Search_Panel VerifyThickness(string thickness)
        {
            ThicknessDD.SelectItem("Next match above:");
            ThicknessValue.Text = thickness;
            MoveFirst.Invoke();
            string currentDataPoint = DataInspectorValues.GetValue(9, 1);
            Assert.AreNotEqual(" ", DataInspectorValues.GetValue(9, 1));
            
            MoveNext.Invoke();
            Assert.AreNotEqual(currentDataPoint, DataInspectorValues.GetValue(9, 1));
            currentDataPoint = DataInspectorValues.GetValue(9, 1);

            SaveTmm.Invoke();
            Assert.AreEqual(true, LockButton.IsEnabled());

            return this;
        }

        public DataInspector_Search_Panel VerifyRadius(string radius)
        {
            RadiusDD.SelectItem("Next match above:");
            RadiusValue.Text = radius;
            MoveFirst.Invoke();
            string currentDataPoint = DataInspectorValues.GetValue(10, 1);
            Assert.AreNotEqual(" ", currentDataPoint);

            MoveNext.Invoke();
            Assert.AreNotEqual(currentDataPoint, DataInspectorValues.GetValue(10, 1));
            SaveTmm.Invoke();
            Assert.AreEqual(true, LockButton.IsEnabled());

            return this;
        }

        public DataInspector_Search_Panel VerifyJointButtons()
        {
            NextJoint.Invoke();
            Assert.AreEqual(false, MovePrevious.IsEnabled());
            Assert.AreEqual(false, MoveNext.IsEnabled());
            Assert.AreEqual(false, MoveLast.IsEnabled());
            Assert.AreEqual(true, MoveFirst.IsEnabled());
            //We need to check here about material of the joints --Need a data set where each joint is a different material
            PreviousJoint.Invoke();
            Assert.AreEqual(false, MovePrevious.IsEnabled());
            Assert.AreEqual(false, MoveNext.IsEnabled());
            Assert.AreEqual(false, MoveLast.IsEnabled());
            Assert.AreEqual(true, MoveFirst.IsEnabled());

            return this;
        }

        public bool VerifyFeaturePresent(String featureName)
        {
            List<String> items = new List<string>();
            //for (int x = 0; x < SelectionList_cb.Items.Count; x++)
            //{
            //    SelectionList_cb.Select(x);
            //    items.Add(SelectionList_cb.SelectedItemText);
            //}
            bool Found = items.Contains(featureName);
            return Found;
        }

        public DataInspector_Search_Panel SetSelection(string selectionValue)
        {
            selectionDown.SelectItem(selectionValue);
            return this;

        }

        public DataInspector_Search_Panel SetJoint(string JointValue)
        {
            AvailableJoints.SelectItem(JointValue);
            return this;

        }

        //Interface Methods
        public override DataInspector_Search_Panel MenuSelection(PurpleButton button)
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

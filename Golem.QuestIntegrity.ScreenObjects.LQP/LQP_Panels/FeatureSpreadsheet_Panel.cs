using System;
using System.Collections.Generic;
using System.Threading;
using WindowsInput;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_CustomElements;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs;
using NUnit.Framework;
using ProtoTest.Golem.Purple.PurpleCore;
using ProtoTest.Golem.Purple.PurpleElements;
using System.Windows.Automation;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class FeatureSpreadsheet_Panel : BasePanel<FeatureSpreadsheet_Panel>
    {
        /*There should really be entire tests devoted to just this panel and other panels
         *  TODO: we need to find a way to determine if a feature has been selected or not when we start this screen
         */
        /*Data Storage for tests for now TODO: This needs to be put into a class*/
        private static string InitialFeatureLength;
        private static string InitialFeatureHeight;
        private static string InitialFeaturePosition;
        private static string CircumferentialExtent;
        private static int Max_RowID;

        //For using the panel data we have to manage the project name
        //Initializing elements based on the project name
        private static string _projectName = Constants.getProjectName();
        private static string _panelPath = "/LifeQuest™ Pipeline/DockPanel{1}/Features: " + _projectName + "/!BLANK!/Feature Spreadsheet";

        private static string _featureDetailsPath = _panelPath +
                                                    "/splitContainerControl1/Panel2/FeatureSpreadsheet_FeatureSpreadsheetTabbedPages/FeatureSpreadsheet_DetailsSection/FeatureSpreadsheet_FeatureSpreadsheetDetailsSectionUC/FeatureSpreadsheetDetailsSectionUC_FeatureSpreadsheetDetailsSectionLayoutControl";
        #region Variables
        private LQP_DevX_DataGrid FeatureSpreadsheetRows;
        //Menu navigation to open this panel
        #region Shortcut Buttons
        private PurpleButton DeleteSelectedFeature;
        private PurpleButton ExportToExcel_Button;

        #endregion

        #region Feature Details subpanel
        //Location and Size Group
        public PurpleTextBox SelectedFeatureLength;
        public PurpleTextBox SelectedFeatureHeight;
        public PurpleTextBox SelectedFeaturePosition;
        public PurpleTextBox SelectedFeatured_CircumferentialExtent;
        public PurpleTextBox FeatureLengthValue;
        public PurpleTextBox FeatureWidthValue;
        public PurpleTextBox FeatureLengthUnit;
        
        //Feature details form controls
        public PurpleTextBox FeatDetails_ID;
        public PurpleTextBox FeatDetails_Label;
        public PurpleTextBox FeatDetails_Type;
        public PurpleTextBox FeatDetails_Construction;
        public PurpleTextBox FeatDetails_Review;
        public PurpleTextBox FeatDetails_InternalComment;
        public PurpleTextBox FeatDetails_Notes;
        #endregion
        

        #endregion
        
        public FeatureSpreadsheet_Panel()
        {
            //Menu navigation to open this panel
            FeatureSpreadsheetRows = new LQP_DevX_DataGrid("spreadsheet rows", _panelPath + "/splitContainerControl1/Panel1/FeatureSpreadsheet_GridControl", "/scroll bar{1}", "/scroll bar");
            DeleteSelectedFeature = new PurpleButton("Delete Selected Feature Button", _panelPath+"/Dock Top/Feature Spreadsheet/FeatureSpreadsheet_DeleteFeature");
            ExportToExcel_Button = new PurpleButton("Export to Excel Button", _panelPath + "/Dock Top/Feature Spreadsheet/FeatureSpreadsheet_ExportToExcel");
            //The top DataGridView of the list of features on the pipe -- This was changed to a custom control in 2014.01.28
            //DataPanel is a custom element now
            
            //Location and Size Group
            SelectedFeatureLength = new PurpleTextBox("FeatureLength", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoLengthControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoLengthControl");
            SelectedFeatureHeight = new PurpleTextBox("Circumfrential Location", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoWidthControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoWidthControl");
            SelectedFeaturePosition = new PurpleTextBox("Feature Position Index", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoAbsolutePositionControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoAbsolutePositionControl");
            SelectedFeatured_CircumferentialExtent = new PurpleTextBox("Circumferenctial Extent", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoCircularExtentControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoCircularExtentControl");

            FeatureLengthValue = new PurpleTextBox("FeatureLengthInch", _panelPath + "/splitContainerControl1/Panel2/FeatureSpreadsheet_FeatureSpreadsheetTabbedPages/FeatureSpreadsheet_FeatureDetails/xtraScrollableControl1/FeatureSpreadsheet_LocationAndSizeGroup/FeatureSpreadsheet_Length");
            FeatureWidthValue = new PurpleTextBox("FeatureWidthInch", _panelPath + "/splitContainerControl1/Panel2/FeatureSpreadsheet_FeatureSpreadsheetTabbedPages/FeatureSpreadsheet_FeatureDetails/xtraScrollableControl1/FeatureSpreadsheet_LocationAndSizeGroup/FeatureSpreadsheet_Width");
            FeatureLengthUnit = new PurpleTextBox("FeatureLengthUnit", _panelPath + "/splitContainerControl1/Panel2/FeatureSpreadsheet_FeatureSpreadsheetTabbedPages/FeatureSpreadsheet_FeatureDetails/xtraScrollableControl1/FeatureSpreadsheet_LocationAndSizeGroup/FeatureSpreadsheet_LengthUnits");
            
            //Feature details controls
            FeatDetails_ID = new PurpleTextBox("FeatureDetail ID", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoIDControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoIDControl");
            FeatDetails_Label = new PurpleTextBox("FeatureDetail FD_Label", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoLabelControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoLabelControl");
            FeatDetails_Type = new PurpleTextBox("FeatureDetail Type", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoTypeControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoTypeControl");
            FeatDetails_Construction = new PurpleTextBox("FeatureDetail Construction", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoLocationOrConstructionControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoLocationOrConstructionControl");
            FeatDetails_Review = new PurpleTextBox("FeatureDetail Review", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoReviewFlagControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoReviewFlagControl");
            FeatDetails_InternalComment = new PurpleTextBox("FeatureDetail Internal Content", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoInternalCommentControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoInternalCommentControl");
            FeatDetails_Notes = new PurpleTextBox("FeatureDetail Notes", _featureDetailsPath + "/FeatureSpreadsheetDetailsSectionUC_FeatureInfoNotesControl/FeatureSpreadsheetDetailsSectionUC_FeatureInfoNotesControl");
            
        }
        
        public void Verify360DegreeFeatures()
        {
            //This is duplicating row IDs in the lsit
            List<int> CircularRowIDS = FeatureSpreadsheetRows.Get360DegreeFeatures();
            for (int i = 0; i < CircularRowIDS.Count; i++)
            {
                FeatureSpreadsheetRows.SelectRow(CircularRowIDS[i]);
                if (SelectedFeatured_CircumferentialExtent.Text != "360.0")
                {
                    Assert.Fail("Found 360 Degree feature type with ID: " + CircularRowIDS[i] + " with a Circumferential Extent not equal to 360 degrees. Feature is reported as " + SelectedFeatured_CircumferentialExtent.Text + " Degrees");
                }
            }
        }
        
        public FeatureSpreadsheet_Panel SelectFeature(int row = 0, string featureType = "blank")
        {
            if (featureType == "blank")
            {
                FeatureSpreadsheetRows.SelectRow(row);
            }
            else
            {
                row = 3; //This forces the control to look for feature type
                FeatureSpreadsheetRows.SelectRow(row, featureType);
            }
            return this;
        }
        
        /// <summary>
        /// Selects a specific row from the Grid
        /// </summary>
        /// <param name="id">The zero index based ID of the Row (ID-1)</param>
        /// <returns></returns>
        public FeatureSpreadsheet_Panel SelectFeatureSpreadsheetRow(int id)
        {
            FeatureSpreadsheetRows.SelectRow(id);
            return this;
        }
        /// <summary>
        /// Deletes a specific feature row
        /// </summary>
        /// <param name="id">The zero index based ID of the Row (ID-1)</param>
        /// <returns></returns>
        public FeatureSpreadsheet_Panel DeleteFeatureSpreadsheetRow(int id)
        {
            FeatureSpreadsheetRows.SelectRow(id);
            DeleteSelectedFeature.Click();
            return this;
        }
        
        #region Change Feature values

        public FeatureSpreadsheet_Panel ChangeXScale()
        {
            int initialflength = int.Parse(InitialFeatureLength);
            PurpleButton FeatureResizeSmaller = new PurpleButton("FeatureResizeSmaller", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureGrowShorter");
            FeatureResizeSmaller.Invoke();
            int newLength = int.Parse(SelectedFeatureLength.Text);
            Assert.Less(newLength, initialflength);

            PurpleButton FeatureResizeBigger = new PurpleButton("FeatureResizeBigger", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureGrowLonger");
            FeatureResizeBigger.Invoke();
            newLength = int.Parse(SelectedFeatureLength.Text);
            Assert.AreEqual(newLength, initialflength);
            //VK_MENU = Alt
            PurpleWindow.HoldKey(VirtualKeyCode.MENU);
            PurpleWindow.PressKey(VirtualKeyCode.RIGHT);
            PurpleWindow.ReleaseKey(VirtualKeyCode.MENU);
            newLength = int.Parse(SelectedFeatureLength.Text);
            Assert.Greater(newLength, initialflength);

            PurpleWindow.HoldKey(VirtualKeyCode.MENU);
            PurpleWindow.PressKey(VirtualKeyCode.LEFT);
            PurpleWindow.ReleaseKey(VirtualKeyCode.MENU);
            newLength = int.Parse(SelectedFeatureLength.Text);
            Assert.AreEqual(newLength, initialflength);
            return this;
        }

        public FeatureSpreadsheet_Panel ChangeYScale()
        {
            int initialfHeight = int.Parse(InitialFeatureHeight);
            PurpleButton FeatureResizeWider = new PurpleButton("FeatureResizeWider", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureGrowWider");
            FeatureResizeWider.Invoke();
            int newHeight = int.Parse(SelectedFeatureHeight.Text);
            Assert.Greater(newHeight, initialfHeight);

            PurpleButton FeatureResizeNarrower = new PurpleButton("FeatureResizeNarrow", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureGrowNarrower");
            FeatureResizeNarrower.Invoke();
            newHeight = int.Parse(SelectedFeatureHeight.Text);
            Assert.AreEqual(newHeight, initialfHeight);

            PurpleWindow.HoldKey(VirtualKeyCode.MENU);
            PurpleWindow.PressKey(VirtualKeyCode.DOWN);
            PurpleWindow.ReleaseKey(VirtualKeyCode.MENU);
            newHeight = int.Parse(SelectedFeatureHeight.Text);
            Assert.Greater(newHeight, initialfHeight);

            PurpleWindow.HoldKey(VirtualKeyCode.MENU);
            PurpleWindow.PressKey(VirtualKeyCode.UP);
            PurpleWindow.ReleaseKey(VirtualKeyCode.MENU);
            newHeight = int.Parse(SelectedFeatureHeight.Text);
            Assert.AreEqual(newHeight, initialfHeight);
            return this;
        }

        public FeatureSpreadsheet_Panel ChangeNudgeXScale()
        {
            int initialfPosition = int.Parse(InitialFeaturePosition);
            PurpleButton FeatureResizeLeft = new PurpleButton("FeatureResizeMoveLeft", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureNudgeLeft");
            FeatureResizeLeft.Invoke();
            int newPosition = int.Parse(SelectedFeaturePosition.Text);
            Assert.Less(newPosition, initialfPosition);

            PurpleButton FeatureResizeRight = new PurpleButton("FeatureReszieMoveRight", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureNudgeRight");
            FeatureResizeRight.Invoke();
            newPosition = int.Parse(SelectedFeaturePosition.Text);
            Assert.AreEqual(newPosition, initialfPosition);

            PurpleWindow.HoldKey(VirtualKeyCode.CONTROL);
            PurpleWindow.PressKey(VirtualKeyCode.LEFT);
            PurpleWindow.ReleaseKey(VirtualKeyCode.CONTROL);
            newPosition = int.Parse(SelectedFeaturePosition.Text);
            Assert.Less(newPosition, initialfPosition);

            PurpleWindow.HoldKey(VirtualKeyCode.CONTROL);
            PurpleWindow.PressKey(VirtualKeyCode.RIGHT);
            PurpleWindow.ReleaseKey(VirtualKeyCode.CONTROL);
            newPosition = int.Parse(SelectedFeaturePosition.Text);
            Assert.AreEqual(newPosition, initialfPosition);
            return this;
        }
        
        public FeatureSpreadsheet_Panel ChangeNudgeYScale()
        {
            int initialfLocation = int.Parse(InitialFeatureHeight);
            PurpleButton FeatureResizeUp = new PurpleButton("FeatureResizeMoveUp", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureNudgeUp");
            FeatureResizeUp.Invoke();
            int newLocation = int.Parse(SelectedFeatureHeight.Text);
            Assert.Greater(newLocation, initialfLocation);

            PurpleButton FeatureResizeDown = new PurpleButton("FeatureResizeMoveDown", "/LifeQuest™ Pipeline/Dock Top/Main Menu/Main_MenuFeatures/Main_MenuFeatureResizeFeatures/Main_MenuFeatureNudgeDown");
            FeatureResizeDown.Invoke();
            newLocation = int.Parse(SelectedFeatureHeight.Text);
            Assert.AreEqual(newLocation, initialfLocation);

            PurpleWindow.HoldKey(VirtualKeyCode.CONTROL);
            PurpleWindow.PressKey(VirtualKeyCode.UP);
            PurpleWindow.ReleaseKey(VirtualKeyCode.CONTROL);
            newLocation = int.Parse(SelectedFeatureHeight.Text);
            Assert.Greater(newLocation, initialfLocation);

            PurpleWindow.HoldKey(VirtualKeyCode.CONTROL);
            PurpleWindow.PressKey(VirtualKeyCode.DOWN);
            PurpleWindow.ReleaseKey(VirtualKeyCode.CONTROL);
            newLocation = int.Parse(SelectedFeatureHeight.Text);
            Assert.AreEqual(newLocation, initialfLocation);
            return this;
        }
        
        public void DeleteFeature()
        {
            //need to check here to make sure the feature was actually deleted somehow
            //it's unlikely that the label AND absolute position would be the same with a row that was deleted and the next selected row
            string label = FeatDetails_Label.Text;
            string position = SelectedFeaturePosition.Text;
            DeleteSelectedFeature.MoveCursor(DeleteSelectedFeature.Bounds.Center());
            DeleteSelectedFeature.Click();
            DeleteSelectedFeature.Click();
            //When a row is deleted, a new row is selected
            string newlabel = FeatDetails_Label.Text;
            string newpos = SelectedFeaturePosition.Text;
            Assert.AreNotEqual(label, newlabel);
            Assert.AreNotEqual(position, newpos);
        }
        #endregion

        #region Export To Excel Handling
        public ExportExcelTemplateOption_Dialog ClickExportExcel()
        {
            ExportToExcel_Button.Click();
            return new ExportExcelTemplateOption_Dialog();
        }

        public bool VerifyExportExcelWarningWindow()
        {
            ExportExcelWarning_Dialog window = new ExportExcelWarning_Dialog();
            return window.VerifyWindowPresent();
        }

        public MainScreen ConfirmExportExcelWarningWindow(bool action)
        {
            ExportExcelWarning_Dialog window = new ExportExcelWarning_Dialog();
            if (action)
            {
                window.ClickYes();
            }
            else
            {
                window.ClickNo();
            }
            return new MainScreen();
        }

        public MainScreen ExportExcelSaveFile(string filename)
        {
            SaveAsExcel_Dialog saveDialog = new SaveAsExcel_Dialog();
            saveDialog.SaveFile(filename);
            return new MainScreen();

        }
        #endregion

        #region ParentFunctions
        public override FeatureSpreadsheet_Panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }
        #endregion
    }
}

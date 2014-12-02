using Gallio.Model.Filters;
using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels;
using NUnit.Framework;
using ProtoTest.Golem.Purple;

namespace Golem.QuestIntegrity.Tests.LQP
{
    class LQP_FilteringSpecific : PurpleTestBase
    {

        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }
        
        public void SetInitialValues()
        {
            //Pipe2D_Panel.SetUpPanel(ProjectFileName);
            FilterData_Panel.replaceDecenteredRadius = "0.123";
            FilterData_Panel.replaceInsideRadius = "0.123";
            FilterData_Panel.replaceWallThickness = "1.000";
            FilterData_Panel.replaceByPercentValue = "300"; //Expressed as %
        }


        
        [Test]
        [Category("Filtering")]
        public void LQP_0001_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Wall thickness, greater than; Replacement values: specified values
            string filterType = "Wall Thickness";
            bool greater = true;

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFilterDataPanel()
                .SwitchToJoint(15)
                .GoToMain()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(15)
                .Criteria_ThicknessGT(true, WtBeforeValue.Value.ToString())
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);


            //SplashScreen.StartOnSplash()
            //.CloseSplashScreen()
            //.OpenProject()
            //.Use2DPipe()
            //.ClickIntoPipe()
            //.UseFilterDataPanel()
            //.SwitchToJoint(15)
            //.GetValuesBeforeFilter(filterType)
            //.FilterSetConstrainTo_WT(greater)
            //.ChangeReplaceValuesBySpecifiedValue_WT()
            //.ApplyFilter()
            //.GetValuesAfterFilter()
            //.CompareValues(filterType, greater)
            //;
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0002_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Wall thickness, less than; Replacement values: specified values
            string filterType = "Wall Thickness";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(16)
            .GetValuesBeforeFilter(filterType)
            .Criteria_ThicknessGT(greater)
            .ChangeReplaceValuesBySpecifiedValue_WT()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValues(filterType,greater);
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0003_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Inside Radius, greater than; Replacement values: specified values
            string filterType = "Inside Radius";
            bool greater = true;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(15)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_IR(greater)
            .ChangeReplaceValuesBySpecifiedValue_IR()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValues(filterType, greater);
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0004_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Inside Radius, less than; Replacement values: specified values
            string filterType = "Inside Radius";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(16)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_IR(greater)
            .ChangeReplaceValuesBySpecifiedValue_IR()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValues(filterType, greater);
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0005_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Decentered Radius, greater than; Replacement values: specified values
            string filterType = "Decentered Radius";
            bool greater = true;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(15)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_DR(greater)
            .ChangeReplaceValuesBySpecifiedValue_DR()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValues(filterType, greater);
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0006_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Decentered Radius, less than; Replacement values: specified values
            string filterType = "Decentered Radius";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(16)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_DR(greater)
            .ChangeReplaceValuesBySpecifiedValue_DR()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValues(filterType, greater)
            ;
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0007_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Wall Thickness, less than; Replacement values: percentage
            string filterType = "Wall Thickness";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(14)
            .GetValuesBeforeFilter(filterType)
            .Criteria_ThicknessGT(greater)
            .ChangeReplaceValuesByPercentage_WT()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValuesPercentage(filterType, greater)
            ;
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0008_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Inside Radius, less than; Replacement values: percentage
            string filterType = "Inside Radius";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(14)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_IR(greater)
            .ChangeReplaceValuesByPercentage_IR()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValuesPercentage(filterType, greater)
            ;
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0009_FogBugz5627_5629()
        {
            //Selection: Joint
            //Constraint to: Decentered Radius, less than; Replacement values: percentage
            string filterType = "Decentered Radius";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(14)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_DR(greater)
            .ChangeReplaceValuesByPercentage_DR()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValuesPercentage(filterType, greater)
            ;
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0010_FogBugz5627_5629()
        {
            //Selection: Range
            //Constraint to: Decentered Radius, less than; Replacement values: percentage
            string filterType = "Decentered Radius";
            bool greater = false;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(12)
            .SwitchToRange(12,13)
            .GetValuesBeforeFilter(filterType)
            .FilterSetConstrainTo_DR(greater)
            .ChangeReplaceValuesByPercentage_DR()
            .ApplyFilter(true, 60000) // This fuction has to sleep because a time out problem after applying the filter. This sleep time varies according to the range to filter
            .GetValuesAfterFilter()
            .CompareValuesPercentage(filterType, greater)
            ;
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0011_FogBugz5630_UndoFilter()
        {
            //Constraint to: Wall thickness, greater than; Replacement values: specified values
            string filterType = "Wall Thickness";
            bool greater = true;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(11)
            .GetValuesBeforeFilter(filterType)
            .Criteria_ThicknessGT(greater)
            .ChangeReplaceValuesBySpecifiedValue_WT()
            .ApplyFilter()
            .GetValuesAfterFilter()
            .CompareValues(filterType, greater)
            .UndoLastFilter()
            .GetValuesAfterFilter()
            .CompareUndoneOrCancelledValues(filterType, greater)
            ;
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0012_FogBugz5630_CancelFilter()
        {
            //Constraint to: Wall thickness, greater than; Replacement values: specified values
            string filterType = "Wall Thickness";
            bool greater = true;

            SetInitialValues();
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseFilterDataPanel()
            .SwitchToJoint(11)
            .GetValuesBeforeFilter(filterType)
            .Criteria_ThicknessGT(greater)
            .ChangeReplaceValuesBySpecifiedValue_WT()
            .CancelFilter()
            .GetValuesAfterFilter()
            .CompareUndoneOrCancelledValues(filterType, greater)
            ;
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0013_FilterData_Joint()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectSliceIndex_DefaultLayout()
                .UseFilterDataPanel()
                .TestJoint();
        }
    }
}

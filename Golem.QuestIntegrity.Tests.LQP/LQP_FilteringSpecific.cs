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
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);

        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0002_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Wall thickness, less than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .GoToMain()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .Criteria_ThicknessGT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);

        }

        [Test]
        [Category("Filtering")]
        public void LQP_0003_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Inside Radius, greater than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFilterDataPanel()
                .SwitchToJoint(15)
                .GoToMain()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .GetDataValue(DIRow.InsideRadius);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(15)
                .Criteria_RadiusGT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.InsideRadius);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);

        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0004_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Inside Radius, less than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .GoToMain()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .GetDataValue(DIRow.InsideRadius);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .Criteria_RadiusLT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.InsideRadius);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);

        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0005_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Decentered Radius, greater than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFilterDataPanel()
                .SwitchToJoint(15)
                .GoToMain()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .GetDataValue(DIRow.DecenteredRadius);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(15)
                .Criteria_DRadiusGT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.DecenteredRadius);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);
        }
        
        [Test]
        [Category("Filtering")]
        public void LQP_0006_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Decentered Radius, less than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .GoToMain()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .GetDataValue(DIRow.DecenteredRadius);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .Criteria_DRadiusLT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.DecenteredRadius);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0007_FogBugz5637_5629()
        {
            //Selection: Joint
            //Constraint to: Wall Thickness, less than; Replacement values: percentage

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                           .CloseSplashScreen()
                           .OpenProject()
                           .UseFilterDataPanel()
                           .SwitchToJoint(16)
                           .GoToMain()
                           .Use2DPipe()
                           .ClickIntoPipe()
                           .UseDataInspector()
                           .GetDataValue(DIRow.WallThickness);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .Criteria_ThicknessLT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            Assert.AreNotEqual(WtBeforeValue.Value, WtAftervalue.Value);
            
        }
        
        
        [Test]
        [Category("Filtering")]
        public void LQP_0011_FogBugz5630_UndoFilter()
        {
            //Constraint to: Wall thickness, greater than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                          .CloseSplashScreen()
                          .OpenProject()
                          .UseFilterDataPanel()
                          .SwitchToJoint(16)
                          .GoToMain()
                          .Use2DPipe()
                          .ClickIntoPipe()
                          .UseDataInspector()
                          .GetDataValue(DIRow.WallThickness);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .Criteria_ThicknessLT(true, WtBeforeValue.Value.ToString())
                .ApplyFilter()
                .GoToMain()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            DataInspectorValueContainer RevertedValue = MainScreen.StartOnMain()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            Assert.AreEqual(WtBeforeValue.Value, RevertedValue.Value);

           
        }

        [Test]
        [Category("Filtering")]
        public void LQP_0012_FogBugz5630_CancelFilter()
        {
            //Constraint to: Wall thickness, greater than; Replacement values: specified values

            DataInspectorValueContainer WtBeforeValue = SplashScreen.StartOnSplash()
                          .CloseSplashScreen()
                          .OpenProject()
                          .UseFilterDataPanel()
                          .SwitchToJoint(16)
                          .GoToMain()
                          .Use2DPipe()
                          .ClickIntoPipe()
                          .UseDataInspector()
                          .GetDataValue(DIRow.WallThickness);

            DataInspectorValueContainer WtAftervalue = MainScreen.StartOnMain()
                .UseFilterDataPanel()
                .SwitchToJoint(16)
                .Criteria_ThicknessLT(true, WtBeforeValue.Value.ToString())
                .CancelFilter()
                .UseDataInspector()
                .GetDataValue(DIRow.WallThickness);

            Assert.AreEqual(WtBeforeValue.Value, WtAftervalue.Value);
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

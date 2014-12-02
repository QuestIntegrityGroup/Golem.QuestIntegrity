using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using NUnit.Framework;
using ProtoTest.Golem.Purple;

namespace Golem.QuestIntegrity.Tests.LQP
{
    public class LQP_Performance : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }

        [Test]
        [Category("Performance")]
        public void LQP_18_ResizingFeatures()
        {
            //This test corresponds to Case:5255
            //Preconditions: This test requires that a feature of a known type be present on the pipe first.  Run test LQP_MenuItems.LQP_33_InsertingConstructionFeatures() or similar first
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseFeatureSpreadsheet()
                .SelectFeature(0, PipeFeatures.Anomaly.ExternalWallLoss.FeatureType)
                .ChangeXScale()
                .ChangeYScale()
                .ChangeNudgeXScale()
                .ChangeNudgeYScale();
        }

        [Test]
        [Category("Performance")]
        public void LQP_00_AddingDataFile()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .AddDataFile(TestFileLocation);
        }

        [Test]
        [Category("Performance")]
        public void Case_5632_TmmPickingMaterial()
        {
            PerfLogging = true;
            string JointMaterialA = "GW110 - GW120";
            string JointMaterialB = "GW120 - GW130";
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseDataInspector()
                .OpenSearchPanel()
                .InitiateTmmPickingUI()
                .SetSelection("Joints")
                .SetJoint(JointMaterialA)
                .VerifyThickness("7.0")
                .SetJoint(JointMaterialB)
                .VerifyThickness("8.0");
        }
       


    }
}

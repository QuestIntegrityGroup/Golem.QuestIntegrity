using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels;
using NUnit.Framework;
using ProtoTest.Golem.Purple;


namespace Golem.QuestIntegrity.Tests.LQP.LQP_PanelTests
{
    public class DataInspector_Tests : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }
        [Test]
        [Category("DataInspector")]
        public void Case_5632_TmmPickingMaterial()
        {
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

        [Test]
        [Category("DataInspector")]
        public void Case_5633_TmmPickingThicknessAndRadius_Joints()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseDataInspector()
                .OpenSearchPanel()
                .InitiateTmmPickingUI()
                .SetSelection("Joints")
                .VerifyThickness("7.0")
                .VerifyRadius("100.0");
        }
        [Test]
        [Category("DataInspector")]
        public void Case_5633_TmmPickingThicknessAndRadius_JointsWithAnomolies()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseDataInspector()
                .OpenSearchPanel()
                .InitiateTmmPickingUI()
                .SetSelection("Joints w/Anomalies")
                .VerifyThickness("7.0")
                .VerifyRadius("100.0");
        }
       

    }
}

using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using NUnit.Framework;
using ProtoTest.Golem.Purple;

namespace Golem.QuestIntegrity.Tests.LQP.LQP_PanelTests
{
    public class LQP_2DPipe : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }

        [Test]
        [Category("2DPipe")]
        public void LQP_001_KeyBoardScroll_Right()
        {
            double position1 = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            double position2 = MainScreen.StartOnMain()
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            Assert.Greater(position2, position1);
        }
        [Test]
        [Category("2DPipe")]
        public void LQP_002_KeyBoardScroll_Left()
        {
            double position1 = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            double position2 = MainScreen.StartOnMain()
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionLEFT)
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            Assert.Less(position2, position1);
        }

        [Test]
        [Category("2DPipe")]
        public void LQP_003_MouseScroll_Right()
        {
            double position1 = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            double position2 = MainScreen.StartOnMain()
                .Use2DPipe()
                .Mouse_ScrollPipe(Constants.DirectionRIGHT)
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            Assert.Greater(position2, position1);
        }
        [Test]
        [Category("2DPipe")]
        public void LQP_004_MouseScroll_Left()
        {
            double position1 = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            double position2 = MainScreen.StartOnMain()
                .Use2DPipe()
                .Mouse_ScrollPipe(Constants.DirectionLEFT)
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectAxialPosition_DefaultLayout();

            Assert.Less(position2, position1);
        }
        [Test]
        [Category("2DPipe")]
        public void LQP_33_InsertingConstructionFeatures()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .SelectFeature(PipeFeatures.Construction.Unknown)
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .UseFeatureSpreadsheet()
                .SelectFeature(0, PipeFeatures.Construction.Unknown.FeatureType);
        }

        [Test]
        [Category("2DPipe")]
        public void LQP_33_InsertingAnomolyFeatures()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFeatureSpreadsheet()
                .GoToMain()
                .SelectFeature(PipeFeatures.Anomaly.Blister)
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .UseFeatureSpreadsheet()
                .SelectFeature(0, PipeFeatures.Anomaly.Blister.FeatureType);

            //.SelectFeature(0, PipeFeatures.Anomaly.Blister.FeatureType, true);
        }

        [Test]
        [Category("2DPipe")]
        public void LQP_33_InsertingOtherFeatures()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFeatureSpreadsheet()
                .GoToMain()
                .SelectFeature(PipeFeatures.Other.Air)
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .UseFeatureSpreadsheet()
                .SelectFeature(0, PipeFeatures.Other.Air.FeatureType);
        }
    }
}

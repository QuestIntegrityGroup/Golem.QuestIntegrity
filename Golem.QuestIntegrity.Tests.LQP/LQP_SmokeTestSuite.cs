using System;
using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels;
using NUnit.Framework;
using ProtoTest.Golem.Purple;

namespace Golem.QuestIntegrity.Tests.LQP
{
    public class LQP_SmokeTestSuite : PurpleTestBase
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
        [Category("SmokeTests")]
        public void LQP_0001_OpenApplication()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen();
        }

        [Test]
        [Category("SmokeTests")]
        public void LQP_0002_AddandRemoveFeature()
        {
            double position1 = 
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
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

            MainScreen.StartOnMain()
                .UseFeatureSpreadsheet()
                .MenuSelection(MainMenu.Features.FeatureType.SelectFeature(PipeFeatures.UseRandomConstructionFeature()))
                .GoToMain()
                .Use2DPipe()
                .DrawFeature(20.00, 20.00)
                .UseFeatureSpreadsheet()
                .DeleteFeature();
        }

        
        [Test]
        [Category("SmokeTests")]
        public void LQP_0003_FilterData()
        {
            
            SplashScreen.StartOnSplash()
            .CloseSplashScreen()
            .OpenProject(TestFileLocation)
            .Use2DPipe()
            .ClickIntoPipe()
            .UseDataInspector()
            .SelectSliceIndex_DefaultLayout()
            .UseFilterDataPanel()
            .TestQuickFilter()
            .Use2DPipe()
            .ClickIntoPipe()
            .UseDataInspector()
            .VerifyPercentLoss("NaN");
        }

        [Test]
        [Category("SmokeTests")]
        public void LQP_0005_TmmPicking()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseDataInspector()
                .OpenSearchPanel()
                .InitiateTmmPickingUI()
                .VerifyMoveButtons()
                .VerifyJointButtons();
        }

        [Test]
        [Category("SmokeTests")]
        public void LQP_0004_FilterData_FormControls()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SelectSliceIndex_DefaultLayout()
                .UseFilterDataPanel()
                .TestConstrainToControls() // This is for Constrain to
                .TestApplyToControls() // This is for Apply To
                .TestReplacementValuesControls(); // This is for Replacement values
                
        }

        [Test]
        [Category("SmokeTests")]
        public void LQP_0006_TestAxialCharControls()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseAxialChart()
                .TestAllControls();
        }

        [Test]
        [Category("SmokeTests")]
        public void LQP_0007_InsertingConstructionFeatures()
        {
            string featureDetailLabel = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseFeatureSpreadsheet()
                .MenuSelection(MainMenu.Features.FeatureType.SelectFeature(PipeFeatures.Construction.Unknown))
                .GoToMain()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .UseFeatureSpreadsheet()
                .FeatDetails_Type.Text;

            Assert.AreEqual(PipeFeatures.Construction.Unknown.FeatureType, featureDetailLabel);
        }

    }
}

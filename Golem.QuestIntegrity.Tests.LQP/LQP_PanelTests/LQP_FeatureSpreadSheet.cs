using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using NUnit.Framework;
using ProtoTest.Golem.Purple;

namespace Golem.QuestIntegrity.Tests.LQP.LQP_PanelTests
{
    public class LQP_FeatureSpreadSheet : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }

        [Test]
        public void foo()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFeatureSpreadsheet()
                .SelectFeatureSpreadsheetRow(6);
        }
        
        [Test]
        [Category("FeatureSpreadsheet")]
        public void FS_001_LQP_20_360DegreePipeFeatures()
        {       
            //Preconditions: This test works on a clean data set.

            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .SelectFeature(PipeFeatures.Construction.Bend)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.BendStart)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.BendEnd)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.CheckValve)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.Equation)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.ExternalWeldCirc)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.Flange)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.GirthWeld)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Construction.ValveCirc)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .SelectFromMenu(MainMenu.File.SaveAll);
        }

        [Test]
        [Category("FeatureSpreadsheet")]
        public void FS_002_LQP_AddAllAnomolyFeatures()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseNavigationPanel()
                .GoToBeginingofPipe()
                .SelectFeature(PipeFeatures.Anomaly.Blister)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Buckle)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Bulge)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Dent)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.DentWithMetalLoss)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Deposit)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.ExternalWallLoss)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.ExtraMetal)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.GeometricAnomaly)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.GirthWeldAnomaly)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.InternalWallLoss)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Lamination)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.ManufacturingAnomaly)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Miscellaneous)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Ovality)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.SeamWeldAnomaly)
                .Use2DPipe()
                .ClickIntoPipe()
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .Use2DPipe()
                .Keyboard_ScrollPipe(Constants.DirectionRIGHT)
                .SelectFeature(PipeFeatures.Anomaly.Wrinkle);
        }

        [Test]
        [Category("FeatureSpreadsheet")]
        public void FS_003_LQP_54_AddNewFeature()
        {
            //Work in progress, there are some issues to solve. 
            //Read the funcion LQP_54_AddNewFeatureAfter and LQP_54_AddNewFeatureBefore for details
            //We have to be careful with this fuction, selecting what feature to use as a reference and the position of that
            //element in the grid.


            string firstposition = SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFeatureSpreadsheet()
                .SelectFeature(1, PipeFeatures.Construction.Bend.FeatureType)
                .SelectedFeaturePosition.Text;

            string secondposition = MainScreen.StartOnMain()
                .UseFeatureSpreadsheet()
                .MenuSelection(MainMenu.Features.FeatureType.SelectFeature(PipeFeatures.Construction.Bend))
                .GoToMain()
                .Use2DPipe()
                .Mouse_ScrollPipe(Constants.DirectionRIGHT)
                .Use2DPipe()
                .DrawFeature(60.00, 60.00)
                .UseFeatureSpreadsheet()
                .SelectedFeaturePosition.Text;

            double firstPos = double.Parse(firstposition);
            double secondPs = double.Parse((secondposition));

            Assert.Greater(secondPs, firstPos);


            
        }

        [Test]
        [Category("FeatureSpreadsheet")]
        public void FS_004_LQP_55_DeleteSelectedFeature()
        {
            //Working
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject()
                .UseFeatureSpreadsheet()
                .DeleteFeatureSpreadsheetRow(3)
                .GoToMain()
                .SelectFromMenu(MainMenu.File.SaveAll)
                .SelectFromMenu(MainMenu.File.CloseProject)
                .OpenProject()
                .UseFeatureSpreadsheet()
                .MenuSelection(MainMenu.View.FeatureSpreadsheet)
                .SelectFeatureSpreadsheetRow(3);

        }
        
        [Test]
        [Category("FeatureSpreadsheet")]
        public void FS_005_Case_5562_CircumferentialFeatures()
        {
            //The purpose of this test is to verify that there are no 360 degree features with a bad width
            //All circumferential features should have a circumference of less than or equal to the insdie wall circumference
            //Width = Circumference = 2 * pie * Radius
            //Outside Radius = Inside Radius + wall thickness or just use the outside radius value 

            //General plan, look through the feature spreadsheet, find 360 degree features, verify width
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseFeatureSpreadsheet()
                .Verify360DegreeFeatures();
        }

        /// <summary>
        /// This test sets the unit system to metric, selects a feature from the feature spreadsheet grid
        /// read the values from the row selected and the feature details, change the unit system to imperial
        /// read the values again and the compares the values converting to the same unit system.
        /// then compares a new row converting from imperial to metric.
        /// </summary>
        //[Test]
        //[Category("FeatureSpreadsheet")]
        //public void FS_007_Case_5641_UnitConversion()
        //{
        //    // Failed, I have to check unit conversion.
        //    // There's a problem with the units conversion, some of the conversions can be detected, and some doesn't.
        //    //TODO we need to figure out how to round some numbers
        //    SplashScreen.StartOnSplash()
        //    .CloseSplashScreen()
        //    .OpenProject(TestFileLocation)
        //    .UseFeatureSpreadsheet()
        //    .GoToMain()
        //    .OpenProgramOptionsFromMenu()
        //    .chooseGeneralItem()
        //    .updateUnitSystem(Constants.METRIC)
        //    .UseFeatureSpreadsheet()
        //    .SelectFeatureSpreadsheetRow(7);
        //    //.ReadFeatureSpreadsheetRow()
        //    //.ReadFeatureSpreadsheetDetailsBefore()
        //    //.UseMainScreen()
        //    //.OpenProgramOptionsFromMenu()
        //    //.chooseGeneralItem()
        //    //.updateUnitSystem(Constants.IMPERIAL)
        //    //.UseFeatureSpreadsheet()
        //    //.ReadFeatureSpreadsheetRow()
        //    //.ReadFeatureSpreadsheetDetailsAfter()
        //    //.CompareFeatureSpreadsheetUnitConversion(Constants.METRIC)
        //    //.SelectFeatureSpreadsheetRow(7)
        //    //.ReadFeatureSpreadsheetRow()
        //    //.ReadFeatureSpreadsheetDetailsBefore()
        //    //.UseMainScreen()
        //    //.OpenProgramOptionsFromMenu()
        //    //.chooseGeneralItem()
        //    //.updateUnitSystem(Constants.METRIC)
        //    //.UseFeatureSpreadsheet()
        //    //.ReadFeatureSpreadsheetRow()
        //    //.ReadFeatureSpreadsheetDetailsAfter()
        //    //.CompareFeatureSpreadsheetUnitConversion(Constants.IMPERIAL);
        //}

        //TODO this test doesn't work - Will fix
        //[Test]
        //[Category("FeatureSpreadsheet")]
        //public void FS_008_Case_7933_LenghtTest()
        //{
        //    SplashScreen.StartOnSplash()
        //        .CloseSplashScreen()
        //        .OpenProject(TestFileLocation)
        //        .OpenFeatureSpreadsheet(ProjectFileName)
        //        .SelectFeature(PipeFeatures.Anomaly.ExternalWallLoss)
        //        .Use2DPipe()
        //        .ClickIntoPipe()
        //        .Use2DPipe()
        //        .DrawFeature(50.00, 60.00)
        //        .ReadFeatureSpreadsheetDetailsBefore()
        //        .ManipulateNewFeature_7933()
        //        .MenuFile_SaveAll()
        //        .MenuFile_CloseProject()
        //        .OpenProject(TestFileLocation, ProjectFileName)
        //        .OpenFeatureSpreadsheet(ProjectFileName)
        //        .FeatSpreadSheetLookForPreviousFeature()
        //        .SelectFeatureSpreadsheetRow(1)
        //        .ReadFeatureSpreadsheetDetailsAfter()
        //        .CompareFeaturesValues_7933()
        //        .DeleteFeature_7933()
        //        .MenuFile_SaveAll();
        //}
    }
}

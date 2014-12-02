using Golem.QuestIntegrity.ScreenObjects.LQP;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using NUnit.Framework;
using ProtoTest.Golem.Purple;


namespace Golem.QuestIntegrity.Tests.LQP
{
    public class LQP_ConverstionTests : PurpleTestBase
    {
        [NUnit.Framework.TearDown]
        public void dispose()
        {
            MainScreen.dispose();
        }
        
        [Test]
        [Category("ConversionTest")]
        public void LQP_0001_DataInspector_MetricToImperial()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.METRIC) //set the unit system first
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SetInitialValues() //This will also calculate expected output to opposite system
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.IMPERIAL)
                .UseDataInspector()
                .SetActualValues()
                .UseDataInspector()
                .VerifyUnitConversions();
        }

        [Test]
        [Category("ConversionTest")]
        public void LQP_0002_DataInspector_ImperialToMetric()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.IMPERIAL) //set the unit system first
                .Use2DPipe()
                .ClickIntoPipe()
                .UseDataInspector()
                .SetInitialValues() //This will also calculate expected output to opposite system
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.METRIC)
                .UseDataInspector()
                .SetActualValues()
                .UseDataInspector()
                .VerifyUnitConversions();
        }


        /// <summary>
        /// Tests that when the system units changes, the values of the navigation panel changes according to the
        /// unit conversion.
        /// From Imperial to metric
        /// </summary>
        [Test]
        [Category("ConversionTest")]
        public void LQP_0003_Case5640_Navigation_ConversionTest_1()
        {
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.IMPERIAL)
                .UseNavigationPanel()
                .ReadNavigationValuesBefore()
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.METRIC)
                .ReadNavigationValuesAfter()
                .CompareNavigationPanelUnits(Constants.IMPERIAL);
        }
        /// <summary>
        /// Tests that when the system units changes, the values of the navigation panel changes according to the
        /// unit conversion.
        /// From metric to imperial
        /// </summary>
        [Test]
        [Category("ConversionTest")]
        public void LQP_0004_Case5640_Navigation_ConversionTest_2()
        {
            //TODO: This test is not complete and can not be executed because the program has. It should be fully tested
            //When the bug is corrected. Reported bug: 7912
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.METRIC)
                .UseNavigationPanel()
                .ReadNavigationValuesBefore()
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.IMPERIAL)
                .ReadNavigationValuesAfter()
                .CompareNavigationPanelUnits(Constants.METRIC);
        }

        /// <summary>
        /// Evaluates the unit conversion in the Material properties panel
        /// From metric to imperial
        /// </summary>
        [Test]
        [Category("ConversionTest")]
        public void LQP_0005_Case5640_Material_ConversionTest()
        {
            //TODO: This test is not complete and can not be executed because the program has. It should be fully tested
            //When the bug is corrected. Reported bug: 7911
            SplashScreen.StartOnSplash()
                .CloseSplashScreen()
                .OpenProject(TestFileLocation)
                .UseMaterialProperties()
                .GoToMain()
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.METRIC)
                .SelectRowInMaterialProperties(1)
                .ReadMaterialValuesBefore()
                .OpenProgramOptionsFromMenu()
                .chooseGeneralItem()
                .updateUnitSystem(Constants.IMPERIAL)
                .SelectRowInMaterialProperties(1)
                .ReadMaterialValuesAfter()
                .CompareMaterialsPanelValues(Constants.METRIC)
                ;
        }

    }
}

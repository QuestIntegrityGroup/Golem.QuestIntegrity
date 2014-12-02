using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;
using System.Collections.Generic;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_DataTools;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_ProgramOptions;
using NUnit.Framework;
using ProtoTest.Golem.Purple;
using System;
using ProtoTest.Golem.Purple.PurpleCore;
using ProtoTest.Golem.Purple.PurpleElements;
using System.Windows.Automation;


namespace Golem.QuestIntegrity.ScreenObjects.LQP
{
    
    public class MainScreen : BaseScreenObject
    {
        /* The Main screen is the first screen that is displayed after users open or create a project. 
         * It contains the following panels by default: 
         *  ProjectProperties
         *  2D Pipe
         *  Axial Chart
         *  Navigation
         *  CrossSection
         *  DataInspector
         * There is also the Project Explorer tab.  However this has to be access through the menu bar since TestStack can't see 
         * the panel 1 tabs.
         */
        //This Window needs to be passed around before a project is created/opened.  Otherwise the window name will change to include the path of the .prj file

        //Dataused for comparisons
        private static double cursorPosition;
        public static double FeaturePosition;

        #region PanelVariables
        //This screen needs to have a panel variable for everything can can be displayed on the main form
        public static ProjectProperties_Panel ProjectProperties;
        public static Pipe2D_Panel pipe2D;
        public static DataInspector_Panel dataInspector;
        public static DataInspector_Search_Panel dataInspectorSearch;
        public static FeatureSpreadsheet_Panel pipeFeaturesSpreadsheet;
        public static ProgramOptions_Dialog programOptions_Dialog;
        public static FilterData_Panel filterData;
        //public static ColorScale_Dialog colorscale_dialog;
        public static ColorScalePage colorscalepage;
        public static AxialChart_Panel axialChart;
        public static Navigation_Panel navPanel;
        public static Material_Properties_Panel materialPanel;

        #endregion
        
        #region Constructors

        public MainScreen()
        {
            PurpleWindow.SetVisualState(Window_VisualStyle.Maximized); 
            
        }
        public static MainScreen StartOnMain()
        {
            return new MainScreen();
        }
        #endregion

        #region NUNIT Fixtures
        [NUnit.Framework.TearDown]
        public static void dispose()
        {
            ProjectProperties = null;
            pipe2D = null;
            dataInspector = null;
            dataInspectorSearch = null;
            pipeFeaturesSpreadsheet = null;
            programOptions_Dialog = null;
            filterData = null;
            //colorscale_dialog = null;
            colorscalepage = null;
            axialChart = null;
            navPanel = null;
            materialPanel = null;
            
        }
        #endregion

        /* THIS SECTION SHOULD BE USED FOR PANEL INTIALIZATION OBJECTS
         * */
        #region PanelInitializers
        private void InitDefaultPanels()
        {
            pipe2D = new Pipe2D_Panel();
            ProjectProperties = new ProjectProperties_Panel();
            dataInspector = new DataInspector_Panel();
            axialChart = new AxialChart_Panel();
            navPanel = new Navigation_Panel();
        }
        
        public Pipe2D_Panel Use2DPipe()
        {
            if (pipe2D == null)
            {
                MainMenu.View.View2D.Invoke();
                pipe2D = new Pipe2D_Panel();
            }
            return pipe2D;
        }

        public AxialChart_Panel UseAxialChart()
        {
            if (axialChart == null)
            {
                MainMenu.View.XYPlotView.Invoke();
                axialChart = new AxialChart_Panel();
            }
            return axialChart;
        }

        public DataInspector_Panel UseDataInspector()
        {
            if (dataInspector == null)
            {
                MainMenu.View.DataInspector.Invoke();
                dataInspector = new DataInspector_Panel();
            }
            return dataInspector;
        }
        
        public FeatureSpreadsheet_Panel UseFeatureSpreadsheet()
        {
            if (pipeFeaturesSpreadsheet == null)
            {
                MainMenu.View.FeatureSpreadsheet.Invoke();
                pipeFeaturesSpreadsheet = new FeatureSpreadsheet_Panel();
            }
            return pipeFeaturesSpreadsheet;
        }
        /// <summary>
        /// Creates a new NavigationPanel (if it's not already created) and set it to MainScreen as navPanel
        /// </summary>
        /// <returns>Navigation_Panel</returns>
        public Navigation_Panel UseNavigationPanel()
        {
            if (navPanel == null)
            {
                MainMenu.View.Navigation.Invoke();
                navPanel = new Navigation_Panel();
            }
            return navPanel;
        }
        
        public FilterData_Panel UseFilterDataPanel()
        {
            if (filterData == null)
            {
                MainMenu.Tools.ProcessData.Invoke();
                filterData = new FilterData_Panel();
            }
            return filterData;
        }
        /// <summary>
        /// Opens the material properties panel
        /// </summary>
        /// <returns>MainScreen</returns>
        public Material_Properties_Panel UseMaterialProperties()
        {
            MainMenu.View.MaterialsProperties.Invoke();
            materialPanel = new Material_Properties_Panel();
            
            return materialPanel;
        }

        #endregion

        /* THIS SECTION IS USED FOR OPENING SUB-SCREENS - FUNCTIONALITY ON PANELS SHOULD NOT BE USED HERE 
         * NAVIGATE TO THE PANEL TO USE THE FUNCTIONALITY
         * */
        #region MenuNavigation - Interaction
        public MainScreen OpenProject(String project = "")
        {
            string projFilePath = project;
            if (projFilePath == "")
            {
                projFilePath = Constants.getTestFileLoc();
            }
            MainMenu.File.Open.Project.Invoke();
            var OpenFile = new OpenFile_Dialog();
            OpenFile.OpenaFile(projFilePath);
            InitDefaultPanels();
            return this;
        }
        public MainScreen AddDataFile(String project)
        {
            MainMenu.File.Add.AddExistingDataFile.Invoke();
            var AddFile = new OpenFile_Dialog();
            AddFile.OpenaFile(project);
            InitDefaultPanels();
            return this;
        }
        public MainScreen SelectFromMenu(PurpleButton button)
        {
            button.Invoke();
            return this;
        }
        public MainScreen SelectFeature(FeatureDetail feature)
        {
            PurpleButton SelectedFeature = MainMenu.Features.FeatureType.SelectFeature(feature);
            SelectedFeature.Invoke();
            return this;
        }
        public ProgramOptions_Dialog OpenProgramOptionsFromMenu()
        {
            //There's a problem where sometimes the Program Options appears as it's own app outside the program tree - We should handle this to make it more dynamic
            MainMenu.Tools.ProgramOptions.Invoke();
            return new ProgramOptions_Dialog();
        }
        #endregion
        
        /* THESE FUCTIONSS SHOULD GO INTO A NAVIGATION PANEL CLASS
         * */
        #region Navigation Panel
        /// <summary>
        /// Read the navigation panel values for center position and view width
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ReadNavigationValuesBefore()
        {
            navPanel.ReadNavigationValuesBefore();
            return this;
        }

        /// <summary>
        /// Read the navigation panel values for center position and view width
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ReadNavigationValuesAfter()
        {
            navPanel.ReadNavigationValuesAfter();
            return this;
        }

        /// <summary>
        /// Compares the values before and after the conversion to verify that the conversion on screen is correct.
        /// </summary>
        /// <param name="unitSystem"></param>
        /// <returns>MainScreen</returns>
        public MainScreen CompareNavigationPanelUnits(string systemFrom)
        {
            navPanel.CompareUnits(systemFrom);
            return this;
        }
        #endregion

        /* THESE FUNCTIONS SHOULD GO INTO A SUMMARY CHARTS PANEL CLASS
         * */
        #region Summary Charts Panel
        /// <summary>
        /// Opens the summary charts panel
        /// </summary>
        /// <param name="projectName">Name of the project</param>
        /// <returns>MainScreen</returns>
        public MainScreen OpenSummaryCharts(string projectName)
        {
            SummaryCharts_Panel scp = SummaryCharts_Panel.GetInstance(projectName);
            scp.OpenSummaryCharts();
            return this;
        }

        /// <summary>
        /// Sets the data drop down in the Summary Charts panel
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ChangeSumChartsData(string dataName)
        {
            SummaryCharts_Panel scp = SummaryCharts_Panel.GetInstance();
            scp.ChangeData(dataName);
            return this;
        }

        public MainScreen ChangeSumChartsMeasure(string measureName)
        {
            SummaryCharts_Panel scp = SummaryCharts_Panel.GetInstance();
            scp.ChangeMeasure(measureName);
            return this;
        }

        /// <summary>
        /// Takes a snapshot of the Summary Charts panel
        /// </summary>
        /// <returns></returns>
        public MainScreen TakeSnapshot_C7932()
        {
            SummaryCharts_Panel scp = SummaryCharts_Panel.GetInstance();
            ImageManipulation im = new ImageManipulation(scp.GetGraphicPanel(), true);
            im.TakeSnapshot();
            return this;
        }

        /// <summary>
        /// Compare snapshots of the test case 7932
        /// </summary>
        /// <returns></returns>
        public MainScreen CompareSnapshots_SummaryCharts()
        {
            SummaryCharts_Panel scp = SummaryCharts_Panel.GetInstance();
            ImageManipulation im = new ImageManipulation(scp.GetGraphicPanel(), true);
            Image controlSnapshot = im.GetImageFromDisk("SummaryChartGraphicPanel-ControlImage");
            if (controlSnapshot != null)
            {
                Image snapshot = im.GetStoredSnapshot(1);
                //Compares current snapshot and control image, and check that are identical
                var compare = im.ImagesMatchReturnValue(snapshot, controlSnapshot, 10);
                Assert.AreEqual(float.Parse(compare), 0);
            }
            else
            {
                Assert.Fail("The image stored on disk for comparison is not present");
            }
            return this;
        }

        /// <summary>
        /// Delete the snapshots taken by the test. 
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen DeleteSnapshots_C7932()
        {
            SummaryCharts_Panel scp = SummaryCharts_Panel.GetInstance();
            ImageManipulation im = new ImageManipulation(scp.GetGraphicPanel(), true);
            im.DeleteAllSnapshots();
            return this;
        }
        #endregion

        /* THESE FUNCTIONS SHOUDL GO INTO A 2D VIEW PANEL
         * */
        #region 2D view Panel
        
        /// <summary>
        /// Sets the color scale configuration for case 7944 - Step 1
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ChangeColorScaleOptions_C7944_Conf1()
        {
            ColorScale_Dialog color = ColorScale_Dialog.GetInstance();
            color.OpenDialog(Constants.getProjectName());
            color.ChooseColorScaleTab();
            color.ChangeColorScale("HSV (Purple->Red)");
            color.ChooseApply();
            color.ChooseOK();
            Thread.Sleep(200);
            return this;
        }

        /// <summary>
        /// Sets the color scale configuration for case 7944 - Step 2
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ChangeColorScaleOptions_C7944_Conf2()
        {
            //ColorScale_Dialog.DeleteInstance();
            ColorScale_Dialog color = ColorScale_Dialog.GetInstance();
            color.OpenDialog(Constants.getProjectName());
            color.ChooseScalarBarTab();
            color.ChangePosition("Top Right");
            Thread.Sleep(200);
            color.ChooseApply();
            color.ChooseOK();
            Thread.Sleep(200);
            return this;
        }

        /// <summary>
        /// Sets the color scale configuration for case 7944 - resets the values
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ChangeColorScaleOptions_C7944_ConfReset()
        {
            ColorScale_Dialog color = ColorScale_Dialog.GetInstance();
            color.ChangeDataType("Wall Thickness");
            color.OpenDialog(Constants.getProjectName());
            color.ChooseColorScaleTab();
            color.ChangeColorScale("Jet (Red->Blue)");
            color.ChooseScalarBarTab();
            //color.ChangePosition(5);
            color.ChangePosition("Custom");
            Thread.Sleep(200);
            color.ChooseApply();
            color.ChooseOK();
            Thread.Sleep(200);
            return this;
        }

        /// <summary>
        /// Takes a snapshot of the 2D Panel's Grapich panel
        /// </summary>
        /// <returns></returns>
        public MainScreen TakeSnapshot_2DPanel()
        {
            ImageManipulation im = new ImageManipulation(pipe2D.pipe2D_GraphicsPanel, true);
            im.TakeSnapshot();
            return this;
        }
        /// <summary>
        /// Compare the images captured
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen CompareSnapshots_2DPanel()
        {
            ImageManipulation im = new ImageManipulation(pipe2D.pipe2D_GraphicsPanel, true);
            Rectangle cropArea1 = new Rectangle(new System.Drawing.Point(534, 390), new System.Drawing.Size(647, 46));
            Rectangle cropArea2 = new Rectangle(new System.Drawing.Point(534, 25), new System.Drawing.Size(647, 46));
            Image snap1 = im.GetStoredSnapshot(1);
            Image image1Crop = im.cropImage(snap1, cropArea1); //Default values
            //im.Save(image1Crop,"snap1"); //Save image for visual inspection
            Image snap2 = im.GetStoredSnapshot(2);
            Image image2Crop = im.cropImage(snap2, cropArea1); //Changed color
            //im.Save(image2Crop, "snap2");  //Save image for visual inspection
            Image snap2a = im.GetStoredSnapshot(2);
            Image image2aCrop = im.cropImage(snap2a, cropArea2); // Get the image before the change
            //im.Save(image2aCrop, "snap2a");  //Save image for visual inspection
            Image snap3 = im.GetStoredSnapshot(3);
            Image image3Crop = im.cropImage(snap3, cropArea2); //Changed position
            //im.Save(image3Crop, "snap3");  //Save image for visual inspection
            Image snap4 = im.GetStoredSnapshot(4);
            Image image4Crop = im.cropImage(snap4, cropArea2); //After reload the project
            //im.Save(image4Crop, "snap4");  //Save image for visual inspection
            Image snap5 = im.GetStoredSnapshot(5);
            Image image5Crop = im.cropImage(snap5, cropArea1); // Back to original position
            //im.Save(image5Crop, "snap5");  //Save image for visual inspection
            //Compare default color scale (Jet (Red->Blue)), and default position (Custom) against color change (HSV (Purple->Red)) 
            var compare1 = im.ImagesMatchReturnValue(image1Crop, image2Crop);
            //Compare the new position (Top Right) before moving the reference (which is empty), and the zone after changing the reference
            var compare2 = im.ImagesMatchReturnValue(image2aCrop, image3Crop);
            //Compare the new position and color before and after closing and opening the project.
            var compare3 = im.ImagesMatchReturnValue(image3Crop, image4Crop);
            //Compare the default color and position after returning to the default position
            var compare4 = im.ImagesMatchReturnValue(image1Crop, image5Crop);
            /* show values for controling purposes
            Console.WriteLine("Comaprison #1: " + compare1); 
            Console.WriteLine("Comaprison #2: " + compare2); 
            Console.WriteLine("Comaprison #3: " + compare3);
            Console.WriteLine("Comaprison #4: " + compare4);
            */
            Assert.LessOrEqual(float.Parse(compare1), 20f);
            Assert.GreaterOrEqual(float.Parse(compare1), 15f);
            Assert.AreNotEqual(float.Parse(compare2), 0f);
            Assert.AreEqual(float.Parse(compare3), 0);
            Assert.AreEqual(float.Parse(compare4), 0);
            return this;
        }

        public MainScreen DeleteSnapshots_C7944()
        {
            ImageManipulation im = new ImageManipulation(pipe2D.pipe2D_GraphicsPanel, true);
            im.DeleteAllSnapshots();
            return this;
        }
        #endregion

        /* THESE FUNCTIONS SHOULD BE MOVED INTO A MATERIAL PROPERTIES PANEL
         * */
        #region Material Properties
        

        /// <summary>
        /// Selects a row in the materials grid by a numeric position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>MainScreen</returns>
        public MainScreen SelectRowInMaterialProperties(int pos)
        {
            materialPanel.ClickOnRow(pos);
            return this;
        }

        /// <summary>
        /// Reads the value of the selected row in the materials property before the change
        /// </summary>
        /// <returns></returns>
        public MainScreen ReadMaterialValuesBefore()
        {
            materialPanel.ReadMaterialValuesBefore();
            return this;
        }

        /// <summary>
        /// Reads the value of the selected row in the materials property after the change
        /// </summary>
        /// <returns></returns>
        public MainScreen ReadMaterialValuesAfter()
        {
            materialPanel.ReadMaterialValuesAfter();
            return this;
        }

        /// <summary>
        /// This function compare the values collected from Materials properties' panel before and after the
        /// unit's change.
        /// </summary>
        /// <returns></returns>
        public MainScreen CompareMaterialsPanelValues(string systemFrom)
        {
            materialPanel.CompareValuesAfterUnitChange(systemFrom);
            return this;
        }
        #endregion
        
        #region Test Functions
        
        //Testing NavigationPanel
        public MainScreen TestNavigationPanel()
        {
            Navigation_Panel nav = new Navigation_Panel();
            //nav.Test();
            nav.ShowChilds();
            return this;
        }

        //Testing images
        /// <summary>
        /// Temporal function
        /// Testing Image manipulation
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen TestImageComparison1()
        {
            ImageManipulation imageM = new ImageManipulation(pipe2D.pipe2D_GraphicsPanel);
            imageM.TakeSnapshot();
            Console.WriteLine("Taken snapshot #"+imageM.GetCurrentSnapshotIndex());
            return this;
        }

        /// <summary>
        /// Temporal function
        /// Testing Image manipulation
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen TestImageComparison2()
        {
            ImageManipulation imageM = new ImageManipulation(pipe2D.pipe2D_GraphicsPanel, true);
            imageM.TakeSnapshot();
            Console.WriteLine("Taken snapshot #" + imageM.GetCurrentSnapshotIndex());
            Console.WriteLine("Comparing snapshot 1 and 2: ");
            var value = imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2));
            Console.WriteLine("Calculation with fuzzines = 10 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2),10));
            Console.WriteLine("Calculation with fuzzines = 20 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 20));
            Console.WriteLine("Calculation with fuzzines = 30 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 30));
            Console.WriteLine("Calculation with fuzzines = 40 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 40));
            Console.WriteLine("Calculation with fuzzines = 50 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 50));
            Console.WriteLine("Calculation with fuzzines = 60 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 60));
            Console.WriteLine("Calculation with fuzzines = 70 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 70));
            Console.WriteLine("Calculation with fuzzines = 80 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 80));
            Console.WriteLine("Calculation with fuzzines = 90 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 90));
            Console.WriteLine("Calculation with fuzzines = 95 : " + imageM.ImagesMatchReturnValue(imageM.GetStoredSnapshot(1), imageM.GetStoredSnapshot(2), 95));
            //imageM.Save(imageM.GetStoredSnapshot(1).Resize(16, 16).GetGrayScaleVersion(),"comp-snapshot1");
            //imageM.Save(imageM.GetStoredSnapshot(2).Resize(16, 16).GetGrayScaleVersion(), "comp-snapshot2");
            System.Drawing.Image imgDifference = imageM.GetDifferenceImageAgainstSnapshot(1);
            System.Drawing.Image imgOverlayed = imageM.OverlayImages(imageM.GetLiveImage(), imageM.GetStoredSnapshot(1));
            System.Drawing.Image imgOverlayed2 = imageM.OverlayImages(imageM.GetStoredSnapshot(1),imageM.GetLiveImage());
            System.Drawing.Image imgCombined = imageM.CombineImages(imageM.CombineImages(imageM.GetStoredSnapshot(1), imgDifference),imgOverlayed);
            imageM.Save(imgDifference, "ImageDifference");
            imageM.Save(imgOverlayed, "ImageOverlayed");
            imageM.Save(imgOverlayed2, "ImageOverlayed2");
            imageM.Save(imgCombined,"ImageCombined");
            return this;
        }
        #endregion

    }
}
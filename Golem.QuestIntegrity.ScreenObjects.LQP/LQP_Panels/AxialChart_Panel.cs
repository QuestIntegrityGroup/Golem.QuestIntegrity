using System.Drawing;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using NUnit.Framework;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class AxialChart_Panel : BasePanel<AxialChart_Panel>
    {
        private static string _ProjectName = Constants.getProjectName();

        private static AxialChart_Panel axialPanel;

        private PurpleDropDown Data_DropDown;
        private PurpleDropDown Measure_DropDown;
        private PurpleDropDown Sensor_DropDown;
        private PurpleSpinner SensorOffset;
        private PurpleCheckBox ShowPoints_Checkbox;
        private PurpleCheckBox ShowLines_Checkbox;
        private PurpleButton Options_Button;
        private PurpleElementBase GraphicPanel; 

        public AxialChart_Panel() {
            Data_DropDown = new PurpleDropDown("Graph Data", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/ViewBar_ScalarDataComboBox"); //Works
            Measure_DropDown = new PurpleDropDown("Graph Measure", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/ViewBar_MeasureComboBox"); //Works
            Sensor_DropDown = new PurpleDropDown("Sensor", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/ViewBar_SensorSelector"); //Doesn't work, it's a complex control
            SensorOffset = new PurpleSpinner("Sensor offset", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/ViewBar_Spinner"); //Not yet tested
            ShowPoints_Checkbox = new PurpleCheckBox("Graph Show points", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/Show points"); //Works
            ShowLines_Checkbox = new PurpleCheckBox("Graph Show Lines", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/Show lines"); //Works
            Options_Button = new PurpleButton("Graph Options", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/LifeQuestBaseView_ViewBar/ViewBar_OptionsButton"); //Not yet tested
            GraphicPanel = new PurpleElementBase("Axial Chart Graphic Panel", "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [Axial Chart]/ChartPane_ChartControl");
        }


        
        
        public MainScreen TestAllControls() {
            Data_DropDown.SelectItem("Inside Radius");
            Data_DropDown.SelectItem("Decentered Radius");
            Data_DropDown.SelectItem("Grade");
            Data_DropDown.SelectItem("Outside Radius");
            Data_DropDown.SelectItem("RSF");
            Data_DropDown.SelectItem("MAOPr");
            Data_DropDown.SelectItem("Velocity");
            Data_DropDown.SelectItem("Pitch and Roll");
            Data_DropDown.SelectItem("Wall Thickness");
            
            Measure_DropDown.SelectItem("Value at Sensor");
            Measure_DropDown.SelectItem("Minimum");
            Measure_DropDown.SelectItem("Maximum");
            Measure_DropDown.SelectItem("Mean");
            Measure_DropDown.SelectItem("Median");
            Measure_DropDown.SelectItem("Mode");
            Measure_DropDown.SelectItem("Variance");
            Measure_DropDown.SelectItem("Standard Deviation");
            Measure_DropDown.SelectItem("Count (no NaNs)");
            Measure_DropDown.SelectItem("Count");

            Measure_DropDown.SelectItem("Value at Sensor");
            Sensor_DropDown.SelectItem("5");

            ShowPoints_Checkbox.Click();
            ShowLines_Checkbox.Click();
            ShowPoints_Checkbox.Click();
            ShowLines_Checkbox.Click();

            return new MainScreen();
        }

        #region Moved from mainscreen
        /// <summary>
        /// Changes Data dropdown and measure dropdown of the Axial Charts
        /// </summary>
        /// <param name="data">data dropdown option</param>
        /// <param name="measure">measure dropdown option</param>
        /// <returns>MainMenu</returns>
        public AxialChart_Panel ChangeAxialChartGraph(string data, string measure)
        {
            ChangeDataDropDown(data);
            ChangeMeasureDropDown(measure);
            return this;
        }

        /// <summary>
        /// Takes a snapshot of the Axial Charts panel
        /// </summary>
        /// <returns></returns>
        public AxialChart_Panel TakeSnapshot_AxialChart()
        {
            ImageManipulation im = new ImageManipulation(GraphicPanel, true);
            im.TakeSnapshot();
            return this;
        }

        public AxialChart_Panel CompareSnapshots_AxialCharts()
        {
            ImageManipulation im = new ImageManipulation(GraphicPanel, true);
            Image controlSnapshot1 = im.GetImageFromDisk("AxialChartGraphicPanel-ControlImage1");
            Image controlSnapshot2 = im.GetImageFromDisk("AxialChartGraphicPanel-ControlImage2");
            Image controlSnapshot3 = im.GetImageFromDisk("AxialChartGraphicPanel-ControlImage3");
            Image controlSnapshot4 = im.GetImageFromDisk("AxialChartGraphicPanel-ControlImage4");
            Image controlSnapshot5 = im.GetImageFromDisk("AxialChartGraphicPanel-ControlImage5");
            Image controlSnapshot6 = im.GetImageFromDisk("AxialChartGraphicPanel-ControlImage6");
            if (controlSnapshot1 != null && controlSnapshot2 != null && controlSnapshot3 != null &&
                controlSnapshot4 != null && controlSnapshot5 != null && controlSnapshot6 != null)
            {
                Image snapshot1 = im.GetStoredSnapshot(1);
                Image snapshot2 = im.GetStoredSnapshot(2);
                Image snapshot3 = im.GetStoredSnapshot(3);
                Image snapshot4 = im.GetStoredSnapshot(4);
                Image snapshot5 = im.GetStoredSnapshot(5);
                Image snapshot6 = im.GetStoredSnapshot(6);

                var compare1 = im.ImagesMatchReturnValue(snapshot1, controlSnapshot1, 20);
                var compare2 = im.ImagesMatchReturnValue(snapshot2, controlSnapshot2, 20);
                var compare3 = im.ImagesMatchReturnValue(snapshot3, controlSnapshot3, 20);
                var compare4 = im.ImagesMatchReturnValue(snapshot4, controlSnapshot4, 20);
                var compare5 = im.ImagesMatchReturnValue(snapshot5, controlSnapshot5, 20);
                var compare6 = im.ImagesMatchReturnValue(snapshot6, controlSnapshot6, 20);

                /*
                Console.WriteLine("Comaprison #1: " + compare1);
                Console.WriteLine("Comaprison #2: " + compare2);
                Console.WriteLine("Comaprison #3: " + compare3);
                Console.WriteLine("Comaprison #4: " + compare4);
                Console.WriteLine("Comaprison #5: " + compare5);
                Console.WriteLine("Comaprison #6: " + compare6);
                */

                Assert.AreEqual(float.Parse(compare1), 0);
                Assert.AreEqual(float.Parse(compare2), 0);
                Assert.AreEqual(float.Parse(compare3), 0);
                Assert.AreEqual(float.Parse(compare4), 0);
                Assert.AreEqual(float.Parse(compare5), 0);
                Assert.AreEqual(float.Parse(compare6), 0);
            }
            else
            {
                Assert.Fail("The images stored on disk for comparison are not present");
            }
            return this;
        }

        /// <summary>
        /// Delete the snapshots taken by the test
        /// </summary>
        /// <returns>MainScreen</returns>
        public AxialChart_Panel DeleteSnapshots_C7936()
        {
            ImageManipulation im = new ImageManipulation(GraphicPanel, true);
            im.DeleteAllSnapshots();
            return this;
        }

        #endregion
        /// <summary>
        /// Changes the data drop down of the Axial Charts
        /// Valid parameters are: "Wall Thickness", "Inside Radius", "Decentered Radius", "Grade", "Outside Radius"
        /// "RSF", "MAOPr", "Velocity", "Pitch and Roll"
        /// </summary>
        /// <param name="value">name of the option in the drop down</param>
        public void ChangeDataDropDown(string value) {
            Data_DropDown.SelectItem(value);
        }

        /// <summary>
        /// Changes the Measure drop down of the Axial Charts
        /// Valid parameters are: "Value at Sensor", "Minimum", "Maximum", "Mean", "Median", "Mode", "Variance", "Standard Deviation"
        /// "Count (no NaNs)", "Count"
        /// </summary>
        /// <param name="value"></param>
        public void ChangeMeasureDropDown(string value) {
            Measure_DropDown.SelectItem(value);
        }

        /// <summary>
        /// Returns the Graphic panel of the summary chart panel
        /// </summary>
        /// <returns>PurpleElementBase</returns>
        public PurpleElementBase GetGraphicPanel()
        {
            return GraphicPanel;
        }


        public override AxialChart_Panel MenuSelection(PurpleButton button)
        {
            button.Invoke();
            return this;
        }

        public override MainScreen GoToMain()
        {
            return new MainScreen();
        }
    }
}

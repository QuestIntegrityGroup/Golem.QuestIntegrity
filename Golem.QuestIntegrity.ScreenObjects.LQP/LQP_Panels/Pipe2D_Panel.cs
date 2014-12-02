using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using WindowsInput;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Functionality;
using System;
using System.Windows;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_MenuNav;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.Purple.PurpleElements;
using ProtoTest.Golem.Purple.PurpleCore;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public class Pipe2D_Panel : BasePanel<Pipe2D_Panel>
    {
        private static string _ProjectName = Constants.getProjectName();
        private static string _PanelPath = "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [2D]";
        //List of values used in tests
        public double selectedPosition { get; set; }
        public Dictionary<string, TableRow> foundPointData;

        private PurpleButton ColorScaleOptions;

        //componentsList
        public PurpleComboBox dataBox_cb;
        public PurpleDropDown data_DropDown; 
        public PurplePanel pipe2D_GraphicsPanel; 
        public PurplePanel pipe2D_GraphicsPanel_viewBar; 
        public PurpleButton optionsButton; 
        public PurpleCheckBox FeaturesCheckbox;
        public PurpleCheckBox FeaturesTmm;
        private PurpleSpinner aspectRatioSpinner;

        public static ColorScale_Dialog colorscale_dialog;

        /*
        public static void SetUpPanel(string ProjectName)
        {
            _ProjectName = Constants.getProjectName();
            _PanelPath = "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [2D]";
        }*/

        public Pipe2D_Panel()
        {
            SetInternalValues();
        }

        /*
        public Pipe2D_Panel(string ProjectName)
        {
            _ProjectName = Constants.getProjectName();
            _PanelPath = "/LifeQuest™ Pipeline/!BLANK!/" + _ProjectName + " [2D]";
            SetInternalValues();
        }*/

        public void SetInternalValues()
        {
            //_ProjectName = ProjectName;
            dataBox_cb = new PurpleComboBox("ScalarData DropDown", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_ScalarDataComboBox");
            data_DropDown = new PurpleDropDown("ScalarData DropDown", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_ScalarDataComboBox");
            pipe2D_GraphicsPanel = new PurplePanel("2D Grapics Panel", _PanelPath + "/ViewSpecial2D_ViewPanel/!BLANK!/!BLANK!/Visualization Toolkit - Win32OpenGL #2");
            pipe2D_GraphicsPanel_viewBar = new PurplePanel("2D view bar", _PanelPath + "/LifeQuestBaseView_ViewBar");
            optionsButton = new PurpleButton("Options Button", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_OptionsButton");
            FeaturesCheckbox = new PurpleCheckBox("Features Checkbox", _PanelPath + "/LifeQuestBaseView_ViewBar/Features");
            FeaturesTmm = new PurpleCheckBox("Features TMM Checkbox", _PanelPath + "/LifeQuestBaseView_ViewBar/Features Tmm");
            aspectRatioSpinner = new PurpleSpinner("AspectRatio Spinner", _PanelPath + "/LifeQuestBaseView_ViewBar/ViewBar_Spinner/ViewBar_Spinner");
            ColorScaleOptions = new PurpleButton("ColorScaleOptions", _PanelPath + "/!BLANK!{1}/Options...");
        }

        
        public void ChangeDataType(String option)
        {
            dataBox_cb.Select(option);
        }
        public bool CheckFeatures(bool state)
        {
            FeaturesCheckbox.Checked = true;
            return FeaturesCheckbox.Checked;
        }
        public bool CheckFeaturesTmm(bool state)
        {
            FeaturesTmm.Checked = true;
            return FeaturesTmm.Checked;
        }
        public void AspectRatio(int value = 0)
        {
            //This function is used to change the spinner box value
            //The spinner box is de-activated right now because White can't find it
            if (value != 0)
            {
                if (value > 0)
                {
                    for (int x = 0; x < value; x++)
                    {
                        aspectRatioSpinner.Increment();
                    }
                }
                else
                {
                    for (int x = 0; x > value; x--)
                    {
                        aspectRatioSpinner.Decrement();
                    }
                }
            }
        }
        /// <summary>
        /// Scans the application and finds the Path for the new 2D panel (after closing and openning the project).
        /// </summary>
        public void Find2DPanel()
        {
            PurpleElementBase PanelAncestor = new PurplePanel("2D Grapics Panel", _PanelPath + "/ViewSpecial2D_ViewPanel/!BLANK!/!BLANK!");
            List<AutomationElement> result =  PanelAncestor.GetChildren();
            
            pipe2D_GraphicsPanel = new PurplePanel("2D Grapics Panel", result[0]);
        }

        public MainScreen ClickIntoPipe(){
            
            pipe2D_GraphicsPanel.MoveCursor(pipe2D_GraphicsPanel.Bounds.Center());
            pipe2D_GraphicsPanel.DoubleLeftClick();
            return new MainScreen();
        }
        
        public MainScreen DrawFeature(Double featureWidth, Double featureHeight)
        {
            //This function will draw a feature on the 2D pipe window
            //TODO: There needs to be a check in in to make sure that the feature will be drawn inside the current bounding box for the 2D pipe.

            //Going to draw the feature in the middle of the pipe pane
            //Depending on the feature being drawn the exact box will change
            Rect pipeBounds = pipe2D_GraphicsPanel.Bounds;
            Point startPoint = new Point();
            startPoint.X = pipeBounds.Center().X - (featureWidth / 2);
            startPoint.Y = pipeBounds.Center().Y + (featureHeight / 2); 
            Point endPoint = new Point();
            endPoint.X = pipeBounds.Center().X + (featureWidth/2);
            endPoint.Y = pipeBounds.Center().Y - (featureHeight/2);
            
            PurpleWindow.HoldKey(VirtualKeyCode.SHIFT);
            pipe2D_GraphicsPanel.DragAndDrop(startPoint, endPoint);
            PurpleWindow.ReleaseKey(VirtualKeyCode.SHIFT);

            //MainScreen.pipeFeaturesSpreadsheet.IncrementFeatureID();

            return new MainScreen();
        }

        public MainScreen Keyboard_ScrollPipe(string direction)
        {
            //This will scroll the pipe the direction indicated for the entire length of the displayed pipe
            //REMEMBER: to scroll left on the pipe with the mouse you have to drag right from left
            //Mouse scrolling will require some modifications to the TestStack.White.InputDevices.Mouse class
            if (direction == Constants.DirectionLEFT)
            {
                //pipe2D_GraphicsPanel.SetFocus();
                PurpleWindow.PressKey(VirtualKeyCode.PRIOR);
                Thread.Sleep(500);
            }
            if (direction == Constants.DirectionRIGHT)
            {
                //pipe2D_GraphicsPanel.SetFocus();
                PurpleWindow.PressKey(VirtualKeyCode.NEXT);
                Thread.Sleep(500);
            }
            return new MainScreen();
        }

        public MainScreen Mouse_ScrollPipe(string direction)
        {
            Point start = new Point();
            Point end = new Point();
            Rect pipeBounds = pipe2D_GraphicsPanel.Bounds;

            if (direction == Constants.DirectionLEFT)
            {
                start = pipeBounds.TopLeft;
                end = pipeBounds.TopRight;
                start.X = start.X + 10;
                end.X = end.X - 10;
            }
            if (direction == Constants.DirectionRIGHT)
            {
                start = pipeBounds.TopRight;
                end = pipeBounds.TopLeft;
                start.X = start.X - 10;
                end.X = end.X + 10;
            }
            //Changed this to test with purple
            pipe2D_GraphicsPanel.DragAndDrop(start, end, true);
            return new MainScreen();
        }

        public ColorScale_Dialog OpenPipe2DOptions()
        {
            ColorScaleOptions.Invoke();
            return ColorScale_Dialog.GetInstance();
        }

        public MainScreen ClickIntoXY(Point p) {
            ClickIntoPipe();
            this.pipe2D_GraphicsPanel.MoveCursor(p);
            this.pipe2D_GraphicsPanel.LMB_Down();
            this.pipe2D_GraphicsPanel.LMB_Up();
            return new MainScreen();
        }

        
        /// <summary>
        /// Look for a point in the 2D Panel suitable for reading it's values from the Data Inspector Panel
        /// </summary>
        /// <param name="panelBounds">The object that contains the panel</param>
        /// <param name="dataInspector">The object of the Data Inspector Panel</param>
        /// <param name="constrain">the data we want to read from the Data Inspector Panel</param>
        /// <param name="nan">check if we want to read a value or a NaN</param>
        /// <returns>Point that represents the coordinae of the point fuond</returns>
        public Point FindPoint(Rect panelBounds, DataInspector_Panel dataInspector, string constrain ,bool nan)
        {
            Dictionary<string, TableRow> testPointResult;
            Random rnd = new Random();
            int x, y;
            bool keepLoop = true;

            while (keepLoop)
            {
                x = rnd.Next((int)panelBounds.Left, (int)panelBounds.Right);
                y = rnd.Next((int)panelBounds.Top + 20, (int)panelBounds.Bottom - 80);
                Point testPoint = new Point(x, y);
                ClickIntoXY(testPoint);
                dataInspector.CalculateDataInspectorDictionary();
                testPointResult = dataInspector.GetDataInspectorDictionary();
                if (nan && testPointResult[constrain].Value.Equals("NaN"))
                {
                    this.foundPointData = testPointResult;
                    keepLoop = false;
                    return testPoint;
                }
                if (!nan && !testPointResult[constrain].Value.Equals("NaN"))
                {
                    this.foundPointData = testPointResult;
                    keepLoop = false;
                    return testPoint;
                }
            }
            return new Point(0, 0);
        }

        public void ChangeDataDropDown(string value)
        {
            data_DropDown.SelectItem(value);
        }

        public override Pipe2D_Panel MenuSelection(PurpleButton button)
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

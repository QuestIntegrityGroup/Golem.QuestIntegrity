using System.Threading;
using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs
{
    public class ColorScale_Dialog : BaseScreenObject
    {
        private static ColorScale_Dialog dialog;
        private string dataType;
        private string _dialogPath;

        private PurpleButton Pipe2DOptions;

        private PurpleButton Apply_Button;
        private PurpleButton OK_Button;
        private PurpleButton Cancel_Button;
        private PurpleButton ColorScalePane_Button;
        private PurpleButton ScalarBarPane_Button;
        private PurpleButton AdvancedPane_Button;
        private PurpleDropDown ColorScale_DropDown;
        private PurpleDropDown DataRange_DropDown;
        private PurpleDropDown Position_DropDown;
        private PurpleButton Position_DD_Button;

        public static Pipe2D_Panel pipe2D;
        public static MainScreen mainscreen;

        private ColorScale_Dialog()
        {
            this.dataType = "Wall Thickness";
            SetPurpleElements();
        }

        private ColorScale_Dialog(string dataType)
        {
            this.dataType = dataType;
            SetPurpleElements();
        }

        private void SetPurpleElements()
        {
            _dialogPath = "/LifeQuest™ Pipeline/Color Scale - " + dataType;

            ColorScalePane_Button = new PurpleButton("ColorScalePane", _dialogPath + "/ColorScaleOptions_CtfTabControl/Color Scale");
            ScalarBarPane_Button = new PurpleButton("ScalarBarPane", _dialogPath + "/ColorScaleOptions_CtfTabControl/Scalar Bar");
            AdvancedPane_Button = new PurpleButton("AdvancedPane", _dialogPath + "/ColorScaleOptions_CtfTabControl/Advanced");
            Apply_Button = new PurpleButton("ApplyButton", _dialogPath + "/ColorScaleOptions_ApplyCurrentViewPaneButton");
            OK_Button = new PurpleButton("OKButtton", _dialogPath + "/ColorScaleOptions_OkButton");
            Cancel_Button = new PurpleButton("CancelButton", _dialogPath + "/ColorScaleOptions_CancelButton");

            ColorScale_DropDown = new PurpleDropDown("Color Scale Drop Down", _dialogPath+"/ColorScaleOptions_CtfTabControl/Color Scale/ColorScaleOptions_ColorScaleTabPage/ColorScaleOptions_ColorMapComboBox");
            DataRange_DropDown = new PurpleDropDown("Data Range Drop Down", _dialogPath+"/ColorScaleOptions_CtfTabControl/Color Scale/ColorScaleOptions_ColorScaleTabPage/ColorScaleOptions_RangeComboBox");

            Position_DropDown = new PurpleDropDown("Position Drop Down", _dialogPath + "/ColorScaleOptions_CtfTabControl/Scalar Bar/ColorScaleOptions_PositionTabPage/ColorScaleOptions_PositionComboBox");
            Position_DD_Button = new PurpleButton("Position's drop down button", _dialogPath + "/ColorScaleOptions_CtfTabControl/Scalar Bar/ColorScaleOptions_PositionTabPage/ColorScaleOptions_PositionComboBox/Drop Down Button");
        }

        /// <summary>
        /// Singleton.
        /// Gets the current ColorScale_Dialog instance or creates a new object if there's no one created.
        /// </summary>
        /// <returns>An object of the class</returns>
        public static ColorScale_Dialog GetInstance()
        {
            if (dialog == null)
            {
                dialog = new ColorScale_Dialog();
            }
            return dialog;
        }

        /// <summary>
        /// Singleton.
        /// Gets the current ColorScale_Dialog instance or creates a new object if there's no one created.
        /// </summary>
        /// <param name="dataType">the name of the Data selected in the data drop down</param>
        /// <returns>An object of the class</returns>
        public static ColorScale_Dialog GetInstance(string dataType)
        {
            if (dialog == null)
            {
                dialog = new ColorScale_Dialog(dataType);
            }
            return dialog;
        }

        public static void DeleteInstance()
        {
            dialog = null;
        }

        /// <summary>
        /// Changes the data type of the option panel
        /// Valid options are:
        /// "Wall Thickness", "Inside Radius", "Decentered Radius", "Grade"
        /// </summary>
        /// <returns>ColorScale_Dialog</returns>
        public void ChangeDataType(string dataType)
        {
            this.dataType = dataType;
            SetPurpleElements();
        }

        public ColorScale_Dialog OpenDialog(string projectName)
        {
            PurpleButton PipeOptions = new PurpleButton("Pipe2DOptions", "/LifeQuest™ Pipeline/!BLANK!/"+projectName+" [2D]/LifeQuestBaseView_ViewBar/ViewBar_OptionsButton");
            PipeOptions.Click();
            return this;
        }

        /// <summary>
        /// Selects the Color Scale Tab
        /// </summary>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChooseColorScaleTab()
        {
            ColorScalePane_Button.Click();
            return this;
        }

        /// <summary>
        /// Selects the Scalar Bar Tab
        /// </summary>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChooseScalarBarTab()
        {
            ScalarBarPane_Button.Click();

            return this;
        }

        /// <summary>
        /// Selects the Advanced Tab
        /// </summary>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChooseAdvancedTab()
        {
            AdvancedPane_Button.Click();

            return this;
        }

        /// <summary>
        /// Hits the cancel button and closes the dialog.
        /// </summary>
        /// <returns>MainMenu</returns>
        public MainScreen ChooseCancel()
        {
            Cancel_Button.Click();
            return new MainScreen();
        }

        /// <summary>
        /// Hits the OK button and closes the dialog.
        /// </summary>
        /// <returns>MainScreen</returns>
        public MainScreen ChooseOK()
        {
            OK_Button.Click();
            return new MainScreen();
        }

        /// <summary>
        /// Hits the apply button.
        /// </summary>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChooseApply()
        {
            Apply_Button.Click();
            return this;
        }


        /// <summary>
        /// Changes the color scale dropdown.
        /// Valid values are:
        /// "Jet (Red->Blue)", "Jet (Blue->Red)", "HSV (Red->Blue)", "HSV (Blue->Red)", "HSV (Purple->Red)", "HSV (Red->Purple)"
        /// "Grayscale" or "Custom"
        /// </summary>
        /// <param name="value">Name of the element in the dropdown</param>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChangeColorScale(string value)
        {
            ColorScale_DropDown.SelectItem(value);
            return this;
        }

        /// <summary>
        /// Changes the position dropdown.
        /// Valid values are:
        /// "Bottom Right", "Bottom Left", "Top Right", "Top Left", "Custom"
        /// </summary>
        /// <param name="value">Name of the element in the dropdown</param>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChangePosition(string value)
        {
            Position_DropDown.SelectItem(value);
            return this;
        }

        /// <summary>
        /// Changes the position dropdown.
        /// </summary>
        /// <param name="value">Position of the element</param>
        /// <returns>ColorScale_Dialog</returns>
        public ColorScale_Dialog ChangePosition(int value)
        {
            Position_DropDown = new PurpleDropDown("Position Drop Down", _dialogPath + "/ColorScaleOptions_CtfTabControl/Scalar Bar/ColorScaleOptions_PositionTabPage/ColorScaleOptions_PositionComboBox");
            Position_DD_Button = new PurpleButton("Position's drop down button", _dialogPath + "/ColorScaleOptions_CtfTabControl/Scalar Bar/ColorScaleOptions_PositionTabPage/ColorScaleOptions_PositionComboBox/Drop Down Button");
            PurpleDropDown Position_DropDown2 = new PurpleDropDown("Position Drop Down", _dialogPath + "/ColorScaleOptions_CtfTabControl/Scalar Bar/ColorScaleOptions_PositionTabPage/ColorScaleOptions_PositionComboBox/ColorScaleOptions_PositionComboBox");

            Position_DD_Button.Click();
            Thread.Sleep(250);
            Position_DropDown.SelectItemByPosition(value);
            Thread.Sleep(250);
            Position_DropDown2.SelectItemByPosition(value);
            Thread.Sleep(250);
            //Position_DropDown2.SelectItem("Top Right");
            return this;
        }
    }
}
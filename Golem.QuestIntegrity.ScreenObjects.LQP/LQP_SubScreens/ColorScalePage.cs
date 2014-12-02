using Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens.LQP_Dialogs;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens
{
    public class ColorScalePage : BaseScreenObject
    {

        private PurpleButton ColorScaleOptionOpen = new PurpleButton("ColorScaleOptionOpen", "/LifeQuest™ Pipeline/Color Scale - Wall Thickness/!BLANK!/Color Scale/Color Scale/Max:{1}/Drop Down Button");
        private PurpleDropDown ColorScaleJetBtoR = new PurpleDropDown("ColorScaleJetBtoR", "/LifeQuest™ Pipeline/Color Scale - Wall Thickness/!BLANK!/Color Scale/Color Scale/Max:{1}");
        private PurpleButton ApplyButton = new PurpleButton("ApplyButton", "/LifeQuest™ Pipeline/Color Scale - Wall Thickness/Apply");
        private PurpleButton OKButton = new PurpleButton("OKButtton", "/LifeQuest™ Pipeline/Color Scale - Wall Thickness/OK");

        public static ColorScale_Dialog colorscale_dialog;
        public static MainScreen mainScreen;



        public ColorScalePage()
        {

        }

        public ColorScalePage UpdateColorScaleJetBtoR()
        {
            //ColorScaleOptionOpen.Click();
            ColorScaleJetBtoR.SelectItem("Jet (Blue->Red)");
            ApplyButton.Click();
            OKButton.Click();

            return new ColorScalePage();
        }

        //public void ChooseApply()
        //{
        //    ApplyButton.Click();
        //}

        //public void ChooseOK()
        //{
        //    OKButton.Click();
        //}



    }
}

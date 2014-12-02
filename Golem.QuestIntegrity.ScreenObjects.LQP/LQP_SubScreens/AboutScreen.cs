using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens
{
    public class AboutScreen : BaseScreenObject
    {
        
        //public WhiteButton okButt= new WhiteButton(SearchCriteria.ByText("OK"), aboutWindow);
        public PurpleButton okButt = new PurpleButton("Ok Button", "THIS PATH WILL NOT WORK");
       
        public static AboutScreen StartScreen()
        {
            return new AboutScreen();
        }

        public SplashScreen clickOkButton()
        {
            okButt.Click();
            //Commenting out moving to purple objects
            //return new SplashScreen(new WhiteWindow("Splash"));
            return new SplashScreen();
        }
    }
}
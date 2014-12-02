using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP
{
    public class SplashScreen : BaseScreenObject
    {
        private PurpleButton CloseSplash = new PurpleButton("CloseSplash", "/LifeQuest™ Pipeline/Splash/Splash_BorderPanel/Splash_ContentPanel/Splash_CloseForm");
        private PurpleButton ExitButton = new PurpleButton("ExitButton", "/LifeQuest™ Pipeline/Splash/Splash_BorderPanel/Splash_ContentPanel/Splash_Exit");

        public SplashScreen()
        {
        }

       
        public static SplashScreen StartOnSplash()
        {
            return new SplashScreen();
        }

        public MainScreen CloseSplashScreen()
        {
            CloseSplash.Click();
            return new MainScreen();
        }
        
    }
}
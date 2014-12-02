using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ProtoTest.Golem.Purple;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_SubScreens
{
    public static class FilterData_Processing_Popup
    {
        private static PurpleElementBase thePopUp = new PurpleElementBase("FilterDataProcessing Popup", "/LifeQuest™ Pipeline/Filtering Data");
        static FilterData_Processing_Popup()
        {
            
        }

        public static void WaitForFilterDataProcess()
        {
            try
            {
                while (thePopUp.IsOnScreen())
                {
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                
            }
        }

    }
}

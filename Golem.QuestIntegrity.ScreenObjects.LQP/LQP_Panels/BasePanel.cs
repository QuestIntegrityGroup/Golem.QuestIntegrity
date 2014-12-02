using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoTest.Golem.Purple.PurpleElements;

namespace Golem.QuestIntegrity.ScreenObjects.LQP.LQP_Panels
{
    public abstract class BasePanel<T> where T: BasePanel<T>
    {
        /// <summary>
        /// Pass in a PurpleButton from the MainMenu Class
        /// </summary>
        public abstract T MenuSelection(PurpleButton button);
        /// <summary>
        /// Returns Test Pointer to the MainScreen
        /// </summary>
        public abstract MainScreen GoToMain();
    }
}
